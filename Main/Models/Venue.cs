using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Заведения")]
public class Venue : BindableBase, ICloneable, ICopyable
{
    [Column("id заведения")]
    public int Id { get; set; }
    [Column("Адрес")]

    public string Address { get; set; }
    [Column("Контактная информация")]
    public string ContactInfo { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if(source is Venue venue)
        {
            this.Id = venue.Id;
            this.Address = venue.Address;
            this.ContactInfo = venue.ContactInfo;
        }
    }
}
