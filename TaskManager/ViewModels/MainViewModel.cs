using CommunityToolkit.Mvvm.ComponentModel;
using TaskManager.Services;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel(ViewModelFactory factory) : BaseViewModel
{
	
	[ObservableProperty] private BaseViewModel _viewModel = factory.Create(typeof(DetailsViewModel));
}