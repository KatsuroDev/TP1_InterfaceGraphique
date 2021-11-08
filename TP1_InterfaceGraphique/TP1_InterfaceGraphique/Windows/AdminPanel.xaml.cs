using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP1_InterfaceGraphique.Classes;

namespace TP1_InterfaceGraphique.Windows
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == QuitBtn)
            {
                LoginController.Disconnect();
                this.Close();
            }
            else if(sender == ScheduleBtn)
            {
                MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(sender == TeachersBtn)
            {
                var window = new TeachersList();
                window.Show();
            }
            else if(sender == StudentsBtn)
            {
                var window = new StudentsList();
                window.Show();
            }


        }
    }
}
