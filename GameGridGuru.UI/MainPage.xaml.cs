using GameGridGuru.UI.ViewModels;

namespace GameGridGuru.UI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel(this);
    }
}