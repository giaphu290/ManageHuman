using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.DTO.CreateDTO;
using Entity.Object;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManageHuman.Controllers
{
    [Authorize(Policy = "ManagerOnly")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("/api/[Controller]/Manager/GetAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                if (_userService.GetUsers() == null)
                {
                    return NotFound("No User");
                }
                var data = _userService.GetUsers();
                var response = mapper.Map<List<UserDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/Manager/AddNewUser")]
        public IActionResult AddNewUser([FromForm] UserCreateDTO userDTO)
        {
            try {
                var data = mapper.Map<User>(userDTO);
                _userService.AddNewUser(data);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/Manager/UpdateUser")]
        public IActionResult UpdateUser([Required]Guid id, [FromForm]UserUpdateDTO _update)
        {

            try
            {
                var data = _userService.GetUserByID(id);
                if (_update.Name != null)
                {
                    data.Name = _update.Name;
                }
                if (_update.UserName != null)
                {
                    data.UserName = _update.UserName;
                }
                if (_update.Password != null)
                {
                    data.Password = _update.Password;
                }
                if (_update.EmailAddress != null)
                {
                    data.EmailAddress = _update.EmailAddress;
                }
                if (_update.PhoneNumber != null)
                {
                    data.PhoneNumber = (long)_update.PhoneNumber;
                }
                if (_update.RoleID != null)
                {
                    data.RoleID = (Guid)_update.RoleID;
                }
                _userService.UpdateUser(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
