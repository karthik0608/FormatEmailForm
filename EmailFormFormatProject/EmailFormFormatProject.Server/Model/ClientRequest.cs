namespace EmailFormFormatProject.Server.Model
{
    public class ClientRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string SKU { get; set; }

        public decimal Quantity { get; set; }

        public string ProductColor { get; set; }

        public string ImprintLocation { get; set; }

        public string ImprintColor { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
