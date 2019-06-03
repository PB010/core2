using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApi.Models;
using ToDoWebApi.Persistence.Repository.Interfaces;

namespace ToDoWebApi.Controllers
{
    [Route("/api/toDos")]
    public class ToDosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public Task<IEnumerable<ToDoDto>> GetAllToDos()
        {
            return _unitOfWork.GetAllToDos();
        }
    }
}
