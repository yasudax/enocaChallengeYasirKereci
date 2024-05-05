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
    public class ProductManager : IProductManager
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductManager(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Result AddProduct(Product request)
        {
            var response = new Result();
            _genericRepository.Insert(request);
            return response;
        }

        public Result DeleteProduct(Product request)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProduct()
        {
            var response = new List<Product>();
            var result = _genericRepository.GetList();
            return result;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Result UpdateProduct(Product request)
        {
            throw new NotImplementedException();
        }
    }
}
