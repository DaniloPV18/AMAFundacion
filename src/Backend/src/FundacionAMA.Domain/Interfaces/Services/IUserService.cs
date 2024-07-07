using System.Linq.Expressions;

namespace FundacionAMA.Domain.Interfaces.Services;

public interface IUserService
{
    User? GetById(int id);
    IEnumerable<User> GetAll(Expression<Func<User, bool>>? filter = null);
    void Create(User user);
    void Update(User User);
    void UpdatePassword(User updatedUser);

}
