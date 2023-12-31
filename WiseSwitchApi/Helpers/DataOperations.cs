﻿namespace WiseSwitchApi.Helpers
{
    public static class DataOperations
    {
        // -- Create --
        public const string CreateBrand = "CreateBrand";
        public const string CreateFirmwareVersion = "CreateFirmwareVersion";
        public const string CreateManufacturer = "CreateManufacturer";
        public const string CreateProductLine = "CreateProductLine";
        public const string CreateProductSeries = "CreateProductSeries";
        public const string CreateSwitchModel = "CreateSwitchModel";

        // -- Delete --
        public const string DeleteBrand = "DeleteBrand";
        public const string DeleteFirmwareVersion = "DeleteFirmwareVersion";
        public const string DeleteManufacturer = "DeleteManufacturer";
        public const string DeleteProductLine = "DeleteProductLine";
        public const string DeleteProductSeries = "DeleteProductSeries";
        public const string DeleteSwitchModel = "DeleteSwitchModel";

        // -- Get --

        // Brand.
        public const string GetAllBrandsOrderByName = "AllBrandsOrderByName";
        public const string GetComboBrands = "ComboBrands";
        public const string GetDisplayBrand = "DisplayBrand";
        public const string GetEditModelBrand = "EditModelBrand";
        public const string GetExistsBrand = "ExistsBrand";
        public const string GetModelBrand = "ModelBrand";
        // Firmware Version.
        public const string GetAllFirmwareVersionsOrderByVersion = "AllFirmwareVersionsOrderByVersion";
        public const string GetComboFirmwareVersions = "ComboFirmwareVersions";
        public const string GetDisplayFirmwareVersion = "DisplayFirmwareVersion";
        public const string GetEditModelFirmwareVersion = "EditModelFirmwareVersion";
        public const string GetExistsFirmwareVersion = "ExistsFirmwareVersion";
        public const string GetModelFirmwareVersion = "ModelFirmwareVersion";
        // Manufacturer.
        public const string GetAllManufacturersOrderByName = "AllManufacturersOrderByName";
        public const string GetComboManufacturers = "ComboManufacturers";
        public const string GetDisplayManufacturer = "DisplayManufacturer";
        public const string GetEditModelManufacturer = "EditModelManufacturer";
        public const string GetExistsManufacturer = "ExistsManufacturer";
        public const string GetModelManufacturer = "ModelManufacturer";
        // Product Line.
        public const string GetAllProductLinesOrderByName = "AllProductLinesOrderByName";
        public const string GetBrandIdOfProductLine = "BrandIdOfProductLine";
        public const string GetComboProductLines = "ComboProductLines";
        public const string GetDisplayProductLine = "DisplayProductLine";
        public const string GetEditModelProductLine = "EditModelProductLine";
        public const string GetExistsProductLine = "ExistsProductLine";
        public const string GetModelProductLine = "ModelProductLine";
        public const string GetComboProductLinesOfBrand = "ComboProductLinesOfBrand";
        // Product Series.
        public const string GetAllProductSeriesOrderByName = "AllProductSeriesOrderByName";
        public const string GetComboProductSeries = "ComboProductSeries";
        public const string GetDependencyChainIdsOfProductSeries = "DependencyChainIdsOfProductSeries";
        public const string GetDisplayProductSeries = "DisplayProductSeries";
        public const string GetEditModelProductSeries = "EditModelProductSeries";
        public const string GetExistsProductSeries = "ExistsProductSeries";
        public const string GetModelProductSeries = "ModelProductSeries";
        public const string GetComboProductSeriesOfProductLine = "ComboProductSeriesOfProductLine";
        // Switch Model.
        public const string GetAllSwitchModelsOrderByModelName = "AllSwitchModelOrderByName";
        public const string GetCreateModelForSwitchModel = "CreateModelForSwitchModel";
        public const string GetComboSwitchModels = "ComboSwitchModel";
        public const string GetDisplaySwitchModel = "DisplaySwitchModel";
        public const string GetEditModelSwitchModel = "EditModelSwitchModel";
        public const string GetExistsSwitchModel = "ExistsSwitchModel";
        public const string GetModelSwitchModel = "ModelSwitchModel";


        // -- Update --
        public const string UpdateBrand = "UpdateBrand";
        public const string UpdateFirmwareVersion = "UpdateFirmwareVersion";
        public const string UpdateManufacturer = "UpdateManufacturer";
        public const string UpdateProductLine = "UpdateProductLine";
        public const string UpdateProductSeries = "UpdateProductSeries";
        public const string UpdateSwitchModel = "UpdateSwitchModel";
    }
}
