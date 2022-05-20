using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.RequestDTO;
using Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppWeb_ToDoListMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        public IToDoListService _toDoListService;

        public ToDoListController(IToDoListService listService) : base()
        {
            _toDoListService = listService;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoListResponseDTO>> Post(ToDoListCreateRequestDTO toDoTask)
        {
            ToDoList toDoListToAdd = new ToDoList
            {
                Title = toDoTask.Title,
                Description = toDoTask.Description,
                UserId = toDoTask.UserId,
            };

            var resultState = await _toDoListService.CreateToDoList(toDoListToAdd);

            if (resultState.IsSuccessful)
            {

                return Ok(resultState.Message);
            }
            else
            {
                return BadRequest(resultState.Message);
            }
        }
    }
}
