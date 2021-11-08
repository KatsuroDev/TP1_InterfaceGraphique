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
    /// Interaction logic for StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Window
    {
        public StudentsList()
        {
            InitializeComponent();

            Update_UserList();
        }



        private void Update_UserList()
        {
            UsersList.Items.Clear();
            foreach (var student in App.Current.Students)
            {
                if(student.Value.ToString().Contains(ResearchBox.Text))
                    UsersList.Items.Add(student.Value);
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersList.SelectedItem != null)
            {
                User user = UsersList.SelectedItem as User;
                if(MessageBox.Show($"Voulez-vous vraiment suprrimer l'étudiant {user} ?", "Supprimer un étudiant", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                   var result =  MessageBox.Show($"Attention : L'étudiant sera retiré de tout les cours et toutes ses\n" +
                        $"évaluations seront perdus. Cette opération est irreversible.\n" +
                        $"Voulez-vous effectuer la suprresion ?", "Supprimer un étudiant", MessageBoxButton.YesNo, MessageBoxImage.Error);
                
                    if(result == MessageBoxResult.Yes)
                    {
                        App.Current.Students.Remove(user.Id);
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
