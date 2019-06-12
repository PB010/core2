﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.ToDos.Models;
using ToDoList.Persistence.Models;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> GetAllToDos();
        Task CreateNewTodo(ToDoForCreationDto dto);
    }
}
