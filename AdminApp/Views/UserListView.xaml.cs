using System.Windows;
using AdminApp.ViewModels;

namespace AdminApp.Views
{
    public partial class UserListView : Window
    {
        public UserListView()
        {
            InitializeComponent();
            // Sets the data context to the UserListViewModel to bind data to the UI
            DataContext = new UserListViewModel();
        }
    }
}