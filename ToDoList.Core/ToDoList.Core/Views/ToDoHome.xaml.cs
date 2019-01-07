using System;
using ToDoList.Entities;
using ToDoList.Repository;
using Xamarin.Forms;

namespace ToDoList.Core.Views
{
    public partial class ToDoHome : ContentPage
    {

        public ToDoHome(bool IsVisibleDeleteButton = false)
        {
            InitializeComponent();
            DeleteButton.IsVisible = IsVisibleDeleteButton;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var toDoItem = (ToDoItem)BindingContext;
            await RepositoryFactory.GetToDoRepository().AddOrUpdateAsync(toDoItem);
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var toDoItem = (ToDoItem)BindingContext;
            var option = await DisplayAlert($"Delete - {toDoItem.Name}", "Are you sure you're going to delete the Task?", "Yes", "No");
            if (option)
            {
                await RepositoryFactory.GetToDoRepository().DeleteAsync(toDoItem);
                await Navigation.PopAsync();
            }

        }
    }
}
