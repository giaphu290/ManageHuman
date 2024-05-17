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
    public class FormTypeRepository : IFormTypeRepository
    {
        private readonly FormTypeDAO formTypeDAO;
        public FormTypeRepository()
        {
            formTypeDAO = new FormTypeDAO();
        }

        public void AddFormTypes(FormType formType)
        {
           formTypeDAO.AddNewFormTypes(formType);   
        }

        public FormType GetFormTypeByID(Guid Id)
        {
         return   formTypeDAO.GetFormTypeById(Id);
        }

        public List<FormType> GetFormTypes()
        {
          return  formTypeDAO.GetFormTypes();
        }

        public void RemoveFormTypebyID(Guid Id)
        {
            formTypeDAO.DeleteFormType(Id);
        }

        public void UpdateFormType(FormType formType)
        {
            formTypeDAO.UpdateFormType(formType);
        }
    }
}
