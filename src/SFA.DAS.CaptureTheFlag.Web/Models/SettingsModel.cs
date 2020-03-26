using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models
{
    public class SettingsModel
    {
        public int MusicVolume { get; set; }
        public int SoundEffectsVolume { get; set; }
        public Graphics GraphicsDetail { get; set; }
    }

    public enum Graphics
    {
        Low, Medium, High
    }

}

