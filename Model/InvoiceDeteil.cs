namespace Model
{
    public class InvoiceDeteil
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}