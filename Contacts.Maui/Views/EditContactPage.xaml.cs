namespace Contacts.Maui.Views;

public partial class EditContactPage : ContentPage
{
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void BtnCancel_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}