using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Data;
using MyFirstApplication.Model;

namespace MyFirstApplication.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleDAL _peopleRepository;

        public PeopleController(IPeopleDAL peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [Route("people"), HttpPost]
        public async Task<IActionResult> Create(People people)
        {
            try
            {
                await _peopleRepository.Create(people);
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("people/{id}"), HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _peopleRepository.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("people/{id}"), HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                People people = await _peopleRepository.Get(id);
                return Ok(people);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("people"), HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<People> people = await _peopleRepository.GetAll();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Route("people"), HttpPut]
        public async Task<IActionResult> Update(People people)
        {
            try
            {
                await _peopleRepository.Update(people);
                return Ok(people);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}