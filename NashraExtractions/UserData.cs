using MaterialDesignThemes.Wpf;
using NashraExtractions.JsonFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace NashraExtractions
{
    static class UserData
    {
        public static string Username { get; set; }
        public static int userType { get; set; }
        public static int LoadMore = 30;
        public static int UserMailCount { get; set; }
        public static int ArchiveDepCount { get; set; }

        public static bool IsDarkMode { get; set; }

        public static void DarkMode(Window window)
        {
            PaletteHelper palette = new PaletteHelper();    
            ITheme theme = palette.GetTheme();  
            theme.SetBaseTheme(Theme.Dark);
            palette.SetTheme(theme);
            var bc = new BrushConverter();
            window.Background = (Brush)bc.ConvertFrom("#FF3C3A3A");
        }
        public static void LightMode(Window window)
        {
            PaletteHelper palette = new PaletteHelper();
            ITheme theme = palette.GetTheme();
            theme.SetBaseTheme(Theme.Light);
            palette.SetTheme(theme);
            window.Background = Brushes.White;
        }
        public static string UserPath { get { return AppDomain.CurrentDomain.BaseDirectory + "UserMails"; } }
        public static string SetID()
        {
            Random r = new Random();
            string id = DateTime.Now.ToString("yyy/mm/dd").Replace('/', '_') + "_" + r.Next(1, 500000);
            return id;
        }
        public static void UpdateFile()
        {
            try
            {
                var Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Mails_Signed");
                for (int i = 0; i < Files.Length; i++)
                {
                    var CreationFileTime = new FileInfo(Files[i]).CreationTime.ToShortDateString();
                    if (CreationFileTime != DateTime.Now.ToShortDateString())  // if Creation file not equal current date
                        new FileInfo(Files[i]).Delete();
                }
                Files = null;

            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("The process cannot access the file"))
                    CloseWord();


                else
                    CustomMessageDialog.ShowDialog(ex.Message, "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

            }



        }
        public static DataTable DefaultViewTable { get; set; }
        public static bool DocIsOpen(string file_name)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(file_name, FileMode.Open, FileAccess.Read, FileShare.None);
                return false;

            }
            catch (IOException ex)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public static void CloseWord()
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("WINWORD");

            for (int i = 0; i < process.Length; i++)
            {
                Console.WriteLine(process[i].ProcessName);
                //process[i].Kill();
            }
        }
        public static bool WordIsOpen()
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("WINWORD");
             if(process.Length == 0)
                return false;
             else
                return true;
        }
        public static void DeleteAllArchiveFiles()
        {
            var Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\archive");
            CloseWord();
            for (int i = 0; i < Files.Length; i++)
            {
                new FileInfo(Files[i]).Delete();
            }
            Files = null;
        }
        public static void DeleteWordFiles()
        {
            try
            {
                var GetFiles = Directory.GetFiles(UserPath);
                if (GetFiles == null)
                    return;

                foreach (var file in GetFiles)
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("The process cannot access the file"))
                {

                    CustomMessageDialog.ShowDialog("برجاء إغلاق المستندات اولا ", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message, "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
        }
    }
}
