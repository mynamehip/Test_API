using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string? search, double? from, double? to, string? sortBy, int page);
    }
}
