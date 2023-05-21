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
    public class RolDALImpl : IRolDAL
    {
        DBProyectoContext context;
        private UnidadDeTrabajo<Rol> unidad;

        public RolDALImpl()
        {
            context = new DBProyectoContext();

        }

        public RolDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Rol entity)
        {
            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
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

        public void AddRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> Find(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Rol Get(int id)
        {
            Rol rol;
            using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
            {

                rol = unidad.genericDAL.Get(id);
            }
            return rol;
        }

        public IEnumerable<Rol> GetAll()
        {
            try
            {
                IEnumerable<Rol> roles;
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
                {
                    roles = unidad.genericDAL.GetAll();
                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Rol entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
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

        public void RemoveRange(IEnumerable<Rol> entities)
        {
            throw new NotImplementedException();
        }

        public Rol SingleOrDefault(Expression<Func<Rol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rol entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Rol> unidad = new UnidadDeTrabajo<Rol>(context))
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

        IEnumerable<Rol> IDALGenerico<Rol>.GetAll()
        {
            IEnumerable<Rol> roles = null;
            using (unidad = new UnidadDeTrabajo<Rol>(context))
            {
                roles = unidad.genericDAL.GetAll();
            }
            return roles;
        }
    }
}
