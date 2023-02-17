using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        IEmailService _emailService;

        public ProductController(IProductRepository productRepository, IEmailService emailService)
        {
            _productRepository = productRepository;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<Product>? allProducts = await _productRepository.GetAsync();
            return Ok(allProducts);
        }

        [HttpGet("sendmail")]
        public IActionResult SendMail()
        {
            bool result = _emailService.Send(to: "muratsuzen@gmail.com", subject: "mail test subject", body: "mail test body");
            return Ok(result);
        }
    }
}
