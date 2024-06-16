using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Продукция")]
public class Product : BindableBase, ICloneable, ICopyable
{
    [Column("id продукции")]
    public int Id { get; set; }

    [Column("название продукции")]
    public string Name { get; set; }
    [Column("id типа товара")]
    public int ProductTypeId { get; set; }
    [Column("цена")]
    public int Cost { get; set; }

    public ProductType ProductType { get; set; }
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if (source is Product product)
        {
            Id = product.Id;
            Name = product.Name;
            ProductTypeId = product.ProductTypeId;
            Cost = product.Cost;
        }
    }
}
