using BusinessLayer.Managers.Interfaces;
using BusinessLayer.Repositories.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IGenericRepository<Order> _genericRepository;

        public OrderManager(IGenericRepository<Order> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Result AddOrder(Order request)
        {
            var response = new Result();
            _genericRepository.Insert(request);
            return response;
        }

        public Result DeleteOrder(Order request)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            var response = new List<Company>();
            var result = _genericRepository.GetList();
            return result;
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdateOrder(Order request)
        {
            throw new NotImplementedException();
        }
    }
}
