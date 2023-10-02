using GameGridGuru.UI.ViewModels;
using Microsoft.Maui.Controls;

namespace GameGridGuru.UI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel(this);
    }
}