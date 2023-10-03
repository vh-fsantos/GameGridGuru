using GameGridGuru.UI.ViewModels;
using Microsoft.Maui.Controls;

namespace GameGridGuru.UI;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        BindingContext = mainViewModel;
    }
}