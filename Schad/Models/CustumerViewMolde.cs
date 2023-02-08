namespace Schad.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int  CustomerType { get; set; }
        public virtual ICollection<InvoiceViewMolde> Invoices { get; set; }
    }
}