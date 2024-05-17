using AutoMapper;
using BusinessObject.DTO.CreateDTO;
using BusinessObject.DTO;
using Entity.Object;
using HumanService.HumanService;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.DTO.CreateAndReponse;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace ManageHuman.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        public ClaimsController(IClaimService claimService, IMapper mapper)
        {
            _claimService = claimService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("/api/[Controller]/GetClaims")]
        public IActionResult GetClaims()
        {
            try
            {
                if (_claimService.GetClaims() == null)
                {
                    return NotFound("No User");
                }
                var data = _claimService.GetClaims();
                var response = _mapper.Map<List<ClaimUpdateDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        [Route("/api/[Controller]/AddNewClaim")]
        public IActionResult AddNewClaim([FromForm] ClaimCreateDTO claimDTO)
        {
            try
            {
                var data = _mapper.Map<Claim>(claimDTO);
                _claimService.AddClaim(data);
                return Ok("Add new claim succesfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/UpdateClaim")]
        public IActionResult UpdateClaim([Required] Guid id, [FromForm] ClaimUpdateDTO _update)
        {

            try
            {
                var data = _claimService.GetClaimByID(id);
                if (_update.ClaimType != null)
                {
                    data.ClaimType = _update.ClaimType;
                }
                if (_update.ClaimValue != null)
                {
                    data.ClaimValue = _update.ClaimValue;
                }
               
                _claimService.UpdateClaim(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
