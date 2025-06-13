using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuteMe.Services
{
    using NAudio.CoreAudioApi;

    public class AudioController
    {
        private static readonly MMDeviceEnumerator enumerator = new MMDeviceEnumerator();

        public static void MuteSystemAudio(bool mute)
        {
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.Mute = mute;
        }

        public static void MuteMic(bool mute)
        {
            var mic = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
            mic.AudioEndpointVolume.Mute = mute;
        }
    }

}
