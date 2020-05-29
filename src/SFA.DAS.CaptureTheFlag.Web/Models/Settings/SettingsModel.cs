using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAS_Capture_The_Flag.Models.Settings
{
    public class SettingsModel
    {
        [Key]
        public int SettingsId { get; set; }
        public int MusicVolume { get; set; }
        public int SoundEffectsVolume { get; set; }
        //public Graphics GraphicsDetail { get; set; }
        public string GraphicsDetail { get; set; }
    }

    //public enum Graphics
    //{
    //    Low,
    //    Medium,
    //    High
    //}
}
