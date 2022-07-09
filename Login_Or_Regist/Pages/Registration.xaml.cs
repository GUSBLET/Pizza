
namespace Pizza.Login_Or_Regist.Pages
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private MainWindow _mainWindow;
        public Registration(MainWindow mainWindow)
        {
            InitializeComponent();
            this._mainWindow = mainWindow;
        }

        private void GoTo_SingUp(object sender, RoutedEventArgs e)
        {
            _mainWindow.EditPage(MainWindow.Pages.Login);
        }

        private void singUp_Click(object sender, RoutedEventArgs e)
        {
            if (Email.Text.Length > 0) // Check login
            {
                if (Password.Password.Length > 0) // Check password
	            {
                    if (Repeat_Password.Password.Length > 0) // Check second password
		            {
                        string[] dataLogin = Email.Text.Split('@'); 
                        if (dataLogin.Length == 2)
                        {
                            string[] data2Login = dataLogin[1].Split('.'); 
                            if (data2Login.Length == 2)
                            {
                                if (Password.Password.Length > 8)
                                {
                                    bool en = true;
                                    bool symbol = false;
                                    bool number = false;
                                    for (int i = 0; i < Password.Password.Length; i++)
                                    {
                                        if (Password.Password[i] >= 'А' && Password.Password[i] <= 'Я') en = false;
                                        if (Password.Password[i] >= '0' && Password.Password[i] <= '9') number = true;
                                        if (Password.Password[i] == '_' || Password.Password[i] == '-' || Password.Password[i] == '!') symbol = true;
                                    }
                                    if (!en)
                                        MessageBox.Show("Only english keyboard");
                                    else if (!symbol)
                                        MessageBox.Show("Add char: _ - !");
                                    else if (!number)
                                        MessageBox.Show("And numbers");
                                    if(en && number && symbol)
                                    {
                                        if (Password.Password == Repeat_Password.Password) 
                                        {
                                            using var dbContext = new ApplicationDbContext();
                                            var userQueryable = dbContext
                                                .Users
                                                .Where(x => x.Login == Email.Text);

                                            var Result = userQueryable.ToList();

                                            if (Result.Count == 0)
                                            {
                                                WorkWithMail workWithMail = new WorkWithMail(Email.Text, Password.Password, new Random().Next(10000, 99999));
                                                workWithMail.SendMail();

                                                _mainWindow.EditPage(MainWindow.Pages.СonfirmRegistration);
                                            } else MessageBox.Show("User already exists");
                                        }
                                        else MessageBox.Show("Passwords do not match");
                                    }
                                }else MessageBox.Show("Password must be more than 8 characters");
                            }
                            else MessageBox.Show("Enter login in form х@x.x");
                        }
                        else MessageBox.Show("Enter login in form х@x.x");
                    }
                    else MessageBox.Show("Reapet password");
                }else MessageBox.Show("Enter your password");
            }else MessageBox.Show("Enter your login");
        }
    }
}
