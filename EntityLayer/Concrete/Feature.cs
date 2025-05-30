﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Post1Description { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}
