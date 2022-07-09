using Pizza.User_Windows.Pages;
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

namespace Pizza.Login_Or_Regist.Windows
{
    /// <summary>
    /// Interaction logic for WorkZone.xaml
    /// </summary>
    public partial class WorkZone : Window
    {
        public WorkZone()
        {
            InitializeComponent();
        }

        public enum WorkPages
        {
            Profile,
            Menu,
            Setting
        }
        public void EditWorkPage(WorkPages page)
        {
            if (page == WorkPages.Profile)
            {
                frame_WorkZone.Navigate(new Profile(this));
            }
            //else if (pages == Pages.Registration)
            //{
            //    frame_LogReg.Navigate(new Registration(this));
            //}
            //else if (pages == Pages.СonfirmRegistration)
            //{
            //    frame_LogReg.Navigate(new СonfirmRegistration(this));
            //}
        }

    }
}
