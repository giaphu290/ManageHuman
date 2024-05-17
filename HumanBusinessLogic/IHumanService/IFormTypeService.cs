using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IFormTypeService
    {
        public List<FormType> GetFormTypes();
        public void AddFormTypes(FormType formType);
        public void RemoveFormTypebyID(Guid Id);
        public void UpdateFormType(FormType formType);
        public FormType GetFormTypeByID(Guid Id);
    }
}
