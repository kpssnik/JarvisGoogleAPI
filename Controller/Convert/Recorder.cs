using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JarvisGoogleAPI.Tools;
using NAudio.Wave;

namespace JarvisGoogleAPI.Controller.Convert
{
    public class Recorder
    {
        private WaveIn waveIn;
        private WaveFileWriter writer;
        private bool isRecording = false;

        // Core functions

        public void StartRecording()
        {
            if (isRecording == false)
            {
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);
                waveIn.WaveFormat = new WaveFormat(Config.Rate, 1);
                writer = new WaveFileWriter(Config.AudioFileName, waveIn.WaveFormat);

                waveIn.StartRecording();
                isRecording = true;
            }
        }

        public void StopRecording()
        {
            if (isRecording == true)
            {
                waveIn.StopRecording();

                isRecording = false;

                if (waveIn != null)
                {
                    waveIn.Dispose();
                    waveIn = null;
                }

                if (writer != null)
                {
                    writer.Close();
                    writer = null;

                }
            }

        }

        // Events
        public void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.WriteData(e.Buffer, 0, e.BytesRecorded);
        }
        public void waveIn_RecordingStopped(object sender, EventArgs e)
        {
        }
    }
}
