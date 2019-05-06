using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class SendMsgDTO
    {
        //该数据是更新还是增加 add = 0/update = 1
        public int dataExec;
        //该数据所属的实体类的名字 User/Coach/Traininfo
        public String dataType;
        //该数据在客户端的id
        public long dataId;
        
        //所属产品线，具体产品名字看bigdataconstant类
        public String belongProduct;
        //数据内容，是具体实体的json串。
        public String content;
        


    }
}
