using W23G72.Models;

namespace W23G72.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader{ get; set; }
    }
}
