using AccountService.DBContext;
using AccountService.Exception;
using AccountService.InterfaceRepository;
using AccountService.Entities;
using AccountService.DTOs;

namespace AccountService.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly MyDbContext _context = new MyDbContext();

    public void CreateAccount(Account account)
    {
        bool accountExists = _context.Account.Any(a => a.Username == account.Username);
        if (accountExists)
        {
            throw new InvalidParamsException(500, "Username đã tồn tại");
        }
        _context.Account.Add(account);
        _context.SaveChanges();
    }

    public Account GetAccount(int id)
    {
        return _context.Account.Find(id);
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _context.Account.ToList();
    }

    public Account LoginAccount(AccountDto account)
    {
        Account _account = _context.Account.Where(u=> u.Username == account.Username).FirstOrDefault();
        if (_account == null)
        {
            throw new InvalidParamsException(500, "Username không tồn tại");
        }
        if(_account.Password != account.Password){
            throw new InvalidParamsException(500, "Mật khẩu không chính xác");
        }
        return _account;
    }
}