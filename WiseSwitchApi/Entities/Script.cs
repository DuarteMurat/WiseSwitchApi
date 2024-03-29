﻿namespace WiseSwitchApi.Entities
{
    public class Script
    {
        public int Id { get; set; }

        public string Reset { get; set; }

        public string DeleteStartupConfig { get; set; }

        public string DeleteConfigFiles { get; set; }

        public string DeleteVlanFiles { get; set; }

        public string ConfigPorts { get; set; }

        public string DeletePortsConfig { get; set; }
    }
}
