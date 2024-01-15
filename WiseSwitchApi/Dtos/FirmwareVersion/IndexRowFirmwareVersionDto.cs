namespace WiseSwitchApi.Dtos.FirmwareVersion
{
    public class IndexRowFirmwareVersionDto : IIndexRow
    {
        public int Id { get; set; }

        public string Version { get; set; }

        public DateTime? LaunchDate { get; set; }
    }
}
