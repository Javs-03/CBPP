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
    public class CabinaDALImpl : ICabinaDAL
    {
        DBProyectoContext context;
        private UnidadDeTrabajo<Cabina> unidad;

        public CabinaDALImpl()
        {
            context = new DBProyectoContext();

        }

        public CabinaDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Cabina entity)
        {
            try
            {
                using (UnidadDeTrabajo<Cabina> unidad = new UnidadDeTrabajo<Cabina>(context))
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

        public void AddRange(IEnumerable<Cabina> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cabina> Find(Expression<Func<Cabina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cabina Get(int id)
        {
            Cabina cabin;
            using (UnidadDeTrabajo<Cabina> unidad = new UnidadDeTrabajo<Cabina>(context))
            {

                cabin = unidad.genericDAL.Get(id);
            }
            return cabin;
        }

        public IEnumerable<Cabina> GetAll()
        {
            try
            {
                IEnumerable<Cabina> booths;
                using (UnidadDeTrabajo<Cabina> unidad = new UnidadDeTrabajo<Cabina>(context))
                {
                    booths = unidad.genericDAL.GetAll();
                }
                return booths;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Cabina entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Cabina> unidad = new UnidadDeTrabajo<Cabina>(context))
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

        public void RemoveRange(IEnumerable<Cabina> entities)
        {
            throw new NotImplementedException();
        }

        public Cabina SingleOrDefault(Expression<Func<Cabina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cabina entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Cabina> unidad = new UnidadDeTrabajo<Cabina>(context))
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

        IEnumerable<Cabina> IDALGenerico<Cabina>.GetAll()
        {
            IEnumerable<Cabina> cabinas = null;
            using (unidad = new UnidadDeTrabajo<Cabina>(context))
            {
                cabinas = unidad.genericDAL.GetAll();
            }
            return cabinas;
        }
    }
}
