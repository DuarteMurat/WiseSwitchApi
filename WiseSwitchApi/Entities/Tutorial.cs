﻿namespace WiseSwitchApi.Entities
{
    public class Tutorial
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
