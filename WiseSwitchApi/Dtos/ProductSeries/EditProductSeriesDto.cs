﻿namespace WiseSwitchApi.Dtos.ProductSeries
{
    public class EditProductSeriesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int ProductLineId { get; set; }

        public int BrandId { get; set; }
    }
}
