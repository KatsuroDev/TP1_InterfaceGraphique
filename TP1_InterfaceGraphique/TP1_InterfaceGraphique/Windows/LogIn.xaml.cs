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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == ForgottenPasswordBtn)
            {
                MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Login();
        }

        private void Login()
        {
            bool? isStudent = StudentRdBtn.IsChecked;

            String usernameInput = UsernameTxtBox.Text;
            String passwordInput = PasswordTxtBox.Password;


            if (isStudent == null)
                throw new NullReferenceException();

            if (!LoginController.TryLogin(usernameInput, passwordInput, isStudent.Value))
            {
                MessageBox.Show("L'identifiant ou le mot de passe est invalide.", "Erreur d'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (LoginController.ActiveUser is Teacher)
            {
                MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (LoginController.ActiveUser is Student)
            {
                MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (LoginController.ActiveUser is Admin)
            {
                var adminpanel = new AdminPanel();
                adminpanel.Show();
                this.Close();

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }
    }
}
