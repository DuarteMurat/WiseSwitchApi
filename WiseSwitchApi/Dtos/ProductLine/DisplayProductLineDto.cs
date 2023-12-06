using System.Globalization;

namespace WiseSwitchApi.Dtos.ProductLine
{
    public class DisplayProductLineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public IEnumerable<string> ProductSeriesNames { get; set; }
    }
}
