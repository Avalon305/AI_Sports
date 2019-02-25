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
        public static void read(string text)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SelectVoice("Microsoft Huihui Desktop");
            //speech.SelectVoice("Microsoft Lili");
            speech.Rate = -3;
            speech.Speak(text);
        }
    }
}
