using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IFormService
    {
        public List<Form> GetForms();
        public void AddForm(Form form);
        public void RemoveFormbyID(Guid Id);
        public void UpdateForm(Form form);
        public Form GetFormByID(Guid Id);
    }
}
