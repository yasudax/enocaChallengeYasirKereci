using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Swashbuckle.AspNetCore.Annotations;
using EntityLayer;
using BusinessLayer.Managers;
using BusinessLayer.Managers.Interfaces;


namespace enocaDotNetChallengev2.Controllers
{
    [ApiController]
    [Route("api/company")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyManager _companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            _companyManager = companyManager;
        }


        //Firma Ekleme
        [HttpPost]
        [Route("add-company")]
        [SwaggerOperation(Summary = "Firma Ekleme", Description = "Firma, tüm bilgileriyle birlikte eklenecektir.")]
        public IActionResult AddCompany(Company request)
        {
            var result = _companyManager.AddCompany(request);
            return Ok(result);
        }


        //Firma Listeleme
        [HttpGet("list-companies")]
        [SwaggerOperation(Summary = "Firma Listeleme", Description = "Tüm firmalar, her bir kolonuyla birlikte listelenecektir.")]
        public IActionResult GetAllCompany()
        {
            var companies = _companyManager.GetAllCompany();
            return Ok(companies);
        }


        //Sipariş Zaman Aralığı Güncelleme
        [HttpPut("update-order-time/{id}")]
        [SwaggerOperation(Summary = "Firma Sipariş İzin Saati Güncelleme", Description = "Sipariş izin saati güncelleme")]
        [SwaggerResponse(200, "Başarılı")]
        [SwaggerResponse(400, "Geçersiz istek")]
        [SwaggerResponse(404, "Firma bulunamadı")]
        public IActionResult UpdateOrderTime(int id, [FromBody] Company updateModel)
        {
            var company = _companyManager.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }

            //İzin Saati Güncelleme İşlemi 
            company.OrderPermissionStartTime = updateModel.OrderPermissionStartTime;
            company.OrderPermissionEndTime = updateModel.OrderPermissionEndTime;
            _companyManager.UpdateCompany(company);

            return Ok();
        }


        //Firma Onay Durumu Güncelleme
        [HttpPut("update-approval-status/{id}")]
        [SwaggerOperation(Summary = "Firma Güncelleme - Onay Durumu Güncelleme", Description = "Onay Durumu Güncelleme")]
        [SwaggerResponse(200, "Başarılı")]
        [SwaggerResponse(400, "Geçersiz istek")]
        [SwaggerResponse(404, "Firma bulunamadı")]
        public IActionResult UpdateApprovalStatus(int id, [FromBody] bool newApprovalStatus)
        {
            var company = _companyManager.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }

            // Onay Durumu Güncelleme işlemi
            company.ApprovalStatus = newApprovalStatus;
            _companyManager.UpdateCompany(company);

            return Ok();
        }
    }
}
