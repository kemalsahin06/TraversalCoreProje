using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RezervationManager : IRezervationServices
    {
        IRezervationDal _rezervationDal;

        public RezervationManager(IRezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }

        public List<Rezervation> GetListApprovalRezervation(int id)
        {
           return _rezervationDal.GetListByFilter(x=>x.AppUserId == id && x.ReservationStatus=="Onay Bekliyor" );
        }

        public void TAdd(Rezervation t)
        {
            _rezervationDal.Insert(t);
        }

        public void TDelete(Rezervation t)
        {
            throw new NotImplementedException();
        }

        public Rezervation TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rezervation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Rezervation t)
        {
            throw new NotImplementedException();
        }
    }
}
