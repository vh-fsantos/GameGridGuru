using Microsoft.Maui.Controls;

namespace GameGridGuru.UI;

public partial class App : Application
{
    public App(MainPage mainPage)
    {
        InitializeComponent();
        MainPage = mainPage;
    }
}