﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductLine : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public IEnumerable<ProductSeries>? ProductSeries { get; set; }
    }
}
