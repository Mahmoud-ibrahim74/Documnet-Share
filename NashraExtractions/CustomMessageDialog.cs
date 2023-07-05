using System.Windows;
namespace NashraExtractions
{
    internal class CustomMessageDialog
    {

        public static void ShowDialog(string title, string caption, MessageBoxButton btns, MessageBoxImage ico)
        {
            MessageBox.Show(title, caption, btns, ico);

        }
        public static void test()
        {
        }
    }
}
