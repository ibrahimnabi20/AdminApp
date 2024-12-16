using AdminApp.Commands;
using AdminApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.ViewModels
{
    public class UserListViewModel
    {
        // Collection to hold all users
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        // Command for refreshing the user list
        public RelayCommand RefreshCommand { get; }

        // Command for deleting a specific user
        public RelayCommand DeleteCommand { get; }

        private readonly HttpClient client;

        public UserListViewModel()
        {
            client = new HttpClient();

            // Define commands and bind their actions
            RefreshCommand = new RelayCommand(async _ => await LoadUsers());
            DeleteCommand = new RelayCommand(async param => await DeleteUser((User)param));
        }

        // Fetch all users from the backend API
        private async Task LoadUsers()
        {
            try
            {
                var response = await client.GetAsync("http://localhost:5000/api/users");
                if (response.IsSuccessStatusCode)
                {
                    var userList = await response.Content.ReadAsAsync<User[]>();
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Users.Clear(); // Clear old users
                        foreach (var user in userList)
                            Users.Add(user);
                    });
                }
                else
                {
                    MessageBox.Show("Failed to load users.");
                }
            }
            catch
            {
                MessageBox.Show("Error: Unable to load users.");
            }
        }

        // Delete a user from the backend API
        private async Task DeleteUser(User user)
        {
            try
            {
                var response = await client.DeleteAsync($"http://localhost:5000/api/users/{user.Id}");
                if (response.IsSuccessStatusCode)
                {
                    Users.Remove(user); // Remove user from collection
                    MessageBox.Show("User deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
            catch
            {
                MessageBox.Show("Error: Unable to delete user.");
            }
        }
    }
}
