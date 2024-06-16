using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Смены")]
public class Shift : BindableBase, ICloneable, ICopyable
{
    [Column("id смены")]
    public int Id { get; set; }
    [Column("id сотрудника")]
    public int EmployeeId { get; set; }
    [Column("начало смены")]
    public DateTime DateTimeBegin { get; set; }
    [Column("окончание смены")]
    public DateTime DateTimeEnd { get; set; }

    public Employee Employee { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if (source is Shift shift)
        {
            Id = shift.Id;
            EmployeeId = shift.EmployeeId;
            DateTimeBegin = shift.DateTimeBegin;
            DateTimeEnd = shift.DateTimeEnd;
        }
    }
}
