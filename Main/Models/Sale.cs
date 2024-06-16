using Main.Interfaces;
using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    [Table("Продажи")]
    public class Sale : BindableBase, ICloneable, ICopyable
    {
        [Column("id продажи")]
        public int Id { get; set; }
        [Column("id продукции")]
        public int ProductId { get; set; }
        [Column("id заведения")]
        public int VenueId { get; set; }
        [Column("id сотрудника")]
        public int EmployeeId { get; set; }

        [Column("Сумма")]
        public int Cost { get; set; }

        [Column("Дата")]
        public DateTime DateTime { get; set; }

        [Column("id способа оплаты")]
        public int PaymentTypeId { get; set; }
        [Column("id акции")]
        public int PromotionId { get; set; }

        public Employee Employee { get; set; }
        public Venue Venue { get; set; }
        public PaymentType PaymentType { get; set; }
        public Product Product { get; set; }
        public Promotion Promotion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void CopyFrom(object source)
        {
            if(source is  Sale sale) 
            {
                Id = sale.Id;
                ProductId = sale.ProductId;
                VenueId = sale.VenueId;
                EmployeeId = sale.EmployeeId;
                PaymentTypeId = sale.PaymentTypeId;
                Cost = sale.Cost;
                DateTime = sale.DateTime;
                PromotionId = sale.PromotionId;
            }
        }
    }
}
