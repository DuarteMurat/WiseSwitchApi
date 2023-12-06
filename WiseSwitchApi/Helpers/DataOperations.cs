namespace WiseSwitchApi.Helpers
{
    public static class DataOperations
    {
        // Create.
        public const string CreateFirmwareVersion = "CreateFirmwareVersion";
        public const string CreateManufacturer = "CreateManufacturer";
        public const string CreateProductLine = "CreateProductLine";

        // Delete.
        public const string DeleteManufacturer = "DeleteManufacturer";
        public const string DeleteProductLine = "DeleteProductLine";

        // -- Get --

        // ProductLine.
        public const string GetAllProductLinesOrderByName = "AllProductLinesOrderByName";
        public const string GetComboProductLines = "ComboProductLines";
        public const string GetDisplayProductLine = "DisplayProductLine";
        public const string GetExistsProductLine = "ExistsProductLine";
        public const string GetModelProductLine = "ModelProductLine";
        // Manufacturer.
        public const string GetAllManufacturersOrderByName = "AllManufacturersOrderByName";
        public const string GetComboManufacturers = "ComboManufacturers";
        public const string GetDisplayManufacturer = "DisplayManufacturer";
        public const string GetExistsManufacturer = "ExistsManufacturer";
        public const string GetModelManufacturer = "ModelManufacturer";

        // Update.
        public const string UpdateManufacturer = "UpdateManufacturer";
        public const string UpdateProductLine = "UpdateProductLine";
    }
}
