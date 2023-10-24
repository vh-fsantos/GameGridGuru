using GameGridGuru.UI.ViewModels;

namespace GameGridGuru.UI.Views;

public partial class CustomerView : ContentView
{
    public CustomerView()
    {
        InitializeComponent();

        // Configurar o contexto de dados (ViewModel) para a página
        this.BindingContext = new CustomerViewModel();
    }
}