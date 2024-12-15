using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AdminApp.Models;
using AdminApp.Services;

namespace AdminApp.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public RelayCommand RefreshCommand { get; }
        public RelayCommand<User> DeleteCommand { get; }

        public UserListViewModel()
        {
            _apiService = new ApiService();

            RefreshCommand = new RelayCommand(async () => await LoadUsersAsync());
            DeleteCommand = new RelayCommand<User>(async user => await DeleteUserAsync(user));

            _ = LoadUsersAsync(); // Hent brugere ved opstart
        }

        private async Task LoadUsersAsync()
        {
            Users.Clear();
            var users = await _apiService.GetUsersAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        private async Task DeleteUserAsync(User user)
        {
            if (user == null) return;

            await _apiService.DeleteUserAsync(user.Id);
            await LoadUsersAsync();
        }
    }
}
