using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.Model;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public RegionController(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }


        //get: api/<RegionController>
        [HttpGet]
        public IActionResult Get()
        {
            //var regions = _repositoryManager.RegionRepository.FindAllRegion().ToList();
            //return Ok(regions);

            //try
            // {
            //     var regions = _repositoryManager.RegionRepository.FindAllRegion().ToList();

            //     throw new Exception("error");

            //     return Ok(regions);
            // }
            //catch (Exception)
            // {
            //     _logger.LogError($"Error : {nameof(Get)}");
            //     return StatusCode(500, "Internal server error.");
            //     //throw;
            // }

            /////MEnggunakan Global Handler
            var regions = _repositoryManager.RegionRepository.FindAllRegion().ToList();
            //throw new Exception("error");

            //use dto
            var regionDto = regions.Select(r => new RegionDto
            {
                RegionId = r.RegionId,
                RegionDescription = r.RegionDescription
            });
            return Ok(regionDto);


        }

        //get: api/<RegionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api//<RegionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public void Put (int id, [FromBody] string value)
        {
        }

        //DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {
        }


        //// GET: RegionController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: RegionController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: RegionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RegionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RegionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RegionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RegionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RegionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
