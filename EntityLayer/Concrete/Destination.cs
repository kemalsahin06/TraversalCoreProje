﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }

        /* -( Will be getting Destination City from City Table )- */
        public string CityName { get; set; }

        public string DayNight { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public string Image2 { get; set; }

        public string CoverImage { get; set; }

        public string Description { get; set; }

        public string Details1 { get; set; }

        public string Details2 { get; set; }

        public int Capacity { get; set; }

        public DateTime BlogDate { get; set; }

        public bool Status { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Rezervation> Rezervations { get; set; }


        public int? GuideID { get; set; }
        public Guide Guide { get; set; }
    }
}
