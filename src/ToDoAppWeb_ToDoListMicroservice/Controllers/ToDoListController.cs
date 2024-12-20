﻿using BLL.Services;
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
        public async Task<ActionResult<ToDoListResponseDTO>> Post(ToDoListRequestDTO toDoList)
        {
            ToDoList toDoListToAdd = new ToDoList
            {
                Title = toDoList.Title,
                Description = toDoList.Description,
                UserId = toDoList.UserId,
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

        [HttpDelete]
        [Route("{toDoListId}")]
        public async Task<ActionResult> Delete(string toDoListId)
        {
            var resultState = await _toDoListService.DeleteToDoList(toDoListId);

            if (resultState.IsSuccessful)
            {

                return Ok(resultState.Message);
            }
            else
            {
                return BadRequest(resultState.Message);
            }
        }

        [HttpPut]
        [Route("{toDoListId}")]
        public async Task<ActionResult> Edit(string toDoListId, ToDoListRequestDTO newtoDoList)
        {
            ToDoList toDoListToEdit = new ToDoList
            {
                Title = newtoDoList.Title,
                Description = newtoDoList.Description,
            };

            var resultState = await _toDoListService.EditToDoList(toDoListId, toDoListToEdit);

            if (resultState.IsSuccessful)
            {

                return Ok(resultState.Message);
            }
            else
            {
                return BadRequest(resultState.Message);
            }
        }

        [HttpPost]
        [Route("{toDoListId}/{toDoTaskId}")]
        public async Task<ActionResult> AddToDoTask(string toDoListId, string toDoTaskId)
        {

            var resultState = await _toDoListService.AddToDoTask(toDoTaskId);

            if (resultState.IsSuccessful)
            {

                return Ok(resultState.Message);
            }
            else
            {
                return BadRequest(resultState.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoListResponseDTO>>> GetToDoLists()
        {
            var toDoList = await _toDoListService.GetToDoLists();

            if (toDoList is null)
            {
                return BadRequest();
            }

            var toDoListResponse = new List<ToDoListResponseDTO>();

            foreach (var list in toDoList)
            {
                var toDoListDTO = new ToDoListResponseDTO()
                {
                    Id = list.Id,
                    Title = list.Title,
                    Description = list.Description,
                    AddedOn = list.AddedOn,
                    UserId = list.UserId,
                    EditedOn = list.EditedOn
                };

                toDoListResponse.Add(toDoListDTO);
            }

            return toDoListResponse;
        }

        [HttpGet]
        [Route("{toDoListId}")]
        public async Task<ActionResult<ToDoListResponseDTO>> GetToDoListById(string toDoListId)
        {
            var toDoList = await _toDoListService.GetToDoListById(toDoListId);

            if (toDoList is null)
            {
                return BadRequest();
            }

            var toDoListResponse = new ToDoListResponseDTO()
            {
                Id = toDoList.Id,
                Title = toDoList.Title,
                Description = toDoList.Description,
                AddedOn = toDoList.AddedOn,
                UserId = toDoList.UserId,
                EditedOn = toDoList.EditedOn
            };

            return toDoListResponse;
        }



        //[HttpGet]
        //[Route("{toDoListId}/toDoTasks")]
        //public async Task<ActionResult<List<ToDoTaskResponseDTO>>> GetToDoListToDoTasks(string toDoListId)
        //{
        //    var toDoList = await _toDoListService.GetToDoListById(toDoListId);

        //    if (toDoList is null)
        //    {
        //        return BadRequest();
        //    }

        //    //var toDoTasks = await _toDoListService.GetToDoListToDoTasks(toDoListId);

        //    List<ToDoTaskResponseDTO> toDoTasksResponse = new List<ToDoTaskResponseDTO>();

        //    foreach (var toDoTask in toDoTasks)
        //    {
        //        var toDoTaskResponse = new ToDoTaskResponseDTO()
        //        {
        //            Id = toDoTask.Id,
        //            Title = toDoTask.Title,
        //            IsCompleted = toDoTask.IsCompleted,
        //            ToDoListId = toDoTask.ToDoListId,
        //        };

        //        toDoTasksResponse.Add(toDoTaskResponse);
        //    }

        //    return toDoTasksResponse;
        //}
    }
}
