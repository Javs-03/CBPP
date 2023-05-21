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
    public class ClienteDALImpl : IClienteDAL
    {
        DBProyectoContext context;
        private UnidadDeTrabajo<Cliente> unidad;

        public ClienteDALImpl()
        {
            context = new DBProyectoContext();

        }

        public ClienteDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Cliente entity)
        {
            try
            {
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
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

        public void AddRange(IEnumerable<Cliente> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> Find(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int id)
        {
            Cliente client;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
            {

                client = unidad.genericDAL.Get(id);
            }
            return client;
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                IEnumerable<Cliente> clients;
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    clients = unidad.genericDAL.GetAll();
                }
                return clients;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Cliente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
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

        public void RemoveRange(IEnumerable<Cliente> entities)
        {
            throw new NotImplementedException();
        }

        public Cliente SingleOrDefault(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
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

        IEnumerable<Cliente> IDALGenerico<Cliente>.GetAll()
        {
            IEnumerable<Cliente> clientes = null;
            using (unidad = new UnidadDeTrabajo<Cliente>(context))
            {
                clientes = unidad.genericDAL.GetAll();
            }
            return clientes;
        }
    }
}
