using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.DTO.CreateDTO;
using Entity.Object;
using HumanService.HumanService;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManageHuman.Controllers
{
    [ApiController]
    public class ClaimUsersController : ControllerBase
    {

        private readonly IClaimUserService _service;
        private readonly IMapper _mapper;
        public ClaimUsersController(IClaimUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        [HttpGet]
        [Route("/api/[Controller]/GetClaimUser")]
        public IActionResult GetClaimUsers()
        {
            try
            {
                if (_service.GetClaimUsers() == null)
                {
                    return NotFound("No User");
                }
                var data = _service.GetClaimUsers();
                var response = _mapper.Map<List<ClaimUserDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/AddNewClaimUser")]
        public IActionResult AddNewClaimUser([FromForm] ClaimUserCreateDTO claimUserDTO)
        {
            try
            {
                var data = _mapper.Map<ClaimUser>(claimUserDTO);
                _service.AddClaimUser(data);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/UpdateUser")]
        public IActionResult UpdateClaimUser([Required] int id, [FromForm] ClaimUserUpdateDTO _update)
        {

            try
            {
                var data = _service.GetClaimUserByID(id);
                if (_update.UserID != null)
                {
                    data.UserID = (Guid)_update.UserID;
                }
                if (_update.ClaimID != null)
                {
                    data.ClaimID = (Guid)_update.ClaimID;
                }
              
                _service.UpdateClaimUser(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
