using multisearch_backend.Entities;

namespace multisearch_backend.DTO
{
    public class MultiSearchDTO
    {
        public MultiSearchDTO(List<Equipments>? equipments, List<Materials>? materials, List<PurchaseOrders>? purchaseOrders, List<SalesOrder>? salesOrders, List<Workforce>? workforce)
        {
            Equipments = equipments;
            Materials = materials;
            PurchaseOrders = purchaseOrders;
            SalesOrders = salesOrders;
            Workforce = workforce;
        }

        public List<Equipments>? Equipments { get; set; }
        public List<Materials>? Materials { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<SalesOrder>? SalesOrders { get; set; }
        public List<Workforce>? Workforce { get; set; }
    }
}
