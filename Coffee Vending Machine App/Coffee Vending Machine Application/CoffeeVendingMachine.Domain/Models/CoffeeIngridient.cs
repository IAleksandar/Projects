

namespace CoffeeVendingMachine.Domain.Models
{
    public class CoffeeIngridient : BaseEntity
    {
        public int CoffeeId { get; set; }
        public int IngridientId { get; set; }
        public Coffee Coffee { get; set; }
        public Ingridients Ingridients { get; set; }
    }
}
