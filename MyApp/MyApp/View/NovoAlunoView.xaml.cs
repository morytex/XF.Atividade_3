
using MyApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
        public static AlunoViewModel AlunoVM { get; set; }

        public NovoAlunoView()
        {
            InitializeComponent();
        }
    }
}