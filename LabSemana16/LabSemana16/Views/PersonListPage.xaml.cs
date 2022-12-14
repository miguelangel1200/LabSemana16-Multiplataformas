using LabSemana16.Model;
using System;
using Xamarin.Forms;

namespace LabSemana16.Views
{
    public partial class PersonListPage : ContentPage
    {
        
        public PersonListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.PersonManager.GetTasksAsync();
        }

        async void OnAddPersonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonPage(true)
            {
                BindingContext = new Person
                {
                    Id = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnPersonSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PersonPage
            {
                BindingContext = e.SelectedItem as Person
            });
        }
    }
}