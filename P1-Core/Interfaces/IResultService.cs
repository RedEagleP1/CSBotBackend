
using P1_Core.Entities;

namespace P1_Core.Interfaces
{
    public interface IResultService
    {
        void ApplyResults(User user, ICollection<Result> results);
    }
}