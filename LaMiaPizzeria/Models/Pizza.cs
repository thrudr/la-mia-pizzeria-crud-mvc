using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public string Imagine { get; set; }

        [Required]
        [Range(1,15000)]
        public double Price { get; set; }


        public Pizza() { }

        public Pizza(string name, string description, string imagine, double price)
        {
            this.Name = name;
            this.Description= description;
            this.Imagine= imagine;
            this.Price= price;
        }
    }
}
