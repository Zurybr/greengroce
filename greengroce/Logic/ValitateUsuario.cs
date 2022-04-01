using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using greengroce.Models;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace greengroce.Logic
{
    public class ValidateUsuario : BussinesData
    {
        private Usuario model { get; set; }
        public ValidateUsuario(Usuario Usuario)
        {

            model = Usuario;
            model.Status = true;
            model.IsDelete = false;
        }
        public ValidateUsuario()
        {
            //dbContext = new AppDbContext();

        }
        public List<Usuario> Get()
        {
            try
            {
                return dbContext.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Usuario GetById(short id)
        {
            try
            {
                return dbContext.Usuarios.Find(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public List<Usuario> Get(Usuario model)
        {
            try
            {
                //var Query = from s in dbContext.Usuarios select s;
                //if (model.Status != false)
                //    Query = Query.Where(c => c.Status == model.Status);
                //if (model.IsDelete != false)
                //    Query = Query.Where(c => c.IsDelete == model.IsDelete);
                var Query = from s in dbContext.Usuarios select s;
                Query = Query.Where(c => c.Status == true && c.IsDelete == false);
                return Query.OrderByDescending(C => C.IdUsuario).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Usuario Insert()
        {
            if (model == null)
                throw new ApplicationException();
            try
            {
                var enc = Encoding.GetEncoding(0);
                byte[] buffer = enc.GetBytes("Mexico00");
                var sha1 = SHA1.Create();
                var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
                var max = dbContext.Usuarios.Max(c => c.IdUsuario) + 1;
                //model.IdUsuario = (short)max;
                model.Password = hash.ToString();
                model.FechaAlta = DateTime.Now;
                model.FechaModificacion = DateTime.Now;
                model.Status = true;
                model.IsDelete = false;
                dbContext.Usuarios.Add(model);
                dbContext.SaveChanges();
                return GetById();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Usuario Update()
        {
            if (model == null)
                throw new ApplicationException();
            try
            {
                var enc = Encoding.GetEncoding(0);
                byte[] buffer = enc.GetBytes("Mexico00");
                var sha1 = SHA1.Create();
                var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
                model = dbContext.Usuarios.Find(model.IdUsuario);
                model.Password = hash.ToString();
                model.FechaModificacion = DateTime.Now;
                dbContext.Entry(model).State = EntityState.Modified;
                dbContext.SaveChanges();
                return GetById();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Usuario GetById()
        {
            return dbContext.Usuarios/*.Include(c => c.Status)*/.Where(c => c.ClaveUsuario == model.ClaveUsuario && c.IdUsuario == dbContext.Usuarios.Max(c => c.IdUsuario)).First();
        }
        public void Delete(short IdUsuario)
        {
            if (IdUsuario == 0)
                throw new ApplicationException();
            model = dbContext.Usuarios.Find(IdUsuario);
            if (model == null)
                throw new ApplicationException();
            try
            {
                //dbContext.Usuarios.Attach(model);
                //dbContext.Entry(model).State = EntityState.Deleted;
                model.FechaModificacion = DateTime.Now;
                model.IsDelete = true;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
    }
}
