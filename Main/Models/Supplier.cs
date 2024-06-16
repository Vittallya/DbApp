using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    [Table("Поставщики")]
    public class Supplier : BindableBase, ICloneable, ICopyable
    {
        [Column("id поставщика")]
        public int Id { get; set; }
        [Column("Название")]

        public string Name { get; set; }
        [Column("Адрес")]

        public string Address { get; set; }
        [Column("Контактное лицо")]
        public string ContactPerson { get; set; }
        [Column("Контактные данные")]
        public string ContactData { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void CopyFrom(object source)
        {
            if (source is  Supplier supplier) 
            {
                Id = supplier.Id;
                Name = supplier.Name;
                Address = supplier.Address;
                ContactPerson = supplier.ContactPerson;
                ContactData = supplier.ContactData;
            }
        }
    }
}
