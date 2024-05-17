using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using Entity.Object;
using HumanService.HumanService;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManageHuman.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;
        public RolesController(IRoleService roleService, IMapper mapper)
        {
            this.roleService = roleService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("/api/[Controller]/GetRoles")]
        public IActionResult GetRoles()
        {
            try
            {
                if (roleService.GetRoles() == null)
                {
                    return NotFound("No Role");
                }
                var data = roleService.GetRoles();
                var response = mapper.Map<List<RoleUpdateDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/[Controller]/GetRoleById")]
        public IActionResult GetRoleById(Guid id)
        {
            try
            {
                var data = roleService.GetRoleByID(id);
                if (data == null)
                {
                    return NotFound("No Role");
                }
                var response = mapper.Map<RoleUpdateDTO>(data);
                return Ok(response);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/UpdateRole")]
        public IActionResult UpdateRole([Required] Guid id, [FromForm] RoleUpdateDTO _update)
        {

            try
            {
                var data = roleService.GetRoleByID(id);
                if (_update.RoleName != null)
                {
                    data.RoleName = _update.RoleName;
                }
                roleService.UpdateRole(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/AddNewRole")]
        public IActionResult AddNewRole([FromForm] RoleCreateDTO roleCreate)
        {
            try
            {
                var data = mapper.Map<Role>(roleCreate);
                roleService.AddRoles(data);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

