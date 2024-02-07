using ControleDeContatos.Models;

namespace ControleDeContatos.Repository.Interfaces
{
    public interface IContactRepository
    {
        ContactModel GetById(int id);
        List<ContactModel> GetAll();
        ContactModel Create(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);
    }
}
