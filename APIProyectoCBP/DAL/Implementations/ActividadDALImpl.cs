using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ActividadDALImpl : IActividadDAL
    {

        DBProyectoContext context;
        private UnidadDeTrabajo<Actividad> unidad;

        public ActividadDALImpl()
        {
            context = new DBProyectoContext();

        }

        public ActividadDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Actividad entity)
        {
            try
            {
                using (UnidadDeTrabajo<Actividad> unidad = new UnidadDeTrabajo<Actividad>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Actividad> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actividad> Find(Expression<Func<Actividad, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Actividad Get(int id)
        {
            Actividad activity;
            using (UnidadDeTrabajo<Actividad> unidad = new UnidadDeTrabajo<Actividad>(context))
            {

                activity = unidad.genericDAL.Get(id);
            }
            return activity;
        }

        public IEnumerable<Actividad> GetAll()
        {
            try
            {
                IEnumerable<Actividad> activities;
                using (UnidadDeTrabajo<Actividad> unidad = new UnidadDeTrabajo<Actividad>(context))
                {
                    activities = unidad.genericDAL.GetAll();
                }
                return activities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Actividad entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Actividad> unidad = new UnidadDeTrabajo<Actividad>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Actividad> entities)
        {
            throw new NotImplementedException();
        }

        public Actividad SingleOrDefault(Expression<Func<Actividad, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Actividad entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Actividad> unidad = new UnidadDeTrabajo<Actividad>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        IEnumerable<Actividad> IDALGenerico<Actividad>.GetAll()
        {
            IEnumerable<Actividad> actividades = null;
            using (unidad = new UnidadDeTrabajo<Actividad>(context))
            {
                actividades = unidad.genericDAL.GetAll();
            }
            return actividades;
        }
    }
}
