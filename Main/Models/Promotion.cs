using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Акции")]
public class Promotion : BindableBase, ICloneable, ICopyable
{
    [Column("id акции")]
    public int Id { get; set; }
    [Column("Название")]
    public string Name { get; set; }
    [Column("Описание")]
    public string Description { get; set; }
    [Column("Дата начала")]
    public DateTime DateBegin { get; set; }
    [Column("Дата окончания")]
    public DateTime DateEnd { get; set; }
    [Column("Скидка")]
    public string Value { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if(source is Promotion promotion)
        {
            this.Id = promotion.Id;
            this.Name = promotion.Name;
            this.Description = promotion.Description;
            this.DateBegin = promotion.DateBegin;
            this.DateEnd = promotion.DateEnd;
            this.Value = promotion.Value;
        }
    }
}
