using ControleDeContatos.Models;
using ControleDeContatos.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            ContactModel contact = _contactRepository.GetById(id);
            return View(contact);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.GetById(id);
            return View(contact);
        }


        [HttpPost]
        public IActionResult Create(ContactModel contact) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Create(contact);
                    TempData["SucessMessage"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao cadastrar contato, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
           
        }


        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SucessMessage"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao alterar contato, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
            
            
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "Contato excluido com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = "Erro ao excluir contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir contato, tente novamente. Detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }

            
        }


    }
}
