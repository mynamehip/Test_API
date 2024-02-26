using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly IHangHoaRepository _hanghoaRepository;
        private readonly MyDBContext _context;

        public HangHoaController(IHangHoaRepository hangHoaRepository, MyDBContext context)
        {
            _hanghoaRepository = hangHoaRepository;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            try
            {
                var result = _hanghoaRepository.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
