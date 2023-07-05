using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace NashraExtractions
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class archive : Window
    {
        string SelectedCellFilePath = "";
        string QueryFilter = "";
        System.ComponentModel.BackgroundWorker worker;
        private DataTable Maindt;

        public archive()
        {
            InitializeComponent();
            worker = new System.ComponentModel.BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            CountAsync();
        }
        private async void CountAsync()
        {
            while (true)
            {
                await System.Threading.Tasks.Task.Delay(1000);
                resultCount.Content = "عدد النتائج :     " + GridTable.Items.Count;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync("load");
        }
        private void view_more_Click(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync("loadmore");
        }
        private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            switch ((string)e.Argument)
            {
                case "load":
                    this.Dispatcher.Invoke(() =>
                    {
                        GridTable.ItemsSource = DbAPI.SelectMailArchive(null).DefaultView;
                        resultCount.Content = "عدد النتائج :     " + GridTable.Items.Count;
                        Maindt = DbAPI.SelectMailArchive(null);
                    });
                    break;
                case "loadmore":
                    this.Dispatcher.Invoke(() =>
                    {
                        UserData.LoadMore += 30;
                        GridTable.ItemsSource = DbAPI.SelectMailArchive(null).DefaultView;
                        resultCount.Content = "عدد النتائج :     " + GridTable.Items.Count;
                        Maindt = DbAPI.SelectMailArchive(null);

                    });
                    break;
                //case "loadmoreQuery":
                //    this.Dispatcher.Invoke(() =>
                //    {
                //        UserData.LoadMore += 30;
                //        GridTable.ItemsSource = DbAPI.SelectMailArchive(null).DefaultView;
                //        resultCount.Content = "عدد النتائج :     " + GridTable.Items.Count;
                //    });
                //    break;
                case "SearchFilter":
                    this.Dispatcher.Invoke(() =>
                    {
                        //GridTable.ItemsSource = DbAPI.SelectMailArchive(null).Select("mail_title like '%" + searchBox.Text + "%' ").CopyToDataTable().DefaultView;
                        //GridTable.ItemsSource = DbAPI.SelectMailArchive(null).AsEnumerable().Where(r => r.Field<string>("mail_title").Contains(searchBox.Text)).CopyToDataTable().DefaultView;
                        //resultCount.Content = "عدد النتائج :     " + GridTable.Items.Count;
                        Console.WriteLine("Res" + Maindt.AsEnumerable().Where(r => r.Field<string>("mail_title").Contains(searchBox.Text)).CopyToDataTable().Rows.Count);
                    });
                    break;
                default:
                    break;
            }

        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void GridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridTable.SelectedItems.Count != 0)
            {
                var GetCelll = GridTable.SelectedCells[2];
                TextBlock GetCellData = (TextBlock)GetCelll.Column.GetCellContent(GetCelll.Item);
                SelectedCellFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\archive\" + GetCellData.Text;
            }
        }





        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }




        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserData.DeleteAllArchiveFiles();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                CustomMessageDialog.ShowDialog("ادخل كلمة البحث", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (SearchOption.SelectedIndex == -1)
            {
                CustomMessageDialog.ShowDialog("ادخل نوع البحث", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (SearchOption.SelectedIndex == 0)
                {
                    //QueryFilter = $"Where mail_title like'%{searchBox.Text}%' and username='{UserData.Username}' ORDER BY mails.id ASC ";
                    //if (!worker.IsBusy)
                    //    worker.RunWorkerAsync("SearchFilter");
                    ////var filtered = Maindt.DefaultView.RowFilter = "mail_title like '%" + searchBox.Text + "%' ";
                    ////GridTable.ItemsSource  = 
                    if (!string.IsNullOrEmpty(searchBox.Text))
                    {
                        DataTable tempDt = Maindt.Copy();
                        tempDt.Clear();
                        foreach (DataRow dr in Maindt.Rows)
                        {
                            if (dr["عنوان المكاتبة"].ToString() == searchBox.Text)
                            {
                                tempDt.ImportRow(dr);
                            }
                        }
                        GridTable.ItemsSource = tempDt.DefaultView;
                    }
                    else
                    {
                        GridTable.ItemsSource = Maindt.DefaultView;
                    }

                }
                else if (SearchOption.SelectedIndex == 1)
                {
                    QueryFilter = $"WHERE date_mail LIKE '" + searchBox.Text + $"%' and username='{UserData.Username}' ORDER BY mails.id ASC  ";
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync("SearchFilter");
                }
                else if (SearchOption.SelectedIndex == 2)
                {
                    string[] Get_Date = searchBox.Text.Split('@');
                    QueryFilter = $" WHERE date_mail BETWEEN '{Get_Date[0]}%' and '{Get_Date[1]}%' and username='{UserData.Username}' ORDER BY mails.id ASC ";
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync("SearchFilter");
                }
                else if (SearchOption.SelectedIndex == 3)
                {
                    QueryFilter = $" WHERE  MONTH(date_mail) =" + searchBox.Text.Trim() + $" and username='{UserData.Username}'  ORDER BY mails.id ASC  ";
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync("SearchFilter");
                }
                else if (SearchOption.SelectedIndex == 4)  //Department
                {
                    if (UserData.userType == 3)
                    {
                        CustomMessageDialog.ShowDialog("عفوا ليس دليك الصلاحيات للقيام بهذه العملية", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                   }
                    QueryFilter = $" WHERE username ={UserData.Username} ORDER BY mails.id ASC  ";
                    if (!worker.IsBusy)
                        worker.RunWorkerAsync("SearchFilter");
                }

            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                ResetVal();
                UserData.LoadMore = 30;
                if (!worker.IsBusy)
                    worker.RunWorkerAsync("load");
            }
        }
        private void ResetVal()
        {
            view_more.IsEnabled = true;
            searchBox.Text = "";
            SearchOption.SelectedIndex = -1;
        }

        private void openDoc_Click_1(object sender, RoutedEventArgs e)
        {
            if (GridTable.SelectedItems.Count > 0)
            {
                System.Diagnostics.Process.Start(SelectedCellFilePath);
            }
        }

        private void deleteDoc_Click(object sender, RoutedEventArgs e)
        {
            //if (GridTable.SelectedItems.Count != 0)
            //{

            //    var GetCelll = GridTable.SelectedCells[2];
            //    TextBlock GetCellData = (TextBlock)GetCelll.Column.GetCellContent(GetCelll.Item);
            //    if (MessageBox.Show(GetCellData.Text + " حذف المكاتبة ", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            //    {
            //        new DbObjects().DeleteMail(GetCellData.Text);  
            //        GridTable.ItemsSource = new DbObjects().SelectMail(UserData.userType).DefaultView;


            //    }
            //}
        }


    }

}
