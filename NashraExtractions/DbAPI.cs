using NashraExtractions.JsonFiles;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NashraExtractions
{
    internal static class DbAPI
    {
        public static void LoginAuthn(string username, string pass, Window window)
        {
            using (WebClient client = new WebClient())
            {
                Login login = new Login();
                try
                {
                    var res = client.DownloadString($"http://192.9.4.20//emails/LoginAuthn.php?username={username}&password={pass}");
                    var replace = res.Replace('[', ' ').Replace(']', ' ').Trim();
                    if (replace.Contains("{"))
                    {
                        login = JsonConvert.DeserializeObject<Login>(replace);
                        UserData.Username = login.UserName;
                        UserData.userType = login.type;
                        CustomMessageDialog.ShowDialog(" تم تسجيل الدخول  بنجاح ", "تم", MessageBoxButton.OK, MessageBoxImage.Information);
                        window.Close();
                        login = null;
                    }
                    else
                    {
                        CustomMessageDialog.ShowDialog(" اسم المستخدم او كلمة المرور غير صحيحة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (WebException ex)
                {
                    CustomMessageDialog.ShowDialog(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        public static void InsertMail(string file_path, int signed, string user_name, int userType, string filename, string mail_title)
        {
            //string fileString = Convert.ToBase64String(file);
            string URI = "http://192.9.4.20/emails/InsertMail.php";
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            NameValueCollection values = new NameValueCollection();
            values.Add("file_path", file_path);
            values.Add("signed", signed.ToString());
            values.Add("user_name", user_name);
            values.Add("userType", userType.ToString());
            values.Add("filename", filename);
            values.Add("mail_title", mail_title);
            values.Add("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            wc.UploadFile(URI, file_path);

            var htmlres = wc.UploadValues(URI, values);
            var res = System.Text.Encoding.UTF8.GetString(htmlres);
            MessageHandler(res);
        }
        public static void UpdateMail(string file_path, string filename, string mail_title)
        {
            //string fileString = Convert.ToBase64String(file);
            string URI = $"http://192.9.4.20/emails/UpdateMail.php?filename={filename}&date={DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}&mail_title={mail_title}";
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            NameValueCollection values = new NameValueCollection();
            values.Add("filename", filename);
            values.Add("mail_title", mail_title);
            values.Add("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var htmlres = wc.UploadValues(URI, values);
            wc.UploadFile(new Uri(URI), "POST", file_path);
            var res = System.Text.Encoding.UTF8.GetString(htmlres);
            MessageHandler(res);
        }
        public static void DeleteMail(string filename)
        {
            string URI = $"http://192.9.4.20/emails/DeleteMail.php?filename={filename}";
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            NameValueCollection values = new NameValueCollection();
            values.Add("filename", filename);
            var htmlres = wc.UploadValues(URI, values);
            var res = System.Text.Encoding.UTF8.GetString(htmlres);
            MessageHandler(res);
        }

        public static DataTable SelectMail()
        {
            using (WebClient client = new WebClient())
            {
                DataTable dt = new DataTable();
                try
                {
                    List<SelectMail> mail = new List<SelectMail>();
                    if (UserData.userType != 4) // if user doesn't archive departement
                    {
                        var res = client.DownloadString($"http://192.9.4.20//emails/SelectMails.php?username={UserData.Username}&datetimeNow={DateTime.Now.ToString("yyyy-MM-dd")}&user_type={UserData.userType}");
                        if (res.Contains("{"))
                        {
                            mail = JsonConvert.DeserializeObject<List<SelectMail>>(res);
                            UserData.UserMailCount = mail.Count;
                            if (mail.Count > 0)
                            {
                                dt = CreateDT(mail);
                                UserData.DefaultViewTable = dt;
                            }
                        }
                        else
                        {
                            dt = CreateDT(null);
                        }
                    }
                    else   // if user is archive departement
                    {
                        var res = client.DownloadString($"http://192.9.4.20//emails/ArchiveView.php?username={UserData.Username}&datetimeNow={DateTime.Now.ToString("yyyy-MM-dd")}");
                        if (res.Contains("{"))
                        {
                            mail = JsonConvert.DeserializeObject<List<SelectMail>>(res);
                            UserData.ArchiveDepCount = mail.Count;
                            if (mail.Count > 0)
                            {
                                dt = CreateDT(mail);
                                UserData.DefaultViewTable = dt;
                            }
                        }
                        else
                        {
                            dt = CreateDT(null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is WebException || ex is DataException || ex is JsonException)
                    {
                        CustomMessageDialog.ShowDialog(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                finally
                {
                    client.Dispose();
                }
                return dt;


            }
        }

        public static DataTable SelectMailArchive(string queryFilter)
        {
            using (WebClient client = new WebClient())
            {
                DataTable dt = new DataTable();
                try
                {
                    string url = string.Empty;
                    if (queryFilter == null)
                    {
                        url = $"http://192.9.4.20//emails/SelectMailsArchive.php?LoadMore={UserData.LoadMore}&username={UserData.Username}&userType={UserData.userType}";
                    }
                    else
                    {
                        url = $"http://192.9.4.20//emails/SelectMailsArchive.php?LoadMore={UserData.LoadMore}&QueryFilter={queryFilter}&username={UserData.Username}&userType={UserData.userType}";
                    }
                    List<SelectMail> mail = new List<SelectMail>();
                    var res = client.DownloadString(url);
                    if (res.Contains("{"))
                    {
                        mail = JsonConvert.DeserializeObject<List<SelectMail>>(res);
                        dt = CreateDTArchive(mail);
                    }
                    else
                    {
                        dt = CreateDTArchive(mail);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is WebException || ex is DataException || ex is JsonException)
                    {
                        CustomMessageDialog.ShowDialog(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                finally
                {
                    client.Dispose();
                }
                return dt;


            }
        }

        private static void DownloadFile(string filename)
        {
            try
            {
                string url = $"http://192.9.4.20//emails/media.php?filename={filename}";
                WebClient client = new WebClient();
                client.DownloadFile(new Uri(url), UserData.UserPath + $@"\{filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int IsSeen(string id)
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString($"http://192.9.4.20//emails/SeenState.php?id={id}");                
                return Convert.ToInt32(res);
            }
        }
        public static int IsSendArchive(string id)
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString($"http://192.9.4.20//emails/ArchiveOneRow.php?id={id}");
                return Convert.ToInt32(res);
            }
        }
        public static void UpdateSeen(string id)
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString($"http://192.9.4.20//emails/UpdateSeen.php?id={id}");
            }
        }
        public static void SignUser(string id)
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString($"http://192.9.4.20//emails/Signed.php?id={id}&userSigned={UserData.Username}");
                MessageHandler(res);
            }
        }
        public static void ArchiveSent(string id)
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString($"http://192.9.4.20//emails/ArchiveSent.php?id={id}");
                MessageHandler(res);
            }
        }
        public static string ArchiveDepCount()
        {
            using (WebClient client = new WebClient())
            {

                var res = client.DownloadString($"http://192.9.4.20//emails/ArchiveState.php?date={DateTime.Now.ToString("yyyy-MM-dd")}");
                
                return res;
            }
        }
        private static DataTable CreateDT(List<SelectMail> ListMail)
        {
            if (ListMail != null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("م", typeof(int));
                table.Columns.Add("عنوان المكاتبة", typeof(string));
                table.Columns.Add("اسم المستخدم", typeof(string));
                table.Columns.Add("تاريخ اخر تحديث", typeof(DateTime));
                table.Columns.Add("تم التوقيع", typeof(bool));
                table.Columns.Add("الموقع عليه", typeof(string));
                table.Columns.Add("اسم الملف", typeof(string));
                for (int i = 0; i < ListMail.Count; i++)
                {
                    table.Rows.Add(new object[] {
                            ListMail[i].id,
                            ListMail[i].mail_title,
                            ListMail[i].username,
                            ListMail[i].date_mail,
                            ListMail[i].isSigned,
                            ListMail[i].UserSigned,
                            ListMail[i].file_name
                        });
                    DownloadFile(ListMail[i].file_name);
                }
                return table;
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("م", typeof(int));
                table.Columns.Add("عنوان المكاتبة", typeof(string));
                table.Columns.Add("اسم المستخدم", typeof(string));
                table.Columns.Add("تاريخ المكاتبة", typeof(DateTime));
                table.Columns.Add("تم التوقيع", typeof(bool));
                table.Columns.Add("الموقع عليه", typeof(string));
                table.Columns.Add("اسم الملف", typeof(string));
                CustomMessageDialog.ShowDialog("لا يوجد مكاتبات لهذا المستخدم", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                return table;
            }
        }
        private static DataTable CreateDTArchive(List<SelectMail> ListMail)
        {
            if (ListMail != null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("م", typeof(int));
                table.Columns.Add("عنوان المكاتبة", typeof(string));
                table.Columns.Add("اسم المستخدم", typeof(string));
                table.Columns.Add("تاريخ اخر تحديث", typeof(DateTime));
                table.Columns.Add("تم التوقيع", typeof(bool));
                table.Columns.Add("الموقع عليه", typeof(string));
                table.Columns.Add("اسم الملف", typeof(string));
                for (int i = 0; i < ListMail.Count; i++)
                {
                    table.Rows.Add(new object[] {
                            ListMail[i].id,
                            ListMail[i].mail_title,
                            ListMail[i].username,
                            ListMail[i].date_mail,
                            ListMail[i].isSigned,
                            ListMail[i].UserSigned,
                            ListMail[i].file_name
                        });
                    //DownloadFiles(ListMail[i].file_name);
                }
                return table;
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("عنوان المكاتبة", typeof(string));
                table.Columns.Add("اسم المستخدم", typeof(string));
                table.Columns.Add("تاريخ المكاتبة", typeof(DateTime));
                table.Columns.Add("تم التوقيع", typeof(bool));
                table.Columns.Add("الموقع عليه", typeof(string));

                table.Columns.Add("اسم الملف", typeof(string));
                CustomMessageDialog.ShowDialog("لا يوجد مكاتبات لهذا المستخدم", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                return table;
            }
        }

        private static void MessageHandler(string state)
        {
            if (state != null)
            {
                if (state.Contains("Duplicate entry"))
                {
                    CustomMessageDialog.ShowDialog("برجاء إدخال عنوان مكاتبة اخر", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (state.Contains("Something Wrong"))
                {
                    CustomMessageDialog.ShowDialog("حدث خطأ ما برجاء المحاولة لاحقا", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (state.Contains("Done742@"))
                {
                    CustomMessageDialog.ShowDialog("تم إدخال ألمكاتبة بنجاح", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (state.Contains("Done754@"))
                {
                    CustomMessageDialog.ShowDialog("تم تحديث ألمكاتبة بنجاح", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (state.Contains("Done790@"))
                {
                    CustomMessageDialog.ShowDialog("تم حذف ألمكاتبة بنجاح", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (state.Contains("Done900@"))
                {
                    CustomMessageDialog.ShowDialog("تم توقيع ألمكاتبة بنجاح", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (state.Contains("Done650@"))
                {
                    CustomMessageDialog.ShowDialog("تم إرسال الأرشيف", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CustomMessageDialog.ShowDialog(state, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
