/*
Navicat MySQL Data Transfer

Source Server         : 华为云宝德龙智能健身
Source Server Version : 50724
Source Host           : 49.4.70.183:3306
Source Database       : ai_sports

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2019-04-28 14:06:06
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
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `member_id` (`fk_training_course_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_activity训练活动表';

-- ----------------------------
-- Records of bdl_activity
-- ----------------------------
INSERT INTO `bdl_activity` VALUES ('1', '1', '1', '123456', '1', '3', '0', '1', '2019-01-21 14:09:23', null);
INSERT INTO `bdl_activity` VALUES ('2', '2', '302', '305865088', '1', '6', '0', '1', '2019-01-26 12:50:08', '2019-04-27 16:31:48');
INSERT INTO `bdl_activity` VALUES ('3', '2', '302', '305865088', '0', '5', '0', '1', '2019-01-28 11:44:45', '2019-04-27 16:31:48');
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
INSERT INTO `bdl_activity` VALUES ('2201', '4501', '301', '17863979633', '0', '2', '0', '0', '2019-03-10 17:21:52', null);
INSERT INTO `bdl_activity` VALUES ('2202', '4501', '301', '17863979633', '1', '4', '0', '0', '2019-03-10 17:21:52', null);
INSERT INTO `bdl_activity` VALUES ('2301', '4601', '801', '305865088', '0', '4', '0', '1', '2019-03-11 12:37:15', null);
INSERT INTO `bdl_activity` VALUES ('2302', '4601', '801', '305865088', '1', '4', '0', '1', '2019-03-11 12:37:15', null);
INSERT INTO `bdl_activity` VALUES ('2401', '4701', '2401', '测试3242314', '0', '2', '0', '0', '2019-03-24 11:25:36', null);
INSERT INTO `bdl_activity` VALUES ('2402', '4701', '2401', '测试3242314', '1', '2', '0', '0', '2019-03-24 11:25:36', null);
INSERT INTO `bdl_activity` VALUES ('2501', '4801', '2501', '宝德龙0165', '0', '3', '0', '1', '2019-04-22 16:26:59', null);
INSERT INTO `bdl_activity` VALUES ('2502', '4801', '2501', '宝德龙0165', '1', '3', '0', '1', '2019-04-22 16:26:59', null);
INSERT INTO `bdl_activity` VALUES ('2601', '4901', '2501', '宝德龙0165', '1', '1', '0', '1', '2019-04-22 16:53:08', null);
INSERT INTO `bdl_activity` VALUES ('2602', '4902', '2501', '宝德龙0165', '0', '2', '0', '0', '2019-04-22 16:54:46', null);
INSERT INTO `bdl_activity` VALUES ('2603', '4902', '2501', '宝德龙0165', '1', '2', '0', '0', '2019-04-22 16:54:46', null);
INSERT INTO `bdl_activity` VALUES ('2701', '5001', '2601', '多垃圾8900', '0', '2', '0', '1', '2019-04-27 15:57:24', '2019-04-27 16:03:38');
INSERT INTO `bdl_activity` VALUES ('2702', '5001', '2601', '多垃圾8900', '1', '2', '0', '1', '2019-04-27 15:57:24', '2019-04-27 16:03:38');
INSERT INTO `bdl_activity` VALUES ('2703', '5002', '2601', '多垃圾8900', '0', '3', '0', '1', '2019-04-27 16:03:50', '2019-04-27 16:05:43');
INSERT INTO `bdl_activity` VALUES ('2704', '5002', '2601', '多垃圾8900', '1', '3', '0', '1', '2019-04-27 16:03:50', '2019-04-27 16:05:43');
INSERT INTO `bdl_activity` VALUES ('2801', '5401', '801', '305865088', '0', '4', '0', '1', '2019-04-27 17:42:03', '2019-04-27 20:48:07');
INSERT INTO `bdl_activity` VALUES ('2802', '5401', '801', '305865088', '1', '4', '0', '1', '2019-04-27 17:42:03', '2019-04-27 20:48:07');
INSERT INTO `bdl_activity` VALUES ('2901', '5501', '801', '305865088', '0', '2', '0', '0', '2019-04-27 20:48:18', null);
INSERT INTO `bdl_activity` VALUES ('2902', '5501', '801', '305865088', '1', '2', '0', '0', '2019-04-27 20:48:18', null);
INSERT INTO `bdl_activity` VALUES ('3001', '5601', '2701', '陈梓豪9633', '0', '2', '0', '0', '2019-04-28 11:44:18', null);
INSERT INTO `bdl_activity` VALUES ('3002', '5601', '2701', '陈梓豪9633', '1', '2', '0', '0', '2019-04-28 11:44:18', null);

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
  `role_id` tinyint(3) unsigned DEFAULT '1' COMMENT '角色id，1：会员；0：教练',
  `fk_coach_id` int(10) unsigned DEFAULT NULL COMMENT '外键关联教练id',
  `label_name` varchar(255) DEFAULT NULL COMMENT '标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔',
  `is_open_fat_reduction` tinyint(3) unsigned DEFAULT '0' COMMENT '是否开启减脂模式 默认0，0:未开启，1:开启',
  `remark` varchar(255) DEFAULT NULL COMMENT '前端备注',
  `last_login_date` datetime DEFAULT NULL COMMENT '上次登录日期',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_member会员表';

-- ----------------------------
-- Records of bdl_member
-- ----------------------------
INSERT INTO `bdl_member` VALUES ('1', '123456', null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, '2019-03-02 18:22:26', '2019-03-04 18:22:29');
INSERT INTO `bdl_member` VALUES ('2', '测试2', null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, '2019-03-03 18:22:30', '2019-03-04 18:22:43');
INSERT INTO `bdl_member` VALUES ('3', '测试3', null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, '2019-03-04 18:22:34', '2019-03-04 18:22:46');
INSERT INTO `bdl_member` VALUES ('4', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('5', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('6', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('7', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('8', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('9', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('10', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('101', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('102', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('103', null, null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, null);
INSERT INTO `bdl_member` VALUES ('104', '', null, '123', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, null, null, '2019-03-08 09:44:45');
INSERT INTO `bdl_member` VALUES ('201', '', '', '', '2019-01-03', '女', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '0', null, null, '0', '', '2019-01-10 17:28:12', '2019-01-18 17:28:03', '2019-03-10 17:28:24');
INSERT INTO `bdl_member` VALUES ('301', '17863979633', '教练', '李', '2019-01-11', '女', '山东省', '5465465465@qq.com', '5645445', '5454545', '54545', '60.00', '175.00', '0', '220', '168', '0', null, null, '0', '', '2019-04-28 11:36:55', '2019-03-01 17:28:34', '2019-03-10 17:28:38');
INSERT INTO `bdl_member` VALUES ('302', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, '0001-01-01 00:00:00', null, null);
INSERT INTO `bdl_member` VALUES ('701', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, '0001-01-01 00:00:00', null, null);
INSERT INTO `bdl_member` VALUES ('801', '305865088', '其钊2', '陈', '2019-03-02', '男', '山东省', '465464654@qq.com', '665454', '5454545', '17863979633', '140.00', '187.00', '25', '199', '168', '1', '301', '增肌,减脂,塑形,康复,', '1', '', '2019-04-28 11:36:48', '2019-03-04 19:34:55', '2019-04-27 20:48:55');
INSERT INTO `bdl_member` VALUES ('901', null, '其钊3', '陈', '2018-12-05', '男', '', '', '556445', '', '684665', '126.00', '179.00', '1', '219', '168', '1', null, '减脂,塑形,', '0', '', null, '2019-03-04 19:38:24', '2019-03-09 00:14:20');
INSERT INTO `bdl_member` VALUES ('902', null, '其钊3', '陈', '2018-12-05', '男', '', '', '556445', '', '684665', '126.00', '179.00', '1', '219', '168', '1', null, '减脂,塑形,', '0', '', null, '2019-03-04 19:38:48', '2019-03-09 00:14:20');
INSERT INTO `bdl_member` VALUES ('903', null, '其钊3', '陈', '2018-12-05', '男', '', '', '556445', '', '684665', '126.00', '179.00', '1', '219', '168', '1', null, '减脂,塑形,', '0', '', null, '2019-03-04 19:39:59', '2019-03-09 00:14:25');
INSERT INTO `bdl_member` VALUES ('904', null, '其钊3', '陈', '2018-12-05', '男', '', '', '556445', '', '684665', '126.00', '179.00', '1', '219', '168', '1', null, '减脂,塑形,', '0', '', null, '2019-03-04 19:44:27', '2019-03-09 00:14:21');
INSERT INTO `bdl_member` VALUES ('1001', null, '其钊4', '陈', '2019-03-08', '男', '', '65653', '3154534', '', '6435', '117.00', '192.00', '0', '220', '168', '1', null, '增肌,康复,', '0', '', null, '2019-03-04 19:50:59', '2019-03-09 00:14:21');
INSERT INTO `bdl_member` VALUES ('1101', null, '其钊', '陈', '2019-03-02', '男', '', '', '', '', '', '112.00', '152.00', '0', '220', '168', '1', null, '', '0', '', null, '2019-03-04 19:57:34', '2019-03-09 00:14:22');
INSERT INTO `bdl_member` VALUES ('1201', null, '其钊', '陈', '2019-03-01', '男', '', '', '', '', '', '114.00', '175.00', '0', '220', '168', '1', null, '增肌,减脂,塑形,康复,', '0', '', null, '2019-03-04 20:12:35', '2019-03-09 00:14:24');
INSERT INTO `bdl_member` VALUES ('1301', null, '其钊', '陈', '2019-03-14', '男', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '1', null, '增肌,减脂,塑形,', '0', '', null, '2019-03-04 20:18:57', '2019-03-09 00:14:22');
INSERT INTO `bdl_member` VALUES ('1401', null, '其钊', '陈', '2019-03-15', '男', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '1', null, '增肌,减脂,塑形,', '0', '', null, '2019-03-04 23:17:25', '2019-03-09 00:14:23');
INSERT INTO `bdl_member` VALUES ('1501', null, '萨达', '抽', '2019-03-09', '女', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '1', '301', '增肌,减脂,塑形,', '0', '', null, '2019-03-04 23:20:12', '2019-03-04 23:27:13');
INSERT INTO `bdl_member` VALUES ('1502', null, '萨达', '抽', '2019-03-09', '女', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '1', null, '增肌,减脂,塑形,', '0', '', null, '2019-03-04 23:23:45', '2019-03-09 00:14:27');
INSERT INTO `bdl_member` VALUES ('1503', null, '萨达', '抽', '2019-03-09', '女', '', '', '', '', '', '60.00', '175.00', '0', '220', '168', '1', null, '增肌,减脂,塑形,', '0', '', null, '2019-03-04 23:24:39', '2019-03-09 00:14:28');
INSERT INTO `bdl_member` VALUES ('1601', null, '喂喂喂', '陈', '2019-03-16', '男', '', '', '', '243324234', '234324', '60.00', '175.00', '0', '220', '168', '1', '301', '增肌,减脂,塑形,', '0', '', null, '2019-03-04 23:42:12', null);
INSERT INTO `bdl_member` VALUES ('1701', null, '其钊', '陈', '2019-03-09', '男', '', '', '', '', '', '60.00', '193.00', '0', '220', '168', '1', '301', '增肌,减脂,塑形,康复,', '0', '', null, '2019-03-06 01:33:59', null);
INSERT INTO `bdl_member` VALUES ('1801', null, '其钊', '陈', '2019-03-09', '男', '', '', '', '', '', '81.00', '175.00', '0', '220', '168', '1', '301', '', '0', '', null, '2019-03-06 12:41:39', null);
INSERT INTO `bdl_member` VALUES ('1901', null, '其钊', '陈', '2019-03-09', '男', '', '', '234234324', '234234', '12324234', '93.00', '173.00', '0', '220', '168', '1', '301', '增肌,减脂,塑形,康复,', '0', '奥术大师大所', null, '2019-03-06 17:22:56', null);
INSERT INTO `bdl_member` VALUES ('2001', null, '其钊', '陈', '2000-04-05', '男', '', '', '', '', '222222222222', '96.00', '195.00', '19', '201', '154', '1', '301', '增肌,减脂,塑形,康复,', '0', '', null, '2019-03-07 12:52:27', null);
INSERT INTO `bdl_member` VALUES ('2101', null, '胡', '教练', '2000-07-07', '男', '', '45654554', '545645545', '', '4456454545', '95.00', '184.00', '19', '201', '154', '0', null, '增肌,减脂,塑形,', '0', '我问问我问问无无无无无', null, '2019-03-13 18:20:24', '2019-03-13 19:09:03');
INSERT INTO `bdl_member` VALUES ('2102', 'YK-4901', '手环测试', '4901', null, null, null, null, null, null, null, null, null, null, null, null, '1', null, null, '0', null, '2019-03-23 14:53:42', '2019-03-18 22:52:42', '2019-03-18 22:54:28');
INSERT INTO `bdl_member` VALUES ('2201', '张方琛7896', '方琛', '张', '2019-03-08', '男', '', '', '', '', '1234567896', '79.00', '188.00', '0', '220', '168', '1', '301', '增肌,塑形,', '0', '', null, '2019-03-20 22:49:20', null);
INSERT INTO `bdl_member` VALUES ('2301', '陈梓豪1231', '梓豪', '陈', '2019-03-15', '男', '', '', '', '', '1231231', '100.00', '187.00', '0', '220', '168', '1', '301', '增肌,康复,', '0', '', null, '2019-03-20 23:15:47', null);
INSERT INTO `bdl_member` VALUES ('2302', '胡琛琛3123', '琛', '胡琛', '2019-03-16', '男', '', '', '', '', '123123123', '108.00', '185.00', '0', '195', '149', '1', '301', '增肌,塑形,', '0', '', null, '2019-03-20 23:19:04', null);
INSERT INTO `bdl_member` VALUES ('2401', '测试3242314', '324', '测试', '1998-04-05', '男', '', '', '', '', '2313212314', '102.00', '186.00', '21', '199', '152', '1', '301', '增肌,减脂,', '0', '', null, '2019-03-24 11:23:28', null);
INSERT INTO `bdl_member` VALUES ('2501', '宝德龙0165', '德龙', '宝', '1999-01-15', '男', '', '', '', '', '13721940165', '102.00', '185.00', '20', '200', '153', '1', '301', '增肌,塑形,', '1', '阿斯顿撒', '2019-04-22 17:23:11', '2019-04-22 16:26:58', '2019-04-22 16:28:52');
INSERT INTO `bdl_member` VALUES ('2601', '多垃圾8900', '垃圾', '多', '2010-01-15', '男', '', '', '', '', '12345678900', '106.00', '171.00', '9', '193', '148', '0', null, '增肌,减脂,', '1', '是你', null, '2019-04-27 15:57:21', '2019-04-27 16:01:19');
INSERT INTO `bdl_member` VALUES ('2701', '陈梓豪9633', '梓豪', '陈', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '0', null, '塑形,', '0', null, '2019-04-28 11:45:26', '2019-04-28 11:44:16', '2019-04-28 11:45:05');

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
  PRIMARY KEY (`id`),
  KEY `member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_personal_setting个人设置';

-- ----------------------------
-- Records of bdl_personal_setting
-- ----------------------------
INSERT INTO `bdl_personal_setting` VALUES ('101', '302', '305865088', '2901', '0', '0', '1', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('102', '302', '305865088', '2901', '0', '1', '2', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('103', '302', '305865088', '2901', '0', '2', '3', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('104', '302', '305865088', '2901', '0', '3', '4', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('105', '302', '305865088', '2901', '0', '4', '5', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('106', '302', '305865088', '2901', '0', '5', '6', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('107', '302', '305865088', '2901', '0', '6', '7', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('108', '302', '305865088', '2901', '0', '7', '8', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('109', '302', '305865088', '2901', '0', '8', '9', '2', null, null, null, null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:56');
INSERT INTO `bdl_personal_setting` VALUES ('110', '302', '305865088', '2902', '1', '9', '1', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('111', '302', '305865088', '2902', '1', '10', '2', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('112', '302', '305865088', '2902', '1', '11', '3', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('113', '302', '305865088', '2902', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('114', '302', '305865088', '2902', '1', '13', '5', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('115', '302', '305865088', '2902', '1', '14', '6', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('116', '302', '305865088', '2902', '1', '15', '7', '1', null, null, null, null, null, null, null, '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('117', '302', '305865088', '2902', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-02-28 00:44:15', '2019-04-27 20:48:16');
INSERT INTO `bdl_personal_setting` VALUES ('201', '301', '17863979633', '2201', '0', '0', '1', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('202', '301', '17863979633', '2201', '0', '1', '2', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('203', '301', '17863979633', '2201', '0', '2', '3', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('204', '301', '17863979633', '2201', '0', '3', '4', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('205', '301', '17863979633', '2201', '0', '4', '5', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('206', '301', '17863979633', '2201', '0', '5', '6', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('207', '301', '17863979633', '2201', '0', '6', '7', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('208', '301', '17863979633', '2201', '0', '7', '8', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('209', '301', '17863979633', '2201', '0', '8', '9', '1', null, null, null, null, null, null, null, '7.00', '6.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:16');
INSERT INTO `bdl_personal_setting` VALUES ('210', '301', '17863979633', '2202', '1', '9', '1', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('211', '301', '17863979633', '2202', '1', '10', '2', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('212', '301', '17863979633', '2202', '1', '11', '3', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('213', '301', '17863979633', '2202', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '70.00', null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('214', '301', '17863979633', '2202', '1', '13', '5', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('215', '301', '17863979633', '2202', '1', '14', '6', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('216', '301', '17863979633', '2202', '1', '15', '7', '2', null, null, null, null, null, null, null, '13.00', '9.00', null, null, '2019-03-10 17:21:52', '2019-03-10 17:22:39');
INSERT INTO `bdl_personal_setting` VALUES ('217', '301', '17863979633', '2202', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-03-10 17:21:52', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('301', '2401', '测试3242314', '2401', '0', '0', '1', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('302', '2401', '测试3242314', '2401', '0', '1', '2', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('303', '2401', '测试3242314', '2401', '0', '2', '3', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('304', '2401', '测试3242314', '2401', '0', '3', '4', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('305', '2401', '测试3242314', '2401', '0', '4', '5', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('306', '2401', '测试3242314', '2401', '0', '5', '6', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('307', '2401', '测试3242314', '2401', '0', '6', '7', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('308', '2401', '测试3242314', '2401', '0', '7', '8', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('309', '2401', '测试3242314', '2401', '0', '8', '9', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:36', '2019-03-24 11:27:36');
INSERT INTO `bdl_personal_setting` VALUES ('310', '2401', '测试3242314', '2402', '1', '9', '1', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('311', '2401', '测试3242314', '2402', '1', '10', '2', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('312', '2401', '测试3242314', '2402', '1', '11', '3', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('313', '2401', '测试3242314', '2402', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '50.00', null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('314', '2401', '测试3242314', '2402', '1', '13', '5', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('315', '2401', '测试3242314', '2402', '1', '14', '6', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('316', '2401', '测试3242314', '2402', '1', '15', '7', '1', null, null, null, null, null, null, null, '4.00', '4.00', null, null, '2019-03-24 11:25:37', '2019-03-24 11:27:52');
INSERT INTO `bdl_personal_setting` VALUES ('317', '2401', '测试3242314', '2402', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-03-24 11:25:37', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('401', '2501', '宝德龙0165', '2501', '0', '0', '1', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('402', '2501', '宝德龙0165', '2501', '0', '1', '2', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('403', '2501', '宝德龙0165', '2501', '0', '2', '3', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('404', '2501', '宝德龙0165', '2501', '0', '3', '4', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('405', '2501', '宝德龙0165', '2501', '0', '4', '5', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('406', '2501', '宝德龙0165', '2501', '0', '5', '6', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('407', '2501', '宝德龙0165', '2501', '0', '6', '7', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('408', '2501', '宝德龙0165', '2501', '0', '7', '8', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('409', '2501', '宝德龙0165', '2501', '0', '8', '9', '1', null, null, null, null, null, '150', '20', '21.00', '24.00', null, null, '2019-04-22 16:26:59', '2019-04-22 16:28:53');
INSERT INTO `bdl_personal_setting` VALUES ('410', '2501', '宝德龙0165', '2601', '1', '9', '1', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('411', '2501', '宝德龙0165', '2601', '1', '10', '2', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('412', '2501', '宝德龙0165', '2601', '1', '11', '3', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('413', '2501', '宝德龙0165', '2601', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('414', '2501', '宝德龙0165', '2601', '1', '13', '5', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('415', '2501', '宝德龙0165', '2601', '1', '14', '6', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('416', '2501', '宝德龙0165', '2601', '1', '15', '7', '1', null, null, null, null, null, '150', '20', '26.00', '34.00', null, null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('417', '2501', '宝德龙0165', '2601', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-22 16:27:00', '2019-04-22 16:53:33');
INSERT INTO `bdl_personal_setting` VALUES ('501', '2501', '宝德龙0165', '2602', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('502', '2501', '宝德龙0165', '2602', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('503', '2501', '宝德龙0165', '2602', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('504', '2501', '宝德龙0165', '2602', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('505', '2501', '宝德龙0165', '2602', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('506', '2501', '宝德龙0165', '2602', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('507', '2501', '宝德龙0165', '2602', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('508', '2501', '宝德龙0165', '2602', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('509', '2501', '宝德龙0165', '2602', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('510', '2501', '宝德龙0165', '2603', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('511', '2501', '宝德龙0165', '2603', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('512', '2501', '宝德龙0165', '2603', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('513', '2501', '宝德龙0165', '2603', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('514', '2501', '宝德龙0165', '2603', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('515', '2501', '宝德龙0165', '2603', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('516', '2501', '宝德龙0165', '2603', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('517', '2501', '宝德龙0165', '2603', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-22 16:54:47', null);
INSERT INTO `bdl_personal_setting` VALUES ('601', '2601', '多垃圾8900', '2703', '0', '0', '1', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('602', '2601', '多垃圾8900', '2703', '0', '1', '2', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('603', '2601', '多垃圾8900', '2703', '0', '2', '3', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('604', '2601', '多垃圾8900', '2703', '0', '3', '4', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('605', '2601', '多垃圾8900', '2703', '0', '4', '5', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('606', '2601', '多垃圾8900', '2703', '0', '5', '6', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('607', '2601', '多垃圾8900', '2703', '0', '6', '7', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('608', '2601', '多垃圾8900', '2703', '0', '7', '8', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('609', '2601', '多垃圾8900', '2703', '0', '8', '9', '6', null, null, null, null, null, '150', '20', '5.00', '5.00', null, null, '2019-04-27 15:57:25', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('610', '2601', '多垃圾8900', '2704', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('611', '2601', '多垃圾8900', '2704', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('612', '2601', '多垃圾8900', '2704', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('613', '2601', '多垃圾8900', '2704', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('614', '2601', '多垃圾8900', '2704', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('615', '2601', '多垃圾8900', '2704', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('616', '2601', '多垃圾8900', '2704', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('617', '2601', '多垃圾8900', '2704', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-27 15:57:26', '2019-04-27 16:03:48');
INSERT INTO `bdl_personal_setting` VALUES ('701', '2701', '陈梓豪9633', '3001', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('702', '2701', '陈梓豪9633', '3001', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('703', '2701', '陈梓豪9633', '3001', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('704', '2701', '陈梓豪9633', '3001', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('705', '2701', '陈梓豪9633', '3001', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('706', '2701', '陈梓豪9633', '3001', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('707', '2701', '陈梓豪9633', '3001', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('708', '2701', '陈梓豪9633', '3001', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('709', '2701', '陈梓豪9633', '3001', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:18', null);
INSERT INTO `bdl_personal_setting` VALUES ('710', '2701', '陈梓豪9633', '3002', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('711', '2701', '陈梓豪9633', '3002', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('712', '2701', '陈梓豪9633', '3002', '1', '11', '3', '3', '0', '0', null, '0', '0.00', '161', '66', '33.00', '33.00', '0.00', null, '2019-04-28 11:44:19', '2019-04-28 12:13:59');
INSERT INTO `bdl_personal_setting` VALUES ('713', '2701', '陈梓豪9633', '3002', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('714', '2701', '陈梓豪9633', '3002', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('715', '2701', '陈梓豪9633', '3002', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('716', '2701', '陈梓豪9633', '3002', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-04-28 11:44:19', null);
INSERT INTO `bdl_personal_setting` VALUES ('717', '2701', '陈梓豪9633', '3002', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-04-28 11:44:19', null);

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
INSERT INTO `bdl_system_setting` VALUES ('1', '青岛科技大学', '123455677', '青岛崂山区松岭路99', '127.0.0.1', '1', null, null);

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
INSERT INTO `bdl_training_activity_record` VALUES ('101', '1', '1', '0', '0', '1', '2019-01-22 15:17:16', null);
INSERT INTO `bdl_training_activity_record` VALUES ('201', '1', '1', '1', '0', '1', '2019-01-28 17:32:58', null);
INSERT INTO `bdl_training_activity_record` VALUES ('202', '2', '2', '1', '1', '0', '2019-02-10 22:01:26', '2019-04-24 20:41:34');
INSERT INTO `bdl_training_activity_record` VALUES ('203', '2', '2', '1', '2', '0', '2019-02-10 22:01:44', null);
INSERT INTO `bdl_training_activity_record` VALUES ('204', '2', '3', '0', '1', '0', '2019-02-10 22:02:31', '2019-04-24 20:41:34');
INSERT INTO `bdl_training_activity_record` VALUES ('205', '2', '3', '0', '2', '0', '2019-02-10 22:03:26', null);
INSERT INTO `bdl_training_activity_record` VALUES ('301', '1', '1', '1', '0', '1', '2019-03-06 14:42:56', null);
INSERT INTO `bdl_training_activity_record` VALUES ('302', '5601', '3002', '1', '0', '0', '2019-04-28 11:46:23', null);

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
  PRIMARY KEY (`id`),
  KEY `fk_training_plan_id` (`fk_training_plan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_course训练课程表';

-- ----------------------------
-- Records of bdl_training_course
-- ----------------------------
INSERT INTO `bdl_training_course` VALUES ('1', '1', '1', '10', '6', '6', '2019-01-21', null, '2019-01-29', '1', '2019-01-21 14:08:01', null);
INSERT INTO `bdl_training_course` VALUES ('2', '305865088', '2', '1', '32', '15', '2018-12-31', '2019-01-31', '2019-01-24', '1', '2019-01-28 15:26:24', '2019-04-27 16:31:48');
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
INSERT INTO `bdl_training_course` VALUES ('4501', '17863979633', '4501', '4', '16', '0', '2019-03-10', '2019-05-09', null, '0', '2019-03-10 17:21:43', null);
INSERT INTO `bdl_training_course` VALUES ('4601', '305865088', '4601', '4', '16', '0', '2019-03-11', '2019-05-10', null, '1', '2019-03-11 12:37:12', null);
INSERT INTO `bdl_training_course` VALUES ('4701', '测试3242314', '4701', '4', '16', '0', '2019-03-24', '2019-05-23', null, '0', '2019-03-24 11:24:00', null);
INSERT INTO `bdl_training_course` VALUES ('4801', '宝德龙0165', '4801', '2', '16', '0', '2019-04-22', '2019-05-22', null, '1', '2019-04-22 16:26:59', null);
INSERT INTO `bdl_training_course` VALUES ('4901', '宝德龙0165', '4901', '2', '16', '0', '2019-04-22', '2019-05-22', null, '1', '2019-04-22 16:53:00', null);
INSERT INTO `bdl_training_course` VALUES ('4902', '宝德龙0165', '4902', '2', '16', '0', '2019-04-22', '2019-05-22', null, '0', '2019-04-22 16:54:46', null);
INSERT INTO `bdl_training_course` VALUES ('5001', '多垃圾8900', '5001', '1', '10', '0', '2019-04-27', '2019-05-06', null, '1', '2019-04-27 15:57:23', '2019-04-27 16:03:37');
INSERT INTO `bdl_training_course` VALUES ('5002', '多垃圾8900', '5002', '2', '16', '0', '2019-04-07', '2019-05-07', null, '1', '2019-04-27 16:03:41', '2019-04-27 16:05:43');
INSERT INTO `bdl_training_course` VALUES ('5003', '多垃圾8900', '5003', '2', '16', '0', '2019-04-27', '2019-05-27', null, '0', '2019-04-27 16:05:46', null);
INSERT INTO `bdl_training_course` VALUES ('5101', '305865088', '5101', '2', '16', '0', '2019-04-27', '2019-05-27', null, '1', '2019-04-27 16:31:54', '2019-04-27 16:36:09');
INSERT INTO `bdl_training_course` VALUES ('5102', '305865088', '5102', '2', '16', '0', '2019-04-27', '2019-05-27', null, '1', '2019-04-27 16:36:12', '2019-04-27 16:56:23');
INSERT INTO `bdl_training_course` VALUES ('5201', '305865088', '5201', '2', '16', '0', '2019-04-27', '2019-05-27', null, '1', '2019-04-27 16:56:27', '2019-04-27 17:01:23');
INSERT INTO `bdl_training_course` VALUES ('5202', '305865088', '5202', '2', '16', '0', '2019-04-27', '2019-05-27', null, '1', '2019-04-27 17:01:26', '2019-04-27 17:26:52');
INSERT INTO `bdl_training_course` VALUES ('5301', '305865088', '5301', '2', '16', '0', '2019-04-03', '2019-05-03', null, '1', '2019-04-27 17:26:56', '2019-04-27 17:41:55');
INSERT INTO `bdl_training_course` VALUES ('5401', '305865088', '5401', '2', '16', '17', '2019-04-27', '2019-05-27', null, '1', '2019-04-27 17:41:58', '2019-04-27 20:48:07');
INSERT INTO `bdl_training_course` VALUES ('5501', '305865088', '5501', '2', '16', '16', '2019-04-27', '2019-05-27', null, '0', '2019-04-27 20:48:11', '2019-04-27 20:51:15');
INSERT INTO `bdl_training_course` VALUES ('5601', '陈梓豪9633', '5601', '2', '16', '0', '2019-04-28', '2019-05-28', null, '0', '2019-04-28 11:44:17', null);

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
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_device_record训练设备记录表';

-- ----------------------------
-- Records of bdl_training_device_record
-- ----------------------------
INSERT INTO `bdl_training_device_record` VALUES ('0', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:08', null);
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
INSERT INTO `bdl_training_device_record` VALUES ('415', '305865088', '204', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('416', '305865088', '205', '0', '1', '0', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:01:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('417', '305865088', '205', '0', '2', '1', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-04 22:02:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('418', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-01 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('419', '305865088', '205', '0', '3', '3', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('420', '305865088', '205', '0', '3', '4', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('421', '305865088', '205', '0', '3', '5', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('422', '305865088', '205', '0', '3', '6', '1', '20.00', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('423', '305865088', '202', '1', '1', '9', '1', '20.50', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('424', '305865088', '202', '1', '1', '13', '1', '20.50', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('425', '305865088', '202', '1', '2', '14', '1', '41.00', '15.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('426', '305865088', '202', '1', '3', '15', '1', '19.00', '52.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('427', '305865088', '202', '1', '4', '16', '1', '14.00', '65.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('428', '305865088', '204', '0', '1', '3', '1', '20.50', '25.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('429', '305865088', '204', '0', '2', '4', '1', '41.00', '15.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('430', '305865088', '204', '0', '3', '5', '1', '19.00', '52.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('431', '305865088', '204', '0', '4', '6', '1', '14.00', '65.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('432', '305865088', '204', '0', '3', '7', '1', '19.00', '52.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('433', '305865088', '204', '1', '4', '8', '1', '14.00', '65.00', '0.00', '10', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('501', '陈梓豪9633', '3501', '0', null, '0', '0', '20.00', '20.00', '0.00', '0', null, '0.00', '0.00', '8', '0', '0', '0', '2019-04-27 14:11:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('502', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '7', null, '0.00', '0.00', '48', '0', '0', '0', '2019-04-27 14:11:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('503', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '1', null, '0.00', '0.00', '21', '0', '0', '0', '2019-04-27 14:11:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('504', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '7', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-27 14:11:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('505', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '6', null, '0.00', '0.00', '38', '0', '0', '0', '2019-04-27 14:11:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('601', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:51', null);
INSERT INTO `bdl_training_device_record` VALUES ('602', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('603', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('604', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('605', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:54', null);
INSERT INTO `bdl_training_device_record` VALUES ('606', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('607', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('608', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('609', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('610', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('611', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('612', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('613', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('614', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('615', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:58', null);
INSERT INTO `bdl_training_device_record` VALUES ('616', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:58', null);
INSERT INTO `bdl_training_device_record` VALUES ('617', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('618', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('619', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('620', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('621', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('622', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('623', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('624', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('625', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('626', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:05', null);
INSERT INTO `bdl_training_device_record` VALUES ('627', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('628', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('629', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('630', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('631', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('632', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('633', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('634', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('635', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('636', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('637', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('638', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:13', null);
INSERT INTO `bdl_training_device_record` VALUES ('639', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('640', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('641', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:29', null);
INSERT INTO `bdl_training_device_record` VALUES ('642', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:30', null);
INSERT INTO `bdl_training_device_record` VALUES ('643', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('644', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('645', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('646', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:33', null);
INSERT INTO `bdl_training_device_record` VALUES ('647', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:34', null);
INSERT INTO `bdl_training_device_record` VALUES ('648', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:34', null);
INSERT INTO `bdl_training_device_record` VALUES ('649', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('650', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('651', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('652', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('653', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('654', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('655', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('656', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('657', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:40', null);
INSERT INTO `bdl_training_device_record` VALUES ('658', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('659', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('660', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('661', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('662', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:43', null);
INSERT INTO `bdl_training_device_record` VALUES ('663', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('664', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('665', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:45', null);
INSERT INTO `bdl_training_device_record` VALUES ('666', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('667', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('668', '陈梓豪9633', '1', '1', null, '11', '0', '27.00', '27.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:47', null);
INSERT INTO `bdl_training_device_record` VALUES ('669', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:48', null);
INSERT INTO `bdl_training_device_record` VALUES ('670', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:48', null);
INSERT INTO `bdl_training_device_record` VALUES ('671', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:49', null);
INSERT INTO `bdl_training_device_record` VALUES ('672', '陈梓豪9633', '1', '1', null, '11', '0', '27.00', '27.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:50', null);
INSERT INTO `bdl_training_device_record` VALUES ('673', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:50', null);
INSERT INTO `bdl_training_device_record` VALUES ('674', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:51', null);
INSERT INTO `bdl_training_device_record` VALUES ('675', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('676', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('677', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('678', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:54', null);
INSERT INTO `bdl_training_device_record` VALUES ('679', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:54', null);
INSERT INTO `bdl_training_device_record` VALUES ('680', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('681', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('682', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('683', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('684', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('685', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:58', null);
INSERT INTO `bdl_training_device_record` VALUES ('686', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('687', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('688', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('689', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('690', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('691', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('692', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('693', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('694', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('695', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('696', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:05', null);
INSERT INTO `bdl_training_device_record` VALUES ('697', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:05', null);
INSERT INTO `bdl_training_device_record` VALUES ('698', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('699', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('700', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('701', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('702', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('703', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('704', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('705', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('706', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('707', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('708', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:13', null);
INSERT INTO `bdl_training_device_record` VALUES ('709', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('710', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:14', null);
INSERT INTO `bdl_training_device_record` VALUES ('711', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:15', null);
INSERT INTO `bdl_training_device_record` VALUES ('712', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('713', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('714', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('715', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('716', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:18', null);
INSERT INTO `bdl_training_device_record` VALUES ('717', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('718', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:19', null);
INSERT INTO `bdl_training_device_record` VALUES ('719', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:20', null);
INSERT INTO `bdl_training_device_record` VALUES ('720', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('721', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:21', null);
INSERT INTO `bdl_training_device_record` VALUES ('722', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('723', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:22', null);
INSERT INTO `bdl_training_device_record` VALUES ('724', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:23', null);
INSERT INTO `bdl_training_device_record` VALUES ('725', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('726', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('727', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('728', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('729', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:26', null);
INSERT INTO `bdl_training_device_record` VALUES ('730', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('731', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:27', null);
INSERT INTO `bdl_training_device_record` VALUES ('732', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:28', null);
INSERT INTO `bdl_training_device_record` VALUES ('733', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:29', null);
INSERT INTO `bdl_training_device_record` VALUES ('734', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:29', null);
INSERT INTO `bdl_training_device_record` VALUES ('735', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:30', null);
INSERT INTO `bdl_training_device_record` VALUES ('736', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('737', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:31', null);
INSERT INTO `bdl_training_device_record` VALUES ('738', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:32', null);
INSERT INTO `bdl_training_device_record` VALUES ('739', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:33', null);
INSERT INTO `bdl_training_device_record` VALUES ('740', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:33', null);
INSERT INTO `bdl_training_device_record` VALUES ('741', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:34', null);
INSERT INTO `bdl_training_device_record` VALUES ('742', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('743', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:35', null);
INSERT INTO `bdl_training_device_record` VALUES ('744', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('745', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:36', null);
INSERT INTO `bdl_training_device_record` VALUES ('746', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:37', null);
INSERT INTO `bdl_training_device_record` VALUES ('747', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:38', null);
INSERT INTO `bdl_training_device_record` VALUES ('748', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('749', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:39', null);
INSERT INTO `bdl_training_device_record` VALUES ('750', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:40', null);
INSERT INTO `bdl_training_device_record` VALUES ('751', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('752', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:41', null);
INSERT INTO `bdl_training_device_record` VALUES ('753', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('754', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('755', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:43', null);
INSERT INTO `bdl_training_device_record` VALUES ('756', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('757', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:44', null);
INSERT INTO `bdl_training_device_record` VALUES ('758', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:45', null);
INSERT INTO `bdl_training_device_record` VALUES ('759', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:45', null);
INSERT INTO `bdl_training_device_record` VALUES ('760', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:46', null);
INSERT INTO `bdl_training_device_record` VALUES ('761', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:47', null);
INSERT INTO `bdl_training_device_record` VALUES ('762', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:47', null);
INSERT INTO `bdl_training_device_record` VALUES ('763', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:48', null);
INSERT INTO `bdl_training_device_record` VALUES ('764', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:49', null);
INSERT INTO `bdl_training_device_record` VALUES ('765', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:49', null);
INSERT INTO `bdl_training_device_record` VALUES ('766', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:50', null);
INSERT INTO `bdl_training_device_record` VALUES ('767', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:50', null);
INSERT INTO `bdl_training_device_record` VALUES ('768', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:51', null);
INSERT INTO `bdl_training_device_record` VALUES ('769', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('770', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('771', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:53', null);
INSERT INTO `bdl_training_device_record` VALUES ('772', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:54', null);
INSERT INTO `bdl_training_device_record` VALUES ('773', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:54', null);
INSERT INTO `bdl_training_device_record` VALUES ('774', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('775', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:55', null);
INSERT INTO `bdl_training_device_record` VALUES ('776', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:56', null);
INSERT INTO `bdl_training_device_record` VALUES ('777', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('778', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('779', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:58', null);
INSERT INTO `bdl_training_device_record` VALUES ('780', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:58', null);
INSERT INTO `bdl_training_device_record` VALUES ('781', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:59', null);
INSERT INTO `bdl_training_device_record` VALUES ('782', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('783', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:00', null);
INSERT INTO `bdl_training_device_record` VALUES ('784', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:01', null);
INSERT INTO `bdl_training_device_record` VALUES ('785', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('786', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:02', null);
INSERT INTO `bdl_training_device_record` VALUES ('787', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('788', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:03', null);
INSERT INTO `bdl_training_device_record` VALUES ('789', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:04', null);
INSERT INTO `bdl_training_device_record` VALUES ('790', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:05', null);
INSERT INTO `bdl_training_device_record` VALUES ('791', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:05', null);
INSERT INTO `bdl_training_device_record` VALUES ('792', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('793', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:06', null);
INSERT INTO `bdl_training_device_record` VALUES ('794', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:07', null);
INSERT INTO `bdl_training_device_record` VALUES ('795', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:08', null);
INSERT INTO `bdl_training_device_record` VALUES ('796', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('797', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('798', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('799', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:10', null);
INSERT INTO `bdl_training_device_record` VALUES ('800', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:11', null);
INSERT INTO `bdl_training_device_record` VALUES ('801', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('802', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:16', null);
INSERT INTO `bdl_training_device_record` VALUES ('803', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:17', null);
INSERT INTO `bdl_training_device_record` VALUES ('804', '陈梓豪9633', '302', '1', null, '11', '3', '40.00', '40.00', '0.00', '0', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:49:09', null);
INSERT INTO `bdl_training_device_record` VALUES ('805', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:24', null);
INSERT INTO `bdl_training_device_record` VALUES ('806', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('807', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:25', null);
INSERT INTO `bdl_training_device_record` VALUES ('808', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:58:47', null);
INSERT INTO `bdl_training_device_record` VALUES ('809', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '2', null, '0.00', '0.00', '0', '62', '71', '0', '2019-04-28 12:00:52', null);
INSERT INTO `bdl_training_device_record` VALUES ('810', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 12:05:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('811', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '8', null, '0.00', '0.00', '0', '82', '91', '76', '2019-04-28 12:06:57', null);
INSERT INTO `bdl_training_device_record` VALUES ('812', '陈梓豪9633', '302', '1', null, '11', '3', '35.00', '35.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 12:12:12', null);
INSERT INTO `bdl_training_device_record` VALUES ('813', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '3', null, '0.00', '0.00', '0', '85', '93', '80', '2019-04-28 12:14:02', null);

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
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `member_id` (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='bdl_training_plan训练计划表';

-- ----------------------------
-- Records of bdl_training_plan
-- ----------------------------
INSERT INTO `bdl_training_plan` VALUES ('1', '123456', '1', '测试训练计划', '2019-01-21', null, '1', '2019-01-21 14:07:35', null);
INSERT INTO `bdl_training_plan` VALUES ('2', '305865088', '302', '测试训练计划128', '2019-01-16', '增肌', '1', '2019-01-28 15:24:35', '2019-04-27 16:31:48');
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
INSERT INTO `bdl_training_plan` VALUES ('4501', '17863979633', '301', '教练单独设置训练计划', '2019-03-10', '增肌', '0', '2019-03-10 17:21:43', null);
INSERT INTO `bdl_training_plan` VALUES ('4601', '305865088', '801', '测试教练用户共同训练计划', '2019-03-11', '塑形', '1', '2019-03-11 12:37:12', null);
INSERT INTO `bdl_training_plan` VALUES ('4701', '测试3242314', '2401', '测试上传324', '2019-03-24', '增肌', '0', '2019-03-24 11:24:00', null);
INSERT INTO `bdl_training_plan` VALUES ('4801', '宝德龙0165', '2501', '力量循环与力量耐力循环', '2019-04-22', '塑形', '1', '2019-04-22 16:26:59', null);
INSERT INTO `bdl_training_plan` VALUES ('4901', '宝德龙0165', '2501', '自定义训练计划', '2019-04-22', '康复', '1', '2019-04-22 16:53:00', null);
INSERT INTO `bdl_training_plan` VALUES ('4902', '宝德龙0165', '2501', '力量循环与力量耐力循环', '2019-04-22', '塑形', '0', '2019-04-22 16:54:46', null);
INSERT INTO `bdl_training_plan` VALUES ('5001', '多垃圾8900', '2601', '力量循环与力量耐力循环', '2019-04-27', '塑形', '1', '2019-04-27 15:57:22', '2019-04-27 16:03:37');
INSERT INTO `bdl_training_plan` VALUES ('5002', '多垃圾8900', '2601', '接口放接口和', '2019-04-07', '康复', '1', '2019-04-27 16:03:41', '2019-04-27 16:05:43');
INSERT INTO `bdl_training_plan` VALUES ('5003', '多垃圾8900', '2601', '', '2019-04-27', '塑形', '0', '2019-04-27 16:05:46', null);
INSERT INTO `bdl_training_plan` VALUES ('5101', '305865088', '801', '请输入标题', '2019-04-27', '请输入您的目标', '1', '2019-04-27 16:31:51', '2019-04-27 16:36:08');
INSERT INTO `bdl_training_plan` VALUES ('5102', '305865088', '801', '无标题', '2019-04-27', '请输入您的目标', '1', '2019-04-27 16:36:12', '2019-04-27 16:56:23');
INSERT INTO `bdl_training_plan` VALUES ('5201', '305865088', '801', '', '2019-04-27', '请输入您的目标', '1', '2019-04-27 16:56:26', '2019-04-27 17:01:23');
INSERT INTO `bdl_training_plan` VALUES ('5202', '305865088', '801', '无标题', '2019-04-27', '请输入您的目标', '1', '2019-04-27 17:01:26', '2019-04-27 17:26:52');
INSERT INTO `bdl_training_plan` VALUES ('5301', '305865088', '801', '新建计划', '2019-04-03', '塑形', '1', '2019-04-27 17:26:55', '2019-04-27 17:41:54');
INSERT INTO `bdl_training_plan` VALUES ('5401', '305865088', '801', '新计划', '2019-04-27', '塑形', '1', '2019-04-27 17:41:58', '2019-04-27 20:48:07');
INSERT INTO `bdl_training_plan` VALUES ('5501', '305865088', '801', '测试训练计划427', '2019-04-27', '减脂', '0', '2019-04-27 20:48:10', null);
INSERT INTO `bdl_training_plan` VALUES ('5601', '陈梓豪9633', '2701', '力量循环与力量耐力循环', '2019-04-28', '塑形', '0', '2019-04-28 11:44:17', null);

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
INSERT INTO `s_key` VALUES ('bdl_member', '2800', '100');
INSERT INTO `s_key` VALUES ('bdl_training_activity_record', '400', '100');
INSERT INTO `s_key` VALUES ('bdl_training_device_record', '900', '100');
INSERT INTO `s_key` VALUES ('bdl_training_plan', '5700', '100');
INSERT INTO `s_key` VALUES ('bdl_training_course', '5700', '100');
INSERT INTO `s_key` VALUES ('bdl_activity', '3100', '100');
INSERT INTO `s_key` VALUES ('bdl_personal_setting', '800', '100');
