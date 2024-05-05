using BusinessLayer.Managers.Interfaces;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Globalization;
using System.Net;

namespace enocaDotNetChallengev2.Controllers
{
    [ApiController]
    [Route("api/order")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly ICompanyManager _companyManager;

        public OrderController(IOrderManager orderManager, ICompanyManager companyManager)
        {
            _orderManager = orderManager;
            _companyManager = companyManager;
        }

        [HttpPost]
        [Route("add-order")]
        [SwaggerOperation(Summary = "Sipariş Ekleme", Description = "Şartlara uyan siparişler alınacak, uymayanlar alınmayacaktır.")]
        [SwaggerResponse(200, "Başarılı")]
        [SwaggerResponse(400, "Geçersiz istek")]
        [SwaggerResponse(404, "Firma bulunamadı")]
        public IActionResult CreateOrder([FromBody] Order request)
        {
            var company = _companyManager.GetCompanyById(request.CompanyId);
            if (company == null)
            {
                return NotFound("Firma bulunamadı");
            }

            if (!company.ApprovalStatus)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Firma şu an sipariş alamıyor ya da kapalı.");
            }
            DateTime startDate = DateTime.ParseExact(company.OrderPermissionStartTime, "HH:mm",
                                        CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(company.OrderPermissionEndTime, "HH:mm",
                                        CultureInfo.InvariantCulture);

            if (DateTime.Now.TimeOfDay < startDate.TimeOfDay || DateTime.Now.TimeOfDay > endDate.TimeOfDay)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Firma izin saatleri dışında.");
            }

           var order = new Order
           {
               CompanyId = request.CompanyId,
               ProductId = request.ProductId,
               CustomerName = request.CustomerName,
               OrderDate = DateTime.Now
           };
            _orderManager.AddOrder(order);

            return Ok("Sipariş başarıyla oluşturuldu");
        }

        [HttpGet("list-order")]
        [SwaggerOperation(Summary = "Sipariş Listeleme", Description = "Bütün siparişler burada gözükecektir.")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderManager.GetAllOrders();
            return Ok(orders);
        }
    }
}
