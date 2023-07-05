using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NashraExtractions
{
    internal class Notifications
    {
        NotifyIcon notifications;

        public  void PushNotification(int curr_state,string title,string txt)
        {
            if(curr_state > Properties.Settings.Default.NotificationsSotred)
            {
                CreateNotifications(title,txt);
                Properties.Settings.Default.NotificationsSotred = curr_state;
            }
        }
        private void CreateNotifications(string title, string txt)
        {
            notifications = new NotifyIcon();
            notifications.Icon = notifications.Icon = Properties.Resources.logo;
            notifications.Visible = true;
            notifications.Click += (sender, e) => Notifications_Click(sender, e);
            notifications.ShowBalloonTip(5000, title, txt, ToolTipIcon.Info);
        }

        private void Notifications_Click(object sender, EventArgs e)
        {
            //if(System.IO.File.Exists(filname))
            //{
            //    System.Diagnostics.Process.Start(filname);
            //}
        }
    }
}
