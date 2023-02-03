namespace Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDeteil> InvoiceDeteils { get; set; }
    }
}