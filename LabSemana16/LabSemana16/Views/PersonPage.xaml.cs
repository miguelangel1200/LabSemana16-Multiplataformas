using LabSemana16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabSemana16.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        bool isNewPerson;
        public PersonPage(bool isNew = false)
        {
            InitializeComponent();
            this.isNewPerson = isNew;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var person = (Person)BindingContext;
            await App.PersonManager.SaveTaskAsync(person, isNewPerson);
            await Navigation.PopAsync();
            Console.WriteLine("Error al guardar");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var person = (Person)BindingContext;
            await App.PersonManager.DeleteTaskAsync(person);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}