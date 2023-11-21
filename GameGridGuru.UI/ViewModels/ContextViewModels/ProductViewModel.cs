using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GameGridGuru.Domain.Models;
using GameGridGuru.Services.Abstractions.Services;
using GameGridGuru.UI.Abstractions.Services;
using GameGridGuru.UI.Abstractions.ViewModels;
using GameGridGuru.UI.ViewModels.HandlersViewModel;
using GameGridGuru.UI.Views.Dialogs;

namespace GameGridGuru.UI.ViewModels.ContextViewModels;

public partial class ProductViewModel : BaseViewModel, IContextViewModel
{
    private ObservableCollection<Product> _products;
    private Product _selectedProduct;
    private bool _isProductSelected;
    
    public ProductViewModel(IPopupService popupService, IProductService productService) : base(popupService)
    {
        ProductService = productService;
        
        _ = LoadProductsAsync();
    }
    
    private IProductService ProductService  { get; }
    
    public string Title => "Produtos";

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
            IsProductSelected = value != null;
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }
    
    public bool IsProductSelected
    {
        get => _isProductSelected;
        set
        {
            _isProductSelected = value;
            OnPropertyChanged(nameof(IsProductSelected));
        }
    }

    private async Task LoadProductsAsync()
    {
        Products = new ObservableCollection<Product>(await ProductService.GetAllAsync());
    }
    
    [RelayCommand]
    private async Task AddProduct()
    {
        var context = new HandlerProductViewModel();
        var view = new HandlerProductView { BindingContext = context };
        var result = await PopupService!.ShowPopupAsync(view);

        if (result is null or false)
            return;
            
        var product = context.GetProduct();
        
        if (await ProductService.AddEntityAsync(product))
            Products.Add(product);
    }
    
    [RelayCommand]
    private async Task EditProduct()
    {
        if (SelectedProduct == null) 
            return;
        
        var context = new HandlerProductViewModel(SelectedProduct);
        var view = new HandlerProductView { BindingContext = context };
        var result = await PopupService!.ShowPopupAsync(view);
        
        if (result is null or false)
            return;
            
        var product = context.GetProduct();
        if (await ProductService.EditEntityAsync(product))
            await LoadProductsAsync();
    }
    
    [RelayCommand]
    private async Task DeleteProduct()
    {
        if (SelectedProduct == null || !await PopupService!.ShowConfirmationDialog("Atenção", "Você irá remover permanentemente este produto, tem certeza de que deseja continuar?")) 
            return;

        if (await ProductService.DeleteEntityAsync(SelectedProduct))
            await LoadProductsAsync();
    }
}