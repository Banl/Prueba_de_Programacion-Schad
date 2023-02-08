namespace Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}