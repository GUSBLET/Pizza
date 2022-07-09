using Pizza.Login_Or_Regist.Pages;
using Pizza.Pages;


namespace Pizza.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using var dbContext = new ApplicationDbContext();
            dbContext.Database.EnsureCreated();
            EditPage(Pages.Login);
        }

        public enum Pages
        {
            Registration,
            СonfirmRegistration,
            Login
        }

        public void EditPage(Pages pages)
        {
            if (pages == Pages.Login)
            {
                frame_LogReg.Navigate(new Login(this));
            }
            else if (pages == Pages.Registration)
            {
                frame_LogReg.Navigate(new Registration(this));
            }
            else if (pages == Pages.СonfirmRegistration)
            {
                frame_LogReg.Navigate(new СonfirmRegistration(this));
            }
        }

        public void EditWindow()
        {
            
        }
    }
}
