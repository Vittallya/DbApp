using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    [Table("Способ оплаты")]
    public class PaymentType : BindableBase, ICloneable, ICopyable
    {
        [Column("id способа оплаты")]
        public int Id { get; set; }
        [Column("способ оплаты")]
        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void CopyFrom(object source)
        {
            if(source is PaymentType paymentType)
            {
                Id = paymentType.Id;
                Name = paymentType.Name;
            }
        }
    }
}
