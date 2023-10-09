using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRezervationDal : GenericRepository<Rezervation>, IRezervationDal
    {
        public List<Rezervation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.ReservationStatus == "Onaylandı" && x.AppUser.Id == id).ToList();

            }
        }

        public List<Rezervation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.ReservationStatus == "Geçmiş Rezervasyonlar" && x.AppUser.Id == id).ToList();

            }
        }

        public List<Rezervation> GetListWithReservationByWaitAprroval(int id)
        {
            using (var context = new Context())
            {
                return context.Rezervations.Include(x => x.Destination).Where(x => x.ReservationStatus == "Onay Bekliyor" && x.AppUser.Id == id).ToList();

            }

        }
    }
}
