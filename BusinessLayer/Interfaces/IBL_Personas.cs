using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Personas
    {
        List<Persona> GetAll();

        Persona Get(long id);

        Persona Add(Persona x);

        Persona Update(Persona x);
    }
}
