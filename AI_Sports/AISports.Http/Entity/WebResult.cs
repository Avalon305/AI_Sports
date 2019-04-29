using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spms.http.entity
{
    /// <summary>
    /// 用于云服务器返回的数据
    /// </summary>
    public class WebResult
    {
        //数据id
        public string dataId;
        //数据所在实体类
        public string dataType;
        //返回结果(内容是0或1，2 这是用来判断上传结果)
        public string result;

    }
}
