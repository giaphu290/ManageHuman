using Entity.Object;
using HumanRepository.IRepository;
using HumanService.IHumanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.HumanService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        public FormService(IFormRepository formRepository) { _formRepository = formRepository; }
        public void AddForm(Form form)
        {
            _formRepository.AddForm(form);
        }

        public Form GetFormByID(Guid Id)
        {
            return _formRepository.GetFormByID(Id);
        }

        public List<Form> GetForms()
        {
           return _formRepository.GetForms();
        }

        public List<Form> GetFormsByUserIdAndFormType(Guid userId, Guid formTypeId)
        {
            return _formRepository.GetFormsByUserIdAndFormType(userId, formTypeId);
        }

        public void RemoveFormbyID(Guid Id)
        {
            _formRepository.RemoveFormbyID(Id);
        }

        public void UpdateForm(Form form)
        {
            _formRepository.UpdateForm(form);
        }
    }
}
