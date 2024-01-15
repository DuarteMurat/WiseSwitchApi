using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    [Index(nameof(ProductLineId), nameof(Name), IsUnique = true)]
    public class ProductSeries : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int ProductLineId { get; set; }

        public ProductLine ProductLine { get; set; }

        public IEnumerable<SwitchModel>? SwitchModel { get; set; }
    }
}
