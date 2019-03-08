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
        /// <summary>
        /// 添加训练活动后，自动根据数据库中的训练活动记录，往个人设置表插入记录
        /// </summary>
        /// <returns></returns>
        public bool SavePersonalSettings(long userPK)
        {
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
                            //添加进集合
                            personalSettingList.Add(personalSetting);
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
    }
}
