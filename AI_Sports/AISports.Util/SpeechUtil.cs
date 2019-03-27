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
            try
            {
                speech.SelectVoice("Microsoft Huihui Desktop");
                //speech.SelectVoice("Microsoft Lili");
                //speech.Rate = -3;
                //调整语速
                speech.Rate = -1;
                //先停止别的语音再重新说
                speech.SpeakAsyncCancelAll();
                //播放语音
                speech.Speak(text);
            }
            catch (Exception)
            {

                Console.WriteLine("语音停止播放");
            }
                
            
           
               
          
            
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
