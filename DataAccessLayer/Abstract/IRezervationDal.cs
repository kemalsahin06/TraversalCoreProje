using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRezervationDal : IGenericDal<Rezervation>
    {
        List<Rezervation> GetListWithReservationByWaitAprroval(int id); // onay bekleyen
        List<Rezervation> GetListWithReservationByAccepted(int id); // Kabul edilen
        List<Rezervation> GetListWithReservationByPrevious(int id); // geçmiş rezervasyon
    }
}
