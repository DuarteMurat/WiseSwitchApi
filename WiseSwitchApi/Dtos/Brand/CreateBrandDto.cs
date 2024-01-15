namespace WiseSwitchApi.Dtos.Brand
{
    public class CreateBrandDto : ICreateModel
    {
        public string Name { get; set; }


        public int ManufacturerId { get; set; }
    }
}
