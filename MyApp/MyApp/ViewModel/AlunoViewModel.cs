using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyApp.Model;
using MyApp.View;

namespace MyApp.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        #region Propriedades
        public Aluno AlunoModel { get; set; }
        public ObservableCollection<Aluno> Alunos { get; set; }

        // UI Events
        public OnAdicionarAlunoCMD OnAdicionarAlunoCMD { get; }
        public ICommand OnNovoCMD { get; private set; }
        #endregion

        public AlunoViewModel()
        {
            AlunoModel = new Aluno();
            Alunos = new ObservableCollection<Aluno>();
            OnAdicionarAlunoCMD = new OnAdicionarAlunoCMD(this);
            OnNovoCMD = new Command(OnNovo);
        }

        public void Adicionar(Aluno paramAluno)
        {
            try
            {
                if (paramAluno == null)
                    throw new Exception("Usuário inválido");

                paramAluno.Id = Guid.NewGuid();
                Alunos.Add(paramAluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
            }
        }

        private async void OnNovo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        private void OnAlunoTapped(object sender, ItemTappedEventArgs args)
        {
            var selecionado = args.Item as Aluno;
            System.Console.WriteLine("Aluno selecionado", "Aluno: " + selecionado.Id, "OK");
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
