using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaihhModel model);
        bool UpdateById(LoaiVM vmodel);
        bool DeleteById(int id);
    }
}
