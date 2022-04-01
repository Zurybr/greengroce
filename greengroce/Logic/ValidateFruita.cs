using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using greengroce.Models;
using System.Collections.Generic;

namespace greengroce.Logic
{
    public class ValidateFruta:BussinesData
    {
        private Fruta model { get; set; }
       
        public ValidateFruta(Fruta Fruta)
        {
           
            model = Fruta;
            model.Status = true;
            model.IsDelete = false;
        }
        public ValidateFruta()
        {
                //dbContext = new AppDbContext();

        }
        public List<Fruta> Get()
        {
            try
            {
                return dbContext.Frutas.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Fruta GetById(short id)
        {
            try
            {
                return dbContext.Frutas.Find(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public List<Fruta> Get(Fruta model)
        {
            try
            {
                //var Query = from s in dbContext.Frutas select s;
                //if (model.Status != false)
                //    Query = Query.Where(c => c.Status == model.Status);
                //if (model.IsDelete != false)
                //    Query = Query.Where(c => c.IsDelete == model.IsDelete);
                var Query = from s in dbContext.Frutas select s;
                    Query = Query.Where(c => c.Status == true && c.IsDelete == false);
                return Query.OrderByDescending(C => C.IdFruta).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Fruta Insert()
        {
            if (model == null)
                throw new ApplicationException();
            try
            {
                var max = dbContext.Frutas.Max(c => c.IdFruta) + 1;
                model.ClaveFruta = model.Nombre.Substring(0, 3) + "00" + max.ToString();
                model.FechaAlta = DateTime.Now;
                model.FechaModificacion = DateTime.Now;
                model.Status = true;
                model.IsDelete = false;
                dbContext.Frutas.Add(model);
                dbContext.SaveChanges();
                return GetById();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GetException(1001, ex.ToString()));
            }
        }
        public Fruta Update()
        {
            if (model == null)
                throw new ApplicationException();
            try
            {
                model = dbContext.Frutas.Find(model.IdFruta);
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
        public Fruta GetById()
        {
            return dbContext.Frutas/*.Include(c => c.Status)*/.Where(c => c.ClaveFruta == model.ClaveFruta && c.IdFruta == dbContext.Frutas.Max(c => c.IdFruta)).First();
        }
        public void Delete(short IdFruta)
        {
            if (IdFruta == 0)
                throw new ApplicationException();
            model = dbContext.Frutas.Find(IdFruta);
            if (model == null)
                throw new ApplicationException();
            try
            {
                //dbContext.Frutas.Attach(model);
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
