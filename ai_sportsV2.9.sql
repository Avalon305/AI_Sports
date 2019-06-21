/*
Navicat MySQL Data Transfer

Source Server         : localhostMysql8.0
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : ai_sports

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-06-21 13:11:40
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
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员卡号ID',
  `activity_type` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练活动编码：力量循环或者力量耐力循环',
  `target_turn_number` int(10) unsigned DEFAULT NULL COMMENT '目标轮次数量，目标在这一圈训练几轮',
  `current_turn_number` int(10) unsigned DEFAULT '0' COMMENT '当前轮次计数',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `member_id` (`fk_training_course_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_activity训练活动表';

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
INSERT INTO `bdl_activity` VALUES ('3101', '5701', '2801', '苑朝阳6789', '0', '2', '0', '1', '2019-05-06 15:31:56', '2019-05-06 15:35:40');
INSERT INTO `bdl_activity` VALUES ('3102', '5701', '2801', '苑朝阳6789', '1', '2', '0', '1', '2019-05-06 15:31:56', '2019-05-06 15:35:40');
INSERT INTO `bdl_activity` VALUES ('3103', '5702', '2802', '苑朝阳6789', '0', '2', '0', '1', '2019-05-06 15:35:40', '2019-05-06 15:39:48');
INSERT INTO `bdl_activity` VALUES ('3104', '5702', '2802', '苑朝阳6789', '1', '2', '0', '1', '2019-05-06 15:35:40', '2019-05-06 15:39:48');
INSERT INTO `bdl_activity` VALUES ('3201', '5801', '2901', '苑朝阳6789', '0', '2', '0', '0', '2019-05-06 15:39:48', null);
INSERT INTO `bdl_activity` VALUES ('3202', '5801', '2901', '苑朝阳6789', '1', '2', '0', '0', '2019-05-06 15:39:48', null);
INSERT INTO `bdl_activity` VALUES ('3301', '5901', '3002', '李小龙0123', '0', '2', '0', '1', '2019-05-06 16:27:22', '2019-05-06 17:05:23');
INSERT INTO `bdl_activity` VALUES ('3302', '5901', '3002', '李小龙0123', '1', '2', '0', '1', '2019-05-06 16:27:22', '2019-05-06 17:05:23');
INSERT INTO `bdl_activity` VALUES ('3303', '5902', '3002', '李小龙0123', '0', '1', '0', '1', '2019-05-06 17:07:37', '2019-05-06 17:11:03');
INSERT INTO `bdl_activity` VALUES ('3304', '5902', '3002', '李小龙0123', '1', '1', '0', '1', '2019-05-06 17:07:37', '2019-05-06 17:11:03');
INSERT INTO `bdl_activity` VALUES ('3305', '5903', '3002', '李小龙0123', '0', '2', '0', '0', '2019-05-06 17:11:04', null);
INSERT INTO `bdl_activity` VALUES ('3401', '6001', '3101', '陈其钊1234', '0', '2', '0', '0', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_activity` VALUES ('3402', '6001', '3101', '陈其钊1234', '1', '2', '0', '0', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_activity` VALUES ('3403', '6002', '3102', 'null', '0', '2', '0', '0', '2019-05-11 21:56:58', null);
INSERT INTO `bdl_activity` VALUES ('3404', '6002', '3102', 'null', '1', '2', '0', '0', '2019-05-11 21:56:58', null);
INSERT INTO `bdl_activity` VALUES ('3501', '6101', '3201', '李泽  1234', '0', '2', '0', '0', '2019-05-12 14:39:23', null);
INSERT INTO `bdl_activity` VALUES ('3502', '6101', '3201', '李泽  1234', '1', '2', '0', '0', '2019-05-12 14:39:23', null);
INSERT INTO `bdl_activity` VALUES ('3503', '6102', '3202', '李泽1234', '0', '2', '0', '0', '2019-05-12 15:14:34', null);
INSERT INTO `bdl_activity` VALUES ('3504', '6102', '3202', '李泽1234', '1', '2', '0', '0', '2019-05-12 15:14:34', null);

-- ----------------------------
-- Table structure for bdl_auth
-- ----------------------------
DROP TABLE IF EXISTS `bdl_auth`;
CREATE TABLE `bdl_auth` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `username` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '用户名',
  `password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '密码',
  `authid` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '手环或卡的openID',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_auth登录用户授权表';

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
  `code_type_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '类型ID，dList是数据项',
  `code_s_value` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '存储值',
  `code_d_value` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '展示值',
  `code_ext_value` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备对应的肌肉',
  `code_ext_value2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '用作存储设备的活动类型，与编码表中的循环类型相对应：0力量循环，1力量耐力，需要用作分组查询依据',
  `code_ext_value3` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '用作存储有氧力量类型：0：力量训练设备；1：有氧训练设备',
  `code_ext_value4` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备图片存储路径',
  `code_state` tinyint(4) DEFAULT '1' COMMENT '是否启用 0 不启用 1启用',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_datacode编码表';

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
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员id',
  `member_firstName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员名',
  `member_familyName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员姓',
  `birth_date` date DEFAULT NULL COMMENT '出生日期',
  `sex` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '住址',
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '住址',
  `email_address` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '邮箱地址',
  `work_phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '工作电话',
  `personal_phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '私人电话',
  `mobile_phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '手机号码',
  `weight` double(10,2) unsigned DEFAULT NULL COMMENT '体重（KG）',
  `height` double(10,2) unsigned DEFAULT NULL COMMENT '身高 (cm)',
  `age` int(6) unsigned DEFAULT NULL COMMENT '年龄',
  `max_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最大心率=220-age',
  `suitable_heart_rate` int(6) unsigned DEFAULT NULL COMMENT '最宜心率',
  `role_id` tinyint(3) unsigned DEFAULT '1' COMMENT '角色id，1：会员；0：教练',
  `fk_coach_id` int(10) unsigned DEFAULT NULL COMMENT '外键关联教练id',
  `label_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔',
  `is_open_fat_reduction` tinyint(3) unsigned DEFAULT '0' COMMENT '是否开启减脂模式 默认0，0:未开启，1:开启',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '前端备注',
  `last_login_date` datetime DEFAULT NULL COMMENT '上次登录日期',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `member_id` (`member_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_member会员表';

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
INSERT INTO `bdl_member` VALUES ('301', '17863979633', '教练', '李', '2019-01-11', '女', '山东省', '5465465465@qq.com', '5645445', '5454545', '54545', '60.00', '175.00', '0', '220', '168', '0', null, null, '0', '', '2019-06-16 17:45:19', '2019-03-01 17:28:34', '2019-03-10 17:28:38');
INSERT INTO `bdl_member` VALUES ('302', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, '0001-01-01 00:00:00', null, null);
INSERT INTO `bdl_member` VALUES ('701', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '0', null, '0001-01-01 00:00:00', null, null);
INSERT INTO `bdl_member` VALUES ('801', '305865088', '其钊', '陈', '2019-03-02', '男', '山东省', '465464654@qq.com', '665454', '5454545', '17863979633', '140.00', '187.00', '25', '199', '168', '1', '301', '增肌,减脂,塑形,康复,', '1', '', '2019-06-16 17:45:20', '2019-03-04 19:34:55', '2019-05-06 17:18:10');
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
INSERT INTO `bdl_member` VALUES ('2801', '苑朝阳6789', '朝阳', '苑', '1990-01-12', '男', '山东省德州市', '123456789@163.com', '', '', '123456789', '75.00', '181.00', '29', '191', '146', '0', null, '增肌,', '0', '', '2019-05-06 16:05:26', '2019-05-06 15:31:55', null);
INSERT INTO `bdl_member` VALUES ('2802', '苑朝阳1234', '朝阳', '苑', '1990-03-16', '男', '山东德州', '123456789@163.com', '', '', '123456789', '85.00', '180.00', '29', '191', '146', '0', null, '增肌,', '0', '', null, '2019-05-06 15:35:40', '2019-05-06 15:36:48');
INSERT INTO `bdl_member` VALUES ('2901', '苑朝阳6789', '朝阳', '苑', '1990-04-14', '男', '山东德州', '123456789@163.com', '', '', '123456789', '84.00', '182.00', '29', '191', '146', '0', null, '增肌,', '0', '', null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_member` VALUES ('3001', '王小明1234', '小明', '王', '1985-07-11', '男', '', '', '', '', '123412341234', '0.00', '100.00', '34', '0', '0', '1', '2801', '', '0', '', null, '2019-05-06 16:14:06', null);
INSERT INTO `bdl_member` VALUES ('3002', '李小龙0123', '小龙', '李', '1979-06-07', '男', '', '', '', '', '012301230123', '81.00', '175.00', '40', '180', '138', '1', '2801', '增肌,塑形,', '1', '', '2019-05-06 16:42:08', '2019-05-06 16:27:22', '2019-05-06 16:59:39');
INSERT INTO `bdl_member` VALUES ('3101', '陈其钊1234', '其钊', '陈', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '1', null, '塑形,', '0', null, '2019-05-11 22:05:52', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_member` VALUES ('3102', 'null', 'ul', 'n', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '1', null, '塑形,', '0', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_member` VALUES ('3201', '李泽  1234', '泽 ', '李', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '1', null, '塑形,', '0', null, null, '2019-05-12 14:39:23', null);
INSERT INTO `bdl_member` VALUES ('3202', '李泽1234', '泽', '李', null, null, null, null, null, null, null, '80.00', '170.00', null, '190', '145', '1', null, '塑形,', '0', null, '2019-05-12 15:15:56', '2019-05-12 15:14:33', null);

-- ----------------------------
-- Table structure for bdl_personal_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_personal_setting`;
CREATE TABLE `bdl_personal_setting` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `fk_member_id` int(10) DEFAULT NULL,
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员卡号ID',
  `fk_training_activity_id` int(10) DEFAULT NULL COMMENT '训练活动名',
  `activity_type` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练活动类型编码',
  `device_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备名',
  `device_order_number` int(10) unsigned DEFAULT NULL COMMENT '设备序号',
  `training_mode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练模式',
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
  `extra_setting` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '额外属性：为保证设备属性的可扩展性，存储为Json串Key、value',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `member_id` (`member_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_personal_setting个人设置';

-- ----------------------------
-- Records of bdl_personal_setting
-- ----------------------------
INSERT INTO `bdl_personal_setting` VALUES ('101', '302', '305865088', '2', '0', '0', '1', '2', '115', '117', '115', null, null, '231', '43', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('102', '302', '305865088', '2', '0', '1', '2', '2', '115', '117', '115', null, null, '152', '28', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('103', '302', '305865088', '2', '0', '2', '3', '2', '115', '117', '115', null, null, '72', '13', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('104', '302', '305865088', '2', '0', '3', '4', '2', '115', '117', '115', null, null, '75', '20', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('105', '302', '305865088', '2', '0', '4', '5', '2', '115', '117', '115', null, null, null, null, '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('106', '302', '305865088', '2', '0', '5', '6', '2', '115', '117', '115', null, null, '90', '0', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('107', '302', '305865088', '2', '0', '6', '7', '2', '115', '117', '115', null, null, '90', '0', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('108', '302', '305865088', '2', '0', '7', '8', '2', '115', '117', '115', null, '127.00', '50', '0', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('109', '302', '305865088', '2', '0', '8', '9', '2', '115', '117', '115', null, null, '60', '20', '20.00', '25.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('110', '302', '305865088', '3', '1', '9', '1', '1', '115', '117', '115', null, '115.00', '60', '20', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('111', '302', '305865088', '3', '1', '10', '2', '1', '115', '117', '115', null, null, '152', '28', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('112', '302', '305865088', '3', '1', '11', '3', '1', '115', '117', '115', null, null, '152', '28', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('113', '302', '305865088', '3', '1', '12', '4', '0', '115', '117', '115', null, null, null, null, null, null, '50.00', null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('114', '302', '305865088', '3', '1', '13', '5', '1', '115', '117', '115', null, '115.00', '60', '20', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('115', '302', '305865088', '3', '1', '14', '6', '1', '115', '117', '115', null, '127.00', '100', '20', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('116', '302', '305865088', '3', '1', '15', '7', '1', '115', '117', '115', null, '127.00', '50', '0', '4.00', '6.00', null, null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
INSERT INTO `bdl_personal_setting` VALUES ('117', '302', '305865088', '3', '1', '16', '8', '0', '115', '117', '115', null, null, null, null, null, null, '30.00', null, '2019-02-28 00:44:15', '2019-06-16 17:40:32');
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
INSERT INTO `bdl_personal_setting` VALUES ('801', '2801', '苑朝阳6789', '3101', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('802', '2801', '苑朝阳6789', '3101', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('803', '2801', '苑朝阳6789', '3101', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('804', '2801', '苑朝阳6789', '3101', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('805', '2801', '苑朝阳6789', '3101', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('806', '2801', '苑朝阳6789', '3101', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('807', '2801', '苑朝阳6789', '3101', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('808', '2801', '苑朝阳6789', '3101', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('809', '2801', '苑朝阳6789', '3101', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('810', '2801', '苑朝阳6789', '3102', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('811', '2801', '苑朝阳6789', '3102', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('812', '2801', '苑朝阳6789', '3102', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('813', '2801', '苑朝阳6789', '3102', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('814', '2801', '苑朝阳6789', '3102', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('815', '2801', '苑朝阳6789', '3102', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('816', '2801', '苑朝阳6789', '3102', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('817', '2801', '苑朝阳6789', '3102', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:31:56', null);
INSERT INTO `bdl_personal_setting` VALUES ('818', '2802', '苑朝阳6789', '3103', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('819', '2802', '苑朝阳6789', '3103', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('820', '2802', '苑朝阳6789', '3103', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('821', '2802', '苑朝阳6789', '3103', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('822', '2802', '苑朝阳6789', '3103', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('823', '2802', '苑朝阳6789', '3103', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('824', '2802', '苑朝阳6789', '3103', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('825', '2802', '苑朝阳6789', '3103', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('826', '2802', '苑朝阳6789', '3103', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('827', '2802', '苑朝阳6789', '3104', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('828', '2802', '苑朝阳6789', '3104', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('829', '2802', '苑朝阳6789', '3104', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('830', '2802', '苑朝阳6789', '3104', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('831', '2802', '苑朝阳6789', '3104', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('832', '2802', '苑朝阳6789', '3104', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('833', '2802', '苑朝阳6789', '3104', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('834', '2802', '苑朝阳6789', '3104', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:35:40', null);
INSERT INTO `bdl_personal_setting` VALUES ('901', '2901', '苑朝阳6789', '3201', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('902', '2901', '苑朝阳6789', '3201', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('903', '2901', '苑朝阳6789', '3201', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('904', '2901', '苑朝阳6789', '3201', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('905', '2901', '苑朝阳6789', '3201', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('906', '2901', '苑朝阳6789', '3201', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('907', '2901', '苑朝阳6789', '3201', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('908', '2901', '苑朝阳6789', '3201', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('909', '2901', '苑朝阳6789', '3201', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('910', '2901', '苑朝阳6789', '3202', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('911', '2901', '苑朝阳6789', '3202', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('912', '2901', '苑朝阳6789', '3202', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('913', '2901', '苑朝阳6789', '3202', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('914', '2901', '苑朝阳6789', '3202', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('915', '2901', '苑朝阳6789', '3202', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('916', '2901', '苑朝阳6789', '3202', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('917', '2901', '苑朝阳6789', '3202', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 15:39:48', null);
INSERT INTO `bdl_personal_setting` VALUES ('1001', '3002', '李小龙0123', '3303', '0', '0', '1', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1002', '3002', '李小龙0123', '3303', '0', '1', '2', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1003', '3002', '李小龙0123', '3303', '0', '2', '3', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1004', '3002', '李小龙0123', '3303', '0', '3', '4', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1005', '3002', '李小龙0123', '3303', '0', '4', '5', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1006', '3002', '李小龙0123', '3303', '0', '5', '6', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1007', '3002', '李小龙0123', '3303', '0', '6', '7', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1008', '3002', '李小龙0123', '3303', '0', '7', '8', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1009', '3002', '李小龙0123', '3303', '0', '8', '9', '4', null, null, null, null, null, '150', '20', '13.00', '14.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1010', '3002', '李小龙0123', '3304', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1011', '3002', '李小龙0123', '3304', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1012', '3002', '李小龙0123', '3304', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1013', '3002', '李小龙0123', '3304', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1014', '3002', '李小龙0123', '3304', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1015', '3002', '李小龙0123', '3304', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1016', '3002', '李小龙0123', '3304', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1017', '3002', '李小龙0123', '3304', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-06 16:27:22', '2019-05-06 17:07:36');
INSERT INTO `bdl_personal_setting` VALUES ('1018', '3002', '李小龙0123', '3305', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1019', '3002', '李小龙0123', '3305', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1020', '3002', '李小龙0123', '3305', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1021', '3002', '李小龙0123', '3305', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1022', '3002', '李小龙0123', '3305', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1023', '3002', '李小龙0123', '3305', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1024', '3002', '李小龙0123', '3305', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1025', '3002', '李小龙0123', '3305', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1026', '3002', '李小龙0123', '3305', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-06 17:11:04', null);
INSERT INTO `bdl_personal_setting` VALUES ('1101', '3101', '陈其钊1234', '3401', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1102', '3101', '陈其钊1234', '3401', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1103', '3101', '陈其钊1234', '3401', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1104', '3101', '陈其钊1234', '3401', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1105', '3101', '陈其钊1234', '3401', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1106', '3101', '陈其钊1234', '3401', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1107', '3101', '陈其钊1234', '3401', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1108', '3101', '陈其钊1234', '3401', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1109', '3101', '陈其钊1234', '3401', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1110', '3101', '陈其钊1234', '3402', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1111', '3101', '陈其钊1234', '3402', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1112', '3101', '陈其钊1234', '3402', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '5.00', '5.00', '0.00', null, '2019-05-11 20:18:49', '2019-05-12 16:02:43');
INSERT INTO `bdl_personal_setting` VALUES ('1113', '3101', '陈其钊1234', '3402', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1114', '3101', '陈其钊1234', '3402', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1115', '3101', '陈其钊1234', '3402', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1116', '3101', '陈其钊1234', '3402', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1117', '3101', '陈其钊1234', '3402', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-11 20:18:49', null);
INSERT INTO `bdl_personal_setting` VALUES ('1118', '3102', 'null', '3403', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1119', '3102', 'null', '3403', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1120', '3102', 'null', '3403', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1121', '3102', 'null', '3403', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1122', '3102', 'null', '3403', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1123', '3102', 'null', '3403', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1124', '3102', 'null', '3403', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1125', '3102', 'null', '3403', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1126', '3102', 'null', '3403', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1127', '3102', 'null', '3404', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1128', '3102', 'null', '3404', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1129', '3102', 'null', '3404', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1130', '3102', 'null', '3404', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1131', '3102', 'null', '3404', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1132', '3102', 'null', '3404', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1133', '3102', 'null', '3404', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1134', '3102', 'null', '3404', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-11 21:56:58', null);
INSERT INTO `bdl_personal_setting` VALUES ('1201', '3201', '李泽  1234', '3501', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1202', '3201', '李泽  1234', '3501', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1203', '3201', '李泽  1234', '3501', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1204', '3201', '李泽  1234', '3501', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1205', '3201', '李泽  1234', '3501', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1206', '3201', '李泽  1234', '3501', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1207', '3201', '李泽  1234', '3501', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1208', '3201', '李泽  1234', '3501', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1209', '3201', '李泽  1234', '3501', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1210', '3201', '李泽  1234', '3502', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1211', '3201', '李泽  1234', '3502', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1212', '3201', '李泽  1234', '3502', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '30.00', '30.00', '0.00', null, '2019-05-12 14:39:24', '2019-05-12 14:43:58');
INSERT INTO `bdl_personal_setting` VALUES ('1213', '3201', '李泽  1234', '3502', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1214', '3201', '李泽  1234', '3502', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1215', '3201', '李泽  1234', '3502', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1216', '3201', '李泽  1234', '3502', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1217', '3201', '李泽  1234', '3502', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-12 14:39:24', null);
INSERT INTO `bdl_personal_setting` VALUES ('1218', '3202', '李泽1234', '3503', '0', '0', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1219', '3202', '李泽1234', '3503', '0', '1', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1220', '3202', '李泽1234', '3503', '0', '2', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1221', '3202', '李泽1234', '3503', '0', '3', '4', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1222', '3202', '李泽1234', '3503', '0', '4', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1223', '3202', '李泽1234', '3503', '0', '5', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1224', '3202', '李泽1234', '3503', '0', '6', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1225', '3202', '李泽1234', '3503', '0', '7', '8', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1226', '3202', '李泽1234', '3503', '0', '8', '9', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1227', '3202', '李泽1234', '3504', '1', '9', '1', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1228', '3202', '李泽1234', '3504', '1', '10', '2', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1229', '3202', '李泽1234', '3504', '1', '11', '3', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1230', '3202', '李泽1234', '3504', '1', '12', '4', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1231', '3202', '李泽1234', '3504', '1', '13', '5', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1232', '3202', '李泽1234', '3504', '1', '14', '6', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1233', '3202', '李泽1234', '3504', '1', '15', '7', '0', null, null, null, null, null, '150', '20', '21.00', '21.00', null, null, '2019-05-12 15:14:34', null);
INSERT INTO `bdl_personal_setting` VALUES ('1234', '3202', '李泽1234', '3504', '1', '16', '8', '0', null, null, null, null, null, null, null, null, null, '30.00', null, '2019-05-12 15:14:34', null);

-- ----------------------------
-- Table structure for bdl_skeleton_length
-- ----------------------------
DROP TABLE IF EXISTS `bdl_skeleton_length`;
CREATE TABLE `bdl_skeleton_length` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_member_id` int(11) DEFAULT NULL COMMENT '关联bdl_member的主键',
  `body_length` double DEFAULT NULL COMMENT '躯干长度(脖子到屁股~)',
  `shoulder_width` double DEFAULT NULL COMMENT '肩宽(单侧肩宽)',
  `arm_length_up` double DEFAULT NULL COMMENT '臂长(上部分)',
  `arm_length_down` double DEFAULT NULL COMMENT '臂长(下部分)',
  `leg_length_up` double DEFAULT NULL COMMENT '腿长(上部分)',
  `leg_length_down` double DEFAULT NULL COMMENT '腿长(下部分)',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of bdl_skeleton_length
-- ----------------------------
INSERT INTO `bdl_skeleton_length` VALUES ('1', '801', '47.12', '18.4', '29.44', '26.77', '43.19', '42.51');

-- ----------------------------
-- Table structure for bdl_system_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_system_setting`;
CREATE TABLE `bdl_system_setting` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `organization_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '机构名称',
  `organization_phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '机构电话',
  `organization_address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '机构地址',
  `ip_address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT 'ip地址',
  `system_version` tinyint(255) DEFAULT NULL COMMENT '系统版本 0：标准版 1：豪华版',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL,
  `user_status` int(3) DEFAULT NULL COMMENT '使用状态',
  `auth_offlinetime` date DEFAULT NULL COMMENT '离线时间',
  `set_unique_id` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '客户机唯一id，机器码',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_system_setting系统设置';

-- ----------------------------
-- Records of bdl_system_setting
-- ----------------------------

-- ----------------------------
-- Table structure for bdl_training_activity_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_activity_record`;
CREATE TABLE `bdl_training_activity_record` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `fk_training_course_id` int(10) unsigned NOT NULL COMMENT '外键训练课程id',
  `fk_activity_id` int(10) DEFAULT NULL COMMENT '外键，训练活动ID',
  `activity_type` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT ' 训练活动编码：力量循环或者力量耐力循环',
  `course_count` int(10) unsigned DEFAULT NULL COMMENT '课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_training_activity_record训练活动记录表';

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
INSERT INTO `bdl_training_activity_record` VALUES ('401', '6001', '3402', '1', '0', '0', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_training_activity_record` VALUES ('402', '6002', '3404', '1', '0', '0', '2019-05-11 21:56:58', null);
INSERT INTO `bdl_training_activity_record` VALUES ('501', '6101', '3502', '1', '0', '0', '2019-05-12 14:39:24', null);
INSERT INTO `bdl_training_activity_record` VALUES ('502', '6102', '3504', '1', '0', '0', '2019-05-12 15:14:34', null);

-- ----------------------------
-- Table structure for bdl_training_course
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_course`;
CREATE TABLE `bdl_training_course` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
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
  PRIMARY KEY (`id`) USING BTREE,
  KEY `fk_training_plan_id` (`fk_training_plan_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_training_course训练课程表';

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
INSERT INTO `bdl_training_course` VALUES ('5701', '苑朝阳6789', '5701', '2', '16', '0', '2019-05-06', '2019-06-05', null, '1', '2019-05-06 15:31:55', '2019-05-06 15:35:40');
INSERT INTO `bdl_training_course` VALUES ('5702', '苑朝阳6789', '5702', '2', '16', '0', '2019-05-06', '2019-06-05', null, '1', '2019-05-06 15:35:40', '2019-05-06 15:39:48');
INSERT INTO `bdl_training_course` VALUES ('5801', '苑朝阳6789', '5801', '2', '16', '0', '2019-05-06', '2019-06-05', null, '0', '2019-05-06 15:39:48', null);
INSERT INTO `bdl_training_course` VALUES ('5901', '李小龙0123', '5901', '3', '10', '0', '2019-05-06', '2019-06-02', null, '1', '2019-05-06 16:27:22', '2019-05-06 17:05:23');
INSERT INTO `bdl_training_course` VALUES ('5902', '李小龙0123', '5902', '1', '20', '0', '2019-05-06', '2019-05-25', null, '1', '2019-05-06 17:05:24', '2019-05-06 17:11:03');
INSERT INTO `bdl_training_course` VALUES ('5903', '李小龙0123', '5903', '2', '16', '0', '2019-05-06', '2019-06-05', null, '0', '2019-05-06 17:11:04', null);
INSERT INTO `bdl_training_course` VALUES ('6001', '陈其钊1234', '6001', '2', '16', '0', '2019-05-11', '2019-06-10', null, '0', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_training_course` VALUES ('6002', 'null', '6002', '2', '16', '0', '2019-05-11', '2019-06-10', null, '0', '2019-05-11 21:56:58', null);
INSERT INTO `bdl_training_course` VALUES ('6101', '李泽  1234', '6101', '2', '16', '0', '2019-05-12', '2019-06-11', null, '0', '2019-05-12 14:39:23', null);
INSERT INTO `bdl_training_course` VALUES ('6102', '李泽1234', '6102', '2', '16', '0', '2019-05-12', '2019-06-11', null, '0', '2019-05-12 15:14:33', null);

-- ----------------------------
-- Table structure for bdl_training_device_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_device_record`;
CREATE TABLE `bdl_training_device_record` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '会员id',
  `fk_training_activity_record_id` int(10) unsigned DEFAULT NULL COMMENT '外键训练活动记录id',
  `activity_type` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练活动类型编码',
  `device_order_number` int(10) unsigned DEFAULT NULL COMMENT '设备在循环中的序号',
  `device_code` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '设备名',
  `training_mode` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练模式',
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
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_training_device_record训练设备记录表';

-- ----------------------------
-- Records of bdl_training_device_record
-- ----------------------------
INSERT INTO `bdl_training_device_record` VALUES ('0', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '14', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:08', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1', '123456', '201', '0', null, '10', null, null, null, null, null, null, null, null, null, null, null, null, '2019-01-23 14:19:42', null);
INSERT INTO `bdl_training_device_record` VALUES ('2', '123456', '201', '0', null, '11', '', null, null, null, null, null, null, null, null, null, null, null, '2019-01-23 14:19:42', '2019-01-23 15:05:51');
INSERT INTO `bdl_training_device_record` VALUES ('3', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('4', '123456', '201', '1', null, '13', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('5', '123456', '201', '1', null, '14', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('6', '123456', '201', '1', null, '15', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('7', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('8', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:20:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('101', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:26:15', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('102', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:28:11', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('201', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:29:43', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('301', '123456', '201', '1', null, '12', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:32:26', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('401', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:33:41', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('402', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('403', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:22', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('404', '123456', '201', '1', null, '16', '1', '0.00', '43.00', '0.00', '1', null, '0.00', '200.00', '0', '0', '0', '0', '2019-01-29 15:34:35', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('405', '305865088', '202', '1', '1', '9', '1', '20.50', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('406', '305865088', '202', '1', '2', '10', '1', '41.00', '15.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('407', '305865088', '202', '1', '3', '11', '1', '19.00', '52.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('408', '305865088', '202', '1', '4', '12', '1', '14.00', '65.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('409', '305865088', '203', '1', '1', '9', '1', '17.00', '32.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 12:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('410', '305865088', '203', '1', '2', '10', '1', '30.00', '36.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 14:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('411', '305865088', '203', '1', '3', '11', '1', '24.00', '29.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 15:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('412', '305865088', '203', '1', '4', '12', '1', '33.00', '40.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 18:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('413', '305865088', '204', '0', '1', '0', '1', '44.00', '55.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-09 22:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('414', '305865088', '204', '0', '2', '1', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-02-01 22:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('415', '305865088', '204', '0', '3', '2', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('416', '305865088', '205', '0', '1', '0', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-05 22:01:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('417', '305865088', '205', '0', '2', '1', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-04 22:02:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('418', '305865088', '205', '0', '3', '2', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-01 22:03:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('419', '305865088', '205', '0', '3', '3', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('420', '305865088', '205', '0', '3', '4', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('421', '305865088', '205', '0', '3', '5', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('422', '305865088', '205', '0', '3', '6', '1', '20.00', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 22:03:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('423', '305865088', '202', '1', '1', '9', '1', '20.50', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('424', '305865088', '202', '1', '1', '13', '1', '20.50', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('425', '305865088', '202', '1', '2', '14', '1', '41.00', '15.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('426', '305865088', '202', '1', '3', '15', '1', '19.00', '52.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('427', '305865088', '202', '1', '4', '16', '1', '14.00', '65.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('428', '305865088', '204', '0', '1', '3', '1', '20.50', '25.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 08:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('429', '305865088', '204', '0', '2', '4', '1', '41.00', '15.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 09:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('430', '305865088', '204', '0', '3', '5', '1', '19.00', '52.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('431', '305865088', '204', '0', '4', '6', '1', '14.00', '65.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('432', '305865088', '204', '0', '3', '7', '1', '19.00', '52.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 10:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('433', '305865088', '204', '1', '4', '8', '1', '14.00', '65.00', '0.00', '13', null, null, '300.00', '60', '156', '189', '140', '2019-03-06 11:10:35', '2019-06-04 13:44:38');
INSERT INTO `bdl_training_device_record` VALUES ('501', '陈梓豪9633', '3501', '0', null, '0', '0', '20.00', '20.00', '0.00', '1', null, '0.00', '0.00', '8', '0', '0', '0', '2019-04-27 14:11:36', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('502', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '8', null, '0.00', '0.00', '48', '0', '0', '0', '2019-04-27 14:11:37', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('503', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '2', null, '0.00', '0.00', '21', '0', '0', '0', '2019-04-27 14:11:38', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('504', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '8', null, '0.00', '0.00', '53', '0', '0', '0', '2019-04-27 14:11:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('505', '陈梓豪9633', '3501', '0', null, '0', '0', '21.00', '21.00', '0.00', '7', null, '0.00', '0.00', '38', '0', '0', '0', '2019-04-27 14:11:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('601', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:51', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('602', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('603', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:53', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('604', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:53', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('605', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:54', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('606', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('607', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('608', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('609', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('610', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('611', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:56', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('612', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('613', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('614', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('615', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('616', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('617', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:43:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('618', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('619', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('620', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:01', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('621', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('622', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('623', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:03', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('624', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:04', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('625', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:04', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('626', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('627', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:06', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('628', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:06', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('629', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:07', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('630', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:08', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('631', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:08', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('632', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('633', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:10', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('634', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:10', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('635', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:11', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('636', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('637', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('638', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:13', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('639', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:14', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('640', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:14', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('641', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:29', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('642', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:30', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('643', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:31', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('644', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:32', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('645', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:32', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('646', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:33', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('647', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:34', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('648', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:34', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('649', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:35', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('650', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:36', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('651', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:36', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('652', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:37', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('653', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:37', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('654', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:38', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('655', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('656', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('657', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:40', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('658', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:41', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('659', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:41', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('660', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:42', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('661', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:42', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('662', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:43', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('663', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:44', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('664', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:44', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('665', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:45', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('666', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:46', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('667', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:46', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('668', '陈梓豪9633', '1', '1', null, '11', '0', '27.00', '27.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:47', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('669', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:48', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('670', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:48', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('671', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:49', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('672', '陈梓豪9633', '1', '1', null, '11', '0', '27.00', '27.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:50', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('673', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:50', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('674', '陈梓豪9633', '1', '1', null, '11', '0', '38.00', '38.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:51', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('675', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('676', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('677', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:53', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('678', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:54', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('679', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:54', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('680', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('681', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('682', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:56', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('683', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('684', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('685', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('686', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('687', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '14', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:44:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('688', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('689', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('690', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:01', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('691', '陈梓豪9633', '1', '1', null, '11', '0', '26.00', '26.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('692', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('693', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '9', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:03', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('694', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '14', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:04', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('695', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:04', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('696', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('697', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('698', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:06', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('699', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:07', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('700', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:07', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('701', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('702', '陈梓豪9633', '1', '1', null, '11', '0', '31.00', '31.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('703', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:10', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('704', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:11', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('705', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:11', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('706', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('707', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('708', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:13', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('709', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:14', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('710', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:14', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('711', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:15', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('712', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:16', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('713', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:16', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('714', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:17', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('715', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:17', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('716', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:18', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('717', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:19', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('718', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:19', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('719', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:20', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('720', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '11', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:21', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('721', '陈梓豪9633', '1', '1', null, '11', '0', '23.00', '23.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:21', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('722', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:22', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('723', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:22', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('724', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:23', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('725', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:24', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('726', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:24', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('727', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:25', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('728', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:26', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('729', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:26', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('730', '陈梓豪9633', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:27', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('731', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:27', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('732', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:28', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('733', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:29', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('734', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:29', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('735', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:30', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('736', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:31', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('737', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:31', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('738', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:32', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('739', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:33', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('740', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '7', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:33', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('741', '陈梓豪9633', '1', '1', null, '11', '0', '35.00', '35.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:34', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('742', '陈梓豪9633', '1', '1', null, '11', '0', '36.00', '36.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:35', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('743', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:35', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('744', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:36', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('745', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:36', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('746', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:37', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('747', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:38', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('748', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('749', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:39', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('750', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:40', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('751', '陈梓豪9633', '1', '1', null, '11', '0', '41.00', '41.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:41', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('752', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:41', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('753', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:42', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('754', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:42', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('755', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:43', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('756', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:44', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('757', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:44', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('758', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:45', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('759', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:45', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('760', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:46', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('761', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '10', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:47', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('762', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:47', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('763', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:48', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('764', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:49', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('765', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:49', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('766', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:50', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('767', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:50', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('768', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:51', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('769', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('770', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('771', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:53', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('772', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:54', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('773', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:54', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('774', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('775', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:55', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('776', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:56', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('777', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('778', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('779', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('780', '陈梓豪9633', '1', '1', null, '11', '0', '25.00', '25.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('781', '陈梓豪9633', '1', '1', null, '11', '0', '37.00', '37.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:45:59', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('782', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('783', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:00', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('784', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:01', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('785', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('786', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('787', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:03', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('788', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:03', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('789', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:04', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('790', '陈梓豪9633', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('791', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('792', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:06', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('793', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:06', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('794', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:07', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('795', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:08', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('796', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('797', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('798', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '2', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:10', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('799', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:10', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('800', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:11', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('801', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:16', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('802', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:16', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('803', '陈梓豪9633', '1', '1', null, '11', '0', '40.00', '40.00', '0.00', '3', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:46:17', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('804', '陈梓豪9633', '302', '1', null, '11', '3', '40.00', '40.00', '0.00', '1', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:49:09', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('805', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:24', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('806', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:25', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('807', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:53:25', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('808', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '8', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 11:58:47', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('809', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '3', null, '0.00', '0.00', '0', '62', '71', '0', '2019-04-28 12:00:52', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('810', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '6', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 12:05:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('811', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '9', null, '0.00', '0.00', '0', '82', '91', '76', '2019-04-28 12:06:57', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('812', '陈梓豪9633', '302', '1', null, '11', '3', '35.00', '35.00', '0.00', '4', null, '0.00', '0.00', '0', '0', '0', '0', '2019-04-28 12:12:12', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('813', '陈梓豪9633', '302', '1', null, '11', '3', '33.00', '33.00', '0.00', '4', null, '0.00', '0.00', '0', '85', '93', '80', '2019-04-28 12:14:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('901', '陈其钊1234', '1', '1', null, '11', '0', '22.00', '22.00', '0.00', '13', null, '0.00', '0.00', '0', '0', '0', '0', '2019-05-11 20:18:23', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('902', '陈其钊1234', '401', '1', null, '11', '0', '22.00', '22.00', '0.00', '12', null, '0.00', '0.00', '0', '0', '0', '0', '2019-05-11 20:27:37', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('903', '陈其钊1234', '401', '1', null, '11', '0', '24.00', '24.00', '0.00', '5', null, '0.00', '0.00', '0', '0', '0', '0', '2019-05-11 20:47:02', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('904', '陈其钊1234', '401', '1', null, '11', '0', '28.00', '28.00', '0.00', '10', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-11 22:04:25', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1001', '李泽  1234', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '8', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 14:37:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1002', '李泽  1234', '1', '1', null, '11', '0', '20.00', '20.00', '0.00', '8', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 14:37:05', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1003', '李泽  1234', '501', '1', null, '11', '0', '30.00', '30.00', '0.00', '8', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 14:43:58', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1004', '李泽1234', '1', '1', null, '11', '0', '30.00', '30.00', '0.00', '14', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 15:12:29', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1005', '陈其钊1234', '401', '1', null, '11', '0', '24.00', '24.00', '0.00', '8', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 15:28:22', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1101', '陈其钊1234', '401', '1', null, '11', '0', '5.00', '5.00', '0.00', '14', null, '0.00', '0.00', '60', '0', '0', '0', '2019-05-12 16:02:43', '2019-06-04 13:47:55');
INSERT INTO `bdl_training_device_record` VALUES ('1102', '陈其钊1234', '401', '1', null, '11', '0', '5.00', '5.00', '0.00', '18', null, '0.00', '15.30', '60', '0', '0', '0', '2019-05-12 16:04:38', '2019-06-04 13:47:55');

-- ----------------------------
-- Table structure for bdl_training_plan
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_plan`;
CREATE TABLE `bdl_training_plan` (
  `id` int(10) unsigned NOT NULL COMMENT '主键自增id',
  `member_id` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `fk_member_id` int(10) unsigned DEFAULT NULL COMMENT '会员id',
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练标题',
  `start_date` date DEFAULT NULL COMMENT '起始日期',
  `training_target` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '训练目标',
  `is_deleted` tinyint(4) unsigned DEFAULT '0' COMMENT '是否删除 1:删除;0:未删除',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  KEY `member_id` (`member_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT COMMENT='bdl_training_plan训练计划表';

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
INSERT INTO `bdl_training_plan` VALUES ('5701', '苑朝阳6789', '2801', '力量循环与力量耐力循环', '2019-05-06', '塑形', '1', '2019-05-06 15:31:55', '2019-05-06 15:35:40');
INSERT INTO `bdl_training_plan` VALUES ('5702', '苑朝阳6789', '2802', '力量循环与力量耐力循环', '2019-05-06', '塑形', '1', '2019-05-06 15:35:40', '2019-05-06 15:39:48');
INSERT INTO `bdl_training_plan` VALUES ('5801', '苑朝阳6789', '2901', '力量循环与力量耐力循环', '2019-05-06', '塑形', '0', '2019-05-06 15:39:48', null);
INSERT INTO `bdl_training_plan` VALUES ('5901', '李小龙0123', '3002', '力量循环与力量耐力循环', '2019-05-06', '塑形', '1', '2019-05-06 16:27:22', '2019-05-06 17:05:23');
INSERT INTO `bdl_training_plan` VALUES ('5902', '李小龙0123', '3002', '自定义训练计划', '2019-05-06', '增肌', '1', '2019-05-06 17:05:24', '2019-05-06 17:11:03');
INSERT INTO `bdl_training_plan` VALUES ('5903', '李小龙0123', '3002', '力量循环', '2019-05-06', '塑形', '0', '2019-05-06 17:11:04', null);
INSERT INTO `bdl_training_plan` VALUES ('6001', '陈其钊1234', '3101', '力量循环与力量耐力循环', '2019-05-11', '塑形', '0', '2019-05-11 20:18:49', null);
INSERT INTO `bdl_training_plan` VALUES ('6002', 'null', '3102', '力量循环与力量耐力循环', '2019-05-11', '塑形', '0', '2019-05-11 21:56:58', null);
INSERT INTO `bdl_training_plan` VALUES ('6101', '李泽  1234', '3201', '力量循环与力量耐力循环', '2019-05-12', '塑形', '0', '2019-05-12 14:39:23', null);
INSERT INTO `bdl_training_plan` VALUES ('6102', '李泽1234', '3202', '力量循环与力量耐力循环', '2019-05-12', '塑形', '0', '2019-05-12 15:14:33', null);

-- ----------------------------
-- Table structure for bdl_uploadmanagement
-- ----------------------------
DROP TABLE IF EXISTS `bdl_uploadmanagement`;
CREATE TABLE `bdl_uploadmanagement` (
  `Pk_UM_Id` int(20) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `UM_Exec` int(6) unsigned DEFAULT NULL COMMENT '进行的操作类型 add：0  update：1',
  `UM_DataId` int(10) unsigned DEFAULT NULL COMMENT '数据的id',
  `UM_DataTable` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '持有数据所在的表名',
  PRIMARY KEY (`Pk_UM_Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=531 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of bdl_uploadmanagement
-- ----------------------------
INSERT INTO `bdl_uploadmanagement` VALUES ('1', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('2', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('3', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('4', '0', '5701', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('5', '0', '5701', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('6', '0', '3101', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('7', '0', '3102', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('8', '0', '801', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('9', '0', '802', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('10', '0', '803', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('11', '0', '804', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('12', '0', '805', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('13', '0', '806', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('14', '0', '807', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('15', '0', '808', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('16', '0', '809', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('17', '0', '810', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('18', '0', '811', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('19', '0', '812', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('20', '0', '813', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('21', '0', '814', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('22', '0', '815', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('23', '0', '816', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('24', '0', '817', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('25', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('26', '1', '5701', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('27', '1', '3101', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('28', '1', '3102', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('29', '0', '5702', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('30', '0', '5702', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('31', '0', '3103', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('32', '0', '3104', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('33', '0', '818', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('34', '0', '819', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('35', '0', '820', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('36', '0', '821', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('37', '0', '822', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('38', '0', '823', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('39', '0', '824', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('40', '0', '825', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('41', '0', '826', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('42', '0', '827', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('43', '0', '828', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('44', '0', '829', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('45', '0', '830', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('46', '0', '831', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('47', '0', '832', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('48', '0', '833', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('49', '0', '834', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('50', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('51', '1', '5701', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('52', '1', '5702', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('53', '1', '3101', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('54', '1', '3102', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('55', '1', '3103', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('56', '1', '3104', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('57', '0', '5801', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('58', '0', '5801', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('59', '0', '3201', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('60', '0', '3202', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('61', '0', '901', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('62', '0', '902', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('63', '0', '903', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('64', '0', '904', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('65', '0', '905', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('66', '0', '906', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('67', '0', '907', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('68', '0', '908', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('69', '0', '909', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('70', '0', '910', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('71', '0', '911', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('72', '0', '912', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('73', '0', '913', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('74', '0', '914', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('75', '0', '915', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('76', '0', '916', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('77', '0', '917', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('78', '1', '2801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('79', '1', '2801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('80', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('81', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('82', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('83', '1', '2801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('84', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('85', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('86', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('87', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('88', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('89', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('90', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('91', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('92', '1', '2801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('93', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('94', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('95', '1', '2801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('96', '0', '5901', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('97', '0', '5901', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('98', '0', '3301', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('99', '0', '3302', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('100', '0', '1001', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('101', '0', '1002', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('102', '0', '1003', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('103', '0', '1004', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('104', '0', '1005', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('105', '0', '1006', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('106', '0', '1007', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('107', '0', '1008', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('108', '0', '1009', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('109', '0', '1010', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('110', '0', '1011', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('111', '0', '1012', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('112', '0', '1013', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('113', '0', '1014', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('114', '0', '1015', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('115', '0', '1016', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('116', '0', '1017', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('117', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('118', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('119', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('120', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('121', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('122', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('123', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('124', '1', '3002', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('125', '1', '3002', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('126', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('127', '1', '5901', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('128', '1', '3301', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('129', '1', '3302', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('130', '0', '5902', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('131', '0', '5902', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('132', '0', '3303', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('133', '0', '3304', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('134', '1', '5901', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('135', '1', '5902', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('136', '1', '3301', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('137', '1', '3302', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('138', '1', '3303', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('139', '1', '3304', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('140', '0', '5903', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('141', '0', '5903', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('142', '0', '3305', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('143', '0', '1018', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('144', '0', '1019', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('145', '0', '1020', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('146', '0', '1021', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('147', '0', '1022', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('148', '0', '1023', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('149', '0', '1024', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('150', '0', '1025', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('151', '0', '1026', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('152', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('153', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('154', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('155', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('156', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('157', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('158', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('159', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('160', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('161', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('162', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('163', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('164', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('165', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('166', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('167', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('168', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('169', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('170', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('171', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('172', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('173', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('174', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('175', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('176', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('177', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('178', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('179', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('180', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('181', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('182', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('183', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('184', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('185', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('186', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('187', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('188', '0', '3101', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('189', '0', '6001', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('190', '0', '6001', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('191', '0', '3401', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('192', '0', '3402', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('193', '0', '1101', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('194', '0', '1102', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('195', '0', '1103', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('196', '0', '1104', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('197', '0', '1105', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('198', '0', '1106', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('199', '0', '1107', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('200', '0', '1108', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('201', '0', '1109', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('202', '0', '1110', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('203', '0', '1111', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('204', '0', '1112', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('205', '0', '1113', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('206', '0', '1114', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('207', '0', '1115', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('208', '0', '1116', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('209', '0', '1117', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('210', '0', '401', 'bdl_training_activity_record');
INSERT INTO `bdl_uploadmanagement` VALUES ('211', '1', '3101', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('212', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('213', '0', '3102', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('214', '0', '6002', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('215', '0', '6002', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('216', '0', '3403', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('217', '0', '3404', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('218', '0', '1118', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('219', '0', '1119', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('220', '0', '1120', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('221', '0', '1121', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('222', '0', '1122', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('223', '0', '1123', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('224', '0', '1124', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('225', '0', '1125', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('226', '0', '1126', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('227', '0', '1127', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('228', '0', '1128', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('229', '0', '1129', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('230', '0', '1130', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('231', '0', '1131', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('232', '0', '1132', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('233', '0', '1133', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('234', '0', '1134', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('235', '0', '402', 'bdl_training_activity_record');
INSERT INTO `bdl_uploadmanagement` VALUES ('236', '1', '3101', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('237', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('238', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('239', '0', '3201', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('240', '0', '6101', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('241', '0', '6101', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('242', '0', '3501', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('243', '0', '3502', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('244', '0', '1201', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('245', '0', '1202', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('246', '0', '1203', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('247', '0', '1204', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('248', '0', '1205', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('249', '0', '1206', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('250', '0', '1207', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('251', '0', '1208', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('252', '0', '1209', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('253', '0', '1210', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('254', '0', '1211', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('255', '0', '1212', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('256', '0', '1213', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('257', '0', '1214', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('258', '0', '1215', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('259', '0', '1216', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('260', '0', '1217', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('261', '0', '501', 'bdl_training_activity_record');
INSERT INTO `bdl_uploadmanagement` VALUES ('262', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('263', '0', '3202', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('264', '0', '6102', 'bdl_training_plan');
INSERT INTO `bdl_uploadmanagement` VALUES ('265', '0', '6102', 'bdl_training_course');
INSERT INTO `bdl_uploadmanagement` VALUES ('266', '0', '3503', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('267', '0', '3504', 'bdl_activity');
INSERT INTO `bdl_uploadmanagement` VALUES ('268', '0', '1218', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('269', '0', '1219', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('270', '0', '1220', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('271', '0', '1221', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('272', '0', '1222', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('273', '0', '1223', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('274', '0', '1224', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('275', '0', '1225', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('276', '0', '1226', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('277', '0', '1227', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('278', '0', '1228', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('279', '0', '1229', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('280', '0', '1230', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('281', '0', '1231', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('282', '0', '1232', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('283', '0', '1233', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('284', '0', '1234', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('285', '0', '502', 'bdl_training_activity_record');
INSERT INTO `bdl_uploadmanagement` VALUES ('286', '1', '3202', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('287', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('288', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('289', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('290', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('291', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('292', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('293', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('294', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('295', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('296', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('297', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('298', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('299', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('300', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('301', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('302', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('303', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('304', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('305', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('306', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('307', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('308', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('309', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('310', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('311', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('312', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('313', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('314', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('315', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('316', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('317', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('318', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('319', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('320', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('321', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('322', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('323', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('324', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('325', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('326', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('327', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('328', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('329', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('330', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('331', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('332', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('333', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('334', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('335', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('336', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('337', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('338', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('339', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('340', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('341', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('342', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('343', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('344', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('345', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('346', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('347', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('348', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('349', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('350', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('351', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('352', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('353', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('354', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('355', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('357', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('358', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('359', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('360', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('361', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('362', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('363', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('364', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('365', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('366', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('367', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('368', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('369', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('370', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('371', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('372', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('373', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('374', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('375', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('376', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('377', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('378', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('379', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('380', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('381', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('382', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('383', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('384', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('385', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('386', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('387', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('388', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('389', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('390', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('391', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('392', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('393', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('394', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('395', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('396', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('397', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('398', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('399', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('400', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('401', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('402', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('403', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('404', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('405', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('406', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('407', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('408', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('409', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('410', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('411', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('412', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('413', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('414', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('415', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('416', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('417', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('418', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('419', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('420', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('421', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('422', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('423', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('424', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('425', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('426', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('427', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('428', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('429', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('430', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('431', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('432', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('433', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('434', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('435', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('436', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('437', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('438', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('439', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('440', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('441', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('442', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('443', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('444', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('445', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('446', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('447', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('448', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('449', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('450', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('451', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('452', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('453', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('454', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('455', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('456', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('457', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('458', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('459', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('460', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('461', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('462', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('463', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('464', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('465', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('466', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('467', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('468', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('469', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('470', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('471', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('472', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('473', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('474', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('475', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('476', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('477', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('478', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('479', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('480', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('481', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('482', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('483', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('484', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('485', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('486', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('487', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('488', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('489', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('490', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('491', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('492', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('493', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('494', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('495', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('496', '1', '801', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('497', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('498', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('499', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('500', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('501', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('502', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('503', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('504', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('505', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('506', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('507', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('508', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('509', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('510', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('511', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('512', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('513', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('514', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('515', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('516', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('517', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('518', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('519', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('520', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('521', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('522', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('523', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('524', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('525', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('526', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('527', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('528', '1', '0', 'bdl_personal_setting');
INSERT INTO `bdl_uploadmanagement` VALUES ('529', '1', '301', 'bdl_member');
INSERT INTO `bdl_uploadmanagement` VALUES ('530', '1', '801', 'bdl_member');

-- ----------------------------
-- Table structure for bluetooth_read
-- ----------------------------
DROP TABLE IF EXISTS `bluetooth_read`;
CREATE TABLE `bluetooth_read` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员id=手环名称',
  `scan_count` int(10) unsigned DEFAULT '0' COMMENT '扫描次数，每次扫描到就加一',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bluetooth_read
-- ----------------------------
INSERT INTO `bluetooth_read` VALUES ('1', '305865088', '2', '2019-03-14 22:59:38', '2019-03-15 01:00:44');
INSERT INTO `bluetooth_read` VALUES ('2', '17863979633', '2', '2019-03-14 22:59:42', '2019-03-15 01:00:45');
INSERT INTO `bluetooth_read` VALUES ('3', '张方琛7896', '0', '2019-03-20 22:49:19', '0000-00-00 00:00:00');
INSERT INTO `bluetooth_read` VALUES ('4', '陈梓豪1231', '0', '2019-03-20 23:15:47', '0000-00-00 00:00:00');
INSERT INTO `bluetooth_read` VALUES ('5', '胡琛琛3123', '0', '2019-03-20 23:19:04', '0000-00-00 00:00:00');

-- ----------------------------
-- Table structure for bluetooth_write
-- ----------------------------
DROP TABLE IF EXISTS `bluetooth_write`;
CREATE TABLE `bluetooth_write` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `member_id` varchar(100) DEFAULT NULL COMMENT '会员id=手环名称',
  `write_state` tinyint(4) DEFAULT '0' COMMENT '写入状态。0：未写入。1：写入成功。2：写入失败。默认为0',
  `bluetooth_name` varchar(255) DEFAULT NULL COMMENT '要写入的手环原名称',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of bluetooth_write
-- ----------------------------

-- ----------------------------
-- Table structure for s_key
-- ----------------------------
DROP TABLE IF EXISTS `s_key`;
CREATE TABLE `s_key` (
  `key_id` longtext CHARACTER SET utf8 COLLATE utf8_general_ci,
  `max_value` bigint(20) DEFAULT NULL,
  `steps` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of s_key
-- ----------------------------
INSERT INTO `s_key` VALUES ('bdl_member', '3300', '100');
INSERT INTO `s_key` VALUES ('bdl_training_activity_record', '600', '100');
INSERT INTO `s_key` VALUES ('bdl_training_device_record', '1200', '100');
INSERT INTO `s_key` VALUES ('bdl_training_plan', '6200', '100');
INSERT INTO `s_key` VALUES ('bdl_training_course', '6200', '100');
INSERT INTO `s_key` VALUES ('bdl_activity', '3600', '100');
INSERT INTO `s_key` VALUES ('bdl_personal_setting', '1300', '100');
