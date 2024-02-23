using ControleDeContatos.Models;
using ControleDeContatos.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UserModel user =  _userRepository.GetByLogin(loginModel.Login);

                    if(user != null)
                    {
                        if(user.ValidationPassword(loginModel.Password)) 
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["ErrorMessage"] = $"Senha invalida, tente novamente";

                    }
                    TempData["ErrorMessage"] = $"Usuario nao encontrado, tente novamente";


                }
                return View("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao entrar, verifique seu login ou senha. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");

            }
        }





    }
}
