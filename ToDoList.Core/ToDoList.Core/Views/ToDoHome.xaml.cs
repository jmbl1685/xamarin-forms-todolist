using System;
using ToDoList.Entities;
using ToDoList.Repository;
using Xamarin.Forms;

namespace ToDoList.Core.Views
{
    public partial class ToDoHome : ContentPage
    {

        public ToDoHome()
        {
            InitializeComponent();
        }


        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var toDoItem = (ToDoItem)BindingContext;
            await RepositoryFactory.GetToDoRepository().AddOrUpdateAsync(toDoItem);
            await Navigation.PopAsync();
        }

    }
}
