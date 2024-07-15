﻿using System.ComponentModel.DataAnnotations;

namespace BasicRestAPI.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }
        public string  Brand { get; set; }
        public string  Model { get; set; }
        public int Price { get; set; }
       
    }
}
