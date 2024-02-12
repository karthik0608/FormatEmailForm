namespace EmailFormFormatProject.Server.Database.Model
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string SKU { get; set; }

        public decimal Quantity { get; set; }

        public string ProductColor { get; set; }

        public string ImprintLocation { get; set; }

        public string ImprintColor { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }
    }
}
