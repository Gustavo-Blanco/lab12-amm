using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.ViewModelCalculator();
        }
    }
}