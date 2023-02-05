namespace Schad.Models
{
    public class InvoiceViewMolde
    {
        public int Id { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public virtual ICollection<InvoiceDeteilViewModel> InvoiceDeteils { get; set; }
    }
}