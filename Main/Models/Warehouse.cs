using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Склад")]
public class Warehouse : BindableBase, ICloneable, ICopyable
{
    [Column("id поставки")]
    public int Id { get; set; }
    [Column("id поставщика")]
    public int SupplierId { get; set; }

    [Column("id заведения")]
    public int VenueId { get; set; }

    [Column("id товара")]
    public int ProductId { get; set; }
    [Column("количество")]
    public int Count { get; set; }
    [Column("дата поставки")]
    public DateTime Date { get; set; }

    public Venue Venue { get; set; }
    public Product Product { get; set; }
    public Supplier Supplier { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if(source is  Warehouse warehouse) 
        {
            Id = warehouse.Id;
            SupplierId = warehouse.SupplierId;
            VenueId = warehouse.VenueId;
            ProductId = warehouse.ProductId;
            Count = warehouse.Count;
            Date = warehouse.Date;
        }
    }
}
