using multisearch_backend.DTO;
using multisearch_backend.Entities;
using Newtonsoft.Json;

namespace multisearch_backend.Services
{
    public static class DataAcessService
    {
        public static MultiSearchDTO? GetAll(string search)
        {
            #region ReadingJson
            var EquipmentsJson = File.ReadAllText(@"Data\equipments.json");
            var MaterialsJson = File.ReadAllText(@"Data\materials.json");
            var PurchaseOrders = File.ReadAllText(@"Data\purchase_orders.json");
            var SalesOrders = File.ReadAllText(@"Data\sales_orders.json");
            var WorkForce = File.ReadAllText(@"Data\workforce.json");
            #endregion

            #region DeserializeObjects
            List<Equipments> equipments = JsonConvert.DeserializeObject<List<Equipments>>(EquipmentsJson);
            List<Materials> materials = JsonConvert.DeserializeObject<List<Materials>>(MaterialsJson);
            List<PurchaseOrders> purchaseOrders = JsonConvert.DeserializeObject<List<PurchaseOrders>>(PurchaseOrders);
            List<SalesOrder> salesOrders = JsonConvert.DeserializeObject<List<SalesOrder>>(SalesOrders);
            List<Workforce> workforce = JsonConvert.DeserializeObject<List<Workforce>>(WorkForce);
            #endregion

            #region Filters
            equipments = equipments.SearchFilter(search);
            materials = materials.SearchFilter(search);
            purchaseOrders = purchaseOrders.SearchFilter(search);
            salesOrders = salesOrders.SearchFilter(search);
            workforce = workforce.SearchFilter(search);
            #endregion

            return new MultiSearchDTO(equipments, materials, purchaseOrders, salesOrders, workforce);
        }

        public static List<T> SearchFilter<T>(this List<T> source, string search)
        {
            if (string.IsNullOrEmpty(search))
                return source;

            var stringProperties = typeof(T)
            .GetProperties()
            .Where(prop => prop.PropertyType == typeof(string));

            return source.Where(x =>
                stringProperties.Any(prop =>
                    prop.GetValue(x).ToString().Contains(search, StringComparison.OrdinalIgnoreCase)
                )
            ).ToList();
        }
    }
}
