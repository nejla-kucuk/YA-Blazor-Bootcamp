
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NK.PasswordStorageApp.Domain.Dtos;
using NK.PasswordStorageApp.WebAPI.Persistance.Contexts;

namespace NK.PasswordStorageApp.WebAPI.Hubs
{
    public class AccountsHub:Hub
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountsHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AccountGetAllDto>> GetAllAsync() 
        {

            var accounts = await _dbContext
                                    .Accounts
                                    .AsNoTracking()
                                    .Select(ac => AccountGetAllDto.MapFromAccount(ac))
                                    .ToListAsync();

            return accounts;
        }


        public async Task CreateAsync(AccountCreateDto newAccount)
        {
            var account = newAccount.ToAccount();

            _dbContext
                      .Accounts
                      .Add(account);

            await _dbContext.SaveChangesAsync(); 

            await Clients // SignalR istemcilerini temsil eder.
                .AllExcept(Context.ConnectionId) // SignalR istemcilerini temsil eder.
                .SendAsync("AccountCreated",// "AccountCreate" olayını gönderir.
                            AccountGetAllDto.MapFromAccount(account)); // Hesap bilgisini DTO'ya dönüştürür ve gönderir.

        }


        public async Task RemoveAsync(Guid id)
        {
            if (id == Guid.Empty)
                return;

            var account = _dbContext
                          .Accounts
                          .FirstOrDefault(ac => ac.Id == id);

            if (account is null)
                return;


            _dbContext
            .Accounts
            .Remove(account);

            await _dbContext.SaveChangesAsync();

            await Clients
                .AllExcept(Context.ConnectionId)
                .SendAsync("AccountRemoved", id);


        }
    }
}
