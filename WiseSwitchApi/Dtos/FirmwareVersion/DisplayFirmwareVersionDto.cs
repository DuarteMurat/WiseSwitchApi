namespace WiseSwitchApi.Dtos.FirmwareVersion
{
    public class DisplayFirmwareVersionDto: IDisplayModel
    {
        public int Id { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> SwitchModelsNames { get; set; }
    }
}
