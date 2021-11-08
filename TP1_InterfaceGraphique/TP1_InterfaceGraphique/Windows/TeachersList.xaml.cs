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

namespace TP1_InterfaceGraphique.Windows
{
    /// <summary>
    /// Interaction logic for TeachersList.xaml
    /// </summary>
    public partial class TeachersList : Window
    {
        public TeachersList()
        {
            InitializeComponent();

            Update_UserList();
        }
        private void Update_UserList()
        {
            UsersList.Items.Clear();
            foreach (var teacher in App.Current.Teachers)
            {
                if (teacher.Value.ToString().Contains(ResearchBox.Text))
                    UsersList.Items.Add(teacher.Value);
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersList.SelectedItem != null)
            {
                User user = UsersList.SelectedItem as User;
                if (MessageBox.Show($"Voulez-vous vraiment suprrimer l'enseignant {user} ?", "Supprimer un enseignant", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var result = MessageBox.Show($"Attention : L'enseignant sera retiré de tout les cours\n" +
                         $"Cette opération est irreversible.\n" +
                         $"Voulez-vous effectuer la suprresion ?", "Supprimer un enseignant", MessageBoxButton.YesNo, MessageBoxImage.Error);

                    if (result == MessageBoxResult.Yes)
                    {
                        App.Current.Teachers.Remove(user.Id);
                        Update_UserList();
                    }
                }
            }
        }

        private void ResearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update_UserList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO", "TODO", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
