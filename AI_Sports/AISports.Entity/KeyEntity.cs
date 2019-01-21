using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Entity
{
    [Serializable]
    [Table("s_key")]
    public class KeyEntity
    {
        [ExplicitKey]
        public string Key_id { get; set; }
        public long Max_value { get; set; } = 0;
        [Write(false)]
        public long LastValue { get; set; }
        public int Steps { get; set; }

        public long GetNextValue()
        {
            LastValue++;
            if (LastValue > Max_value)
                return 0;
           
            return LastValue;
        }
    }
}
