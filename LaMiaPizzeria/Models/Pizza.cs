namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagine { get; set; }
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
