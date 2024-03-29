﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Manufacturer : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public IEnumerable<Brand>? Brands { get; set; }
    }
}
