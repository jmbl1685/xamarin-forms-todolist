using System;
using ToDoList.Entities;
using ToDoList.Repository;
using Xamarin.Forms;

namespace ToDoList.Core
{
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var toDoItem = new ToDoItem
            {
                Name = Name.Text,
                Notes = Notes.Text,
                Done = Done.IsToggled
            };
            await RepositoryFactory.GetToDoRepository().AddOrUpdateAsync(toDoItem);
        }

        private async void OnListClicked(object sender, EventArgs e)
        {
            var toDoList = await RepositoryFactory.GetToDoRepository().GetAsync();
        }
    }
}
