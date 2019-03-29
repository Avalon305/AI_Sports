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
        public static SpeechSynthesizer speech = new SpeechSynthesizer();

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
                //停止
                speech.SpeakAsyncCancelAll();
            }
            catch (Exception)
            {

                Console.WriteLine("语音播放异常");
            }






        }

        /// <summary>
        /// 停止语音
        /// </summary>
        public static void stop()
        {
            try
            {
                speech.SpeakAsyncCancelAll();
                //speech.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("停止语音异常");
            }
           

        }

    }
}
