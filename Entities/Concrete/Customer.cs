﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        //bir dakika geleceğim tmm
        //bu burda dursun pasif olarakü
        [Key]
        
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string CompanyName { get; set; }     
   
    }
}
