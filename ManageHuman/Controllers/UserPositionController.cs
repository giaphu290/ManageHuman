using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.Object;
using Entity.Object;
using HumanService.HumanService;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageHuman.Controllers
{
    [ApiController]
    public class UserPositionController : ControllerBase
    {
        private readonly IUserPositionService _service;
        private readonly IFormService _formService;
        private readonly IMapper _mapper;
        private readonly IUserService userService;
        public UserPositionController(IUserPositionService service, IFormService formService, IMapper mapper, IUserService userService)
        {
            _service = service;
            _formService = formService;
            _mapper = mapper;
            this.userService = userService;
        }
        [Authorize(Policy = "ManagerOnly")]
        [HttpGet]
        [Route("api/[Controller]/Manager/getsalarys")]
        public IActionResult GetSalary()
        {
            try
            {
                if (_service.GetSalarys() == null)
                {
                    return NotFound("No User");
                }
                var data = _service.GetSalarys();
                //foreach (var item in data)
                //{
                //    if (item.timestart < DateTimeOffset.Now && item.timeend > DateTimeOffset.Now) { }

                //    item.Salary
                //}

                var response = _mapper.Map<List<UserPositionDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Manager
        [Authorize(Policy = "ManagerOnly")]
        [HttpPut]
        [Route("api/[Controller]/Manager/status")]
        public IActionResult ChangeStatusSalary(Guid id)
        {

            if (_service.GetSalarys == null)
            {
                return NotFound("No User Position");
            }
            var salary = _service.GetUserPositionById(id);
            if (salary == null)
            {
                return NotFound();
            }

            _service.UpdateStatusSalary(salary);
            return Ok("Delete Successfully");

        }
        [Authorize]
        [HttpGet]
        [Route("api/[Controller]/salary")]
        public IActionResult GetSalaryByPersonal()
        {
            try
            {
                var user = HttpContext.User;
                var userIdClaim = user.FindFirst("UserID");

                if (userIdClaim == null)
                {
                    return Unauthorized("UserID claim not found");
                }

                if (!Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    return BadRequest("Invalid UserID format");
                }

                var data = _service.GetSalaryByUser(userId);
                if (data == null)
                {
                    return NotFound("User's salary data not found");
                }

                var response = _mapper.Map<List<UserPositionDTO>>(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Authorize]
        [HttpGet]
        [Route("api/[Controller]/Calculate")]
        public IActionResult CalculateAuto()
        {
            try
            {    var salaries = _service.GetSalarys();
                var data = _mapper.Map<List<UserPositionUpdateDTO>>(salaries);

                foreach (var salary in data)
                {
                    int index = 0;
                    var forms = _formService.GetFormsByUserIdAndFormType(salary.UserID, Guid.Parse("be200e0e-af66-47f6-9340-7c08d4bd1f49"));

                    foreach (var form in forms)
                    {
                        if (form.DateCreate > salary.timestart)
                        {
                            index++;
                        }
                    }
                    var request = _service.UpdateTotalSalary(index, salary.UserID);
                    if (request != true)
                    {
                        return BadRequest();
                    }
                }

                return Ok("Calculation completed successfully.");
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy = "ManagerOnly")]
        [HttpPost]
        [Route("/api/[Controller]/Manaer/AddNewUserPosition")]
        public IActionResult AddUserPosition([FromForm] UserPositionCreateDTO user)
        {
            try
            {
                var data = _mapper.Map<UserPosition>(user);
                _service.AddUserPosition(data);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
