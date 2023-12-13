namespace WiseSwitchApi.Dtos.SwitchModel
{
    public class CreateSwitchModelDto
    {
        public string ModelName { get; set; }

        public string ModelYear { get; set; }


        public int DefaultFirmwareVersionId { get; set; }


        public int ProductSeriesId { get; set; }

        public int ProductLineId { get; set; }

        public int BrandId { get; set; }
    }
}
