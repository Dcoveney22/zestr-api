using ZestrApi.Models;

namespace ZestrApi.Interfaces
{
    public interface ISalesUploadService
    {
        Task<IEnumerable<SaleRecord>> ParseCsv(IFormFile file);
    }
}