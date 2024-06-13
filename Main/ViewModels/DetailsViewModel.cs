using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows;
using System.Windows.Input;

namespace Main.ViewModels;

internal class DetailsViewModel : BindableBase, IDialogAware
{
    public string Title { get; private set; }

    public event Action<IDialogResult> RequestClose;

    public ICommand AcceptCommand => new DelegateCommand(OnAccept);

    private void OnAccept()
    {
        RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
    }

    public object Item { get; set; }
    public object Content { get; set; }
    public bool CanCloseDialog() => true;

    public void OnDialogClosed()
    {
    }

    public dynamic Lists { get; set; }

    public void OnDialogOpened(IDialogParameters parameters)
    {

        var resource = new ResourceDictionary
        {
            Source = new Uri("/Main;component/Resources/Views.xaml",
                     UriKind.RelativeOrAbsolute)
        };
        var viewName = parameters.GetValue<string>("viewName");
        Lists = parameters.GetValue<object>("lists");
        Item = parameters.GetValue<object>("item");
        Content = resource[viewName];
        Title = parameters.GetValue<string>("name");
    }
}
