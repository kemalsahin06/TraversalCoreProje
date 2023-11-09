using System;

namespace SıgnalIRApii.DAL
{
    public enum ECity
    {
        Antalya = 1,
        İzmir =2 ,
        İstanbul = 3,
        Ankara = 4,
        Malatya = 5,
        Edirne = 6,
        Bursa=7
    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
