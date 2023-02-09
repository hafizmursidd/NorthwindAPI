using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.Model;
using Northwind.Domain.Base;
using Northwind.Domain.Entities;
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
        [HttpGet] //
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
        [HttpGet("{id}", Name = "GetRegion")]
        public IActionResult FindRegionById(int id)
        {
            var region = _repositoryManager.RegionRepository.FindRegionById(id);

            if (region == null)
            {
                _logger.LogError("Region object sent from client is null");
                return BadRequest($"Region with id {id} is not found");
            }
            var regionDto = new RegionDto 
            { 
                RegionId = region.RegionId, 
                RegionDescription = region.RegionDescription};

            return Ok(regionDto);
        }

        //POST api//<RegionController>
        [HttpPost]
        public IActionResult CreateRegion([FromBody] RegionDto regionDto)
        {
            // lakukan validasi pada regiondto not null
            if (regionDto == null)
            {
                _logger.LogError("Regiondto object sent from client is null");
                return BadRequest("Regiondto object is null");
            }

            var region = new Region ()
            {
                RegionId = regionDto.RegionId,
                RegionDescription = regionDto.RegionDescription
            };
            //post to database
            _repositoryManager.RegionRepository.Insert(region);

            //Redirect
            return CreatedAtRoute("GetRegion", new { id = regionDto.RegionId }, regionDto);
        }

        //PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRegion (int id, [FromBody] RegionDto regionDto)
        {
            // lakukan validasi pada regiondto not null
            if (regionDto == null)
            {
                _logger.LogError("Regiondto object sent from client is null");
                return BadRequest("Regiondto object is null");
            }

            var region = new Region()
            {
                RegionId = id,
                RegionDescription = regionDto.RegionDescription
            };
            _repositoryManager.RegionRepository.Edit(region);

            //Redirect
            return CreatedAtRoute("GetRegion", new { id = regionDto.RegionId }, 
                new RegionDto
                {
                    RegionId = id, RegionDescription = region.RegionDescription
                });

        }

        //DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public IActionResult delete(int? id)
        {
            if (id == null)
            {
                _logger.LogError("Region id sent from client is null");
                return BadRequest("Regiondto object is null");
            }

            var region = _repositoryManager.RegionRepository.FindRegionById(id.Value);
            if (region == null)
            {
                _logger.LogError($"Region with id \"{id}\" is not found");
                return NotFound();
            }

            _repositoryManager.RegionRepository.Remove(region);
            return Ok("Data Has Been Removed");
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
