using AccountService.Entities;
using AccountService.Models;

namespace AccountService.InterfaceRepository;

public interface IAccountRepository{
    IEnumerable<Account> GetAccounts();

    Account GetAccount(int id);
    void CreateAccount(Account account);

    Account LoginAccount(AccountModel account);
}