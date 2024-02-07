using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Interfaces;

namespace ControleDeContatos.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BancoContext _context;

        public ContactRepository(BancoContext context)
        {
            _context = context;
        }


        public ContactModel GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }


        public List<ContactModel> GetAll()
        {
            return _context.Contacts.ToList();
        }



        public ContactModel Create(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactdb = GetById(contact.Id);

            if(contactdb == null)
            {
                throw new Exception($"Houve um erro ao identificar o id {contact.Id}");
            }

            contactdb.Name = contact.Name;
            contactdb.Email = contact.Email;
            contactdb.Phone = contact.Phone;

            _context.Contacts.Update(contactdb);
            _context.SaveChanges();

            return contactdb;

        }

        public bool Delete(int id)
        {
            ContactModel contactdb = GetById(id);

            if(contactdb == null) 
            {
                throw new Exception($"Houve um erro ao identificar o id {id}");
            }
            _context.Contacts.Remove(contactdb);
            _context.SaveChanges();
            return true;
        }


    }
}
