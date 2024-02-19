using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaihhController : ControllerBase
    {
        private readonly MyDBContext _dbContext;
        public LoaihhController(MyDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _dbContext.Loaihh.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loaiById = _dbContext.Loaihh.Where(x => x.MaLoai == id).FirstOrDefault();
            if (loaiById == null)
            {
                return NotFound();
            }
            return Ok(loaiById);
        }

        [HttpPost]
        public IActionResult Create(LoaihhModel model)
        {
            try
            {
                Loaihh loai = new Loaihh
                {
                    TenLoai = model.TenLoai
                };
                _dbContext.Add(loai);
                _dbContext.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, LoaihhModel model)
        {
            var loaiById = _dbContext.Loaihh.Where(x => x.MaLoai == id).FirstOrDefault();
            if (loaiById == null)
            {
                return NotFound();
            }
            loaiById.TenLoai = model.TenLoai;
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
