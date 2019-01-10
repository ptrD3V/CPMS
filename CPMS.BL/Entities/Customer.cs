namespace CPMS.BL.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BillingInfo BillingInfo { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
