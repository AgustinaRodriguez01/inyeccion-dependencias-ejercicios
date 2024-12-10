using System.ComponentModel.DataAnnotations;

namespace inyeccion_dependencias_ejercicios.Model
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
