﻿namespace WiseSwitchApi.Dtos.Brand
{
    public class EditBrandDto : IEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int ManufacturerId { get; set; }
    }
}
