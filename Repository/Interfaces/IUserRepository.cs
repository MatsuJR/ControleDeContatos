using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetByLogin(string login);
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(int id);
    }
}
