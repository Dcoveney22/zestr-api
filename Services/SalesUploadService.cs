using ZestrApi.Data;
using ZestrApi.Interfaces;
using ZestrApi.Models;

namespace ZestrApi.Services
{
    public class SalesUploadService : ISalesUploadService
    {
        private readonly ZestrDbContext _context;

        public SalesUploadService(ZestrDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SaleRecord>> ParseCsv(IFormFile file)
        {
            var records = new List<SaleRecord>();

            using var reader = new StreamReader(file.OpenReadStream());
            var headers = reader.ReadLine()?.Split(',');

            if (headers == null) return records;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()?.Split(',');
                if (line == null) continue;

                var record = new SaleRecord
                {
                    Id = Guid.NewGuid(),
                    StaffId = Guid.Parse(line[0]),
                    WeekCommencing = DateTime.SpecifyKind(DateTime.Parse(line[1]), DateTimeKind.Utc),
                    ItemSales = new Dictionary<string, int>()
                };

                for (int i = 2; i < headers.Length; i++)
                {
                    record.ItemSales[headers[i]] = int.Parse(line[i]);
                }

                records.Add(record);

            }
            await _context.SaleRecords.AddRangeAsync(records);
            await _context.SaveChangesAsync();
            return records;
        }
    }
}