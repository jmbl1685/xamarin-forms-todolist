using System;
using System.IO;
using ToDoList.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDoList.Core
{
    public partial class App : Application
    {
        public App()
        {
            var connection = DBConnection.Connect();
            if (connection == null)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var sqliteFile = Path.Combine(path, "TodoSQLite.db3");
                DBConnection.Connect(sqliteFile);
            }
            MainPage = new NavigationPage(new Home());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
