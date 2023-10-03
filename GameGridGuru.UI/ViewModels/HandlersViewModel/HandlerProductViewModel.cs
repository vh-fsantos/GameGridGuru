using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerProductViewModel : BaseViewModel, IHandlerViewModel
{
    private string _productName;
    private float _productValue;
    private int _productId;

    public HandlerProductViewModel() { }
    
    public HandlerProductViewModel(Product product)
    {
        ProductId = product.Id;
        ProductName = product.Name;
        ProductValue = product.Value;
    }

    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            OnPropertyChanged(nameof(ProductId));
        }
    }
    
    public string ProductName
    {
        get => _productName;
        set
        {
            _productName = value;
            OnPropertyChanged(nameof(ProductName));
        }
    }

    public float ProductValue
    {
        get => _productValue;
        set
        {
            _productValue = value;
            OnPropertyChanged(nameof(ProductValue));
        }
    }
}