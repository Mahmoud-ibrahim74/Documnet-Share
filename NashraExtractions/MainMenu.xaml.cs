using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace NashraExtractions
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        string SelectedCellFilePath = "";
        string file_exe = "";
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        string uploadedFile = "";
        System.ComponentModel.BackgroundWorker _worker;
        public string table_id { get; set; }
        public DataTable DefaultTable { get; set; } = null;
        public MainMenu()
        {
            if (UserData.WordIsOpen())
            {
                CustomMessageDialog.ShowDialog("برجاء إغلاق المستندات اولا ", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                this.Close();
            }
            else
            {
                InitializeComponent();
                LoginState();
                FileUpdatableAsync();

                ScreenResponsive responsive = new ScreenResponsive(this);
                MaterialDesignThemes.Wpf.Card[] cards = new MaterialDesignThemes.Wpf.Card[3];
                cards[0] = topCard;
                cards[1] = ContainerCard;
                cards[2] = StateCard;
                responsive.SetCardResponsive(cards);
                rectGeo.Rect = new Rect(0, 0, responsive._Width, responsive._Height);
                openFileDialog.Filter = "Word Files|*.doc;*.docx;";
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = "Word Files";
                openFileDialog.Title = "رفع مكاتبة";
                _worker = new System.ComponentModel.BackgroundWorker();
                _worker.DoWork += _worker_DoWork;
                _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
                //Display();
                //JsonConverting();
            }


        }

        private void _worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                GridTable.IsEnabled = true;
            }
            if (e.Result is DataTable)
            {
                GridTable.ItemsSource = ((DataTable)e.Result).DefaultView;
                GridTable.Columns[6].Width = 500;
                GridTable.Columns[1].Width = 500;
                DefaultTable = DbAPI.SelectMail();
            }
        }

        private void _worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if ((string)e.Argument == "viewTable")
            {
                try
                {
                    e.Result = DbAPI.SelectMail();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((string)e.Argument == "Signed")
            {
                DbAPI.SignUser(table_id);
            }
            else if ((string)e.Argument == "DeleteWords")
            {
                UserData.DeleteWordFiles();
            }

        }

        private async void LoginState()
        {
            while (true)
            {
                await Task.Delay(1000);
                if (!string.IsNullOrWhiteSpace(UserData.Username) && !string.IsNullOrWhiteSpace(UserData.userType.ToString()))
                {
                    username.Content = UserData.Username;
                    TopGrid.IsEnabled = true;
                    ContainerGrid.IsEnabled = true;
                    StateCard.IsEnabled = true;

                    if (UserData.userType == 1 || UserData.userType == 2)  // if user is admin
                    {
                        AddDoc.IsEnabled = false;
                        InsertDoc.IsEnabled = false;
                        UpdateMail.IsEnabled = false;
                    }
                    else if (UserData.userType == 3)
                    {
                        SignedBtn.IsEnabled = false;

                        SendArchive.Visibility = Visibility.Hidden;
                        ArchiveCount.Visibility = Visibility.Hidden;
                        sendIcon.Visibility = Visibility.Hidden;
                    }
                    else if (UserData.userType == 4)   // if user is archive
                    {
                        AddDoc.IsEnabled = false;
                        InsertDoc.IsEnabled = false;
                        UpdateMail.IsEnabled = false;
                        SendArchive.IsEnabled = false;
                        SignedBtn.IsEnabled = false;
                        archive.IsEnabled = false;
                    }

                    MailCount.Content = UserData.UserMailCount.ToString();
                    ArchiveCount.Content = DbAPI.ArchiveDepCount();
                    //if (UserData.userType == 4)
                    //{
                    //    MailCount.Content = UserData.UserMailCount.ToString();
                    //    ArchiveCount.Content = UserData.ArchiveDepCount.ToString();
                    //}
                    //else
                    //{
                    //    MailCount.Content = UserData.UserMailCount.ToString();
                    //}


                    //int get_curr = Convert.ToInt32(MailCount.Content);
                    //new Notifications().PushNotification(get_curr, "مكاتبة جديدة", "تم اضافة مكاتبة جديد");
                    if (UserData.userType == 3)
                        LineState();



                }
            }
        }
        public void LineState()
        {
            //if (GridTable.SelectedItems.Count > 0)
            //{
            //    phase1.IsChecked = true;
            //    var GetCelll = GridTable.SelectedCells[1];
            //    var GetCelll_issign = GridTable.SelectedCells[6];
            //    TextBlock GetCellData = (TextBlock)GetCelll.Column.GetCellContent(GetCelll.Item);
            //    var GetCellData_issing = (CheckBox)GetCelll_issign.Column.GetCellContent(GetCelll_issign.Item);
            //    int seen_val = new DbObjects().MessageState(GetCellData.Text, UserData.userType);
            //    bool issign = (bool)GetCellData_issing.IsChecked;
            //    switch (seen_val)
            //    {
            //        case 1:
            //            MailState.Value = 4;
            //            phase2.IsChecked = true;
            //            break;
            //        default:
            //            phase2.IsChecked = false;
            //            MailState.Value = 0;
            //            break;
            //    }
            //    switch (issign)
            //    {
            //        case true:
            //            phase3.IsChecked = true;
            //            MailState.Value = 8;
            //            break;
            //        default:
            //            phase3.IsChecked = false;
            //            MailState.Value = 0;
            //            break;
            //    }

            //}
        }
        private async void FileUpdatableAsync()
        {
            while (true)
            {
                await Task.Delay(1000);
                UserData.UpdateFile();
            }
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if (Keyboard.IsKeyDown(Key.RightCtrl) && e.Key == Key.L || Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.L)
            {
                if (UserData.Username == null)
                    mainWindow.ShowDialog();
            }
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.W)
            {
                if (MessageBox.Show("Word سوف يتم اغلاق برنامج ", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    UserData.CloseWord();
                }
            }
            else if (Keyboard.IsKeyDown(Key.F5))
            {
                if (!string.IsNullOrWhiteSpace(UserData.Username) && !string.IsNullOrWhiteSpace(UserData.userType.ToString()))
                {
                    if (!_worker.IsBusy)
                    {
                        GridTable.IsEnabled = false;
                        _worker.RunWorkerAsync("viewTable");
                    }
                }
            }

        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("إغلاق التطبيق", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ViewDoc_Click(object sender, RoutedEventArgs e)
        {
            if (!_worker.IsBusy)
            {
                GridTable.IsEnabled = false;
                _worker.RunWorkerAsync("viewTable");
            }
        }
        //private void ViewMails()
        //{
        //    GridTable.ItemsSource = DbAPI.SelectMail().DefaultView;
        //    GridTable.Columns[6].Width = 500;
        //    GridTable.Columns[1].Width = 500;
        //    DefaultTable = DbAPI.SelectMail();

        //}


        private void AddDoc_Click(object sender, RoutedEventArgs e)
        {

            if (openFileDialog.ShowDialog() == true)
            {
                System.Diagnostics.Process.Start(openFileDialog.FileName);
                filename.Content = openFileDialog.FileName;
                file_exe = new FileInfo(openFileDialog.FileName).Extension;
                uploadedFile = openFileDialog.FileName;
            }
        }

        private void OpenDoc_Click(object sender, RoutedEventArgs e)
        {
            if (GridTable.SelectedItems.Count > 0)
            {
                if (!UserData.WordIsOpen())
                    System.Diagnostics.Process.Start(UserData.UserPath + @"\" + SelectedCellFilePath);
                else
                    CustomMessageDialog.ShowDialog("برجاء إغلاق المستندات اولا ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);


                if (UserData.userType != 3)
                {
                    try
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            DbAPI.UpdateSeen(table_id);
                        });


                    }
                    catch (Exception ex)
                    {
                        CustomMessageDialog.ShowDialog(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
            else
            {
                CustomMessageDialog.ShowDialog("برجاء اختيار مكاتبة اولا", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void GridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridTable.SelectedItems.Count != 0)
            {
                var GetCelll = GridTable.SelectedCells[6]; // get filename
                TextBlock GetCellData = (TextBlock)GetCelll.Column.GetCellContent(GetCelll.Item);

                var mailId = GridTable.SelectedCells[0]; // get id from table
                TextBlock mail_id = (TextBlock)mailId.Column.GetCellContent(mailId.Item);
                SelectedCellFilePath = GetCellData.Text;
                table_id = mail_id.Text;

                if (DbAPI.IsSeen(table_id) == 1)
                {
                    phase1.IsChecked = true;
                    MailState.Value = 1;

                    var getCheckBox = GridTable.SelectedCells[4];
                    CheckBox CheckBoxItem = (CheckBox)getCheckBox.Column.GetCellContent(getCheckBox.Item);
                    if (CheckBoxItem.IsChecked == true)
                    {
                        phase2.IsChecked = true;
                        MailState.Value = 6;
                        UpdateMail.IsEnabled = false;
                        SendArchive.IsEnabled = true;

                        if (DbAPI.IsSendArchive(table_id) == 1)
                        {
                            phase3.IsChecked = true;
                            MailState.Value = 12;
                        }
                        else
                        {
                            phase3.IsChecked = false;

                        }
                    }
                    else
                    {
                        phase2.IsChecked = false;
                        phase3.IsChecked = false;
                        SendArchive.IsEnabled = false;
                    }

                }
                else
                {
                    phase1.IsChecked = false;
                    phase2.IsChecked = false;
                    phase3.IsChecked = false;
                    MailState.Value = 0;

                    if (UserData.userType == 3)
                        UpdateMail.IsEnabled = true;

                }




            }
        }


        private void filename_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(uploadedFile))
            {
                System.Diagnostics.Process.Start(filename.Content.ToString());
            }
            else
            {
                CustomMessageDialog.ShowDialog("برجاء اختيار ملف اولا", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void DeleteMail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void DragSign_Click(object sender, RoutedEventArgs e)
        {
            new archive().ShowDialog();
        }

        private void InsertDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string file_name = $"{Guid.NewGuid().ToString()}{file_exe}";
                if (UserData.userType == 3) // this user not admin
                {
                    if (!File.Exists(uploadedFile))  //  if user doesn't select file
                    {
                        CustomMessageDialog.ShowDialog("برجاء اختيار ملف اولا", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    FileStream stream = File.OpenRead(uploadedFile);
                    byte[] fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);

                    string title_mail = new System.Windows.Documents.TextRange(Mail_Title.Document.ContentStart, Mail_Title.Document.ContentEnd).Text;
                    DbAPI.InsertMail(uploadedFile, 0, UserData.Username, UserData.userType, file_name, title_mail);
                    uploadedFile = null;
                    filename.Content = null;
                }
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("The process cannot access the file"))
                {

                    CustomMessageDialog.ShowDialog("برجاء إغلاق المستند اولا ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateMail_Click(object sender, RoutedEventArgs e)
        {
            if (GridTable.SelectedItems.Count != 0)
            {
                var title_table = GridTable.SelectedCells[1];
                TextBlock title_mail = (TextBlock)title_table.Column.GetCellContent(title_table.Item);


                if (MessageBox.Show(table_id + " تحديث المكاتبة رقم ", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DbAPI.UpdateMail(UserData.UserPath + @"\" + SelectedCellFilePath, SelectedCellFilePath, title_mail.Text);
                    //ViewMails();
                }
            }
        }

        private void SignedBtn_Click(object sender, RoutedEventArgs e)
        {

            if (GridTable.SelectedItems.Count != 0)
            {
                if (MessageBox.Show(table_id + " توقيع المكاتبة رقم  ", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (!_worker.IsBusy)
                        _worker.RunWorkerAsync("Signed");
                }
            }
            else
            {
                CustomMessageDialog.ShowDialog("برجاء اختيار مكاتبة اولا", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void SendArchive_Click(object sender, RoutedEventArgs e)
        {
            if (GridTable.SelectedItems.Count != 0)
            {
                if (MessageBox.Show(table_id + " إرسال المكاتبة  رقم ", "تحذير", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DbAPI.ArchiveSent(table_id);
                }
            }
            else
            {
                CustomMessageDialog.ShowDialog("برجاء اختيار مكاتبة اولا", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserData.WordIsOpen())
            {
                CustomMessageDialog.ShowDialog("برجاء إغلاق المستندات اولا ", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!_worker.IsBusy)
                _worker.RunWorkerAsync("DeleteWords");
        }

        private void ThemeMode_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.IsDarkMode)
            {
                UserData.DarkMode(this);
                UserData.IsDarkMode = true;
            }
            else
            {
                UserData.LightMode(this);
                UserData.IsDarkMode = false;
            }


        }
    }

}
