namespace Schad.Models
{
    public class CustomerTypeViewMolde
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CustomerViewModel> Customers { get; set; }
    }
}
