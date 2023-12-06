using WiseSwitchApi.Data;
using WiseSwitchApi.Entities;

namespace WiseSwitchApi.Helpers
{
    public class DataHelper
    {
        private readonly IDataUnit _dataUnit;

        public DataHelper(IDataUnit dataUnit)
        {
            _dataUnit = dataUnit;
        }


        // Get data.
        public async Task<object> GetDataAsync(string dataOperation, object value)
        {
            switch (dataOperation)
            {
                case DataOperations.GetAllManufacturersOrderByName: return await _dataUnit.Manufacturers.GetAllOrderByName();
                case DataOperations.GetComboManufacturers: return await _dataUnit.Manufacturers.GetComboManufacturersAsync();
                case DataOperations.GetDisplayManufacturer: return await _dataUnit.Manufacturers.GetDisplayDtoAsync((int)value);
                case DataOperations.GetExistsManufacturer: return await _dataUnit.Manufacturers.ExistsAsync((int)value);
                case DataOperations.GetModelManufacturer: return await _dataUnit.Manufacturers.GetAsNoTrackingByIdAsync((int)value);

                default: throw new InvalidOperationException(dataOperation);
            };
        }


        // Post data.
        public async Task<IEntity> PostDataAsync(string dataOperation, object value)
        {
            var posted = dataOperation switch
            {
                DataOperations.CreateManufacturer => await _dataUnit.Manufacturers.CreateAsync(value as Manufacturer),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return posted;
        }


        // Put data.
        public async Task<IEntity> PutDataAsync(string dataOperation, object value)
        {
            var putted = dataOperation switch
            {
                DataOperations.UpdateManufacturer => _dataUnit.Manufacturers.Update(value as Manufacturer),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return putted;
        }


        // Delete data.
        public async Task<IEntity> DeleteDataAsync(string dataOperation, object value)
        {
            var deleted = dataOperation switch
            {
                DataOperations.DeleteManufacturer => await _dataUnit.Manufacturers.DeleteAsync((int)value),

                _ => throw new InvalidOperationException(dataOperation)
            };

            // Save changes.
            try { await _dataUnit.SaveChangesAsync(); }
            catch { throw; }

            return deleted;
        }
    }
}
