using InternSharp.Models;

namespace InternSharp.Repositories
{
    public interface IInternshipRepository
    {
        Task<IEnumerable<InternshipModel>> GetAllInternshipsAsync();
        Task<InternshipModel> GetInternshipByIdAsync(int id);
    }
}
