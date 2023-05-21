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
    public class ReservaDALImpl : IReservaDAL
    {
        DBProyectoContext context;
        private UnidadDeTrabajo<Reserva> unidad;

        public ReservaDALImpl()
        {
            context = new DBProyectoContext();

        }

        public ReservaDALImpl(DBProyectoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Reserva entity)
        {
            try
            {
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
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

        public void AddRange(IEnumerable<Reserva> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> Find(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reserva Get(int id)
        {
            Reserva reservation;
            using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
            {

                reservation = unidad.genericDAL.Get(id);
            }
            return reservation;
        }

        public IEnumerable<Reserva> GetAll()
        {
            try
            {
                IEnumerable<Reserva> bookings;
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
                {
                    bookings = unidad.genericDAL.GetAll();
                }
                return bookings;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Reserva entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
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

        public void RemoveRange(IEnumerable<Reserva> entities)
        {
            throw new NotImplementedException();
        }

        public Reserva SingleOrDefault(Expression<Func<Reserva, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reserva entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(context))
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

        IEnumerable<Reserva> IDALGenerico<Reserva>.GetAll()
        {
            IEnumerable<Reserva> reservas = null;
            using (unidad = new UnidadDeTrabajo<Reserva>(context))
            {
                reservas = unidad.genericDAL.GetAll();
            }
            return reservas;
        }
    }
}
