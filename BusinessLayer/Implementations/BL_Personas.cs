using BusinessLayer.Interfaces;
using DataAccesLayer.DALs.Interfaces;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class BL_Personas : IBL_Personas
    {
        private IDAL_Personas _dal;

        public BL_Personas(IDAL_Personas dal)
        {
            _dal = dal;
        }

        public List<Persona> GetAll()
        {
            return _dal.GetAll();
        }

        public Persona Get(long id)
        {
            return _dal.Get(id);
        }

        public Persona Add(Persona x)
        {
            return _dal.Add(x);
        }

        public Persona Update(Persona x)
        {
            return _dal.Update(x);
        }
    }
}
