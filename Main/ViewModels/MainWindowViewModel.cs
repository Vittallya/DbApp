using Main.ContextDb;
using Main.Interfaces;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Main.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private string _title = "База данных";
    private readonly IDialogService dialogService;
    private readonly MainDbContext dbContext;
    private readonly ResourceDictionary tablesResourceDictionary;
    public string Title
    {
        get { return _title; }
        set { SetProperty(ref _title, value); }
    }

    public ICommand AddItemCommand { get; }
    public ICommand EditItemCommand => new DelegateCommand(OnEdit, () => SelectedItem != null);
    public ICommand DeleteItemCommand => new DelegateCommand(OnDelete, () => SelectedItem != null);

    public ITableHandler<object> SelectedTable { get; set; }
    public ObservableCollection<object> Items { get; set; }

    public object SelectedTableView { get; set; }
    public object SelectedItem { get; set; }
    public int SelectedItemIndex { get; set; }
    public IEnumerable<ITableHandler<object>> TableHandlers { get; set; }

    public MainWindowViewModel(
          IDialogService dialogService
        , MainDbContext dbContext
        , IEnumerable<ITableHandler<object>> tableHandlers
        , IContainerProvider containerProvider)
    {
        TableHandlers = tableHandlers;
        this.dialogService = dialogService;
        this.dbContext = dbContext;
        AddItemCommand = new DelegateCommand(OnAdd);
        tablesResourceDictionary = new ResourceDictionary
        {
            Source = new System.Uri("/Main;component/Resources/Tables.xaml", System.UriKind.RelativeOrAbsolute)
        };
    }


    private async void OnSelectedTableChanged(ITableHandler<object> tableHandler)
    {
        SelectedItem = null;
        await tableHandler.LoadData();
        Items = new ObservableCollection<object>(tableHandler.GetData());
        SelectedTableView = tablesResourceDictionary[tableHandler.ViewTableName];

        if(SelectedTableView is ListView listView)
        {
            listView.SetBinding(ListView.SelectedItemProperty, 
                new Binding { Path = new PropertyPath("SelectedItem"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            listView.SetBinding(ListView.ItemsSourceProperty,new Binding { Path = new PropertyPath("Items") });

            listView.SetBinding(ListView.SelectedIndexProperty,
                new Binding { Path = new PropertyPath("SelectedItemIndex"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
        }

    }

    private async void OnAdd()
    {
        if (SelectedTable != null) 
        {
            var item = SelectedTable.GetDefault();

            dialogService.ShowDialog("DetailsWindow", new DialogParameters
            {
                { "viewName", SelectedTable.ViewDetailsName },
                { "item", item },
                { "name", "Добавить" },
                { "lists", await SelectedTable.GetLists()}
            }, async dr =>
            {
                if (dr.Result == ButtonResult.OK)
                {
                    await dbContext.AddAsync(item);
                    await dbContext.SaveChangesAsync();
                    Items.Add(item);
                }
            });
        };
    }

    private async void OnDelete()
    {
        var message = "Удалить элемент?";

        if(MessageBox.Show(message, "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            dbContext.Remove(SelectedItem);
            await dbContext.SaveChangesAsync();
            Items.RemoveAt(SelectedItemIndex);
            SelectedItem = null;
        }
    }

    private async void OnEdit()
    {
        if (SelectedTable != null)
        {
            var index = SelectedItemIndex;
            var item = ((ICloneable)SelectedItem).Clone();

            dialogService.ShowDialog("DetailsWindow", new DialogParameters
            {
                { "viewName", SelectedTable.ViewDetailsName },
                { "name", "Редактировать" },
                { "item", item },
                { "lists", await SelectedTable.GetLists()}
            }, async dr =>
            {
                if (dr.Result == ButtonResult.OK)
                {
                    ((ICopyable)SelectedItem).CopyFrom(item);
                    await dbContext.SaveChangesAsync();
                    Items[index] = item;
                }
            });
        };
    }
    protected override void OnPropertyChanged(PropertyChangedEventArgs args)
    {
        base.OnPropertyChanged(args);

        if (args.PropertyName == nameof(SelectedTable))
        {
            OnSelectedTableChanged(SelectedTable);
        }
    }
}
