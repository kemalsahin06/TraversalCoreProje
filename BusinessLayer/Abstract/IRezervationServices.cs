using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRezervationServices : IGenericService<Rezervation>
    {
        
        List<Rezervation> GetListWithReservationByWaitAprroval(int id);
        List<Rezervation> GetListWithReservationByPrevious(int id);
        List<Rezervation> GetListWithReservationByAccepted(int id);
    }
}
