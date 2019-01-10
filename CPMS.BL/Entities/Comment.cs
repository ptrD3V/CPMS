namespace CPMS.BL.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int DeveloperID { get; set; }
        public int TaskID { get; set; }
    }
}
