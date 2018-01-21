using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.ViewModel;

namespace MyApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlunoView : ContentPage
	{
		public AlunoView ()
		{
			InitializeComponent ();
		}

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as MyApp.Model.Aluno;
            DisplayAlert("Aluno selecionado", "Aluno: " + selecionado.Id, "OK");
        }
    }
}