using Pizza.Login_Or_Regist.Windows;

namespace Pizza.User_Windows.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private WorkZone _workZone;
        public Profile(WorkZone workZone)
        {
            InitializeComponent();
            _workZone = workZone;
        }
    }
}
