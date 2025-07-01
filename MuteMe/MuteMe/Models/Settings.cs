using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuteMe.Models
{
    public class AppSettings
    {
        public int IdleTimeoutSeconds { get; set; } = 120;
        public int GracePeriodSeconds { get; set; } = 2;
        public bool MuteSystem { get; set; } = true;
        public bool MuteMic { get; set; } = true;
        public bool ShowNotifications { get; set; } = true;
    }
}
