﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string ClientCompany { get; set; }
        public string ClientComment { get; set; }
        public string ClientTitle { get; set; }
        public string ImageURL { get; set; }

    }
}
