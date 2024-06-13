using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main.Interfaces;

public interface ITableHandler<out T>
{
    string ViewDetailsName { get; }
    string ViewTableName { get; }
    Task<object> GetLists();
    string TableName { get; }
    Task LoadData();
    T GetDefault()
    {
        return Activator.CreateInstance<T>();
    }
    IReadOnlyCollection<T> GetData();    
}
