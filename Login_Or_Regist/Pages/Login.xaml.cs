
namespace Pizza.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private MainWindow _mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void singIn_Click(object sender, RoutedEventArgs e)
        {
            if (Email.Text.Length > 0)
            {
                if (Password.Password.Length > 0)
                {
                    using var dbContext = new ApplicationDbContext();

                    var userQueryable = dbContext
                        .Users
                        .Where(x => x.Login == Email.Text)
                        .Where(x => x.Password == Password.Password);

                    var Result = userQueryable.ToList();
                    if (Result.Count == 1)
                    {
                        MessageBox.Show("User is authorized");
                    } else MessageBox.Show("Error");

                }
                else MessageBox.Show("Enter password");
            }
            else MessageBox.Show("Enter login");
        }

        private void GoTo_SingUp(object sender, RoutedEventArgs e)
        {
            _mainWindow.EditPage(MainWindow.Pages.Registration);
        }
    }
}
