namespace Maui.DesignTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		this.subFrame.IsVisible = false;
		this.subFrame2.IsVisible = false;

		InAnimation();
	}

	private async void InAnimation()
	{
		await Task.WhenAll
		(
			this.mainFrame.ScaleTo(10, 0),
			this.mainFrame.FadeTo(0, 0)
		);

		await Task.WhenAll
		(
			this.mainFrame.ScaleTo(1, 1000, Easing.SinIn),
			this.mainFrame.FadeTo(0.7, 1000, Easing.SinOut)
		);

		this.subFrame.IsVisible = true;
		this.subFrame2.IsVisible = true;

		await Task.WhenAll
		(
			this.subFrame.FadeTo(0.7, 300, Easing.SinIn),
			this.subFrame2.FadeTo(0.7, 300, Easing.SinIn)
		);
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		await Task.WhenAll
		(
			this.subFrame.FadeTo(0, 300, Easing.SinOut),
			this.subFrame2.FadeTo(0, 300, Easing.SinOut)
		);

		await Task.WhenAll
		(
			this.mainFrame.FadeTo(0, 1000, Easing.SinIn),
			this.mainFrame.ScaleTo(10, 1000, Easing.SinOut)
		);

		await Navigation.PushAsync(new MainPage());
	}
}

