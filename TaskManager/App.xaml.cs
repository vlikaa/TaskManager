using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Services;
using TaskManager.ViewModels;
using TaskManager.Views;

namespace TaskManager;

public partial class App
{
	private readonly ServiceCollection _serviceCollection = [];
	private static ServiceProvider? _serviceProvider;
	
	public static ServiceProvider ServiceProvider => _serviceProvider!;

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);

		_serviceCollection.AddSingleton<MainView>();
		_serviceCollection.AddSingleton<MainViewModel>();
		_serviceCollection.AddSingleton<BaseViewModel, DetailsViewModel>();
		
		_serviceCollection.AddSingleton<ViewModelFactory>();

		_serviceProvider = _serviceCollection.BuildServiceProvider();

		var view = _serviceProvider.GetRequiredService<MainView>();

		view.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
		
		view.ShowDialog();
	}
}