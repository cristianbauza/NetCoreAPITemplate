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
        private readonly ApplicationDbContext _db;

        public DAL_Personas_EFCore(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Persona> GetAll()
        {
            List<Persona> result = new List<Persona>();
            _db.Personas.ToList().ForEach(y => result.Add(y.GetEntity()));
            return result;
        }

        public Persona Get(long id)
        {
            return _db.Personas.Find(id)?.GetEntity();
        }

        public Persona Add(Persona x)
        {
            Personas aux = Personas.GetEntityToSave(x);
            _db.Personas.Add(aux);
            _db.SaveChanges();
            return aux.GetEntity();
        }

        public Persona Update(Persona x)
        {
            Personas aux = Personas.GetEntityToSave(x);
            _db.Personas.Attach(aux);
            _db.SaveChanges();
            return aux.GetEntity();
        }
    }
}
