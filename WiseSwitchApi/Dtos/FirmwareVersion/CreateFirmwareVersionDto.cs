namespace WiseSwitchApi.Dtos.FirmwareVersion
{
    public class CreateFirmwareVersionDto : ICreateModel
    {
        public string Version { get; set; }

        public DateTime? LaunchDate { get; set; }
    }
}
