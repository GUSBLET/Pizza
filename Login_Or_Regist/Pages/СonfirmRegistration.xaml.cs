

using System.Text.RegularExpressions;

namespace Pizza.Login_Or_Regist.Pages
{
    /// <summary>
    /// Interaction logic for СonfirmRegistration.xaml
    /// </summary>
    public partial class СonfirmRegistration : Page
    {
        private MainWindow _mainWindow;
        public СonfirmRegistration(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Confirm_Regist(object sender, RoutedEventArgs e)
        {
            using var dbContext = new ApplicationDbContext();
            WorkWithMail workWithMail = new WorkWithMail();
            Regex regex = new Regex(@"\D");
            int Key = workWithMail.GetConfirmKey();
            int KeyBox = Convert.ToInt32(regex.Replace(KeyCode.Text, ""));
            if (Key == KeyBox)
            {
                var user = new TableUsers()
                {
                    Login = workWithMail.GetConfirmLogin(),
                    Password = workWithMail.GetConfirmPassword()
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                MessageBox.Show("User registered");
                _mainWindow.EditPage(MainWindow.Pages.Login);

            } else MessageBox.Show("Incorrect key");


        }
    }
}
