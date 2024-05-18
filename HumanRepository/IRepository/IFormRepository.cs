using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.IRepository
{
    public interface IFormRepository
    {
        public List<Form> GetForms();
        public void AddForm(Form form);
        public void RemoveFormbyID(Guid Id);
        public void UpdateForm(Form form);
        public Form GetFormByID(Guid Id);
        public List<Form> GetFormsByUserIdAndFormType(Guid userId, Guid formTypeId);
        public List<Form> GetFormsByUser(Guid userId);
    }
}
