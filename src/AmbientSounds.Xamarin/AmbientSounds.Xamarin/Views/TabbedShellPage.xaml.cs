﻿using AmbientSounds.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmbientSounds.Xamarin.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TabbedShellPage : TabbedPage
{
    public TabbedShellPage()
    {
        InitializeComponent();
        BindingContext = App.Services.GetRequiredService<ShellPageViewModel>();
    }

    public ShellPageViewModel ViewModel => (ShellPageViewModel)BindingContext;

    private async void OnAppearing(object sender, System.EventArgs e)
    {
        base.OnAppearing();

        await ViewModel.InitializeAsync();
    }

    private void OnDisappearing(object sender, System.EventArgs e)
    {
        ViewModel.Dispose();
    }
}