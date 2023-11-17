using System.Collections.ObjectModel;
using System.Windows.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Infraestructure.Abstractions.Repositories;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels;

public class ProductViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Product> _products;
    private Product _selectedProduct;
    
    public ProductViewModel(IPopupService popupService, IProductRepository customerRepository)
    {
        AddProductCommand = new Command(AddProduct);
        ProductRepository = customerRepository;
        PopupService = popupService;
        
        _ = LoadProductsAsync();
    }
    
    private IProductRepository ProductRepository  { get; }
    private IPopupService PopupService { get; }
    public string Title => "Produtos";
    public ICommand AddProductCommand { get; set; }

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
            _ = EditProduct();
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }

    private async Task LoadProductsAsync()
    {
        Products = new ObservableCollection<Product>(await ProductRepository.GetProductsAsync());
    }
    
    private async void AddProduct()
    {
        var context = new HandlerProductViewModel();
        var view = new HandlerProductView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not Product productInputModel) 
            return;

        var product = new Product();
        if (await ProductRepository.AddProductAsync(product))
            Products.Add(product);
    }
    
    private async Task EditProduct()
    {
        if (SelectedProduct == null) 
            return;
        
        var context = new HandlerProductViewModel(SelectedProduct);
        var view = new HandlerProductView { BindingContext = context };
        var customerInfo = await PopupService.ShowPopupAsync(view);

        if (customerInfo is not Product customerInputModel) 
            return;
        
        if (await ProductRepository.EditProductAsync(SelectedProduct))
        {
            await LoadProductsAsync();
        }
    }
}