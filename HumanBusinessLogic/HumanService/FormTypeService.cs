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
    public class FormTypeService : IFormTypeService
    {
        private readonly IFormTypeRepository _formTypeRepository;
        public FormTypeService(IFormTypeRepository formTypeRepository)
        {
            _formTypeRepository = formTypeRepository;
        }

        public void AddFormTypes(FormType formType)
        {
            _formTypeRepository.AddFormTypes(formType);
        }

        public FormType GetFormTypeByID(Guid Id)
        {
            return _formTypeRepository.GetFormTypeByID(Id);
        }

        public List<FormType> GetFormTypes()
        {
            return _formTypeRepository.GetFormTypes();
        }

        public void RemoveFormTypebyID(Guid Id)
        {
            _formTypeRepository.RemoveFormTypebyID(Id);
        }

        public void UpdateFormType(FormType formType)
        {
            _formTypeRepository.UpdateFormType(formType);
        }
    }
}
