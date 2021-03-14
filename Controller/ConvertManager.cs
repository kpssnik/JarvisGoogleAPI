﻿using JarvisGoogleAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JarvisGoogleAPI.Controller.Convert;

namespace JarvisGoogleAPI.Controller
{
    public class ConvertManager
    {
        private bool isRecording = false;
        private Recorder recorder = new Recorder();
        private Recognizer recognizer = new Recognizer();

        private string result = null;
        public string Result { get { return result; } }

        // Returns true when recording finished and result is ready
        public bool DoRecord(KeyEventArgs e)
        {
            if (e.KeyCode == Config.RecordKey)
            {
                if (isRecording == false)
                {
                    recorder.StartRecording();
                    isRecording = true;
                    return false;
                }
                else
                {
                    recorder.StopRecording();

                    result = recognizer.RecognizeTextFromWav();
                    isRecording = false;
                    //MessageBox.Show(result);      
                    return true;
                }
            }

            return false;
        }



    }
}
