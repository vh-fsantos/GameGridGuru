using System.Globalization;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerProductViewModel : BaseViewModel, IHandlerViewModel
{
    private readonly CultureInfo _cultureInfo;
    private string _productName;
    private string _productValue;
    private int _productId;

    public HandlerProductViewModel()
    {
        _cultureInfo = new CultureInfo("pt-BR");
    }
    
    public HandlerProductViewModel(Product product) : this()
    {
        ProductId = product.Id;
        ProductName = product.Name;
        ProductValue = product.Value.ToString(_cultureInfo);
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

    public string ProductValue
    {
        get => _productValue;
        set
        {
            _productValue = value;
            OnPropertyChanged(nameof(ProductValue));
        }
    }

    public Product GetProduct()
    {
        try
        {
            if (!float.TryParse(ProductValue, _cultureInfo, out var value) || ProductValue.Contains('.'))
                return null;
            
            return new Product
            {
                Id = ProductId,
                Name = ProductName,
                Value = value
            };
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception trying to retrieve a product - {exception.Message}");
            return null;
        }
    }
        
}