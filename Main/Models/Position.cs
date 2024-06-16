using Main.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models;

[Table("Должности")]
public class Position : ICloneable, ICopyable
{
    [Column("id должности")]
    public int Id { get; set; }
    [Column("Должность")]
    public string Name { get; set; }
    [Column("Ставка")]
    public int Salary { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public void CopyFrom(object source)
    {
        if(source is  Position position) 
        { 
            Id = position.Id; Name = position.Name; Salary = position.Salary;
        }
    }
}
