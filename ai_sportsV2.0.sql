/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50634
Source Host           : localhost:3306
Source Database       : ai_sports

Target Server Type    : MYSQL
Target Server Version : 50634
File Encoding         : 65001

Date: 2019-04-20 14:08:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for bdl_activity
-- ----------------------------
DROP TABLE IF EXISTS `bdl_activity`;
CREATE TABLE `bdl_activity` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `fk_training_course_id` int(10) unsigned NOT NULL COMMENT '外键训练课程id',
  `fk_member_id` int(10) unsigned DEFAULT NULL COMMENT '会员外键id',
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员卡号ID',
  `activity_type` varchar(8) DEFAULT NULL COMMENT '训练活动编码：力量循环或者力量耐力循环',
  `target_turn_number` int(10) unsigned DEFAULT NULL COMMENT '目标轮次数量，目标在这一圈训练几轮',
  `current_turn_number` int(10) unsigned DEFAULT '0' COMMENT '当前轮次计数',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_activity训练活动表';

-- ----------------------------
-- Records of bdl_activity
-- ----------------------------
INSERT INTO `bdl_activity` VALUES ('1', '1', '1', '123456', '1', '3', '0', '1', '2019-01-21 14:09:23', null);
INSERT INTO `bdl_activity` VALUES ('2', '2', '302', '305865088', '1', '6', '1', '1', '2019-01-26 12:50:08', null);
INSERT INTO `bdl_activity` VALUES ('3', '2', '302', '305865088', '0', '5', '1', '1', '2019-01-28 11:44:45', null);
INSERT INTO `bdl_activity` VALUES ('301', '1901', '302', '305865088', '0', '4', '0', '1', '2019-02-26 23:51:23', null);
INSERT INTO `bdl_activity` VALUES ('302', '1901', '302', '305865088', '1', '4', '0', '1', '2019-02-26 23:51:23', null);
INSERT INTO `bdl_activity` VALUES ('401', '2001', '302', '305865088', '0', '4', '0', '1', '2019-02-26 23:57:07', null);
INSERT INTO `bdl_activity` VALUES ('402', '2001', '302', '305865088', '1', '4', '0', '1', '2019-02-26 23:57:07', null);
INSERT INTO `bdl_activity` VALUES ('501', '2101', '302', '305865088', '0', '4', '0', '1', '2019-02-27 00:04:25', null);
INSERT INTO `bdl_activity` VALUES ('502', '2101', '302', '305865088', '1', '4', '0', '1', '2019-02-27 00:04:25', null);
INSERT INTO `bdl_activity` VALUES ('601', '2801', '302', '305865088', '0', '4', '0', '1', '2019-02-27 17:36:31', null);
INSERT INTO `bdl_activity` VALUES ('602', '2801', '302', '305865088', '1', '4', '0', '1', '2019-02-27 17:36:31', null);
INSERT INTO `bdl_activity` VALUES ('701', '3001', '302', '305865088', '0', '4', '0', '1', '2019-02-27 17:45:10', null);
INSERT INTO `bdl_activity` VALUES ('702', '3001', '302', '305865088', '1', '4', '0', '1', '2019-02-27 17:45:10', null);
INSERT INTO `bdl_activity` VALUES ('703', '3002', '302', '305865088', '0', '4', '0', '1', '2019-02-27 17:49:43', null);
INSERT INTO `bdl_activity` VALUES ('704', '3002', '302', '305865088', '1', '4', '0', '1', '2019-02-27 17:49:43', null);
INSERT INTO `bdl_activity` VALUES ('801', '3101', '302', '305865088', '0', '4', '0', '1', '2019-02-27 18:01:40', null);
INSERT INTO `bdl_activity` VALUES ('802', '3101', '302', '305865088', '1', '4', '0', '1', '2019-02-27 18:01:40', null);
INSERT INTO `bdl_activity` VALUES ('901', '3201', '302', '305865088', '0', '4', '0', '1', '2019-02-28 00:42:51', null);
INSERT INTO `bdl_activity` VALUES ('902', '3201', '302', '305865088', '1', '4', '0', '1', '2019-02-28 00:42:51', null);
INSERT INTO `bdl_activity` VALUES ('903', '3202', '302', '305865088', '0', '4', '0', '1', '2019-02-28 00:44:15', null);
INSERT INTO `bdl_activity` VALUES ('904', '3202', '302', '305865088', '1', '4', '0', '1', '2019-02-28 00:44:15', null);
INSERT INTO `bdl_activity` VALUES ('1001', '3301', '302', '305865088', '0', '4', '0', '1', '2019-02-28 09:46:31', null);
INSERT INTO `bdl_activity` VALUES ('1002', '3301', '302', '305865088', '1', '4', '0', '1', '2019-02-28 09:46:31', null);
INSERT INTO `bdl_activity` VALUES ('1101', '3401', '302', '305865088', '0', '4', '0', '1', '2019-02-28 10:30:46', null);
INSERT INTO `bdl_activity` VALUES ('1102', '3401', '302', '305865088', '1', '4', '0', '1', '2019-02-28 10:30:46', null);
INSERT INTO `bdl_activity` VALUES ('1201', '3501', '302', '305865088', '0', '4', '0', '1', '2019-02-28 14:25:36', null);
INSERT INTO `bdl_activity` VALUES ('1202', '3501', '302', '305865088', '1', '4', '0', '1', '2019-02-28 14:25:36', null);
INSERT INTO `bdl_activity` VALUES ('1203', '3502', '302', '305865088', '0', '4', '0', '1', '2019-02-28 14:33:16', null);
INSERT INTO `bdl_activity` VALUES ('1204', '3502', '302', '305865088', '1', '4', '0', '1', '2019-02-28 14:33:16', null);
INSERT INTO `bdl_activity` VALUES ('1205', '3503', '302', '305865088', '0', '4', '0', '1', '2019-02-28 14:35:04', null);
INSERT INTO `bdl_activity` VALUES ('1206', '3503', '302', '305865088', '1', '4', '0', '1', '2019-02-28 14:35:04', null);
INSERT INTO `bdl_activity` VALUES ('1301', '3601', '302', '305865088', '0', '4', '0', '1', '2019-02-28 16:32:20', null);
INSERT INTO `bdl_activity` VALUES ('1302', '3601', '302', '305865088', '1', '4', '0', '1', '2019-02-28 16:32:20', null);
INSERT INTO `bdl_activity` VALUES ('1303', '3602', '302', '305865088', '0', '4', '0', '1', '2019-02-28 16:32:45', null);
INSERT INTO `bdl_activity` VALUES ('1304', '3602', '302', '305865088', '1', '4', '0', '1', '2019-02-28 16:32:45', null);
INSERT INTO `bdl_activity` VALUES ('1401', '3701', '302', '305865088', '0', '7', '0', '1', '2019-03-01 12:52:37', null);
INSERT INTO `bdl_activity` VALUES ('1402', '3701', '302', '305865088', '1', '4', '0', '1', '2019-03-01 12:52:37', null);
INSERT INTO `bdl_activity` VALUES ('1501', '3801', '302', '305865088', '0', '4', '0', '1', '2019-03-01 13:07:45', null);
INSERT INTO `bdl_activity` VALUES ('1502', '3801', '302', '305865088', '1', '8', '0', '1', '2019-03-01 13:07:45', null);
INSERT INTO `bdl_activity` VALUES ('1503', '3802', '302', '305865088', '0', '4', '0', '1', '2019-03-01 13:09:58', null);
INSERT INTO `bdl_activity` VALUES ('1504', '3802', '302', '305865088', '1', '10', '0', '1', '2019-03-01 13:09:58', null);
INSERT INTO `bdl_activity` VALUES ('1601', '3901', '302', '305865088', '0', '3', '0', '1', '2019-03-01 13:38:22', null);
INSERT INTO `bdl_activity` VALUES ('1602', '3901', '302', '305865088', '1', '2', '0', '1', '2019-03-01 13:38:22', null);
INSERT INTO `bdl_activity` VALUES ('1701', '4001', '302', '305865088', '0', '1', '0', '1', '2019-03-02 17:54:16', null);
INSERT INTO `bdl_activity` VALUES ('1702', '4001', '302', '305865088', '1', '1', '0', '1', '2019-03-02 17:54:16', null);
INSERT INTO `bdl_activity` VALUES ('1801', '4101', '302', '305865088', '0', '4', '0', '1', '2019-03-04 10:31:59', null);
INSERT INTO `bdl_activity` VALUES ('1802', '4101', '302', '305865088', '1', '4', '0', '1', '2019-03-04 10:31:59', null);
INSERT INTO `bdl_activity` VALUES ('1901', '4201', '302', '305865088', '0', '4', '0', '1', '2019-03-05 22:32:13', null);
INSERT INTO `bdl_activity` VALUES ('1902', '4201', '302', '305865088', '1', '4', '0', '1', '2019-03-05 22:32:13', null);
INSERT INTO `bdl_activity` VALUES ('2001', '4301', '1701', '305865088', '0', '6', '0', '1', '2019-03-06 01:35:25', null);
INSERT INTO `bdl_activity` VALUES ('2002', '4301', '1701', '305865088', '1', '6', '0', '1', '2019-03-06 01:35:25', null);
INSERT INTO `bdl_activity` VALUES ('2101', '4401', '2001', '305865088', '0', '5', '0', '1', '2019-03-07 12:57:58', null);
INSERT INTO `bdl_activity` VALUES ('2102', '4401', '2001', '305865088', '1', '7', '0', '1', '2019-03-07 12:57:58', null);
INSERT INTO `bdl_activity` VALUES ('2201', '4501', '301', '17863979633', '0', '4', '2', '1', '2019-03-10 17:21:52', null);
INSERT INTO `bdl_activity` VALUES ('2202', '4501', '301', '17863979633', '1', '4', '2', '1', '2019-03-10 17:21:52', null);
INSERT INTO `bdl_activity` VALUES ('2301', '4601', '801', '305865088', '0', '4', '2', '1', '2019-03-11 12:37:15', null);
INSERT INTO `bdl_activity` VALUES ('2302', '4601', '801', '305865088', '1', '4', '2', '1', '2019-03-11 12:37:15', null);
INSERT INTO `bdl_activity` VALUES ('2901', '5101', '2501', 'YK-488A', '0', '2', '1', '0', '2019-03-22 15:00:29', '2019-04-07 22:58:47');
INSERT INTO `bdl_activity` VALUES ('2902', '5101', '2501', 'YK-488A', '1', '2', '2', '1', '2019-03-22 15:00:29', '2019-04-07 23:07:44');
INSERT INTO `bdl_activity` VALUES ('3001', '5201', '801', '305865088', '0', '2', '0', '0', '2019-03-25 22:24:59', null);
INSERT INTO `bdl_activity` VALUES ('3002', '5201', '801', '305865088', '1', '2', '0', '0', '2019-03-25 22:24:59', null);
INSERT INTO `bdl_activity` VALUES ('3101', '5301', '2601', '徐靖皓5791', '0', '2', '0', '1', '2019-03-25 22:28:05', null);
INSERT INTO `bdl_activity` VALUES ('3102', '5301', '2601', '徐靖皓5791', '1', '2', '0', '1', '2019-03-25 22:28:05', null);
INSERT INTO `bdl_activity` VALUES ('3201', '5401', '2601', '徐靖皓91031', '0', '2', '0', '0', '2019-03-25 22:31:45', null);
INSERT INTO `bdl_activity` VALUES ('3202', '5401', '2601', '徐靖皓91031', '1', '2', '0', '0', '2019-03-25 22:31:45', null);
INSERT INTO `bdl_activity` VALUES ('3301', '5501', '301', '17863979633', '0', '4', '0', '0', '2019-04-04 19:41:01', null);
INSERT INTO `bdl_activity` VALUES ('3302', '5501', '301', '17863979633', '1', '4', '0', '0', '2019-04-04 19:41:01', null);
INSERT INTO `bdl_activity` VALUES ('3401', '5601', '2701', 'YK-4A50', '0', '2', '0', '0', '2019-04-07 17:45:37', null);
INSERT INTO `bdl_activity` VALUES ('3402', '5601', '2701', 'YK-4A50', '1', '2', '0', '0', '2019-04-07 17:45:37', null);
INSERT INTO `bdl_activity` VALUES ('3403', '5602', '2702', '张方琛23180118', '0', '3', '0', '1', '2019-04-07 18:06:19', null);
INSERT INTO `bdl_activity` VALUES ('3404', '5602', '2702', '张方琛23180118', '1', '2', '0', '1', '2019-04-07 18:06:19', null);
INSERT INTO `bdl_activity` VALUES ('3405', '5603', '2702', '张方琛23180118', '1', '2', '0', '0', '2019-04-07 18:08:54', null);
INSERT INTO `bdl_activity` VALUES ('3406', '5604', '2703', 'YK-4B07', '0', '2', '0', '0', '2019-04-07 18:11:09', null);
INSERT INTO `bdl_activity` VALUES ('3407', '5604', '2703', 'YK-4B07', '1', '2', '0', '0', '2019-04-07 18:11:09', null);
INSERT INTO `bdl_activity` VALUES ('3501', '5701', '2801', '陈其钊9633', '0', '2', '0', '0', '2019-04-07 22:31:15', null);
INSERT INTO `bdl_activity` VALUES ('3502', '5701', '2801', '陈其钊9633', '1', '2', '0', '0', '2019-04-07 22:31:15', null);
INSERT INTO `bdl_activity` VALUES ('3601', '5801', '2901', '陈梓豪9633', '0', '2', '0', '0', '2019-04-11 22:17:06', null);
INSERT INTO `bdl_activity` VALUES ('3602', '5801', '2901', '陈梓豪9633', '1', '2', '0', '0', '2019-04-11 22:17:06', null);

-- ----------------------------
-- Table structure for bdl_auth
-- ----------------------------
DROP TABLE IF EXISTS `bdl_auth`;
CREATE TABLE `bdl_auth` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `username` varchar(50) DEFAULT NULL COMMENT '用户名',
  `password` varchar(50) DEFAULT NULL COMMENT '密码',
  `authid` varchar(255) DEFAULT NULL COMMENT '手环或卡的openID',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_auth登录用户授权表';

-- ----------------------------
-- Records of bdl_auth
-- ----------------------------

-- ----------------------------
-- Table structure for bdl_datacode
-- ----------------------------
DROP TABLE IF EXISTS `bdl_datacode`;
CREATE TABLE `bdl_datacode` (
  `id` int(10) NOT NULL,
  `code_xh` int(10) DEFAULT NULL COMMENT '排序号，下拉列表按这个排序',
  `code_type_id` varchar(255) DEFAULT NULL COMMENT '类型ID，dList是数据项',
  `code_s_value` varchar(255) DEFAULT NULL COMMENT '存储值',
  `code_d_value` varchar(255) DEFAULT NULL COMMENT '展示值',
  `code_ext_value` varchar(255) DEFAULT NULL COMMENT '设备对应的肌肉',
  `code_ext_value2` varchar(255) DEFAULT NULL COMMENT '用作存储设备的活动类型，与编码表中的循环类型相对应：0力量循环，1力量耐力，需要用作分组查询依据',
  `code_ext_value3` varchar(255) DEFAULT NULL COMMENT '用作存储有氧力量类型：0：力量训练设备；1：有氧训练设备',
  `code_ext_value4` varchar(255) DEFAULT NULL COMMENT '设备图片存储路径',
  `code_state` tinyint(4) DEFAULT '1' COMMENT '是否启用 0 不启用 1启用',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_datacode编码表';

-- ----------------------------
-- Records of bdl_datacode
-- ----------------------------
INSERT INTO `bdl_datacode` VALUES ('1', null, 'DLIST', 'DEVICE', '设备', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('18', '1', 'DEVICE', '0', '腿部推蹬机', '腿部', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('19', '2', 'DEVICE', '1', '坐式背阔肌高拉机', '背部', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('20', '3', 'DEVICE', '2', '三头肌训练机', '手臂', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('21', '4', 'DEVICE', '3', '腿部内弯机', '腿部', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('22', '5', 'DEVICE', '4', '腿部外弯机', '腿部', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('23', '6', 'DEVICE', '5', '蝴蝶机', '胸', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('24', '7', 'DEVICE', '6', '反向蝴蝶机', '胸', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('25', '8', 'DEVICE', '7', '坐式背部伸展机', '背部', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('26', '9', 'DEVICE', '8', '躯干扭转组合', '躯干', '0', '0', '/AI_Sports;component/AISports.View/Images/legDeviceTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('27', '1', 'DEVICE', '9', '坐式腿伸展训练机', '腿部', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('28', '2', 'DEVICE', '10', '坐式推胸机', '胸', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('29', '3', 'DEVICE', '11', '坐式划船机', '背部', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('30', '4', 'DEVICE', '12', '椭圆跑步机', '', '1', '1', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('31', '5', 'DEVICE', '13', '坐式屈腿训练机', '腿部', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('32', '6', 'DEVICE', '14', '腹肌训练机', '躯干', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('33', '7', 'DEVICE', '15', '坐式背部伸展机', '背部', '1', '0', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('34', '8', 'DEVICE', '16', '健身车', null, '1', '1', '/AI_Sports;component/AISports.View/Images/deviceImageTest.jpg', '1');
INSERT INTO `bdl_datacode` VALUES ('35', null, 'DLIST', 'TRAIN_MODE', '训练模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('36', '1', 'TRAIN_MODE', '0', '标准模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('37', '2', 'TRAIN_MODE', '1', '适应性模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('38', '3', 'TRAIN_MODE', '2', '等速模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('39', null, 'DLIST', 'CYCLE_TYPE', '循环类型', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('40', '1', 'CYCLE_TYPE', '0', '力量循环', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('41', '2', 'CYCLE_TYPE', '1', '力量耐力循环', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('42', '4', 'TRAIN_MODE', '3', '心率模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('43', '5', 'TRAIN_MODE', '4', '增肌模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('44', '6', 'TRAIN_MODE', '5', '主动模式', null, null, null, null, '1');
INSERT INTO `bdl_datacode` VALUES ('45', '7', 'TRAIN_MODE', '6', '主被动模式', null, null, null, null, '1');

-- ----------------------------
-- Table structure for bdl_member
-- ----------------------------
DROP TABLE IF EXISTS `bdl_member`;
CREATE TABLE `bdl_member` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员id',
  `member_firstName` varchar(50) DEFAULT NULL COMMENT '会员名',
  `member_familyName` varchar(50) DEFAULT NULL COMMENT '会员姓',
  `birth_date` date DEFAULT NULL COMMENT '出生日期',
  `sex` varchar(8) DEFAULT NULL COMMENT '住址',
  `address` varchar(255) DEFAULT NULL COMMENT '住址',
  `email_address` varchar(50) DEFAULT NULL COMMENT '邮箱地址',
  `work_phone` varchar(50) DEFAULT NULL COMMENT '工作电话',
  `personal_phone` varchar(50) DEFAULT NULL COMMENT '私人电话',
  `mobile_phone` varchar(50) DEFAULT NULL COMMENT '手机号码',
  `weight` double(10,2) unsigned DEFAULT NULL COMMENT '体重（KG）',
  `height` double(10,2) unsigned DEFAULT NULL COMMENT '身高 (cm)',
  `age` int(6) unsigned DEFAULT NULL COMMENT '年龄',
  `max_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最大心率=220-age',
  `suitable_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最宜心率',
  `role_id` tinyint(3) unsigned DEFAULT NULL COMMENT '角色id，1：会员；0：教练',
  `fk_coach_id` int(10) unsigned DEFAULT NULL COMMENT '外键关联教练id',
  `label_name` varchar(255) DEFAULT NULL COMMENT '标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔',
  `is_open_fat_reduction` tinyint(3) unsigned DEFAULT '0' COMMENT '是否开启减脂模式 默认0，0:未开启，1:开启',
  `remark` varchar(255) DEFAULT NULL COMMENT '前端备注',
  `last_login_date` datetime DEFAULT NULL COMMENT '上次登录日期',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_member会员表';

-- ----------------------------
-- Records of bdl_member
-- ----------------------------
INSERT INTO `bdl_member` VALUES ('301', '17863979633', '教练', '李', '2019-01-11', '女', '山东省', '5465465465@qq.com', '5645445', '5454545', '54545', '60.00', '175.00', '0', '220', '168', '0', null, null, '0', '', '2019-04-16 13:50:04', '2019-03-01 17:28:34', '2019-04-04 20:42:34');
INSERT INTO `bdl_member` VALUES ('801', '305865088', '其钊2', '陈', '2019-03-02', '男', '山东省', '465464654@qq.com', '665454', '5454545', '17863979633', '60.00', '187.00', '25', '199', '168', '1', '301', '增肌,减脂,塑形,康复,', '0', '', '2019-04-07 16:30:18', '2019-03-04 19:34:55', '2019-03-13 12:22:18');
INSERT INTO `bdl_member` VALUES ('2501', 'YK-488A', '备', '刘', '2010-04-02', '男', '上海', '122333@qq.ocm', '55854', '251235', '63281454', '72.00', '171.00', '9', '211', '161', '0', null, '增肌,减脂,塑形,', '0', '', '2019-04-06 14:39:51', '2019-03-22 14:51:08', '2019-04-07 18:49:45');
INSERT INTO `bdl_member` VALUES ('2601', '徐靖皓91031', '靖皓', '徐', '2019-03-16', '男', '北京', '632qq.com', '512', '25', '5791', '60.00', '181.00', '0', '123', '94', '0', null, '增肌,减脂,塑形,', '0', '', '2019-03-29 21:22:59', '2019-03-23 17:37:26', '2019-03-28 14:18:39');
INSERT INTO `bdl_member` VALUES ('2701', 'YK-4A50', 'K-', 'Y', null, null, null, null, null, null, null, '80.00', null, null, '190', '145', '1', null, '塑形,', '0', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_member` VALUES ('2702', '张方琛23180118', '方琛', '张', '2019-04-05', '男', '', '', '', '', '123123123', '50.00', '150.00', '0', '167', '128', '1', '301', '增肌,', '1', '', null, '2019-04-07 18:06:18', '2019-04-07 18:08:08');
INSERT INTO `bdl_member` VALUES ('2703', 'YK-4B07', 'K-', 'Y', null, null, null, null, null, null, null, '80.00', null, null, '190', '145', '1', null, '塑形,', '0', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_member` VALUES ('2801', '陈其钊9633', '其钊', '陈', null, null, null, null, null, null, null, '80.00', null, null, '190', '145', '1', null, '塑形,', '0', null, null, '2019-04-07 22:31:15', '2019-04-16 20:14:16');
INSERT INTO `bdl_member` VALUES ('2901', '陈梓豪9633', '梓豪', '陈', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '0', null, '塑形,', '0', null, null, '2019-04-11 22:17:06', '2019-04-16 20:14:19');

-- ----------------------------
-- Table structure for bdl_personal_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_personal_setting`;
CREATE TABLE `bdl_personal_setting` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `fk_member_id` int(10) DEFAULT NULL,
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员卡号ID',
  `fk_training_activity_id` int(10) DEFAULT NULL COMMENT '训练活动名',
  `activity_type` varchar(255) DEFAULT NULL COMMENT '训练活动类型编码',
  `device_code` varchar(255) DEFAULT NULL COMMENT '设备名',
  `device_order_number` int(10) unsigned DEFAULT NULL COMMENT '设备序号',
  `training_mode` varchar(255) DEFAULT NULL COMMENT '训练模式',
  `seat_height` int(10) unsigned DEFAULT NULL COMMENT '座位高度cm',
  `backrest_distance` int(10) unsigned DEFAULT NULL COMMENT '靠背距离',
  `footboard_distance` int(10) unsigned DEFAULT NULL COMMENT '踏板距离',
  `lever_length` int(10) DEFAULT NULL COMMENT '杠杆长度',
  `lever_angle` double(10,2) DEFAULT NULL COMMENT '杠杆角度',
  `front_limit` int(10) DEFAULT NULL COMMENT '前方限制',
  `back_limit` int(10) DEFAULT NULL COMMENT '后方限制',
  `consequent_force` double(10,2) unsigned DEFAULT NULL COMMENT '顺向力',
  `reverse_force` double(10,2) DEFAULT NULL COMMENT '反向力',
  `power` double(10,2) DEFAULT NULL COMMENT '功率',
  `extra_setting` text COMMENT '额外属性：为保证设备属性的可扩展性，存储为Json串Key、value',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_personal_setting个人设置';

-- ----------------------------
-- Records of bdl_personal_setting
-- ----------------------------
INSERT INTO `bdl_personal_setting` VALUES ('101', '302', '305865088', '3001', '0', '0', '1', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('102', '302', '305865088', '3001', '0', '1', '2', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('103', '302', '305865088', '3001', '0', '2', '3', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('104', '302', '305865088', '3001', '0', '3', '4', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('105', '302', '305865088', '3001', '0', '4', '5', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('106', '302', '305865088', '3001', '0', '5', '6', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('107', '302', '305865088', '3001', '0', '6', '7', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('108', '302', '305865088', '3001', '0', '7', '8', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('109', '302', '305865088', '3001', '0', '8', '9', '0', null, null, null, null, null, null, null, '8.00', '13.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('110', '302', '305865088', '3002', '1', '9', '1', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('111', '302', '305865088', '3002', '1', '10', '2', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('112', '302', '305865088', '3002', '1', '11', '3', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('113', '302', '305865088', '3002', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('114', '302', '305865088', '3002', '1', '13', '5', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('115', '302', '305865088', '3002', '1', '14', '6', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('116', '302', '305865088', '3002', '1', '15', '7', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('117', '302', '305865088', '3002', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-02-28 00:44:15', '2019-03-25 22:24:59');
INSERT INTO `bdl_personal_setting` VALUES ('201', '301', '17863979633', '3301', '0', '0', '1', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('202', '301', '17863979633', '3301', '0', '1', '2', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('203', '301', '17863979633', '3301', '0', '2', '3', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('204', '301', '17863979633', '3301', '0', '3', '4', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('205', '301', '17863979633', '3301', '0', '4', '5', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('206', '301', '17863979633', '3301', '0', '5', '6', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('207', '301', '17863979633', '3301', '0', '6', '7', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('208', '301', '17863979633', '3301', '0', '7', '8', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('209', '301', '17863979633', '3301', '0', '8', '9', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-10 17:21:52', '2019-04-04 20:42:28');
INSERT INTO `bdl_personal_setting` VALUES ('210', '301', '17863979633', '3302', '1', '9', '1', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('211', '301', '17863979633', '3302', '1', '10', '2', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('212', '301', '17863979633', '3302', '1', '11', '3', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('213', '301', '17863979633', '3302', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('214', '301', '17863979633', '3302', '1', '13', '5', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('215', '301', '17863979633', '3302', '1', '14', '6', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('216', '301', '17863979633', '3302', '1', '15', '7', '1', null, null, null, null, null, null, null, '7.00', '8.00', null, null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('217', '301', '17863979633', '3302', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-10 17:21:52', '2019-04-04 19:41:01');
INSERT INTO `bdl_personal_setting` VALUES ('401', '2501', 'YK-488A', '2901', '0', '0', '1', '0', '0', '0', null, '0', '0.00', '101', '20', '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-04-07 16:05:15');
INSERT INTO `bdl_personal_setting` VALUES ('402', '2501', 'YK-488A', '2901', '0', '1', '2', '0', '0', '0', null, '0', '0.00', '169', '23', '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-04-07 21:50:34');
INSERT INTO `bdl_personal_setting` VALUES ('403', '2501', 'YK-488A', '2901', '0', '2', '3', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:22');
INSERT INTO `bdl_personal_setting` VALUES ('404', '2501', 'YK-488A', '2901', '0', '3', '4', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:25');
INSERT INTO `bdl_personal_setting` VALUES ('405', '2501', 'YK-488A', '2901', '0', '4', '5', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:27');
INSERT INTO `bdl_personal_setting` VALUES ('406', '2501', 'YK-488A', '2901', '0', '5', '6', '0', '0', '0', null, '0', '0.00', '0', '100', '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-28 01:02:36');
INSERT INTO `bdl_personal_setting` VALUES ('407', '2501', 'YK-488A', '2901', '0', '6', '7', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:31');
INSERT INTO `bdl_personal_setting` VALUES ('408', '2501', 'YK-488A', '2901', '0', '7', '8', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:34');
INSERT INTO `bdl_personal_setting` VALUES ('409', '2501', 'YK-488A', '2901', '0', '8', '9', '0', '0', '0', null, '0', '0.00', '100', '0', '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:19:31');
INSERT INTO `bdl_personal_setting` VALUES ('410', '2501', 'YK-488A', '2902', '1', '9', '1', '0', '5', '0', null, '0', '5.00', '199', '0', '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-04-07 23:08:23');
INSERT INTO `bdl_personal_setting` VALUES ('411', '2501', 'YK-488A', '2902', '1', '10', '2', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:38');
INSERT INTO `bdl_personal_setting` VALUES ('412', '2501', 'YK-488A', '2902', '1', '11', '3', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:40');
INSERT INTO `bdl_personal_setting` VALUES ('413', '2501', 'YK-488A', '2902', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-22 15:00:29', '2019-03-22 15:01:00');
INSERT INTO `bdl_personal_setting` VALUES ('414', '2501', 'YK-488A', '2902', '1', '13', '5', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:43');
INSERT INTO `bdl_personal_setting` VALUES ('415', '2501', 'YK-488A', '2902', '1', '14', '6', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:45');
INSERT INTO `bdl_personal_setting` VALUES ('416', '2501', 'YK-488A', '2902', '1', '15', '7', '0', null, null, null, null, null, null, null, '5.00', '5.00', null, null, '2019-03-22 15:00:29', '2019-03-27 23:55:49');
INSERT INTO `bdl_personal_setting` VALUES ('417', '2501', 'YK-488A', '2902', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-22 15:00:29', '2019-03-22 15:01:00');
INSERT INTO `bdl_personal_setting` VALUES ('501', '2601', '徐靖皓91031', '3201', '0', '0', '1', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('502', '2601', '徐靖皓91031', '3201', '0', '1', '2', '0', '0', '0', null, '0', '0.00', '60', '30', '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:23:22');
INSERT INTO `bdl_personal_setting` VALUES ('503', '2601', '徐靖皓91031', '3201', '0', '2', '3', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('504', '2601', '徐靖皓91031', '3201', '0', '3', '4', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('505', '2601', '徐靖皓91031', '3201', '0', '4', '5', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('506', '2601', '徐靖皓91031', '3201', '0', '5', '6', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('507', '2601', '徐靖皓91031', '3201', '0', '6', '7', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('508', '2601', '徐靖皓91031', '3201', '0', '7', '8', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('509', '2601', '徐靖皓91031', '3201', '0', '8', '9', '0', null, null, null, null, null, null, null, '3.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('510', '2601', '徐靖皓91031', '3202', '1', '9', '1', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('511', '2601', '徐靖皓91031', '3202', '1', '10', '2', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('512', '2601', '徐靖皓91031', '3202', '1', '11', '3', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('513', '2601', '徐靖皓91031', '3202', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('514', '2601', '徐靖皓91031', '3202', '1', '13', '5', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('515', '2601', '徐靖皓91031', '3202', '1', '14', '6', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('516', '2601', '徐靖皓91031', '3202', '1', '15', '7', '0', null, null, null, null, null, null, null, '4.00', '3.00', null, null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('517', '2601', '徐靖皓91031', '3202', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-25 22:28:06', '2019-03-28 14:19:56');
INSERT INTO `bdl_personal_setting` VALUES ('601', '2701', 'YK-4A50', '3401', '0', '0', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('602', '2701', 'YK-4A50', '3401', '0', '1', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('603', '2701', 'YK-4A50', '3401', '0', '2', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('604', '2701', 'YK-4A50', '3401', '0', '3', '4', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('605', '2701', 'YK-4A50', '3401', '0', '4', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('606', '2701', 'YK-4A50', '3401', '0', '5', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('607', '2701', 'YK-4A50', '3401', '0', '6', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('608', '2701', 'YK-4A50', '3401', '0', '7', '8', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('609', '2701', 'YK-4A50', '3401', '0', '8', '9', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('610', '2701', 'YK-4A50', '3402', '1', '9', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('611', '2701', 'YK-4A50', '3402', '1', '10', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('612', '2701', 'YK-4A50', '3402', '1', '11', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('613', '2701', 'YK-4A50', '3402', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('614', '2701', 'YK-4A50', '3402', '1', '13', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('615', '2701', 'YK-4A50', '3402', '1', '14', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('616', '2701', 'YK-4A50', '3402', '1', '15', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('617', '2701', 'YK-4A50', '3402', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 17:45:37', null);
INSERT INTO `bdl_personal_setting` VALUES ('618', '2702', '张方琛23180118', '3403', '0', '0', '1', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('619', '2702', '张方琛23180118', '3403', '0', '1', '2', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('620', '2702', '张方琛23180118', '3403', '0', '2', '3', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('621', '2702', '张方琛23180118', '3403', '0', '3', '4', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('622', '2702', '张方琛23180118', '3403', '0', '4', '5', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('623', '2702', '张方琛23180118', '3403', '0', '5', '6', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('624', '2702', '张方琛23180118', '3403', '0', '6', '7', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('625', '2702', '张方琛23180118', '3403', '0', '7', '8', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('626', '2702', '张方琛23180118', '3403', '0', '8', '9', '3', null, null, null, null, null, '100', '0', '100.00', '26.00', null, null, '2019-04-07 18:06:19', '2019-04-07 18:08:08');
INSERT INTO `bdl_personal_setting` VALUES ('627', '2702', '张方琛23180118', '3404', '1', '9', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('628', '2702', '张方琛23180118', '3404', '1', '10', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('629', '2702', '张方琛23180118', '3404', '1', '11', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('630', '2702', '张方琛23180118', '3404', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('631', '2702', '张方琛23180118', '3404', '1', '13', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('632', '2702', '张方琛23180118', '3404', '1', '14', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('633', '2702', '张方琛23180118', '3404', '1', '15', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('634', '2702', '张方琛23180118', '3404', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:06:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('635', '2702', '张方琛23180118', '3405', '1', '9', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('636', '2702', '张方琛23180118', '3405', '1', '10', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('637', '2702', '张方琛23180118', '3405', '1', '11', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('638', '2702', '张方琛23180118', '3405', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('639', '2702', '张方琛23180118', '3405', '1', '13', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('640', '2702', '张方琛23180118', '3405', '1', '14', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('641', '2702', '张方琛23180118', '3405', '1', '15', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('642', '2702', '张方琛23180118', '3405', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:08:54', null);
INSERT INTO `bdl_personal_setting` VALUES ('643', '2703', 'YK-4B07', '3406', '0', '0', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('644', '2703', 'YK-4B07', '3406', '0', '1', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('645', '2703', 'YK-4B07', '3406', '0', '2', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('646', '2703', 'YK-4B07', '3406', '0', '3', '4', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('647', '2703', 'YK-4B07', '3406', '0', '4', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('648', '2703', 'YK-4B07', '3406', '0', '5', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('649', '2703', 'YK-4B07', '3406', '0', '6', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('650', '2703', 'YK-4B07', '3406', '0', '7', '8', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('651', '2703', 'YK-4B07', '3406', '0', '8', '9', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('652', '2703', 'YK-4B07', '3407', '1', '9', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('653', '2703', 'YK-4B07', '3407', '1', '10', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('654', '2703', 'YK-4B07', '3407', '1', '11', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('655', '2703', 'YK-4B07', '3407', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('656', '2703', 'YK-4B07', '3407', '1', '13', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('657', '2703', 'YK-4B07', '3407', '1', '14', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('658', '2703', 'YK-4B07', '3407', '1', '15', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('659', '2703', 'YK-4B07', '3407', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 18:11:09', null);
INSERT INTO `bdl_personal_setting` VALUES ('701', '2801', '陈其钊9633', '3501', '0', '0', '1', '3', '0', '0', null, '0', '0.00', '199', '28', '21.00', '21.00', null, null, '2019-04-07 22:31:15', '2019-04-16 19:39:33');
INSERT INTO `bdl_personal_setting` VALUES ('702', '2801', '陈其钊9633', '3501', '0', '1', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('703', '2801', '陈其钊9633', '3501', '0', '2', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('704', '2801', '陈其钊9633', '3501', '0', '3', '4', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('705', '2801', '陈其钊9633', '3501', '0', '4', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('706', '2801', '陈其钊9633', '3501', '0', '5', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('707', '2801', '陈其钊9633', '3501', '0', '6', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('708', '2801', '陈其钊9633', '3501', '0', '7', '8', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('709', '2801', '陈其钊9633', '3501', '0', '8', '9', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('710', '2801', '陈其钊9633', '3502', '1', '9', '1', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('711', '2801', '陈其钊9633', '3502', '1', '10', '2', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('712', '2801', '陈其钊9633', '3502', '1', '11', '3', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('713', '2801', '陈其钊9633', '3502', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('714', '2801', '陈其钊9633', '3502', '1', '13', '5', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('715', '2801', '陈其钊9633', '3502', '1', '14', '6', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('716', '2801', '陈其钊9633', '3502', '1', '15', '7', '0', null, null, null, null, null, '100', '0', '21.00', '21.00', null, null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('717', '2801', '陈其钊9633', '3502', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-07 22:31:15', null);
INSERT INTO `bdl_personal_setting` VALUES ('801', '2901', '陈梓豪9633', '3601', '0', '0', '1', '6', '0', '0', null, '0', '0.00', '157', '26', '21.00', '21.00', null, null, '2019-04-11 22:17:07', '2019-04-17 00:07:59');
INSERT INTO `bdl_personal_setting` VALUES ('802', '2901', '陈梓豪9633', '3601', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('803', '2901', '陈梓豪9633', '3601', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('804', '2901', '陈梓豪9633', '3601', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('805', '2901', '陈梓豪9633', '3601', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('806', '2901', '陈梓豪9633', '3601', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('807', '2901', '陈梓豪9633', '3601', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('808', '2901', '陈梓豪9633', '3601', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('809', '2901', '陈梓豪9633', '3601', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('810', '2901', '陈梓豪9633', '3602', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('811', '2901', '陈梓豪9633', '3602', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('812', '2901', '陈梓豪9633', '3602', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('813', '2901', '陈梓豪9633', '3602', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('814', '2901', '陈梓豪9633', '3602', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('815', '2901', '陈梓豪9633', '3602', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('816', '2901', '陈梓豪9633', '3602', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-11 22:17:07', null);
INSERT INTO `bdl_personal_setting` VALUES ('817', '2901', '陈梓豪9633', '3602', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-11 22:17:07', null);

-- ----------------------------
-- Table structure for bdl_skeleton_length
-- ----------------------------
DROP TABLE IF EXISTS `bdl_skeleton_length`;
CREATE TABLE `bdl_skeleton_length` (
  `id` int(11) NOT NULL,
  `fk_member_id` int(11) DEFAULT NULL COMMENT '关联bdl_member的主键',
  `body_length` double DEFAULT NULL COMMENT '躯干长度(脖子到屁股~)',
  `shouder_width` double DEFAULT NULL COMMENT '肩宽(单侧肩宽)',
  `arm_length_up` double DEFAULT NULL COMMENT '臂长(上部分)',
  `arm_length_down` double DEFAULT NULL COMMENT '臂长(下部分)',
  `leg_length_up` double DEFAULT NULL COMMENT '腿长(上部分)',
  `leg_length_down` double DEFAULT NULL COMMENT '腿长(下部分)',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of bdl_skeleton_length
-- ----------------------------

-- ----------------------------
-- Table structure for bdl_system_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_system_setting`;
CREATE TABLE `bdl_system_setting` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `organization_name` varchar(255) DEFAULT NULL COMMENT '机构名称',
  `organization_phone` varchar(255) DEFAULT NULL COMMENT '机构电话',
  `organization_address` varchar(255) DEFAULT NULL COMMENT '机构地址',
  `ip_address` varchar(255) DEFAULT NULL COMMENT 'ip地址',
  `system_version` tinyint(255) DEFAULT NULL COMMENT '系统版本 0：标准版 1：豪华版',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_system_setting系统设置';

-- ----------------------------
-- Records of bdl_system_setting
-- ----------------------------
INSERT INTO `bdl_system_setting` VALUES ('1', '青岛科技大学', '123455677', '青岛崂山区松岭路99', '127.0.0.1', '1', '2019-03-01 10:11:16', null);

-- ----------------------------
-- Table structure for bdl_training_activity_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_activity_record`;
CREATE TABLE `bdl_training_activity_record` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `fk_training_course_id` int(10) unsigned NOT NULL COMMENT '外键训练课程id',
  `fk_activity_id` int(10) DEFAULT NULL COMMENT '外键，训练活动ID',
  `activity_type` varchar(8) DEFAULT NULL COMMENT ' 训练活动编码：力量循环或者力量耐力循环',
  `course_count` int(10) unsigned DEFAULT NULL COMMENT '课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_activity_record训练活动记录表';

-- ----------------------------
-- Records of bdl_training_activity_record
-- ----------------------------
INSERT INTO `bdl_training_activity_record` VALUES ('3101', '5101', '2901', '0', '0', '1', '2019-03-28 01:01:19', '2019-04-07 17:38:44');
INSERT INTO `bdl_training_activity_record` VALUES ('3102', '5401', '3201', '0', '0', '0', '2019-03-28 01:02:28', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3201', '5101', '2901', '0', '0', '0', '2019-04-07 16:31:47', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3301', '5101', '2901', '0', '0', '0', '2019-04-07 17:15:08', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3302', '5101', '2902', '1', '0', '1', '2019-04-07 17:16:11', '2019-04-07 18:58:35');
INSERT INTO `bdl_training_activity_record` VALUES ('3303', '5601', '3402', '1', '0', '0', '2019-04-07 17:45:37', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3304', '5604', '3407', '1', '0', '0', '2019-04-07 18:11:09', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3305', '5101', '2902', '1', '1', '1', '2019-04-07 18:59:10', '2019-04-07 19:18:07');
INSERT INTO `bdl_training_activity_record` VALUES ('3306', '5101', '2902', '1', '1', '0', '2019-04-07 19:18:40', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3307', '5101', '2901', '0', '1', '1', '2019-04-07 19:22:38', '2019-04-07 19:36:09');
INSERT INTO `bdl_training_activity_record` VALUES ('3308', '5101', '2901', '0', '1', '0', '2019-04-07 19:36:25', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3309', '5101', '2901', '0', '1', '0', '2019-04-07 20:52:47', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3310', '5101', '2901', '0', '1', '0', '2019-04-07 20:52:52', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3311', '5101', '2901', '0', '1', '1', '2019-04-07 20:52:58', '2019-04-07 21:50:36');
INSERT INTO `bdl_training_activity_record` VALUES ('3401', '5101', '2901', '0', '2', '1', '2019-04-07 21:51:05', '2019-04-07 21:59:11');
INSERT INTO `bdl_training_activity_record` VALUES ('3402', '5101', '2902', '1', '2', '1', '2019-04-07 21:53:35', '2019-04-07 23:07:44');
INSERT INTO `bdl_training_activity_record` VALUES ('3403', '5101', '2901', '0', '2', '1', '2019-04-07 21:59:35', '2019-04-07 22:09:11');
INSERT INTO `bdl_training_activity_record` VALUES ('3404', '5101', '2901', '0', '2', '1', '2019-04-07 22:09:42', '2019-04-07 22:51:46');
INSERT INTO `bdl_training_activity_record` VALUES ('3405', '5701', '3502', '1', '0', '0', '2019-04-07 22:31:15', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3406', '5604', '3406', '0', '0', '0', '2019-04-07 22:37:56', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3407', '5101', '2901', '0', '2', '1', '2019-04-07 22:52:10', '2019-04-07 22:55:45');
INSERT INTO `bdl_training_activity_record` VALUES ('3408', '5101', '2901', '0', '2', '1', '2019-04-07 22:56:30', '2019-04-07 22:58:46');
INSERT INTO `bdl_training_activity_record` VALUES ('3409', '5101', '2901', '0', '2', '0', '2019-04-07 22:59:11', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3410', '5101', '2902', '1', '2', '0', '2019-04-07 23:08:14', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3501', '5801', '3601', '0', '0', '0', '2019-04-11 22:17:07', null);
INSERT INTO `bdl_training_activity_record` VALUES ('3502', '5701', '3501', '0', '0', '0', '2019-04-11 22:24:33', null);

-- ----------------------------
-- Table structure for bdl_training_course
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_course`;
CREATE TABLE `bdl_training_course` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL,
  `fk_training_plan_id` int(10) unsigned DEFAULT NULL COMMENT '外键训练计划id',
  `rest_days` int(10) unsigned DEFAULT NULL COMMENT '休息天数（间隔）',
  `target_course_count` int(10) unsigned DEFAULT NULL COMMENT '目标课程轮次计数=前端课程天',
  `current_course_count` int(10) unsigned DEFAULT '0' COMMENT '当前课程轮次计数',
  `start_date` date DEFAULT NULL COMMENT '起始日期',
  `end_date` date DEFAULT NULL COMMENT '预计结束日期=起始日期+休息天数*课程天数',
  `current_end_date` date DEFAULT NULL COMMENT '当前进度预计结束日期.更新完成状态时，根据计数和间隔更新此日期',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_course训练课程表';

-- ----------------------------
-- Records of bdl_training_course
-- ----------------------------
INSERT INTO `bdl_training_course` VALUES ('1', '1', '1', '10', '6', '6', '2019-01-21', null, '2019-01-29', '1', '2019-01-21 14:08:01', null);
INSERT INTO `bdl_training_course` VALUES ('2', '305865088', '2', '1', '6', '9', '2018-12-31', '2019-01-05', '2019-01-24', '1', '2019-01-28 15:26:24', null);
INSERT INTO `bdl_training_course` VALUES ('1901', '305865088', '1901', '4', '16', null, '2019-02-26', '2019-04-27', null, '1', '2019-02-26 23:51:15', null);
INSERT INTO `bdl_training_course` VALUES ('2001', '305865088', '2001', '4', '16', null, '2019-02-26', '2019-04-27', null, '1', '2019-02-26 23:57:01', null);
INSERT INTO `bdl_training_course` VALUES ('2101', '305865088', '2101', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 00:04:22', null);
INSERT INTO `bdl_training_course` VALUES ('2201', '305865088', '2201', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 16:29:17', null);
INSERT INTO `bdl_training_course` VALUES ('2301', '305865088', '2301', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 16:34:25', null);
INSERT INTO `bdl_training_course` VALUES ('2401', '305865088', '2401', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 16:42:06', null);
INSERT INTO `bdl_training_course` VALUES ('2501', '305865088', '2501', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 16:45:51', null);
INSERT INTO `bdl_training_course` VALUES ('2601', '305865088', '2601', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:15:07', null);
INSERT INTO `bdl_training_course` VALUES ('2701', '305865088', '2701', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:24:47', null);
INSERT INTO `bdl_training_course` VALUES ('2801', '305865088', '2801', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:36:25', null);
INSERT INTO `bdl_training_course` VALUES ('2901', '305865088', '2901', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:40:45', null);
INSERT INTO `bdl_training_course` VALUES ('3001', '305865088', '3001', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:45:07', null);
INSERT INTO `bdl_training_course` VALUES ('3002', '305865088', '3002', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 17:49:36', null);
INSERT INTO `bdl_training_course` VALUES ('3101', '305865088', '3101', '4', '16', null, '2019-02-27', '2019-04-28', null, '1', '2019-02-27 18:01:35', null);
INSERT INTO `bdl_training_course` VALUES ('3201', '305865088', '3201', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 00:42:47', null);
INSERT INTO `bdl_training_course` VALUES ('3202', '305865088', '3202', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 00:44:09', null);
INSERT INTO `bdl_training_course` VALUES ('3301', '305865088', '3301', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 09:46:24', null);
INSERT INTO `bdl_training_course` VALUES ('3401', '305865088', '3401', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 10:30:39', null);
INSERT INTO `bdl_training_course` VALUES ('3501', '305865088', '3501', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 14:25:20', null);
INSERT INTO `bdl_training_course` VALUES ('3502', '305865088', '3502', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 14:33:12', null);
INSERT INTO `bdl_training_course` VALUES ('3503', '305865088', '3503', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 14:35:00', null);
INSERT INTO `bdl_training_course` VALUES ('3601', '305865088', '3601', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 16:32:17', null);
INSERT INTO `bdl_training_course` VALUES ('3602', '305865088', '3602', '4', '16', null, '2019-02-28', '2019-04-29', null, '1', '2019-02-28 16:32:42', null);
INSERT INTO `bdl_training_course` VALUES ('3701', '305865088', '3701', '4', '16', null, '2019-03-01', '2019-04-30', null, '1', '2019-03-01 12:52:31', null);
INSERT INTO `bdl_training_course` VALUES ('3801', '305865088', '3801', '4', '16', null, '2019-03-01', '2019-04-30', null, '1', '2019-03-01 13:07:42', null);
INSERT INTO `bdl_training_course` VALUES ('3802', '305865088', '3802', '4', '16', null, '2019-03-01', '2019-04-30', null, '1', '2019-03-01 13:09:49', null);
INSERT INTO `bdl_training_course` VALUES ('3901', '305865088', '3901', '4', '16', null, '2019-03-01', '2019-04-30', null, '1', '2019-03-01 13:38:12', null);
INSERT INTO `bdl_training_course` VALUES ('4001', '305865088', '4001', '2', '12', '7', '2019-03-02', '2019-03-24', null, '1', '2019-03-02 17:53:56', null);
INSERT INTO `bdl_training_course` VALUES ('4101', '305865088', '4101', '4', '16', '5', '2019-03-04', '2019-05-03', null, '1', '2019-03-04 10:31:53', null);
INSERT INTO `bdl_training_course` VALUES ('4201', '305865088', '4201', '4', '16', '0', '2019-03-05', '2019-05-04', null, '1', '2019-03-05 22:32:08', null);
INSERT INTO `bdl_training_course` VALUES ('4301', '305865088', '4301', '4', '16', '0', '2019-03-06', '2019-05-05', null, '1', '2019-03-06 01:35:15', null);
INSERT INTO `bdl_training_course` VALUES ('4401', '305865088', '4401', '4', '16', '0', '2019-03-07', '2019-05-06', null, '1', '2019-03-07 12:57:32', null);
INSERT INTO `bdl_training_course` VALUES ('4501', '17863979633', '4501', '6', '20', '2', '2019-03-10', '2019-07-02', null, '1', '2019-03-10 17:21:43', null);
INSERT INTO `bdl_training_course` VALUES ('4601', '305865088', '4601', '4', '16', '2', '2019-03-11', '2019-05-10', null, '1', '2019-03-11 12:37:12', null);
INSERT INTO `bdl_training_course` VALUES ('5101', 'YK-488A', '5101', '2', '3', '2', '2019-03-22', '2019-03-26', null, '0', '2019-03-22 15:00:18', null);
INSERT INTO `bdl_training_course` VALUES ('5201', '305865088', '5201', '1', '6', '1', '2019-03-25', '2019-03-30', null, '0', '2019-03-25 22:24:43', null);
INSERT INTO `bdl_training_course` VALUES ('5301', '徐靖皓5791', '5301', '4', '16', '0', '2019-03-25', '2019-05-24', null, '1', '2019-03-25 22:27:54', null);
INSERT INTO `bdl_training_course` VALUES ('5401', '徐靖皓91031', '5401', '4', '16', '0', '2019-03-25', '2019-05-24', null, '0', '2019-03-25 22:31:28', null);
INSERT INTO `bdl_training_course` VALUES ('5501', '17863979633', '5501', '4', '16', '0', '2019-04-04', '2019-06-03', null, '0', '2019-04-04 19:40:50', null);
INSERT INTO `bdl_training_course` VALUES ('5601', 'YK-4A50', '5601', '2', '16', '0', '2019-04-07', '2019-05-07', null, '0', '2019-04-07 17:45:37', null);
INSERT INTO `bdl_training_course` VALUES ('5602', '张方琛23180118', '5602', '2', '16', '0', '2019-04-07', '2019-05-07', null, '1', '2019-04-07 18:06:19', null);
INSERT INTO `bdl_training_course` VALUES ('5603', '张方琛23180118', '5603', '2', '16', '0', '2019-04-07', '2019-05-07', null, '0', '2019-04-07 18:08:53', null);
INSERT INTO `bdl_training_course` VALUES ('5604', 'YK-4B07', '5604', '2', '16', '0', '2019-04-07', '2019-05-07', null, '0', '2019-04-07 18:11:09', null);
INSERT INTO `bdl_training_course` VALUES ('5701', '陈其钊9633', '5701', '2', '16', '0', '2019-04-07', '2019-05-07', null, '0', '2019-04-07 22:31:15', null);
INSERT INTO `bdl_training_course` VALUES ('5801', '陈梓豪9633', '5801', '2', '16', '0', '2019-04-11', '2019-05-11', null, '0', '2019-04-11 22:17:06', null);

-- ----------------------------
-- Table structure for bdl_training_device_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_device_record`;
CREATE TABLE `bdl_training_device_record` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员id',
  `fk_training_activity_record_id` int(10) unsigned DEFAULT NULL COMMENT '外键训练活动记录id',
  `activity_type` varchar(8) DEFAULT NULL COMMENT '训练活动类型编码',
  `device_order_number` int(10) unsigned DEFAULT NULL COMMENT '设备在循环中的序号',
  `device_code` varchar(8) DEFAULT NULL COMMENT '设备名',
  `training_mode` varchar(8) DEFAULT NULL COMMENT '训练模式',
  `consequent_force` double(10,2) DEFAULT NULL,
  `reverse_force` double(10,2) DEFAULT NULL,
  `power` double(10,2) unsigned DEFAULT NULL COMMENT '功率',
  `count` int(10) unsigned DEFAULT NULL COMMENT '训练个数',
  `speed` double(10,2) unsigned DEFAULT NULL COMMENT '速度 1位小数 千米每时',
  `distance` double(10,2) unsigned DEFAULT NULL COMMENT '距离 千米，两位小数',
  `energy` double(10,2) DEFAULT NULL COMMENT '训练总耗能 单位卡路里',
  `training_time` int(10) unsigned DEFAULT NULL COMMENT '训练时间 单位秒',
  `avg_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '平均心率',
  `max_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最大心率',
  `min_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最小心率',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_device_record训练设备记录表';

-- ----------------------------
-- Records of bdl_training_device_record
-- ----------------------------
INSERT INTO `bdl_training_device_record` VALUES ('0', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1', '123456', '201', '0', null, '10', null, null, null, null, null, null, null, null, null, null, null, null, '2019-01-23 14:19:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('2', '123456', '201', '0', null, '11', '', null, null, null, null, null, null, null, null, null, null, null, '2019-01-23 14:19:42', '2019-01-23 15:05:51');
INSERT INTO `bdl_training_device_record` VALUES ('3', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('4', '123456', '201', '1', null, '13', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('5', '123456', '201', '1', null, '14', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('6', '123456', '201', '1', null, '15', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('7', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('8', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('101', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:26:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('102', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:28:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('201', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:29:43', null);
INSERT INTO `bdl_training_device_record` VALUES ('301', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:32:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('401', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:33:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('402', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('403', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('404', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '0', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('405', '305865088', '202', '1', '1', '9', '1', '20.50', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('406', '305865088', '202', '1', '2', '10', '1', '41.00', '15.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('407', '305865088', '202', '1', '3', '11', '1', '19.00', '52.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('408', '305865088', '202', '1', '4', '12', '1', '14.00', '65.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('409', '305865088', '203', '1', '1', '9', '1', '17.00', '32.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 12:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('410', '305865088', '203', '1', '2', '10', '1', '30.00', '36.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 14:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('411', '305865088', '203', '1', '3', '11', '1', '24.00', '29.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 15:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('412', '305865088', '203', '1', '4', '12', '1', '33.00', '40.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 18:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('413', '305865088', '204', '0', '1', '0', '1', '44.00', '55.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-09 22:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('414', '305865088', '204', '0', '2', '1', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-02-01 22:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('415', '305865088', '204', '0', '3', '5', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('416', '305865088', '205', '0', '1', '0', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:01:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('417', '305865088', '205', '0', '2', '1', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-04 22:02:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('418', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-01 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('419', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('420', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('421', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('422', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('1801', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1802', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1803', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1804', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1805', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1806', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1807', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1808', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('1809', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1810', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1811', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1812', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1813', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1814', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1815', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1816', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1817', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1818', 'YK-4A50', '20', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1819', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1820', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1821', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1822', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1823', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1824', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1825', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1826', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1827', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('1828', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1829', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1830', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1831', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1832', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1833', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1834', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1835', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1836', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1837', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1838', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1839', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1840', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1841', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1842', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1843', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1844', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1845', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1846', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1847', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1848', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1849', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('1850', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1851', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1852', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1853', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1854', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1855', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1856', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1857', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1858', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1859', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1860', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1861', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1862', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1863', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1864', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1865', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1866', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1867', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1868', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1869', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1870', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1871', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('1872', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1873', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1874', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1875', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1876', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1877', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1878', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1879', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1880', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1881', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1882', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1883', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1884', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1885', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1886', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1887', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1888', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1889', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1890', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1891', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1892', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('1893', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1894', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1895', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1896', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1897', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1898', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1899', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1900', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1901', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1902', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1903', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1904', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1905', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1906', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1907', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('1908', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1909', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1910', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1911', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1912', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1913', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1914', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1915', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1916', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1917', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1918', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1919', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1920', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1921', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1922', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1923', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1924', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1925', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1926', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1927', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1928', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('1929', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1930', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1931', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1932', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1933', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1934', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1935', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1936', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1937', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1938', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1939', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1940', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1941', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1942', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1943', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1944', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1945', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1946', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1947', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1948', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('1949', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1950', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1951', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1952', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1953', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1954', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1955', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1956', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1957', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1958', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1959', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1960', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1961', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1962', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1963', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1964', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1965', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('1966', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1967', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1968', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1969', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1970', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1971', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1972', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1973', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1974', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1975', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1976', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1977', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1978', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1979', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1980', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1981', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1982', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1983', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1984', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1985', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('1986', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1987', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1988', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1989', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1990', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1991', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1992', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1993', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1994', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1995', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1996', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1997', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1998', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('1999', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('2000', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:02:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('2101', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2102', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2103', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2104', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2105', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2106', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2107', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2108', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2109', 'YK-4A50', '20', '0', null, '0', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 16:05:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2110', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2111', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2112', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2113', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2114', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2115', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2116', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2117', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2118', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:12:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2119', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('2120', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('2121', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('2122', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('2123', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('2124', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('2125', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('2126', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('2127', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:13:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('2128', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2129', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2130', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2131', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2132', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2133', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2134', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2135', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2136', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:15:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2137', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2138', 'YK-488A', '3101', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2139', 'YK-488A', '3101', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2140', 'YK-488A', '3101', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2141', 'YK-488A', '3101', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2142', 'YK-488A', '3101', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2143', 'YK-488A', '3101', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2144', 'YK-488A', '3101', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2145', 'YK-488A', '3101', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:27:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('2201', 'YK-488A', '3101', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('2202', 'YK-488A', '3101', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2203', 'YK-488A', '3101', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2204', 'YK-488A', '3101', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2205', 'YK-488A', '3101', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2206', 'YK-488A', '3101', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2207', 'YK-488A', '3101', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2208', 'YK-488A', '3101', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2209', 'YK-488A', '3101', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:31:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2210', 'YK-488A', '3203', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2211', 'YK-488A', '3203', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2212', 'YK-488A', '3203', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2213', 'YK-488A', '3203', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2214', 'YK-488A', '3203', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2215', 'YK-488A', '3203', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('2216', 'YK-488A', '3203', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('2217', 'YK-488A', '3203', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 16:51:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('2301', 'YK-488A', '3204', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2302', 'YK-488A', '3204', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2303', 'YK-488A', '3204', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2304', 'YK-488A', '3204', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2305', 'YK-488A', '3204', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2306', 'YK-488A', '3204', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2307', 'YK-488A', '3204', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2308', 'YK-488A', '3204', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2309', 'YK-488A', '3204', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2310', 'YK-488A', '3204', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2311', 'YK-488A', '3204', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2312', 'YK-488A', '3204', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('2313', 'YK-488A', '3204', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2314', 'YK-488A', '3204', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2315', 'YK-488A', '3204', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2316', 'YK-488A', '3204', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2317', 'YK-488A', '3204', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2318', 'YK-488A', '3204', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2319', 'YK-488A', '3204', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2320', 'YK-488A', '3204', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2321', 'YK-488A', '3204', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2322', 'YK-488A', '3204', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2323', 'YK-488A', '3204', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2324', 'YK-488A', '3204', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 17:10:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2325', 'YK-488A', '3302', '1', null, '9', '0', '0.00', '0.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-07 18:42:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('2326', 'YK-488A', '3302', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2327', 'YK-488A', '3302', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2328', 'YK-488A', '3302', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2329', 'YK-488A', '3302', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2330', 'YK-488A', '3302', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2331', 'YK-488A', '3302', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2332', 'YK-488A', '3302', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2333', 'YK-488A', '3302', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2334', 'YK-488A', '3302', '1', null, '9', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2335', 'YK-488A', '3302', '1', null, '10', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2336', 'YK-488A', '3302', '1', null, '11', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2337', 'YK-488A', '3302', '1', null, '12', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2338', 'YK-488A', '3302', '1', null, '13', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2339', 'YK-488A', '3302', '1', null, '14', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2340', 'YK-488A', '3302', '1', null, '15', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2341', 'YK-488A', '3302', '1', null, '16', '4', '9.00', '12.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 18:58:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2342', 'YK-488A', '3305', '1', null, '9', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2343', 'YK-488A', '3305', '1', null, '10', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2344', 'YK-488A', '3305', '1', null, '11', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2345', 'YK-488A', '3305', '1', null, '12', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2346', 'YK-488A', '3305', '1', null, '13', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2347', 'YK-488A', '3305', '1', null, '14', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2348', 'YK-488A', '3305', '1', null, '15', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2349', 'YK-488A', '3305', '1', null, '16', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:18:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2350', 'YK-488A', '3307', '0', null, '0', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('2351', 'YK-488A', '3307', '0', null, '1', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2352', 'YK-488A', '3307', '0', null, '2', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2353', 'YK-488A', '3307', '0', null, '3', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2354', 'YK-488A', '3307', '0', null, '4', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2355', 'YK-488A', '3307', '0', null, '5', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2356', 'YK-488A', '3307', '0', null, '6', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2357', 'YK-488A', '3307', '0', null, '7', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2358', 'YK-488A', '3307', '0', null, '8', '2', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 19:36:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2401', 'YK-488A', '3311', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2402', 'YK-488A', '3311', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2403', 'YK-488A', '3311', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2404', 'YK-488A', '3311', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2405', 'YK-488A', '3311', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2406', 'YK-488A', '3311', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2407', 'YK-488A', '3311', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2408', 'YK-488A', '3311', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2409', 'YK-488A', '3311', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2410', 'YK-488A', '3311', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2411', 'YK-488A', '3311', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2412', 'YK-488A', '3311', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2413', 'YK-488A', '3311', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2414', 'YK-488A', '3311', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2415', 'YK-488A', '3311', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2416', 'YK-488A', '3311', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2417', 'YK-488A', '3311', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2418', 'YK-488A', '3311', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2419', 'YK-488A', '3311', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2420', 'YK-488A', '3311', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2421', 'YK-488A', '3311', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2422', 'YK-488A', '3311', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2423', 'YK-488A', '3311', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2424', 'YK-488A', '3311', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2425', 'YK-488A', '3311', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2426', 'YK-488A', '3311', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2427', 'YK-488A', '3311', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2428', 'YK-488A', '3311', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2429', 'YK-488A', '3311', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2430', 'YK-488A', '3311', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2431', 'YK-488A', '3311', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2432', 'YK-488A', '3311', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2433', 'YK-488A', '3311', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2434', 'YK-488A', '3311', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2435', 'YK-488A', '3311', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2436', 'YK-488A', '3311', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:50:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('2437', 'YK-488A', '3401', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2438', 'YK-488A', '3401', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2439', 'YK-488A', '3401', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2440', 'YK-488A', '3401', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2441', 'YK-488A', '3401', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2442', 'YK-488A', '3401', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2443', 'YK-488A', '3401', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2444', 'YK-488A', '3401', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2445', 'YK-488A', '3401', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 21:59:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2446', 'YK-488A', '3403', '0', null, '0', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2447', 'YK-488A', '3403', '0', null, '1', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2448', 'YK-488A', '3403', '0', null, '2', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2449', 'YK-488A', '3403', '0', null, '3', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2450', 'YK-488A', '3403', '0', null, '4', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2451', 'YK-488A', '3403', '0', null, '5', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2452', 'YK-488A', '3403', '0', null, '6', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2453', 'YK-488A', '3403', '0', null, '7', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2454', 'YK-488A', '3403', '0', null, '8', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:09:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2455', 'YK-488A', '3404', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2456', 'YK-488A', '3404', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2457', 'YK-488A', '3404', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2458', 'YK-488A', '3404', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2459', 'YK-488A', '3404', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2460', 'YK-488A', '3404', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2461', 'YK-488A', '3404', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2462', 'YK-488A', '3404', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:51:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2463', 'YK-488A', '20', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2464', 'YK-488A', '20', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2465', 'YK-488A', '20', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2466', 'YK-488A', '20', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2467', 'YK-488A', '20', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2468', 'YK-488A', '20', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2469', 'YK-488A', '20', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2470', 'YK-488A', '20', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:54:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('2471', 'YK-488A', '3407', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:45', null);
INSERT INTO `bdl_training_device_record` VALUES ('2472', 'YK-488A', '3407', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2473', 'YK-488A', '3407', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2474', 'YK-488A', '3407', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2475', 'YK-488A', '3407', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2476', 'YK-488A', '3407', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2477', 'YK-488A', '3407', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2478', 'YK-488A', '3407', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:55:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2479', 'YK-488A', '3408', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:45', null);
INSERT INTO `bdl_training_device_record` VALUES ('2480', 'YK-488A', '3408', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2481', 'YK-488A', '3408', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2482', 'YK-488A', '3408', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2483', 'YK-488A', '3408', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2484', 'YK-488A', '3408', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2485', 'YK-488A', '3408', '1', null, '15', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('2486', 'YK-488A', '3408', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 22:58:47', null);
INSERT INTO `bdl_training_device_record` VALUES ('2487', 'YK-488A', '3402', '1', null, '9', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:43', null);
INSERT INTO `bdl_training_device_record` VALUES ('2488', 'YK-488A', '3402', '1', null, '10', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2489', 'YK-488A', '3402', '1', null, '11', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2490', 'YK-488A', '3402', '1', null, '12', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2491', 'YK-488A', '3402', '1', null, '13', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2492', 'YK-488A', '3402', '1', null, '14', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2493', 'YK-488A', '3402', '1', null, '15', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2494', 'YK-488A', '3402', '1', null, '16', '4', '5.00', '5.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:07:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('2495', 'YK-488A', '3410', '1', null, '9', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2496', 'YK-488A', '3410', '1', null, '10', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2497', 'YK-488A', '3410', '1', null, '11', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2498', 'YK-488A', '3410', '1', null, '12', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2499', 'YK-488A', '3410', '1', null, '13', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2500', 'YK-488A', '3410', '1', null, '14', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:09:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2501', 'YK-488A', '3410', '1', null, '16', '0', '456.00', '123.00', '789.00', '987', null, '654.00', '321.00', '666', '11', '22', '33', '2019-04-07 23:10:50', null);
INSERT INTO `bdl_training_device_record` VALUES ('2601', '陈梓豪9633', '3501', '0', null, '0', '3', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '13', '0', '0', '0', '2019-04-14 23:30:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('2602', '陈梓豪9633', '3501', '0', null, '0', '3', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '52', '0', '0', '0', '2019-04-14 23:32:43', null);
INSERT INTO `bdl_training_device_record` VALUES ('2603', '陈其钊9633', '3502', '0', null, '0', '3', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '11', '0', '0', '0', '2019-04-14 23:40:28', null);
INSERT INTO `bdl_training_device_record` VALUES ('2604', '陈梓豪9633', '3501', '0', null, '0', '3', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '27', '0', '0', '0', '2019-04-14 23:41:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('2605', '陈梓豪9633', '20', '0', null, '0', '6', '0.00', '0.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2606', '陈梓豪9633', '20', '0', null, '0', '6', '0.00', '0.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('2607', '陈梓豪9633', '20', '0', null, '0', '6', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('2608', '陈梓豪9633', '20', '0', null, '0', '6', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('2609', '陈梓豪9633', '20', '0', null, '0', '6', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('2610', '陈梓豪9633', '20', '0', null, '0', '6', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-15 00:26:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('2611', '陈梓豪9633', '3501', '0', null, '0', '6', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '26', '45', '90', '0', '2019-04-15 00:28:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('2701', '陈梓豪9633', '3501', '0', null, '0', '0', '17.00', '17.00', '0.00', '1', null, '0.00', '0.00', '5', '0', '0', '0', '2019-04-16 14:00:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('2702', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '36', '0', '0', '0', '2019-04-16 14:02:28', null);
INSERT INTO `bdl_training_device_record` VALUES ('2703', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '1', null, '0.00', '0.00', '8', '0', '0', '0', '2019-04-16 14:09:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('2704', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '46', '0', '0', '0', '2019-04-16 14:11:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2705', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '3', null, '0.00', '0.00', '21', '0', '0', '0', '2019-04-16 14:12:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('2706', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '19', '0', '0', '0', '2019-04-16 14:32:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('2707', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '19', '0', '0', '0', '2019-04-16 14:35:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('2708', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '5', null, '0.00', '0.00', '27', '0', '0', '0', '2019-04-16 14:40:34', null);
INSERT INTO `bdl_training_device_record` VALUES ('2709', '陈梓豪9633', '3501', '0', null, '0', '1', '17.00', '21.00', '0.00', '0', null, '0.00', '0.00', '24', '0', '0', '0', '2019-04-16 14:41:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('2710', '陈梓豪9633', '3501', '0', null, '0', '1', '19.00', '21.00', '0.00', '0', null, '0.00', '0.00', '17', '0', '0', '0', '2019-04-16 14:58:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2711', '陈梓豪9633', '3501', '0', null, '0', '1', '19.00', '21.00', '0.00', '0', null, '0.00', '0.00', '11', '0', '0', '0', '2019-04-16 15:09:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('2712', '陈梓豪9633', '3501', '0', null, '0', '2', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '23', '0', '0', '0', '2019-04-16 15:11:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2713', '陈梓豪9633', '3501', '0', null, '0', '2', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '10', '0', '0', '0', '2019-04-16 15:14:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2714', '陈其钊9633', '1', '0', null, '0', '0', '21.00', '21.00', '0.00', '6', null, '0.00', '0.00', '58', '0', '0', '0', '2019-04-16 15:48:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('2715', '陈其钊9633', '1', '0', null, '0', '0', '21.00', '21.00', '0.00', '1', null, '0.00', '0.00', '9', '0', '0', '0', '2019-04-16 16:23:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('2716', '陈梓豪9633', '3501', '0', null, '0', '2', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-16 16:25:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('2717', '陈梓豪9633', '3501', '0', null, '0', '2', '21.00', '21.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-16 16:36:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('2718', '陈梓豪9633', '3501', '0', null, '0', '2', '5.00', '5.00', '0.00', '5', null, '0.00', '0.00', '33', '0', '0', '0', '2019-04-16 19:13:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('2801', '陈梓豪9633', '3501', '0', null, '0', '2', '21.00', '21.00', '0.00', '5', null, '0.00', '0.00', '36', '0', '0', '0', '2019-04-16 22:38:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('2802', '陈梓豪9633', '3501', '0', null, '0', '3', '21.00', '21.00', '0.00', '8', null, '0.00', '0.00', '46', '78', '90', '0', '2019-04-16 22:40:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('2803', '陈梓豪9633', '3501', '0', null, '0', '4', '27.00', '21.00', '0.00', '2', null, '0.00', '0.00', '22', '0', '0', '0', '2019-04-16 22:41:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2804', '陈梓豪9633', '3501', '0', null, '0', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-16 22:46:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('2805', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '5', null, '0.00', '0.00', '37', '0', '0', '0', '2019-04-16 22:47:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('2806', '陈梓豪9633', '3501', '0', null, '0', '0', '24.00', '24.00', '0.00', '4', null, '0.00', '0.00', '28', '0', '0', '0', '2019-04-16 22:55:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('2807', '陈梓豪9633', '3501', '0', null, '0', '1', '15.00', '21.00', '0.00', '3', null, '0.00', '0.00', '50', '0', '0', '0', '2019-04-16 22:56:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('2808', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '1', null, '0.00', '0.00', '25', '0', '0', '0', '2019-04-16 23:07:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2809', '陈梓豪9633', '3501', '0', null, '0', '1', '19.00', '21.00', '0.00', '1', null, '0.00', '0.00', '52', '0', '0', '0', '2019-04-16 23:10:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2810', '陈梓豪9633', '3501', '0', null, '0', '1', '19.00', '21.00', '0.00', '1', null, '0.00', '0.00', '52', '0', '0', '0', '2019-04-16 23:10:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('2811', '陈梓豪9633', '3501', '0', null, '0', '1', '19.00', '21.00', '0.00', '1', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-16 23:14:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('2812', '陈梓豪9633', '3501', '0', null, '0', '1', '21.00', '21.00', '0.00', '5', null, '0.00', '0.00', '36', '0', '0', '0', '2019-04-16 23:17:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('2813', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '7', null, '0.00', '0.00', '51', '0', '0', '0', '2019-04-16 23:19:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2814', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '4', null, '0.00', '0.00', '26', '0', '0', '0', '2019-04-16 23:22:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2815', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '1', null, '0.00', '0.00', '9', '0', '0', '0', '2019-04-16 23:25:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('2816', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '6', null, '0.00', '0.00', '45', '0', '0', '0', '2019-04-16 23:28:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2817', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '5', null, '0.00', '0.00', '37', '0', '0', '0', '2019-04-16 23:46:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2818', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '59', '0', '0', '0', '2019-04-16 23:58:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('2819', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '7', null, '0.00', '0.00', '46', '0', '0', '0', '2019-04-17 00:01:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('2820', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '54', '0', '0', '0', '2019-04-17 00:04:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2821', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '7', null, '0.00', '0.00', '56', '0', '0', '0', '2019-04-17 00:10:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2822', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '48', '0', '0', '0', '2019-04-17 00:14:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('2823', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '7', null, '0.00', '0.00', '49', '0', '0', '0', '2019-04-17 00:17:40', null);
INSERT INTO `bdl_training_device_record` VALUES ('2824', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '2', null, '0.00', '0.00', '10', '0', '0', '0', '2019-04-17 00:19:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2825', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-17 00:25:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2826', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '7', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-17 00:28:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('2827', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '54', '0', '0', '0', '2019-04-17 00:31:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('2828', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '8', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-17 00:35:40', null);
INSERT INTO `bdl_training_device_record` VALUES ('2829', '陈梓豪9633', '3501', '0', null, '0', '6', '0.00', '0.00', '0.00', '1', null, '0.00', '0.00', '8', '0', '0', '0', '2019-04-17 00:40:10', null);

-- ----------------------------
-- Table structure for bdl_training_plan
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_plan`;
CREATE TABLE `bdl_training_plan` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL,
  `fk_member_id` int(10) unsigned DEFAULT NULL COMMENT '会员id',
  `title` varchar(255) DEFAULT NULL COMMENT '训练标题',
  `start_date` date DEFAULT NULL COMMENT '起始日期',
  `training_target` varchar(255) DEFAULT NULL COMMENT '训练目标',
  `is_deleted` tinyint(4) unsigned DEFAULT '0' COMMENT '是否删除 1:删除;0:未删除',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_plan训练计划表';

-- ----------------------------
-- Records of bdl_training_plan
-- ----------------------------
INSERT INTO `bdl_training_plan` VALUES ('1', '123456', '1', '测试训练计划', '2019-01-21', null, '1', '2019-01-21 14:07:35', null);
INSERT INTO `bdl_training_plan` VALUES ('2', '305865088', '302', '测试训练计划128', '2019-01-16', '增肌', '1', '2019-01-28 15:24:35', null);
INSERT INTO `bdl_training_plan` VALUES ('1901', '305865088', '302', '226测试', '2019-02-26', '减脂', '1', '2019-02-26 23:51:14', null);
INSERT INTO `bdl_training_plan` VALUES ('2001', '305865088', '302', '测试226', '2019-02-26', '减脂', '1', '2019-02-26 23:57:01', null);
INSERT INTO `bdl_training_plan` VALUES ('2101', '305865088', '302', '测试226', '2019-02-27', '塑形', '1', '2019-02-27 00:04:22', null);
INSERT INTO `bdl_training_plan` VALUES ('2201', '305865088', '302', '227测试', '2019-02-27', '减脂', '1', '2019-02-27 16:29:17', null);
INSERT INTO `bdl_training_plan` VALUES ('2301', '305865088', '302', '227', '2019-02-27', '减脂', '1', '2019-02-27 16:34:25', null);
INSERT INTO `bdl_training_plan` VALUES ('2401', '305865088', '302', '227', '2019-02-27', '减脂', '1', '2019-02-27 16:41:50', null);
INSERT INTO `bdl_training_plan` VALUES ('2501', '305865088', '302', '227BUG测试', '2019-02-27', '塑形', '1', '2019-02-27 16:45:48', null);
INSERT INTO `bdl_training_plan` VALUES ('2601', '305865088', '302', '227测试', '2019-02-27', '减脂', '1', '2019-02-27 17:14:55', null);
INSERT INTO `bdl_training_plan` VALUES ('2701', '305865088', '302', '测试227', '2019-02-27', '减脂', '1', '2019-02-27 17:24:44', null);
INSERT INTO `bdl_training_plan` VALUES ('2801', '305865088', '302', '227测试', '2019-02-27', '减脂', '1', '2019-02-27 17:36:18', null);
INSERT INTO `bdl_training_plan` VALUES ('2901', '305865088', '302', '测试227', '2019-02-27', '塑形', '1', '2019-02-27 17:40:45', null);
INSERT INTO `bdl_training_plan` VALUES ('3001', '305865088', '302', '测试插入个人设置', '2019-02-27', '增肌', '1', '2019-02-27 17:45:07', null);
INSERT INTO `bdl_training_plan` VALUES ('3002', '305865088', '302', '227测试', '2019-02-27', '康复', '1', '2019-02-27 17:49:35', null);
INSERT INTO `bdl_training_plan` VALUES ('3101', '305865088', '302', '测试', '2019-02-27', '塑形', '1', '2019-02-27 18:01:35', null);
INSERT INTO `bdl_training_plan` VALUES ('3201', '305865088', '302', '228测试', '2019-02-28', '减脂', '1', '2019-02-28 00:42:47', null);
INSERT INTO `bdl_training_plan` VALUES ('3202', '305865088', '302', '测试228', '2019-02-28', '减脂', '1', '2019-02-28 00:44:09', null);
INSERT INTO `bdl_training_plan` VALUES ('3301', '305865088', '302', '测试228', '2019-02-28', '塑形', '1', '2019-02-28 09:46:24', null);
INSERT INTO `bdl_training_plan` VALUES ('3401', '305865088', '302', '测试228', '2019-02-28', '塑形', '1', '2019-02-28 10:30:39', null);
INSERT INTO `bdl_training_plan` VALUES ('3501', '305865088', '302', '测试228', '2019-02-28', '塑形', '1', '2019-02-28 14:25:20', null);
INSERT INTO `bdl_training_plan` VALUES ('3502', '305865088', '302', '训练228', '2019-02-28', '减脂', '1', '2019-02-28 14:33:12', null);
INSERT INTO `bdl_training_plan` VALUES ('3503', '305865088', '302', '测试228', '2019-02-28', '减脂', '1', '2019-02-28 14:35:00', null);
INSERT INTO `bdl_training_plan` VALUES ('3601', '305865088', '302', '测试229', '2019-02-28', '塑形', '1', '2019-02-28 16:32:17', null);
INSERT INTO `bdl_training_plan` VALUES ('3602', '305865088', '302', '测试229', '2019-02-28', '塑形', '1', '2019-02-28 16:32:42', null);
INSERT INTO `bdl_training_plan` VALUES ('3701', '305865088', '302', '测试31', '2019-03-01', '减脂', '1', '2019-03-01 12:52:31', null);
INSERT INTO `bdl_training_plan` VALUES ('3801', '305865088', '302', '测试3.1', '2019-03-01', '减脂', '1', '2019-03-01 13:07:42', null);
INSERT INTO `bdl_training_plan` VALUES ('3802', '305865088', '302', '测试31', '2019-03-01', '塑形', '1', '2019-03-01 13:09:49', null);
INSERT INTO `bdl_training_plan` VALUES ('3901', '305865088', '302', '测试225', '2019-03-01', '塑形', '1', '2019-03-01 13:38:12', null);
INSERT INTO `bdl_training_plan` VALUES ('4001', '305865088', '302', '红光满面5454', '2019-03-02', '减脂', '1', '2019-03-02 17:53:56', null);
INSERT INTO `bdl_training_plan` VALUES ('4101', '305865088', '302', '阿斯顿撒', '2019-03-04', '减脂', '1', '2019-03-04 10:31:52', null);
INSERT INTO `bdl_training_plan` VALUES ('4201', '305865088', '302', '撒大声地', '2019-03-05', '塑形', '1', '2019-03-05 22:32:08', null);
INSERT INTO `bdl_training_plan` VALUES ('4301', '305865088', '1701', '萨达撒', '2019-03-06', '减脂', '1', '2019-03-06 01:35:15', null);
INSERT INTO `bdl_training_plan` VALUES ('4401', '305865088', '2001', '测试训练计划37', '2019-03-07', '增肌', '1', '2019-03-07 12:57:32', null);
INSERT INTO `bdl_training_plan` VALUES ('4501', '17863979633', '301', '教练单独设置训练计划', '2019-03-10', '增肌', '1', '2019-03-10 17:21:43', null);
INSERT INTO `bdl_training_plan` VALUES ('4601', '305865088', '801', '测试教练用户共同训练计划', '2019-03-11', '塑形', '1', '2019-03-11 12:37:12', null);
INSERT INTO `bdl_training_plan` VALUES ('5101', 'YK-488A', '2501', '洗的蛋疼', '2019-03-22', '减脂', '0', '2019-03-22 15:00:18', null);
INSERT INTO `bdl_training_plan` VALUES ('5201', '305865088', '801', 'bibi', '2019-03-25', '减脂', '0', '2019-03-25 22:24:43', null);
INSERT INTO `bdl_training_plan` VALUES ('5301', '徐靖皓5791', '2601', 'bibi', '2019-03-25', '减脂', '1', '2019-03-25 22:27:54', null);
INSERT INTO `bdl_training_plan` VALUES ('5401', '徐靖皓91031', '2601', 'bbb', '2019-03-25', '减脂', '0', '2019-03-25 22:31:27', null);
INSERT INTO `bdl_training_plan` VALUES ('5501', '17863979633', '301', 'sd', '2019-04-04', '增肌', '0', '2019-04-04 19:40:50', null);
INSERT INTO `bdl_training_plan` VALUES ('5601', 'YK-4A50', '2701', '力量循环与力量耐力循环', '2019-04-07', '塑形', '0', '2019-04-07 17:45:37', null);
INSERT INTO `bdl_training_plan` VALUES ('5602', '张方琛23180118', '2702', '力量循环与力量耐力循环', '2019-04-07', '塑形', '1', '2019-04-07 18:06:19', null);
INSERT INTO `bdl_training_plan` VALUES ('5603', '张方琛23180118', '2702', '力量耐力循环', '2019-04-07', '塑形', '0', '2019-04-07 18:08:53', null);
INSERT INTO `bdl_training_plan` VALUES ('5604', 'YK-4B07', '2703', '力量循环与力量耐力循环', '2019-04-07', '塑形', '0', '2019-04-07 18:11:09', null);
INSERT INTO `bdl_training_plan` VALUES ('5701', '陈其钊9633', '2801', '力量循环与力量耐力循环', '2019-04-07', '塑形', '0', '2019-04-07 22:31:15', null);
INSERT INTO `bdl_training_plan` VALUES ('5801', '陈梓豪9633', '2901', '力量循环与力量耐力循环', '2019-04-11', '塑形', '0', '2019-04-11 22:17:06', null);

-- ----------------------------
-- Table structure for s_key
-- ----------------------------
DROP TABLE IF EXISTS `s_key`;
CREATE TABLE `s_key` (
  `key_id` longtext,
  `max_value` bigint(20) DEFAULT NULL,
  `steps` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of s_key
-- ----------------------------
INSERT INTO `s_key` VALUES ('bdl_member', '3000', '100');
INSERT INTO `s_key` VALUES ('bdl_training_activity_record', '3600', '100');
INSERT INTO `s_key` VALUES ('bdl_training_device_record', '2900', '100');
INSERT INTO `s_key` VALUES ('bdl_training_plan', '5900', '100');
INSERT INTO `s_key` VALUES ('bdl_training_course', '5900', '100');
INSERT INTO `s_key` VALUES ('bdl_activity', '3700', '100');
INSERT INTO `s_key` VALUES ('bdl_personal_setting', '900', '100');
