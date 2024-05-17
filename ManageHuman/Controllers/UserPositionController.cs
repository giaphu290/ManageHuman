using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Object;
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
        //Employee
        [Authorize(Policy = "ManagerOnly")]
        [HttpGet]
        [Route("api/[Controller]/getsalarys")]
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

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Manager
        [Authorize(Policy = "ManagerOnly")]
        [HttpPut]
        [Route("api/[Controller]/status")]
        public IActionResult ChangeStatusSalary(Guid id) {

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
        [Authorize(Policy = "EmployeerOnly")]
        [HttpGet]
        [Route("api/[Controller]/salary")]
        public IActionResult GetSalaryByPersonal(Guid id)
        {
            try { 
            var data = _service.GetSalaryByUser(id);
                var response = _mapper.Map<List<UserPositionDTO>>(data);
                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy ="ManagerOnly")]
        [HttpGet]
        [Route("api/[Controller]/Calculate")]
        public IActionResult CalculateAuto()
        {
            try
            {
                var data = userService.GetUsers();
                foreach (var user in data)
                {
                    // Handle the formType GUID parsing appropriately
                    Guid formTypeGuid;
                    if (!Guid.TryParse("", out formTypeGuid))
                    {
                        throw new ArgumentException("Invalid form type GUID.");
                    }

                    var forms = _formService.GetFormsByUserIdAndFormType(user.UserID, formTypeGuid);
                    int index = 0;

                    foreach (var form in forms)
                    {
                        var salaries = _service.GetSalaryByUser(form.UsersID);
                        foreach (var salary in salaries)
                        {
                            if (salary.Paid == false && salary.timestart < form.DateCreate)
                            {
                                index++;
                            }
                        }
                    }

                    _service.UpdateTotalSalary(index, user.UserID);
                }

                return Ok("Calculation completed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
