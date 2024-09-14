using MediatR;
using P1_Core.Entities;
using Microsoft.EntityFrameworkCore;
using P1_Core;

namespace P1_Application.UseCases.AddCurrencyToUser
{
    public class AddCurrencyToUserUseCase : IRequestHandler<AddCurrencyToUserRequest>
    {
        private IRepository<User> _userRepository;
        private IRepository<Currency> _currencyRepository;
        public AddCurrencyToUserUseCase(IRepository<User> userRepository, IRepository<Currency> currencyRepository)
        {
            _userRepository = userRepository;
            _currencyRepository = currencyRepository;
        }
        public async Task Handle(AddCurrencyToUserRequest request, CancellationToken cancellationToken)
        {
            // we need to get the user to ensure that it's now a tracked entity in EF
            var userQuery = await _userRepository.Query().Include(u => u.UserCurrencies).FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);
            //TODO come back to this and clean it up
            if (userQuery.UserCurrencies.Any(u => u.Currency.Id == request.CurrencyId))
            {
                var userCurrency = userQuery.UserCurrencies.First(u => u.Currency.Id == request.CurrencyId);
                userCurrency.Amount += request.Amount;
                await _userRepository.UpdateAsync(userQuery);
            }
            else
            {
                var currency = await _currencyRepository.GetByIdAsync(request.CurrencyId);
                var userCurrency = new UserCurrency
                {
                    User = userQuery,
                    Currency = currency,
                    Amount = request.Amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                userQuery.UserCurrencies.Add(userCurrency);
                await _userRepository.UpdateAsync(userQuery);
            }
        }
    }

    public class AddCurrencyToUserRequest : IRequest
    {
        public AddCurrencyToUserRequest(int userId, int currencyId, int amount)
        {
            UserId = userId;
            CurrencyId = currencyId;
            Amount = amount;
        }
        public int UserId { get; }
        public int CurrencyId { get; }
        public int Amount { get; }
    }

}