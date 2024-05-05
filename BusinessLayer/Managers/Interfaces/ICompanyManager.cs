using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers.Interfaces
{
    public interface ICompanyManager
    {
        Result AddCompany(Company request);
        Result DeleteCompany(Company request);
        Result UpdateCompany(Company request);
        List<Company> GetAllCompany();
        Company GetCompanyById(int id);
    }
}
