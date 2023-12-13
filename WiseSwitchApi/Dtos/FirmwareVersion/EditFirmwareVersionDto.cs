namespace WiseSwitchApi.Dtos.FirmwareVersion
{
    public class EditFirmwareVersionDto
    {
        public int Id { get; set; }

        public string Version { get; set; }

        public DateTime? LaunchDate { get; set; }
    }
}
