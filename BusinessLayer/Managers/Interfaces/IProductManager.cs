using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.Interfaces
{
    public interface IProductManager
    {
        Result AddProduct(Product request);
        Result DeleteProduct(Product request);
        Result UpdateProduct(Product request);
        List<Product> GetAllProduct();
        Product GetProductById(int id);
    }
}
