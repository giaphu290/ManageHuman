using Entity.Dbcontext;
using Entity.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class FormDAO
    {
        private readonly HumanDbcontext _context;
        public FormDAO()
        {

            _context = new HumanDbcontext();
        }
        public List<Form> GetForms()
        {
            try
            {
                return _context.Forms.Include(x => x.FormType).Include(x => x.Users).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void AddNewForms(Form form)
        {
            try
            {
                _context.Add(form);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdateForm(Form form)
        {
            try
            {
                var a = _context.Forms!.SingleOrDefault(c => c.FormID == form.FormID);

                _context.Entry(a).CurrentValues.SetValues(form);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteForm(Guid id)
        {
            try
            {
                var data = _context.Forms.Where(x => x.FormID == id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Form GetFormById(Guid id)
        {
            try
            {
                var data = _context.Forms.SingleOrDefault(c => c.FormID == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

