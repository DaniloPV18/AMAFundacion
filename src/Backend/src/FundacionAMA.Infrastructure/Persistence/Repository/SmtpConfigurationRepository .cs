using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository;


public class SmtpConfigurationRepository : BaseRepository<SmtpConfiguration>, ISmtpConfigurationRepository
{

    public SmtpConfigurationRepository(AMADbContext context) :
        base(context)
    {

    }


    //public User? GetById(int userId)
    //{
    //    this.First(a => a.Id == userId);
    //    return _context.User.Find(userId);
    //}

    //public IEnumerable<User> GetAll()
    //{
    //    return _context.User.ToList();
    //}

    //public void Create(User newUser)
    //{
    //    _context.User.Add(newUser);
    //    _context.SaveChanges();
    //}

    //public void Update(int userId, User updatedUser)
    //{
    //    var usuarioExistente = _context.User.Find(userId);
    //    if (usuarioExistente != null)
    //    {
    //        usuarioExistente.Name = updatedUser.Name;
    //        usuarioExistente.Email = updatedUser.Email;
    //        // Actualizar otros campos según sea necesario
    //        _context.SaveChanges();
    //    }
    //}

    //public void Delete(int userId)
    //{
    //    var usuarioExistente = _context.User.Find(userId);
    //    if (usuarioExistente != null)
    //    {
    //        _context.User.Remove(usuarioExistente);
    //        _context.SaveChanges();
    //    }
    //}
}
