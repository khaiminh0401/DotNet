using AccountService.DTOs;
using AccountService.Entities;

namespace AccountService.InterfaceRepository;

public interface IAccountRepository{
    IEnumerable<Account> GetAccounts();

    Account GetAccount(int id);
    void CreateAccount(Account account);

    Account LoginAccount(AccountDto account);
}