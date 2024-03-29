﻿using System.ComponentModel.DataAnnotations;
using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Entities
{
    public class SwitchModel : IEntity
    {
        public int Id { get; set; }

        string IEntity.Name => ModelName;


        [Required]
        public string ModelName { get; set; }

        [Required]
        public string ModelYear { get; set; }


        public int ProductSeriesId { get; set; }

        public ProductSeries ProductSeries { get; set; }


        public int DefaultFirmwareVersionId { get; set; }

        public FirmwareVersion DefaultFirmwareVersion { get; set; }


        public int? ScriptId { get; set; }

        public Script Script { get; set; }


        public int? TutorialId { get; set; }

        public Tutorial Tutorial { get; set; }
    }
}
