using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using ControleDeContatos.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            UserModel user = _userRepository.GetById(id);
            return View(user);
        }


        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.GetById(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "Usuário excluido com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = "Erro ao excluir contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir Usuário, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        public IActionResult Create(UserModel user) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = _userRepository.Create(user);

                    TempData["SucessMessage"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao cadastrar usuário, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }





        [HttpPost]
        public IActionResult Update(UserWithoutPass userwhithoutpass)
        {
            try
            {
                UserModel user = null;
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userwhithoutpass.Id,
                        Name = userwhithoutpass.Name,
                        Login = userwhithoutpass.Login,
                        Email = userwhithoutpass.Email,
                        Perfil = userwhithoutpass.Perfil,
                    };

                    user = _userRepository.Update(user);
                    TempData["SucessMessage"] = "Usuario alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao alterar Usuario, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }


        }






    }
}
