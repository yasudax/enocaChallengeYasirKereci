using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.Interfaces
{
    public interface IOrderManager
    {
        Result AddOrder(Order request);
        List<Order> GetAllOrders();

        Result DeleteOrder(Order request);
        Result UpdateOrder(Order request);
        Order GetOrderById(int id);
    }
}
