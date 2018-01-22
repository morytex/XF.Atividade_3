
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
        public NovoAlunoView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtNome.Text = txtRM.Text = txtEmail.Text = string.Empty;
        }
    }
}