namespace CPMS.GUI.Models
{
    public class BillingInfoModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public AddressModel Address { get; set; }
        public string ICO { get; set; }
        public string DIC { get; set; }
        public string IBAN { get; set; }
    }
}
