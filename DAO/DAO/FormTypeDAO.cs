using Entity.Dbcontext;
using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class FormTypeDAO
    {
        private readonly HumanDbcontext _context;
        public FormTypeDAO()
        {

            _context = new HumanDbcontext();
        }
        public List<FormType> GetFormTypes()
        {
            try
            {
                return _context.FormTypes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void AddNewFormTypes(FormType formType)
        {
            try
            {
                _context.Add(formType);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdateFormType(FormType formType)
        {
            try
            {
                var a = _context.FormTypes!.SingleOrDefault(c => c.TypeID == formType.TypeID);

                _context.Entry(a).CurrentValues.SetValues(formType);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteFormType(Guid Id)
        {
            try
            {
                var data = _context.FormTypes.Where(x => x.TypeID == Id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FormType GetFormTypeById(Guid Id)
        {
            try
            {
                var data = _context.FormTypes.SingleOrDefault(c => c.TypeID == Id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

