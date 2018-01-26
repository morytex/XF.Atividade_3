
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlunoView : ContentPage
	{
		public AlunoView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.AlunoVM.Carregar();
        }
    }
}