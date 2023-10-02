using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels;

public class ProductViewModel : BaseViewModel, IContextViewModel
{
    private readonly MainViewModel _mainViewModel;
    
    public ProductViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    
    public string Title => "Produtos";
    
}