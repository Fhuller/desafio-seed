namespace multisearch_backend.Entities
{
    public class SalesOrder
    {
        public int? SalesOrderID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Customer {  get; set; }
        public string? MaterialID { get; set; }
        public string? MaterialName { get; set; }
        public int? Quantity { get; set; }
        public int? TotalValue { get; set; }
    }
}
