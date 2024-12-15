using System.Windows;
using AdminApp.ViewModels;

namespace AdminApp.Views
{
    public partial class UserListView : Window
    {
        public UserListView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }
    }
}
