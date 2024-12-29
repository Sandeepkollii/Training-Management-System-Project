using CourseWebApi.IRepo;
using CourseWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        IBatchRepository _repo;
        ILogger<BatchController> _logger;
        public BatchController(IBatchRepository repo, ILogger<BatchController> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        // GET: api/<BatchController>
        [HttpGet]
        public IActionResult  Get()
        {

            var _log4net = log4net.LogManager.GetLogger(typeof(BatchController));
            _log4net.Info("inside get method");
            //    _logger.LogWarning("inside get method");
            //    _logger.LogInformation("inside get method");
            //    _logger.LogError("inside get method");
            //    _logger.LogCritical("inside get method");
            var list = _repo.GetBatchDetails();
            if (list.Count < 3)
            {
                _logger.LogError("Plase do needful as there are no batches");
            }
            else
                _logger.LogInformation("Batches are available");

            return Ok(_repo.GetBatchDetails());
        }

        // GET api/<BatchController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("inside get details method");
            return Ok(_repo.GetBatchById(id));
        }

        // POST api/<BatchController>
        [HttpPost]
        public IActionResult Post(Batch batch)
        {
            _repo.AddBatch(batch);
            return Created("batch added", batch);
        }

        // PUT api/<BatchController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Batch batch)
        {
            _repo.UpdateBatch(id, batch);
            return Ok();
        }

        // DELETE api/<BatchController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteBatch(id);
            return Ok();
        }
    }
}
