using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AI_Sports.Service
{
    class PersonalSettingService
    {
        PersonalSettingDAO personalSettingDAO = new PersonalSettingDAO();
        ActivityDAO activityDAO = new ActivityDAO();
        DatacodeDAO datacodeDao = new DatacodeDAO();
        SkeletonLengthDAO skeletonLengthDAO = new SkeletonLengthDAO();
        /// <summary>
        /// 添加训练活动后，自动根据数据库中的训练活动记录，往个人设置表插入记录
        /// </summary>
        /// <returns></returns>
        public bool SavePersonalSettings(long userPK)
        {
            //上传表
            UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                //1.先查询当前训练课程对应的训练活动集合
                List<ActivityEntity> activities = activityDAO.ListActivitysByCourseId(ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId")));
                //遍历每一条活动
                foreach (var activity in activities)
                {
                    //先查询判断个人设置表是否有该会员ID，该活动类型的记录，传入会员id和活动类型
                    string memberID = CommUtil.GetSettingString("memberId");
                    List<PersonalSettingEntity> personalSettingEntities = personalSettingDAO.ListSettingByMemberIdActivityType(memberID, activity.Activity_type);

                    //若个人设置表无该会员该训练活动的记录，则每个设备往个人设置表插入一条记录
                    if (personalSettingEntities.Count == 0)
                    {
                        //查询出每个活动类型对应着哪些设备
                        List<DatacodeEntity> datacodeEntities = datacodeDao.ListByTypeIdAndExtValue("DEVICE", activity.Activity_type);
                        //批量插入 构建集合
                        var personalSettingList = new List<PersonalSettingEntity>();
                        foreach (var item in datacodeEntities)
                        {
                            var personalSetting = new PersonalSettingEntity();
                            personalSetting.Id = KeyGenerator.GetNextKeyValueLong("bdl_personal_setting");
                            personalSetting.Activity_type = activity.Activity_type;
                            //默认标准模式
                            personalSetting.Training_mode = "0";
                            personalSetting.Device_code = item.Code_s_value;
                            personalSetting.Device_order_number = item.Code_xh;
                            //主键设置为传入的主键，因为传入前判断是登陆的教练单独训练还是有用户登录
                            personalSetting.Fk_member_id = userPK;
                            personalSetting.Member_id = CommUtil.GetSettingString("memberId");
                            personalSetting.Gmt_create = System.DateTime.Now;
                            //这个外键id用于展示的时候联查活动表和设置表。能够根据当前存在的训练活动查出相应的设置。根据活动id联查是最简单的方法。
                            //否则如果根据会员卡号查有可能出现没选这个训练活动却因为以前添加过设置查出来了。如果再根据类型判断查询也很麻烦。添加活动的时候更新个人设置里这个外键活动id是最好的办法。
                            personalSetting.Fk_training_activity_id = activity.Id;

                            //分别设置力度和功率 单车跑步机只设置功率 其他设置力度
                            if ("12".Equals(item.Code_s_value) || "16".Equals(item.Code_s_value))
                            {
                                personalSetting.Power = 30;
                            }
                            else
                            {
                                //设置各个属性的默认值
                                personalSetting.Consequent_force = 21;//顺向力
                                personalSetting.Reverse_force = 21;//反向力
                                personalSetting.Front_limit = 100;//前方限制
                                personalSetting.Back_limit = 0;//后方限制
                            }

                            //添加进集合
                            personalSettingList.Add(personalSetting);

                            //插入至上传表
                            uploadManagementDao.Insert(new UploadManagement(personalSetting.Id, "bdl_personal_setting", 0));
                        }
                        //使用基本DAO 批量插入数据库
                        personalSettingDAO.BatchInsert(personalSettingList);

                    }
                    //如果有记录就更新记录的外键活动id
                    else if (personalSettingEntities.Count > 0)
                    {
                        PersonalSettingEntity personalSetting = new PersonalSettingEntity();
                        personalSetting.Fk_training_activity_id = activity.Id;
                        personalSetting.Member_id = CommUtil.GetSettingString("memberId");
                        personalSetting.Activity_type = activity.Activity_type;
                        personalSettingDAO.UpdateSettingActivityId(personalSetting);
                    }

                }


                ts.Complete();
            }
            return true;
        }

        /// <summary>
        /// 为自动创建的用户自动添加默认个人设置
        /// </summary>
        /// <returns></returns>
        public long AutoSavePersonalSettings(long userPK, long coursePkId , string memberId)
        {
            //上传表
            UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
            long resultCode = 0;
            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                //1.先查询当前训练课程对应的训练活动集合
                List<ActivityEntity> activities = activityDAO.ListActivitysByCourseId(coursePkId);
                //遍历每一条活动
                foreach (var activity in activities)
                {

                    //查询出每个活动类型对应着哪些设备
                    List<DatacodeEntity> datacodeEntities = datacodeDao.ListByTypeIdAndExtValue("DEVICE", activity.Activity_type);
                    //批量插入 构建集合
                    var personalSettingList = new List<PersonalSettingEntity>();
                    foreach (var item in datacodeEntities)
                    {
                        var personalSetting = new PersonalSettingEntity();
                        personalSetting.Id = KeyGenerator.GetNextKeyValueLong("bdl_personal_setting");
                        personalSetting.Activity_type = activity.Activity_type;
                        //默认标准模式
                        personalSetting.Training_mode = "0";
                        personalSetting.Device_code = item.Code_s_value;
                        personalSetting.Device_order_number = item.Code_xh;
                        //主键设置为传入的主键
                        personalSetting.Fk_member_id = userPK;
                        //设置会员UID
                        personalSetting.Member_id = memberId;
                        personalSetting.Gmt_create = System.DateTime.Now;
                        //这个外键id用于展示的时候联查活动表和设置表。能够根据当前存在的训练活动查出相应的设置。根据活动id联查是最简单的方法。
                        //否则如果根据会员卡号查有可能出现没选这个训练活动却因为以前添加过设置查出来了。如果再根据类型判断查询也很麻烦。添加活动的时候更新个人设置里这个外键活动id是最好的办法。
                        personalSetting.Fk_training_activity_id = activity.Id;

                        //分别设置力度和功率 单车跑步机只设置功率 其他设置力度
                        if ("12".Equals(item.Code_s_value) || "16".Equals(item.Code_s_value))
                        {
                            personalSetting.Power = 30;
                        }
                        else
                        {
                            //设置各个属性的默认值
                            personalSetting.Consequent_force = 21;//顺向力
                            personalSetting.Reverse_force = 21;//反向力
                            personalSetting.Front_limit = 150;//前方限制
                            personalSetting.Back_limit = 20;//后方限制
                        }
                        
                        
                        //添加进集合
                        personalSettingList.Add(personalSetting);
                        //插入至上传表
                        uploadManagementDao.Insert(new UploadManagement(personalSetting.Id, "bdl_personal_setting", 0));
                    }
                    //使用基本DAO 批量插入数据库
                    resultCode += personalSettingDAO.BatchInsert(personalSettingList);

                }

                ts.Complete();

            }
            return resultCode;

        }



        /// <summary>
        /// 根据会员id，活动类型，更新力量设备的个人设置 除去12号和16号单车、跑步机
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateStrengthDeviceSettingByType(PersonalSettingEntity entity)
        {
            
            personalSettingDAO.UpdateStrengthDeviceSettingByType(entity);
        }
        /// <summary>
        /// 根据会员id，活动类型 更新耐力训练设备 单车和跑步机
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateEnduranceDeviceSettingByType(PersonalSettingEntity entity)
        {
            personalSettingDAO.UpdateEnduranceDeviceSettingByType(entity);
        }
        /// <summary>
        /// 根据3D扫描的到的用户身体数据更新个人设置的通配参数：座位高度、靠背距离、踏板距离
        /// </summary>
        public void UpdatePersonalSettingBy3DScan()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //1.首先得到用户的身体长度数据 根据会员id统一更新座位高度、靠背距离、踏板长度
                string memberPK = CommUtil.GetSettingString("memberPrimarykey");
                string coachId = CommUtil.GetSettingString("coachId");

                string fkmemberId = (memberPK != null && memberPK != "") ? memberPK : coachId;
                string memberId = CommUtil.GetSettingString("memberId");
                //根据当前登陆用户主键PK查询扫描数据
                SkeletonLengthEntity skeletonLengthEntity = skeletonLengthDAO.getSkeletonLengthRecord(fkmemberId);

                //计算公式：y=K*X+B ==> 设备参数 = k * 用户某一部位长度 + 常量 具体取值多少合适需要结合实际测试。可能不同的参数需要不同的K和B 根据实际情况修改也可
                double K = 2.7;//后方限制系数
                double M = 0.5;//前方限制系数
                double B = 0;//常量
                var personalSettingEntity = new PersonalSettingEntity
                {
                    Member_id = memberId,
                    //基于小腿计算座位高度
                    Seat_height = (int?)Math.Round(K * skeletonLengthEntity.Leg_length_down + B),
                    //靠背距离基于大腿长
                    Backrest_distance = (int?)Math.Round(K * skeletonLengthEntity.Leg_length_up + B),
                    //踏板距离基于小腿长
                    Footboard_distance = (int?)Math.Round(K * skeletonLengthEntity.Leg_length_down + B),
                    
                };

                personalSettingDAO.UpdatePersonalSettingBy3DScan(personalSettingEntity);

                //2.根据会员id，设备编码，单独更新每一种设备的前后方限制、杠杆角度（如果有的话）
                //0:腿部推蹬机
                var personalSetting0 = new PersonalSettingEntity
                {
                    Member_id = memberId,
                    //腿部推蹬机
                    Device_code = "0",
                    //基于大腿加小腿来设置前后方限制
                    Back_limit = (int?)Math.Round(M * (skeletonLengthEntity.Leg_length_up + skeletonLengthEntity.Leg_length_down) + B),
                    //前方限制
                    Front_limit = (int?)Math.Round(K * (skeletonLengthEntity.Leg_length_up + skeletonLengthEntity.Leg_length_down) + B),
                };

                personalSettingDAO.UpdateLimitByType(personalSetting0);

                //1：坐式背阔肌高拉机 基于大臂加小臂来设置前后方限制
                var personalSetting1 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "1",
                    //后方限制
                    Back_limit = (int?)Math.Round(M * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),
                    //前方限制
                    Front_limit = (int?)Math.Round(K * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),
                };

                personalSettingDAO.UpdateLimitByType(personalSetting1);

                //2：三头肌训练机 基于小臂来设置前后方限制
                var personalSetting2 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "2",
                    Back_limit = (int?)Math.Round(M * (skeletonLengthEntity.Arm_length_down) + B),
                    Front_limit = (int?)Math.Round(K * (skeletonLengthEntity.Arm_length_down) + B),
                };

                personalSettingDAO.UpdateLimitByType(personalSetting2);

                //3：腿部内弯机 比较特殊,两腿夹着垫子向内用力合拢 感觉和肢体数据无关 前后方限制为张开的角度，前方限制角度小 后方限制可以合拢成90度 暂且先这么写
                var personalSetting3 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "3",
                    //前方限制
                    Front_limit = 75,
                    //后方限制
                    Back_limit = 0,
                };

                personalSettingDAO.UpdateLimitByType(personalSetting3);

                
                //4：腿部外弯机 比较特殊，垫子夹着两腿，两腿用力向外张开 感觉和肢体数据无关 前后方限制为张开的角度，前方限制角度小  暂且先这么写
                var personalSetting4 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "3",
                    //前方限制
                    Front_limit = 75,
                    //后方限制
                    Back_limit = 20,
                };

                personalSettingDAO.UpdateLimitByType(personalSetting4);

                //5：蝴蝶机 向胸前内拉
                var personalSetting5 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "5",
                    //前方限制
                    Front_limit = 90,
                    //后方限制
                    Back_limit = 0,
                };

                personalSettingDAO.UpdateLimitByType(personalSetting5);


                //6：反向蝴蝶机 向外张开拉
                var personalSetting6 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "6",
                    //前方限制
                    Front_limit = 90,
                    //后方限制
                    Back_limit = 0,
                };

                personalSettingDAO.UpdateLimitByType(personalSetting6);


                //7:坐式背部伸展机器
                var personalSetting7 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "7",
                    //前方限制 大概往前弯腰50度
                    Front_limit = 50,
                    //后方限制 
                    Back_limit = 0,
                    //杠杆角度根据人体躯干长
                    Lever_angle = (int?)Math.Round(K * (skeletonLengthEntity.Body_length) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting7);

                //8:躯干扭转组合
                var personalSetting8 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "8",
                    //前方限制 
                    Front_limit = 60,
                    //后方限制 
                    Back_limit = 20,

                };

                personalSettingDAO.UpdateLimitByType(personalSetting8);

                //9:坐式腿伸展训练机
                var personalSetting9 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "9",
                    //前方限制 
                    Front_limit = 60,
                    //后方限制 
                    Back_limit = 20,
                    //杠杆角度根据小腿长
                    Lever_angle = (int?)Math.Round(K * (skeletonLengthEntity.Leg_length_down) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting9);

                //10:坐式推胸机 根据大臂加小臂
                var personalSetting10 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "10",
                    //前方限制 
                    Front_limit = (int?)Math.Round(K * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),
                    //后方限制 
                    Back_limit = (int?)Math.Round(M * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting10);

                //11:坐式划船机 根据大臂加小臂
                var personalSetting11 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "11",
                    //前方限制 
                    Front_limit = (int?)Math.Round(K * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),
                    //后方限制 
                    Back_limit = (int?)Math.Round(M * (skeletonLengthEntity.Arm_length_up + skeletonLengthEntity.Arm_length_down) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting11);

                //12:椭圆跑步机不用设置

                //13:坐式屈腿训练机
                var personalSetting13 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "13",
                    //前方限制 
                    Front_limit = 60,
                    //后方限制 
                    Back_limit = 20,
                    //杠杆角度根据小腿长
                    Lever_angle = (int?)Math.Round(K * (skeletonLengthEntity.Leg_length_down) + B),
                };

                personalSettingDAO.UpdateLimitByType(personalSetting13);

                //14:腹肌训练机
                var personalSetting14 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "14",
                    //前方限制 
                    Front_limit = 100,
                    //后方限制 
                    Back_limit = 20,
                    //杠杆角度根据躯干长
                    Lever_angle = (int?)Math.Round(K * (skeletonLengthEntity.Body_length) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting14);

                //15:坐式背部伸展机器
                var personalSetting15 = new PersonalSettingEntity
                {
                    Member_id = memberId,

                    Device_code = "15",
                    //前方限制 大概往前弯腰50度
                    Front_limit = 50,
                    //后方限制 
                    Back_limit = 0,
                    //杠杆角度根据人体躯干长
                    Lever_angle = (int?)Math.Round(K * (skeletonLengthEntity.Body_length) + B),

                };

                personalSettingDAO.UpdateLimitByType(personalSetting15);

                ts.Complete();
            }
            


        }

    }
}
