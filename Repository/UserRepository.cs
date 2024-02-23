using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repository.Interfaces;

namespace ControleDeContatos.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly BancoContext _context;
        public UserRepository(BancoContext context)
        {
           _context = context;
        }


        public List<UserModel> GetAll()
        {
           return _context.Users.ToList();
        }

        public UserModel GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => x.Login == login);
        }

        public UserModel GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }


        public UserModel Create(UserModel user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }


        public UserModel Update(UserModel user)
        {
            UserModel userdb = GetById(user.Id);
            if (userdb == null)
            {
                throw new Exception($"Houve um erro ao identificar o id {user.Id}");
            }
            userdb.Name = user.Name; 
            userdb.Login = user.Login;
            userdb.Email = user.Email;
            userdb.Perfil = user.Perfil;

            // Atualiza a propriedade Updated com a data e hora atual em UTC
           

            _context.Users.Update(userdb);
            _context.SaveChanges();
            return userdb;
        }


        public bool Delete(int id)
        {
            UserModel userdb = GetById(id);
            if(userdb == null) 
            {
                throw new Exception($"Houve um erro ao identificar o id {id}");
            }
            _context.Users.Remove(userdb);
            _context.SaveChanges();
            return true;
        }

        

        
    }
}
