using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    [Table("Типы товаров")]
    public class ProductType : BindableBase, ICloneable, ICopyable
    {
        [Column("id типа товара")]
        public int Id { get; set; }
        [Column("Тип товара")]
        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void CopyFrom(object source)
        {
            if(source is ProductType productType)
            {
                Id = productType.Id;
                Name = productType.Name;
            }
        }
    }
}
