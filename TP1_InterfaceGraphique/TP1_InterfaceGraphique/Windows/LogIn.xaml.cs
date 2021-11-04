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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            
            bool? isStudent = StudentRdBtn.IsChecked;

            String usernameInput = UsernameTxtBox.Text;
            String passwordInput = PasswordTxtBox.Password;


            if (isStudent == null)
                throw new NullReferenceException();


            int userId;
            if (!Int32.TryParse(usernameInput, out userId))
            {
                MessageBox.Show($"L'identifiant ou le mot de passe est invalide.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (!LoginController.TryLogin(userId, passwordInput, isStudent.Value))
            {
                MessageBox.Show($"L'identifiant ou le mot de passe est invalide.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
