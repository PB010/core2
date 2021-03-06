﻿using System;

namespace ToDoList.Application.ToDos.Models
{
    public class ToDoForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ToDoTime { get; set; }
        public int ToDoPrioritiesId { get; set; }

        public DateTime ConvertTime()
        {
            return DateTime.Parse(ToDoTime);
        }
    }
}
