﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Brand : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }


        public IEnumerable<ProductLine> ProductLines { get; set; }
    }
}
