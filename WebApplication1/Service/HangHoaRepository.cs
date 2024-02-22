using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private MyDBContext _context;
        public static int PAGE_SIZE { get; set; } = 2;

        public HangHoaRepository(MyDBContext context)
        {
            _context = context;
        }

        public List<HangHoaModel> GetAll(string? search, double? from, double? to, string? sortBy, int page)
        {
            var allProduct = _context.HangHoa.Include(hh => hh.Loaihh).AsQueryable();
            #region Filtering
            if (string.IsNullOrEmpty(search) == false)
            {
                allProduct = allProduct.Where(hh => hh.Tenhh.Contains(search));
            }
            if (from.HasValue)
            {
                allProduct = allProduct.Where(hh => hh.Dongia >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(hh => hh.Dongia <= to);
            }
            #endregion
            #region Sort
            allProduct = allProduct.OrderBy(hh => hh.Tenhh);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProduct = allProduct.OrderByDescending(hh => hh.Tenhh);
                        break;
                    case "gia_asc":
                        allProduct = allProduct.OrderBy(hh => hh.Dongia);
                        break;
                    case "gia_desc":
                        allProduct = allProduct.OrderByDescending(hh => hh.Dongia);
                        break;
                }
            }
            #endregion
            //#region Paging
            //int page = 3;
            //allProduct = allProduct.Skip((page - 1)*PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion
            //var result = allProduct.Select(hh => new HangHoaModel
            //{
            //    Mahh = hh.Mahh,
            //    Tenhh = hh.Tenhh,
            //    Dongia = hh.Dongia,
            //    TenLoai = hh.Loaihh.TenLoai
            //});
            //return result.ToList();

            var result = PaginatedList<Hanghoa>.Create(allProduct, page, PAGE_SIZE);
            return result.Select(hh => new HangHoaModel
            {
                Mahh = hh.Mahh,
                Tenhh = hh.Tenhh,
                Dongia = hh.Dongia,
                TenLoai = hh.Loaihh.TenLoai
            }).ToList();

        }
    }
}
