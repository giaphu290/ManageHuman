using AutoMapper;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.DTO.CreateDTO;
using BusinessObject.DTO;
using Entity.Object;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace ManageHuman.Controllers
{
    [Authorize(Policy = "ManagerOnly")]
    [ApiController]
    public class FormTypesController : ControllerBase
    {

        private readonly IFormTypeService _service;
        private readonly IMapper _mapper;
        public FormTypesController(IFormTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
       
        [HttpGet]
        [Route("/api/[Controller]/GetFormType")]
        public IActionResult GetFormTypes()
        {
            try
            {
                if (_service.GetFormTypes() == null)
                {
                    return NotFound("No font type");
                }
                var data = _service.GetFormTypes();
                var response = _mapper.Map<List<FormTypeUpdateDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/AddNewFormType")]
        public IActionResult AddNewFormType([FromForm] FormTypeCreateDTO form)
        {
            try
            {
                var data = _mapper.Map<FormType>(form);
                _service.AddFormTypes(data);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/UpdateFormType")]
        public IActionResult UpdateFormType([Required] Guid id, [FromForm] FormTypeUpdateDTO _update)
        {

            try
            {
                var data = _service.GetFormTypeByID(id);
                if (_update.TypeName != null)
                {
                    data.TypeName = _update.TypeName;
                }
             
                _service.UpdateFormType(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
