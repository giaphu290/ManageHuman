using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Object;
using HumanService.HumanService;
using HumanService.IHumanService;
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
        public UserPositionController(IUserPositionService service, IFormService formService, IMapper mapper)
        {
            _service = service;
            _formService = formService;
            _mapper = mapper;
        }
        //Employee
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
        [HttpPut]
        
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
        [HttpGet]
        [Route("api/[Controller]/salary")]
        public IActionResult GetSalaryByPersonal(Guid id)
        {
            try { 
            var data = _service.GetSalaryByUser(id);
                var response = _mapper.Map<UserPositionDTO>(data);
                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
