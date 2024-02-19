using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class LoaiRepository : ILoaiRepository
    {
        private MyDBContext _context;

        public LoaiRepository(MyDBContext context)
        {
            _context = context;
        }

        public LoaiVM Add(LoaihhModel model)
        {
            var loai = new Loaihh
            {
                TenLoai = model.TenLoai
            };
            _context.Add(loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai
            };
        }

        public bool DeleteById(int id)
        {
            var loai = _context.Loaihh.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loaihh.Select(l => new LoaiVM
            {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai,
            }).ToList();
            return loais;
        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loaihh.SingleOrDefault(l => l.MaLoai == id);
            if(loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public bool UpdateById(LoaiVM vmodel)
        {
            var loai = _context.Loaihh.SingleOrDefault(l => l.MaLoai == vmodel.MaLoai);
            if(loai != null)
            {
                loai.TenLoai = vmodel.TenLoai;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
