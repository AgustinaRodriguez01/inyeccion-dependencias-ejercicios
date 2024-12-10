using System.ComponentModel.DataAnnotations;

namespace inyeccion_dependencias_ejercicios.Model
{
    public class OrderDetails
    {
        [Key]

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public decimal Discount { get; set; }
    }
}
