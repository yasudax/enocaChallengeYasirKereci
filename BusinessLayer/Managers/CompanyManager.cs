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
    public class CompanyManager : ICompanyManager
    {
        private readonly IGenericRepository<Company> _genericRepository;
        public CompanyManager(IGenericRepository<Company> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Result AddCompany(Company request)
        {
            var response = new Result();
            _genericRepository.Insert(request);
            return response;
        }

        public Result DeleteCompany(Company request)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllCompany()
        {
            var response = new List<Company>();
            var result = _genericRepository.GetList();
            return result;            
        }

        public Company GetCompanyById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public Result UpdateCompany(Company request)
        {
            var response = new Result();
            _genericRepository.Update(request);
            return response;
        }
    }
}
