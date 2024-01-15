using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    public class FirmwareVersion : IEntity
    {
        public int Id { get; set; }

        string IEntity.Name => Version;


        [Required]
        public string Version { get; set; }

        public DateTime? LaunchDate { get; set; }


        public IEnumerable<SwitchModel>? SwitchModels { get; set; }
    }
}
