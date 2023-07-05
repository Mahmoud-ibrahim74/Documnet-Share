using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace NashraExtractions
{

    class DbObjects
    {
        MySqlConnection connection;
        private string ServerName = "localhost";
        private string Database = "emails";
        private string username = "root";
        private string Pass = "";
        private readonly string ConnString = "";

        public DbObjects()
        {
            ConnString = "SERVER =" + ServerName + ";" + "DATABASE = " +
                       Database + ";Port=3306;" + "UID = " + username + ";" + "PASSWORD =" + Pass + ";" +
                       " Convert Zero Datetime=True;charset=utf8;";
            connection = new MySqlConnection(ConnString);
        }


        //    public void InsertUser(string username, string password, int type, int DepNo)
        //{
        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand("INSERT INTO login (`username`, `password`, `type`, `Depart_No`) VALUES (@user,@pass,@type,@dep_no);", connection);
        //    command.Parameters.AddWithValue("@user", username);
        //    command.Parameters.AddWithValue("@pass", username);
        //    command.Parameters.AddWithValue("@type", username);
        //    command.Parameters.AddWithValue("@dep_no", username);
        //    command.ExecuteNonQuery();
        //    connection.Close();

        //}
        public void Login(string username, string password, System.Windows.Window login_frm)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from login where username =@user and password =@pass", connection);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserData.Username = reader["username"].ToString();
                    UserData.userType = Convert.ToInt32(reader["type"].ToString());
                    CustomMessageDialog.ShowDialog(" تم تسجيل الدخول  بنجاح ", "تم", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    login_frm.Close();


                }
                else
                {
                    CustomMessageDialog.ShowDialog(" اسم المستخدم او كلمة المرور غير صحيحة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                connection.Close();


            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "   خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
        }
        //public void LoginTest()
        //{
        //    connection.Open();
        //    MySqlCommand mySqlCommand = new MySqlCommand("select * from login", connection);
        //    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
        //    while (mySqlDataReader.Read())
        //    {
        //        MessageBox.Show(mySqlDataReader["username"].ToString());
        //    }
        //}

        public void InsertMail(byte[] file, int signed, string user_name, int userType, string filename, string mail_title)
        {

            try
            {
                connection.Open();
                string query = "INSERT INTO `mails`(mail_title,`user_type`, `username`, `date_mail`, `isSigned`, `Word_File`,file_name) VALUES (@title,@type," +
                    "@user_name,@date," +
                    "@signed,@file,@file_name)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", mail_title);
                cmd.Parameters.AddWithValue("@type", userType);
                cmd.Parameters.AddWithValue("@user_name", user_name);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@signed", signed);
                cmd.Parameters.AddWithValue("@file", file);
                cmd.Parameters.AddWithValue("@file_name", filename);
                cmd.ExecuteNonQuery();
                CustomMessageDialog.ShowDialog("تم رفع المكاتبة بنجاح ", "تم", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else if (ex.Message.Contains("Duplicate entry"))
                {
                    CustomMessageDialog.ShowDialog("يوجد مكاتبة بنفس العنوان" + "\n" + "برجاء تغيير العنوان ", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "  حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
        }
        public void UpdatetMail(byte[] file, string filename)
        {

            try
            {
                connection.Open();
                string query = "UPDATE `mails` SET `isSigned`= 1,UserSigned = @user_sign ,`Word_File`= @file  WHERE file_name = @file_name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@file", file);
                cmd.Parameters.AddWithValue("@file_name", filename);
                cmd.Parameters.AddWithValue("@user_sign", UserData.Username);

                cmd.ExecuteNonQuery();
                CustomMessageDialog.ShowDialog("تم", " تم رفع المكاتبة بعد التوقيع بنجاح ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
        }


        public string SelectMailCount(int userType)
        {
            string RowCount = "";
            string query = "";
            if (userType == 1 || userType == 2)
                query = "SELECT COUNT(*) FROM mails WHERE date_mail LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%' and isSigned = 0 and username="+UserData.Username+" ";
            else
                query = "SELECT COUNT(*) FROM mails WHERE date_mail LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%'";


            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                RowCount = cmd.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                connection.Close();
            }
            return RowCount;

        }

        public DataTable SelectMail(int userType)
        {
            string query = "";
            if (userType == 1 || userType == 2)
            {
                query = "SELECT mail_title as 'عنوان المكاتبة',file_name as 'اسم المكاتبة',username as 'اسم المستخدم'," +
                   "date_mail as 'توقيت المكاتبة',isSigned as 'تم التوقيع' " +
                    " FROM mails WHERE date_mail LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%';";
            }
            else
            {
                query = "SELECT mail_title as 'عنوان المكاتبة',file_name as 'اسم المكاتبة',username as 'اسم المستخدم'," +
                        "date_mail as 'توقيت المكاتبة',isSigned as 'تم التوقيع', UserSigned as 'الموقع عليه' " +
                        " FROM mails WHERE date_mail LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%' and username = '" + UserData.Username + "' ";
            }
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dt);
                DownloadWordFiles();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ", "خطأ فى الإتصال بالشبكة", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog("خطأ", ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                connection.Close();

            }

            return dt;
        }
        public DataTable SelectMailArchive(string query)
        {
            DataTable dt = new DataTable();
            string sql_query = "";
            if (string.IsNullOrEmpty(query))  // default view 
            {
                sql_query = "SELECT id as 'م', mail_title as 'عنوان المكاتبة',file_name as 'اسم المكاتبة',username as 'اسم المستخدم'," +
                       "date_mail as 'توقيت المكاتبة',isSigned as 'تم التوقيع',UserSigned as 'الموقع عليه' " +
                        " FROM mails ORDER BY `mails`.`id` ASC LIMIT " + UserData.LoadMore + " ";
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql_query, connection);
                    adapter.Fill(dt);
                    DownloadArchiveWordFiles(null);
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                    }
                    else
                    {
                        CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                    connection.Close();
                }
            }
            else   // query filter
            {
                sql_query = "SELECT id as 'م', mail_title as 'عنوان المكاتبة',file_name as 'اسم المكاتبة',username as 'اسم المستخدم'," +
                       "date_mail as 'توقيت المكاتبة',isSigned as 'تم التوقيع',UserSigned as 'الموقع عليه' " +
                        " FROM mails "+query+"  ";
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql_query, connection);
                    adapter.Fill(dt);
                    DownloadArchiveWordFiles(query);
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                    connection.Close();
                }
            }
            return dt;
        }
        private void DownloadArchiveWordFiles(string query_download)
        {
            if (string.IsNullOrEmpty(query_download))  // default view 
            {
                try
                {
                    string query = "SELECT Word_File,file_name FROM mails  ORDER BY `mails`.`id` ASC LIMIT " + UserData.LoadMore + "  ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string file_path = $@"archive\{reader["file_name"].ToString()}";
                        if (!File.Exists(file_path))
                            File.WriteAllBytes(file_path, (byte[])reader["Word_File"]);
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                    else
                    {
                        CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }

                }
            }
            else
            {
                try
                {
                    string query = "SELECT Word_File,file_name FROM mails "+query_download+"";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string file_path = $@"archive\{reader["file_name"].ToString()}";
                        if (!File.Exists(file_path))
                            File.WriteAllBytes(file_path, (byte[])reader["Word_File"]);
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                    {
                        CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                    }
                    else
                    {
                        CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }

                }
            }
        }
        private void DownloadWordFiles()
        {
            try
            {
                //UserData.CloseWord();
                string query = "SELECT Word_File,file_name from mails WHERE date_mail LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string file_path = $@"Mails_Signed\{reader["file_name"].ToString()}";
                    File.Delete(file_path);
                    if (!File.Exists(file_path))
                    {
                        File.WriteAllBytes(file_path, (byte[])reader["Word_File"]);
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ", "خطأ فى الإتصال بالشبكة", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog("خطأ", ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
        }


        public int MessageState(string filename, int user_type)
        {
            int seen_msg = 0;
            string query = "";
            if (user_type != 3)  // if user  admin
                query = "update mails set seen_msg = 1   WHERE   file_name = '" + filename + "' ";
            else
                query = "select seen_msg from mails  WHERE   file_name = '" + filename + "' ";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                seen_msg = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ", "خطأ فى الإتصال بالشبكة", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog("خطأ", ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
            connection.Close();
            return seen_msg;
        }

        public void DeleteMail(string file_name)
        {

            try
            {
                connection.Open();
                string query = "DELETE from mails WHERE file_name like '" + file_name + "' ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CustomMessageDialog.ShowDialog(" تم حذف المكاتبة ", "تم", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                connection.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Unable to connect to any of the specified MySQL hosts"))
                {
                    CustomMessageDialog.ShowDialog("خطأ فى الإتصال بالشبكة", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);

                }
                else
                {
                    CustomMessageDialog.ShowDialog(ex.Message + "حدث خطأ برجاء المحاولة مرة اخري", "خطأ", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
        }


    }
}
