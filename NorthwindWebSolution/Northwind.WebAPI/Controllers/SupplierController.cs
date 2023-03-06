using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.Model;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using System.Xml.Linq;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ILoggerManager _logger;
        private IRepositoryManager _repositoryManager;
        private readonly IServiceManager serviceManager;


        public SupplierController(IRepositoryManager repositoryManager,
            ILoggerManager logger, IServiceManager serviceManager)
        {
            _repositoryManager = repositoryManager;
            this._logger = logger;
            this.serviceManager = serviceManager;
        }


        [HttpPost]
        public IActionResult CreateSupplierProduct([FromBody] SupplierProductDto supplierProductDto)
        {
            if (supplierProductDto != null)
            {
                serviceManager.SupplierServices.CreateSupplierProduct(supplierProductDto, out var supplierId);

                return CreatedAtRoute("GetSupplierById", new { id = supplierId }, supplierProductDto);
            }
            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetSupplierById")]
        public IActionResult GetSupplierById(int id)
        {
            var supplierProduct = _repositoryManager.SupplierRepository.GetSupplierProduct(id);
            return Ok(supplierProduct);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
