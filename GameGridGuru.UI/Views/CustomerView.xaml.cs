using GameGridGuru.UI.ViewModels;

namespace GameGridGuru.UI.Views;

public partial class CustomerView : ContentView
{
    public CustomerView()
    {
        InitializeComponent();
    }

    private void ClickGestureRecognizer_OnClicked(object sender, EventArgs e)
    {
        var context = (CustomerViewModel) BindingContext;
        context.EditCustomerCommand.Execute(null);
    }

    private void TapGestureRecognizer_OnTapped(object sender, TappedEventArgs e)
    {
        var context = (CustomerViewModel) BindingContext;
        context.EditCustomerCommand.Execute(null);
    }
}