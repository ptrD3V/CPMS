namespace CPMS.BL.Entities
{
    public class BillingInfo
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public Address Address { get; set; }
        public string ICO { get; set; }
        public string DIC { get; set; }
        public string IBAN { get; set; }
    }
}
