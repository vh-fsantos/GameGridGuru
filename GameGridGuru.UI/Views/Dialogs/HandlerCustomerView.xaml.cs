using System;
using CommunityToolkit.Maui.Views;
using GameGridGuru.Domain.InputModel;
using GameGridGuru.UI.ViewModels.HandlersViewModel;

namespace GameGridGuru.UI.Views.Dialogs;

public partial class HandlerCustomerView : Popup
{
    public HandlerCustomerView()
    {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        var context = (HandlerCustomerViewModel) BindingContext;
        CloseAsync(new CustomerInputModel { Id = context.CustomerId, Name = context.CustomerName, PhoneNumber = context.CustomerPhoneNumber });
    }
}