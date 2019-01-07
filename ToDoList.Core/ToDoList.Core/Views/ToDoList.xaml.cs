using System;
using ToDoList.Entities;
using ToDoList.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        public ToDoList()
        {
            InitializeComponent();
            TodoListLoad(); 
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await RepositoryFactory.GetToDoRepository().GetAsync();
        }

        private async void TodoListLoad()
        {
            listView.ItemsSource = await RepositoryFactory.GetToDoRepository().GetAsync();

        }
        private async void OnItemAdded(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ToDoHome()
            {
                BindingContext = new ToDoItem()
            });
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var toDoItem = e.SelectedItem as ToDoItem;
                await Navigation.PushAsync(new ToDoHome(true)
                {
                    BindingContext = toDoItem
                });
            }
        }
    }
}