using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Сотрудники")]
public class Employee : BindableBase, ICloneable, ICopyable
{
    [Column("id сотрудника")]
    public int Id { get; set; }
    [Column("id должности")]
    public int PositionId { get; set; }
    [Column("id заведения")]
    public int VenueId { get; set; }
    [Column("ФИО")]
    public string FIO { get; set; }
    [Column("Контактные данные")]
    public string ContactData { get; set; }
    [Column("Дата рождения")]
    public DateTime DateBirth { get; set; }

    public Position Position { get; set; }
    public Venue Venue { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if(source is Employee employee)
        {
            Id = employee.Id;
            PositionId = employee.PositionId;
            VenueId = employee.VenueId;
            ContactData = employee.ContactData;
            DateBirth = employee.DateBirth;
            FIO = employee.FIO;
        }
    }
}
