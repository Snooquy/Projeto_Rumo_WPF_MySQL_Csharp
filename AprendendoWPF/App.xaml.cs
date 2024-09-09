using System.Configuration;
using System.Data;
using System.Windows;
using AprendendoWPF.View;

namespace AprendendoWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var LoginView = new LoginView();
            LoginView.Show();
            LoginView.IsVisibleChanged += (s, ev) =>
            {
                if (LoginView.IsVisible == false && LoginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    LoginView.Close();
                }
            };
        }
    }

}
