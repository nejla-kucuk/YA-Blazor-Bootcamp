using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NK.PasswordStorageApp.Domain.Dtos;
using NK.PasswordStorageApp.WebAPI.Hubs;
using NK.PasswordStorageApp.WebAPI.Persistance.Contexts;


namespace NK.PasswordStorageApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IHubContext<AccountsHub> _accountsHubContext;

        public AccountsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken) //Asekron uygulamalarda kullanılır. 
        {

            var account = await _dbContext
                                    .Accounts
                                    .AsNoTracking() //datayı tekrar düzenleyip kaydetmiyoruz. bundan dolayı kullanılır.
                                    .Select(ac => AccountGetAllDto.MapFromAccount(ac)) //buraya uygun sql sorgusu üretir.
                                    .ToListAsync(cancellationToken);

            return Ok(account);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var account = await _dbContext
                                .Accounts
                                .AsNoTracking()
                                .FirstOrDefaultAsync(ac => ac.Id == id,cancellationToken);
            
            if (account is null)
                return NotFound();

            return Ok(AccountGetByIdDto.MapFromAccount(account));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(AccountCreateDto newAccount, CancellationToken cancellationToken)
        {
            var account = newAccount.ToAccount();

            _dbContext
                      .Accounts
                      .Add(account);//Ekleme işlemi sekron yapılır.

            await _dbContext.SaveChangesAsync(cancellationToken); //Kaydetme işlemi askron yapılır.


            await _accountsHubContext
                .Clients
                .All
                .SendAsync("AccountCreated", 
                            AccountGetAllDto.MapFromAccount(account), 
                            cancellationToken); // SignalR ile yapıldı.

            // return Ok(account.Id);
            return Ok(new { data = account.Id, 
                            message = "The account was added successfully!" });

        }



        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, AccountUpdateDto updateDto, CancellationToken cancellationToken)
        {
            if(id != updateDto.Id)
                return BadRequest("The id in the URL does not match the id in the body.");

            var account = _dbContext
                          .Accounts
                          .FirstOrDefault(ac => ac.Id == id);

            var updatedAccount = updateDto.ToAccount(account);

            /*_dbContext
                .Accounts
                .Update(updatedAccount); daha yavaştır zaten ef core bu takibi yapıyor yeniden kaydetmemize gerek yok.
            */

            await _dbContext.SaveChangesAsync(cancellationToken); //değişen kolonlarda değişiklik yapar. 

            await _accountsHubContext
                .Clients
                .All
                .SendAsync("AccountUpdated",
                            AccountGetAllDto.MapFromAccount(account),
                            cancellationToken); // SignalR ile yapıldı.

            // return Ok(account.Id);
            return Ok(new
            {
                data = account.Id,
                message = "The account was added successfully!"
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveAsync(Guid id,CancellationToken cancellationToken)
        {
            if(id == Guid.Empty)
                return BadRequest("id is not valid. Please do not send empty guids for god sake!");

            var account = _dbContext
                          .Accounts
                          .FirstOrDefault(ac => ac.Id == id);

            if (account is null)
                return NotFound();


             _dbContext
             .Accounts
             .Remove(account);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _accountsHubContext
                .Clients.All
                .SendAsync("AccountRemoved",
                            AccountGetAllDto.MapFromAccount(account),
                            cancellationToken); // SignalR ile yapıldı.

            return NoContent();


        }
    }
}
