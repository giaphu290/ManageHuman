using DAO.DAO;
using Entity.Object;
using HumanRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.Repository
{
    public class FormRepository : IFormRepository
    {
        private readonly FormDAO formDAO;
        public FormRepository()
        {
            formDAO = new FormDAO();
        }
        public void AddForm(Form form)
        {
            formDAO.AddNewForms(form);
        }

        public Form GetFormByID(Guid Id)
        {
          return  formDAO.GetFormById(Id);
        }

        public List<Form> GetForms()
        {
            return formDAO.GetForms();
        }

        public List<Form> GetFormsByUserIdAndFormType(Guid userId, Guid formTypeId)
        {
           return formDAO.GetFormsByUserIdAndFormType(userId, formTypeId);
        }

        public void RemoveFormbyID(Guid Id)
        {
            formDAO.DeleteForm(Id);
        }

        public void UpdateForm(Form form)
        {
            formDAO.UpdateForm(form);
        }
    }
}
