using Microsoft.AspNetCore.Mvc;
using W23G72.Models;

namespace W23G72.ViewModels
{
    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}
