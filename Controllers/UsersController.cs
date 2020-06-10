using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPI.Data;
using RestAPI.Dtos;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        //{
        //    var userItems = _repository.GetAllUsers();

        //    return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        //}

        //[HttpGet("{id}")]
        //public ActionResult <UserReadDto> GetUserById(int id)
        //{
        //    var userItem = _repository.GetUserById(id);

        //    return Ok(_mapper.Map<UserReadDto>(userItem));
        //}

        [HttpPost]
        public ActionResult<String> GetUsers(JsonElement request)
        {
            string[] items = string.Join(string.Empty, Regex.Split(request.ToString(), "[^0-9a-zA-Z,]+")).Split(",");
            IEnumerable<string> userItems;
            if (items[0]=="")
                return BadRequest();

            userItems = _repository.GetUsers(items);

            if(userItems==null)
                return BadRequest();

            return Ok(userItems);
        }
    }
}
