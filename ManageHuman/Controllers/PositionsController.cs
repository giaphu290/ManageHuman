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
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    public class PositionsController : ControllerBase
    {

        private readonly IPositionService _service;
        private readonly IMapper _mapper;
        public PositionsController(IPositionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("/api/[Controller]/GetPositions")]
        public IActionResult GetPositions()
        {
            try
            {
                if (_service.GetPositions() == null)
                {
                    return NotFound("No User");
                }
                var data = _service.GetPositions();
                var response = _mapper.Map<List<PositionUpdateDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/AddNewPosition")]
        public IActionResult AddNewPosition([FromForm] PositionCreateDTO dTO)
        {
            try
            {
                var data = _mapper.Map<Position>(dTO);
                _service.AddPosition(data);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/UpdatePosition")]
        public IActionResult UpdatePosition([Required] Guid id, [FromForm] PositionUpdateDTO _update)
        {

            try
            {
                var data = _service.GetPositionByID(id);
                if (_update.NameOfPosition != null)
                {
                    data.NameOfPosition = _update.NameOfPosition;
                }
                if (_update.Salary != null)
                {
                    data.Salary = (float)_update.Salary;
                }
                if (_update.FromDate != null)
                {
                    data.FromDate = (DateTime)_update.FromDate;
                }
                if (_update.ToDate != null)
                {
                    data.ToDate = (DateTime)_update.ToDate;
                }
               

                _service.UpdatePosition(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
