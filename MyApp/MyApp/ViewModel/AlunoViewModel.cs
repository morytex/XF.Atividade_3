using MyApp.Model;
using MyApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        #region Propriedades
        private Aluno selecionado;
        public Aluno Selecionado
        {
            get { return selecionado; }
            set
            {
                selecionado = value as Aluno;
                EventPropertyChanged();
            }
        }
        public List<Aluno> CopiaListaAlunos;
        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();

        // UI Events
        public OnAdicionarAlunoCMD OnAdicionarAlunoCMD { get; }
        public ICommand OnNovoCMD { get; private set; }
        #endregion

        public AlunoViewModel()
        {
            AlunoRepository instance = AlunoRepository.Instance;
            OnAdicionarAlunoCMD = new OnAdicionarAlunoCMD(this);
            OnNovoCMD = new Command(OnNovo);

            CopiaListaAlunos = new List<Aluno>();
            CopiaListaAlunos = AlunoRepository.GetAlunos().ToList();
            CopiaListaAlunos.ForEach(ca => Alunos.Add(ca));
        }

        public void Adicionar(Aluno paramAluno)
        {
            if ((paramAluno == null) || (string.IsNullOrWhiteSpace(paramAluno.Nome)))
                App.Current.MainPage.DisplayAlert("Atenção", "O campo nome é obrigatório", "OK");
            else if (AlunoRepository.SalvarAluno(paramAluno) > 0)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
        }

        private async void OnNovo()
        {
            App.AlunoVM.Selecionado = new Model.Aluno();
            await App.Current.MainPage.Navigation
                .PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnAdicionarAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnAdicionarAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            alunoVM.Adicionar(parameter as Aluno);
        }
    }
}
