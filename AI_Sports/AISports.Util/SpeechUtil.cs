using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Util
{
    class SpeechUtil
    {
        private static SpeechSynthesizer speech = new SpeechSynthesizer();

        public static void read(string text)
        {
           
                speech.SelectVoice("Microsoft Huihui Desktop");
                //speech.SelectVoice("Microsoft Lili");
                speech.Rate = -3;
                speech.Speak(text);
          
            
        }
        /// <summary>
        /// 停止语音
        /// </summary>
        public static void stop()
        {
            speech.Dispose();
        }

    }
}
