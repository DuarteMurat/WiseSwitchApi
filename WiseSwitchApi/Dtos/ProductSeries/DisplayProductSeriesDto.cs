namespace WiseSwitchApi.Dtos.ProductSeries
{
    public class DisplayProductSeriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductLineName { get; set; }

        public IEnumerable<string> SwitchModelsNames { get; set; }
    }
}
