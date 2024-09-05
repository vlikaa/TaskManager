using TaskManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel(ViewModelFactory factory) : BaseViewModel
{
	
	[ObservableProperty] private double _buttonWidth = 50; 
	[ObservableProperty] private BaseViewModel _viewModel = factory.Create(typeof(DetailsViewModel));
}