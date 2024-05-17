using AutoMapper;
using BusinessObject.DTO.CreateAndReponse;
using BusinessObject.DTO.CreateDTO;
using BusinessObject.DTO;
using Entity.Object;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ManageHuman.Controllers
{
 
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly IFormService _service;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FormsController(IFormService service, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("/api/[Controller]/GetForms")]
        public IActionResult GetForms()
        {
            try
            {

                if (_service.GetForms() == null)
                {
                    return NotFound("No User");
                }
                var data = _service.GetForms();
                var response = _mapper.Map<List<FormDTO>>(data);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Policy = "EmployeeOnly")]
        [HttpPost]
        [Route("/api/[Controller]/AddNewForm")]
        public IActionResult AddNewForm([FromForm] FormCreateDTO form)
        {
            try
            {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filePath = path + form.Attachments.FileName;
                    using (FileStream fileStream = System.IO.File.Create(path + form.Attachments.FileName))
                    {
                        form.Attachments.CopyTo(fileStream);
                        fileStream.Flush();

                    }

                var data = _mapper.Map<Form>(form);
                //
                var user = HttpContext.User;
                var username = user.FindFirst("UserID")?.Value;
                data.UsersID = Guid.Parse(username);
                //
                data.Attachments = filePath;      
                _service.AddForm(data);
                return Ok("Create new from succesfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Policy = "ManagerOnly")]
        [HttpPut]
        [Route("/api/[Controller]/UpdateForm")]
        public  IActionResult UpdateForm([Required] Guid id, [FromForm] FormUpdateDTO _update)
        {
            try
            {
                var data = _service.GetFormByID(id);
                if (_update.UsersID != null)
                {
                    data.UsersID = (Guid)_update.UsersID;
                }
                if (_update.TypeID != null)
                {
                    data.TypeID = (Guid)_update.TypeID;
                }if (_update.Title != null)
                {
                    data.Title = _update.Title;
                }if (_update.Description != null)
                {
                    data.Description = _update.Description;
                }
                if (_update.Attachments != null && _update.Attachments.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filePath = path + _update.Attachments.FileName;
                    using (FileStream fileStream = System.IO.File.Create(path + _update.Attachments.FileName))
                    {
                        _update.Attachments.CopyTo(fileStream);
                        fileStream.Flush();

                    }
                    data.Attachments = filePath;
                }

                _service.UpdateForm(data);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
