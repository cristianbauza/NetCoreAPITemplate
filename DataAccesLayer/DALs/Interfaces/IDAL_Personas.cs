using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.DALs.Interfaces
{
    public interface IDAL_Personas
    {
        List<Persona> GetAll();

        Persona Get(long id);

        Persona Add(Persona x);

        Persona Update(Persona x);
    }
}
