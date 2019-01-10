namespace CPMS.GUI.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BillingInfoModel BillingInfo { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
