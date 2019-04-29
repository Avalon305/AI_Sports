
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_Sports.Dao;

using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Http.Entity;
using AI_Sports.Entity;
using AI_Sports.AISports.Util;
using AI_Sports.AISports.Dto;
using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Http.Dto;

namespace AI_Sports.Service
{
    class UploadManagementService
    {
        /// <summary>
        /// 查询20条数据
        /// </summary>
        /// <returns></returns>
        public List<UploadManagement> ListLimit20()
        {
            //Console.WriteLine("ListLimit20()-执行");
            return new UploadManagementDAO().ListLimit20();
        }

        /// <summary>
        /// 根据主键ID删除
        /// </summary>
        /// <param name="id">主键</param>
        public void deleteByPrimaryKey(long id)
        {
            new UploadManagementDAO().DeleteByPrimaryKey(new UploadManagement(id));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="uploadManagement">传入上传管理者实体</param>
        /// <returns>返回可以用来上传的json对象</returns>
        public ServiceResult GetServiceResult(UploadManagement uploadManagement)
        {
            //service返回结果对象
            ServiceResult serviceResult = new ServiceResult();

            //bdl_activity表
            if (uploadManagement.UM_DataTable == "bdl_activity")
            {
                //uploadManagement.Pk_UM_Type = "ActivityEntity";
                ActivityDAO activityDAO = new ActivityDAO();
                var result = activityDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }

                ActivityDTO activityDTO = new ActivityDTO(result);
                serviceResult.Data = JsonTools.Obj2JSONStrNew<ActivityDTO>(activityDTO);
            }

            //bdl_member表
            else if (uploadManagement.UM_DataTable == "bdl_member")
            {
                MemberDAO memberDAO = new MemberDAO();


                var result = memberDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }

                MemberDTO memberDTO = new MemberDTO(result);
                serviceResult.Data = JsonTools.Obj2JSONStrNew<MemberDTO>(memberDTO);
            }


            //bdl_personal_setting表
            else if (uploadManagement.UM_DataTable == "bdl_personal_setting")
            {
                PersonalSettingDAO personalSettingDAO = new PersonalSettingDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = personalSettingDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }
                PersonalSettingDTO personalSettingDTO = new PersonalSettingDTO(result);

                serviceResult.Data = JsonTools.Obj2JSONStrNew<PersonalSettingDTO>(personalSettingDTO);
            }

            //bdl_skeleton_length表
            else if (uploadManagement.UM_DataTable == "bdl_skeleton_length")
            {
                SkeletonLengthDAO skeletonLengthDAO = new SkeletonLengthDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = skeletonLengthDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }
                SkeletonLengthDTO skeletonLengthDTO = new SkeletonLengthDTO(result);
                serviceResult.Data = JsonTools.Obj2JSONStrNew<SkeletonLengthDTO>(skeletonLengthDTO);
            }

            //bdl_system_setting表
            else if (uploadManagement.UM_DataTable == "bdl_system_setting")
            {
                SystemSettingDAO systemSettingDAO = new SystemSettingDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = systemSettingDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }

                SystemSettingDTO systemSettingDTO = new SystemSettingDTO(result);
                
                serviceResult.Data = JsonTools.Obj2JSONStrNew<SystemSettingDTO>(systemSettingDTO);
            }

            //bdl_training_activity_record表
            else if (uploadManagement.UM_DataTable == "bdl_training_activity_record")
            {
                TrainingActivityRecordDAO trainingActivityRecordDAO = new TrainingActivityRecordDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = trainingActivityRecordDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }
                TrainingActivityRecordDTO trainingActivityRecordDTO = new TrainingActivityRecordDTO(result);

                serviceResult.Data = JsonTools.Obj2JSONStrNew<TrainingActivityRecordDTO>(trainingActivityRecordDTO);
            }

            //bdl_training_course表
            else if (uploadManagement.UM_DataTable == "bdl_training_course")
            {
                
                TrainingCourseDAO trainingCourseDAO = new TrainingCourseDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = trainingCourseDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }

                TrainingCourseDTO trainingCourseDTO = new TrainingCourseDTO(result);

                serviceResult.Data = JsonTools.Obj2JSONStrNew<TrainingCourseDTO>(trainingCourseDTO);
            }


            //bdl_training_device_record表
            else if (uploadManagement.UM_DataTable == "bdl_training_device_record")
            {
                TrainingDeviceRecordDAO trainingDeviceRecordDAO = new TrainingDeviceRecordDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = trainingDeviceRecordDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }

                TrainingDeviceRecordDTO trainingDeviceRecordDTO = new TrainingDeviceRecordDTO(result);
                serviceResult.Data = JsonTools.Obj2JSONStrNew<TrainingDeviceRecordDTO>(trainingDeviceRecordDTO);
            }
            //bdl_training_plan表
            else if (uploadManagement.UM_DataTable == "bdl_training_plan")
            {
                TrainingPlanDAO trainingPlanDAO = new TrainingPlanDAO();

                //Tr devicePrescriptionDAO = new DevicePrescriptionDAO();
                var result = trainingPlanDAO.Load(uploadManagement.UM_DataId);
                if (result == null)
                {
                    return null;
                }



                TrainingPlanDTO trainingPlanDTO = new TrainingPlanDTO(result);
                serviceResult.Data = JsonTools.Obj2JSONStrNew<TrainingPlanDTO>(trainingPlanDTO);
            }
            return serviceResult;
        }

    }
}