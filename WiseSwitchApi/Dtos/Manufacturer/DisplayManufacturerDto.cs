namespace WiseSwitchApi.Dtos.Manufacturer
{
    public class DisplayManufacturerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public IEnumerable<string> BrandsNames { get; set; }
    }
}
