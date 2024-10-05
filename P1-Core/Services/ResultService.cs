using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Core.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepository<UserItem> _userItemRepository;
        public ResultService(IRepository<UserItem> userItemRepository, IRepository<User> userRepository)
        {
            _userItemRepository = userItemRepository;
        }

        // we'll need the user Id, the Item Id, and then increment the quantity of the item in the UserItem table
        public async void ApplyResults(User user, ICollection<Result> results)
        {
            foreach (Result result in results)
            {
                foreach (ItemResult item in result.ItemResults)
                {
                    //TODO should handle the transaction to roll back changes 
                    await _userItemRepository.AddAsync(new UserItem
                    {
                        UserId = user.Id,
                        ItemId = item.ItemId,
                        Quantity = +item.Quantity
                    });
                }
            }
        }
    }
}