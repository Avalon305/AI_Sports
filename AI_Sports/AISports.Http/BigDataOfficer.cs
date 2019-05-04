using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Http.Dto;
using AI_Sports.AISports.Http.Entity;
using AI_Sports.AISports.Util;
using AI_Sports.Service;
using spms.http.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http
{
    //大数据交互指挥官
    public class BigDataOfficer
    {
        private static string WEBSUCCESS = "success";

        private static string WEBQUESTION = "failed";

        //SetterDAO里面有插入刷新功能
        //SetterDAO setterDao = new SetterDAO();
        UploadManagementService uploadManagementService = new UploadManagementService();





        //定时器轮询方法
        public void Run()
        {
            /*
            if (setterDao.ListAll() == null)
            {
                //网路不通 或 未注册 不上传
                return;
            }*/

            //Console.WriteLine("大数据线程实例化run方法-执行:");
            var result = uploadManagementService.ListLimit20();
            if (result == null)
            {
                ;//Console.WriteLine("大数据线程RUN方法-result==null");
            }
            foreach (var uploadManagementone in result)
            {
                SendMsgDTO sendMsgDto = new SendMsgDTO();
                UploadManagement uploadManagement = new UploadManagement();
                uploadManagement = uploadManagementone;


                //选择是那一个类，将类名进行赋值
                switch (uploadManagement.UM_DataTable)
                {
                    case "bdl_activity":
                        sendMsgDto.dataType = "ActivityEntity";
                        break;
                    case "bdl_member":
                        sendMsgDto.dataType = "MemberEntity";
                        break;
                    case "bdl_personal_setting":
                        sendMsgDto.dataType = "PersonalSettingEntity";
                        break;
                    case "bdl_skeleton_length":
                        sendMsgDto.dataType = "SkeletonLengthEntity";
                        break;
                    case "bdl_system_setting":
                        sendMsgDto.dataType = "SystemSettingEntity";
                        break;
                    case "bdl_training_activity_record":
                        sendMsgDto.dataType = "TrainingActivityRecordEntity";
                        break;

                    case "bdl_training_course":
                        sendMsgDto.dataType = "TrainingCourseEntity";
                        break;
                    case "bdl_training_device_record":
                        sendMsgDto.dataType = "TrainingDeviceRecordEntity";
                        break;
                    case "bdl_training_plan":
                        sendMsgDto.dataType = "TrainingPlanEntity";
                        break;
                    default:
                        Console.WriteLine("没有这个表");
                        Console.WriteLine(uploadManagement.UM_DataTable);
                        break;
                }

                //sendMsgDto.dataType = "TrainingCourseEntity";


                sendMsgDto.dataExec = uploadManagement.UM_Exec;
                sendMsgDto.dataId = uploadManagement.UM_DataId;
                sendMsgDto.belongProduct = "aisport";
                //sendMsgDto.content = JsonTools.Obj2JSONStrNew <TrainingCourseEntity>
                // Console.WriteLine("大数据线程实例化Upload方法-table:" + uploadManagement.UM_DataTable);
                //1.查询
                ServiceResult serviceResult = uploadManagementService.GetServiceResult(uploadManagement);
                sendMsgDto.content = serviceResult.Data;
                int i = 1;
                Console.WriteLine("这里是上传表的每一条内容" + i + "数字" + uploadManagement.Pk_UM_Id + uploadManagement.UM_DataId + uploadManagement.UM_Exec);
                i++;
                if (serviceResult == null)
                {
                    //没有查到返回
                    Console.WriteLine("没有查到信息");
                    return;
                }
                //用于接受云服务器端返回的字符串
                string strWebResult = "";
                //创建一个新的用来接受服务器端返回结果的实体类对象
                WebResult webResult = new WebResult();
                //固定的url
                serviceResult.URL = "msg";
                

                serviceResult.Data = JsonTools.Obj2JSONStrNew<SendMsgDTO>(sendMsgDto);

                try
                {
                    //2.上传
                    //返回的值
                    strWebResult = HttpSender.POSTByJsonStr(serviceResult.URL, serviceResult.Data);
                }
                catch
                {
                    Console.WriteLine("发送失败");
                }
                
                if(strWebResult!=null)
                {
                    //将接受云服务器的字符串装换成实体类对象
                    webResult = JsonTools.DeserializeJsonToObject<WebResult>(strWebResult);
                    //3.根据结果删除，返回信息中是否包括0和1，包括就删除

                    if (webResult.result == "0")
                    {
                        uploadManagementService.deleteByPrimaryKey(uploadManagement.Pk_UM_Id);
                    }
                    else
                     if (webResult.result == "1")
                    {
                        uploadManagementService.deleteByPrimaryKey(uploadManagement.Pk_UM_Id);
                    }
                    else
                     if (webResult.result == "2")
                    {
                        break;//不做处理，五分钟后再发，目的是等待云服务器建表
                    }
                }
                else
                {
                    Console.WriteLine("云端返回为空");
                    //return;
                }
                

            }



        }

    }


}

