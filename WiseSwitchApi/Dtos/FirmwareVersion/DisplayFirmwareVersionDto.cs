namespace WiseSwitchApi.Dtos.FirmwareVersion
{
    public class DisplayFirmwareVersionDto
    {
        public int Id { get; set; }

        public string Version { get; set; }

        public IEnumerable<string> SwitchModelsNames { get; set; }
    }
}
