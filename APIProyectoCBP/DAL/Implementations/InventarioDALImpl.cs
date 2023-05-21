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
    public class InventarioDALImpl : IInventarioDAL
    {
        DBProyectoContext context;
        private UnidadDeTrabajo<Inventario> unidad;

        public InventarioDALImpl()
        {
            context = new DBProyectoContext();

        }

        public InventarioDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Inventario entity)
        {
            try
            {
                using (UnidadDeTrabajo<Inventario> unidad = new UnidadDeTrabajo<Inventario>(context))
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

        public void AddRange(IEnumerable<Inventario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventario> Find(Expression<Func<Inventario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Inventario Get(int id)
        {
            Inventario inventory;
            using (UnidadDeTrabajo<Inventario> unidad = new UnidadDeTrabajo<Inventario>(context))
            {

                inventory = unidad.genericDAL.Get(id);
            }
            return inventory;
        }

        public IEnumerable<Inventario> GetAll()
        {
            try
            {
                IEnumerable<Inventario> products;
                using (UnidadDeTrabajo<Inventario> unidad = new UnidadDeTrabajo<Inventario>(context))
                {
                    products = unidad.genericDAL.GetAll();
                }
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Inventario entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Inventario> unidad = new UnidadDeTrabajo<Inventario>(context))
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

        public void RemoveRange(IEnumerable<Inventario> entities)
        {
            throw new NotImplementedException();
        }

        public Inventario SingleOrDefault(Expression<Func<Inventario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Inventario entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Inventario> unidad = new UnidadDeTrabajo<Inventario>(context))
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

        IEnumerable<Inventario> IDALGenerico<Inventario>.GetAll()
        {
            IEnumerable<Inventario> inventarios = null;
            using (unidad = new UnidadDeTrabajo<Inventario>(context))
            {
                inventarios = unidad.genericDAL.GetAll();
            }
            return inventarios;
        }
    }
}
