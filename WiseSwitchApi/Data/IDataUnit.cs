using WiseSwitchApi.Repository.Interfaces;

namespace WiseSwitchApi.Data
{
    public interface IDataUnit
    {
        IBrandRepository Brands { get; }
        IManufacturerRepository Manufacturers { get; }
        IProductLineRepository ProductLines { get; }
        IProductSeriesRepository ProductSeries { get; }
        IUserRepository Users { get; }
        ISwitchModelRepository SwitchModels { get; }
        IFirmwareVersionRepository FirmwareVersions { get; }

        Task<int> SaveChangesAsync();
    }
}