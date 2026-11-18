namespace MyMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Hello!", "Your C# app works!", "OK");
    }
}
