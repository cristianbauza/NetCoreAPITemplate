using DataAccesLayer.DALs.Interfaces;
using DataAccesLayer.Models;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.DALs.Implementatios
{
    public class DAL_Personas_EFCore : IDAL_Personas
    {
        public List<Persona> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Persona> result = new List<Persona>();
                db.Personas.ToList().ForEach(y => result.Add(y.GetEntity()));
                return result;
            }
        }

        public Persona Get(long id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Personas.Find(id)?.GetEntity();
            }
        }

        public Persona Add(Persona x)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Personas aux = Personas.GetEntityToSave(x);
                db.Personas.Add(aux);
                db.SaveChanges();
                return aux.GetEntity();
            }
        }

        public Persona Update(Persona x)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Personas aux = Personas.GetEntityToSave(x);
                db.Personas.Attach(aux);
                db.SaveChanges();
                return aux.GetEntity();
            }
        }
    }
}
