using System.Collections.ObjectModel;
using GameGridGuru.Domain.Models;
using GameGridGuru.UI.Abstractions.ViewModels;

namespace GameGridGuru.UI.ViewModels.HandlersViewModel;

public class HandlerCardProductViewModel : BaseViewModel, IHandlerViewModel
{
    private ObservableCollection<Product> _products;
    private Product _selectedProduct;
    private int _productQuantity;
    private float _productValue;
    
    public HandlerCardProductViewModel(IEnumerable<Product> products)
    {
        Products = new ObservableCollection<Product>(products);
    }

    public ObservableCollection<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }

    public int ProductQuantity
    {
        get => _productQuantity;
        set
        {
            _productQuantity = value;
            OnPropertyChanged(nameof(ProductQuantity));
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

    public CardProduct GetProduct()
    {
        return new CardProduct
        {
            ProductId = SelectedProduct.Id,
            Quantity = ProductQuantity
        };
    }
}