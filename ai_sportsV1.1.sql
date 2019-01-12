/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50634
Source Host           : localhost:3306
Source Database       : ai_sports

Target Server Type    : MYSQL
Target Server Version : 50634
File Encoding         : 65001

Date: 2019-01-12 19:06:43
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for bdl_activity
-- ----------------------------
DROP TABLE IF EXISTS `bdl_activity`;
CREATE TABLE `bdl_activity` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_training_course_id` int(10) unsigned NOT NULL COMMENT '外键训练课程id',
  `activity_name` varchar(255) NOT NULL COMMENT '训练活动名：力量循环或者力量耐力循环',
  `target_turn_number` int(10) unsigned NOT NULL COMMENT '目标轮次数量，目标在这一圈训练几轮',
  `current_turn_number` int(10) unsigned DEFAULT '0' COMMENT '当前轮次计数',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_training_course_id` (`fk_training_course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_datacode
-- ----------------------------
DROP TABLE IF EXISTS `bdl_datacode`;
CREATE TABLE `bdl_datacode` (
  `fk_code_id` int(11) NOT NULL AUTO_INCREMENT,
  `code_xh` int(11) DEFAULT NULL COMMENT '排序号，下拉列表按这个排序',
  `code_type_id` varchar(255) DEFAULT NULL COMMENT '类型ID，dList是数据项',
  `code_s_value` varchar(255) DEFAULT NULL COMMENT '存储值',
  `code_d_value` varchar(255) DEFAULT NULL COMMENT '展示值',
  `code_state` tinyint(4) DEFAULT '1' COMMENT '是否启用 0 不启用 1启用',
  PRIMARY KEY (`fk_code_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_member
-- ----------------------------
DROP TABLE IF EXISTS `bdl_member`;
CREATE TABLE `bdl_member` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `member_id` varchar(100) NOT NULL COMMENT '会员id',
  `member_firstName` varchar(50) NOT NULL COMMENT '会员名',
  `member_familyName` varchar(50) NOT NULL COMMENT '会员姓',
  `birth_date` date NOT NULL COMMENT '出生日期',
  `sex` tinyint(4) unsigned NOT NULL COMMENT '0：女士；1：先生',
  `address` varchar(255) DEFAULT NULL COMMENT '住址',
  `email_address` varchar(50) DEFAULT NULL COMMENT '邮箱地址',
  `work_phone` varchar(50) DEFAULT NULL COMMENT '工作电话',
  `personal_phone` varchar(50) DEFAULT NULL COMMENT '私人电话',
  `mobile_phone` varchar(50) DEFAULT NULL COMMENT '手机号码',
  `weight` int(11) unsigned DEFAULT NULL COMMENT '体重（KG）',
  `height` int(11) unsigned DEFAULT NULL COMMENT '身高 (cm)',
  `age` int(11) unsigned DEFAULT NULL COMMENT '年龄',
  `max_heart_rate` int(11) unsigned DEFAULT NULL COMMENT '最大心率=220-age',
  `suitable_heart_rate` int(11) unsigned DEFAULT NULL COMMENT '最宜心率',
  `role_id` tinyint(11) unsigned DEFAULT NULL COMMENT '角色id，1：会员；0：教练',
  `fk_coach_id` int(11) unsigned DEFAULT NULL COMMENT '外键关联教练id',
  `label_name` varchar(255) DEFAULT NULL COMMENT '标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔',
  `is_open_fat_reduction` tinyint(3) unsigned DEFAULT '0' COMMENT '是否开启减脂模式 默认0，0:未开启，1:开启',
  `remark` varchar(255) DEFAULT NULL COMMENT '前端备注',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_coach_id` (`fk_coach_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_personal_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_personal_setting`;
CREATE TABLE `bdl_personal_setting` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_member_id` int(10) unsigned NOT NULL COMMENT '外键会员id',
  `seat_height` decimal(10,0) DEFAULT NULL COMMENT '座位高度',
  `backrest_distance` decimal(10,0) DEFAULT NULL COMMENT '靠背距离',
  `front_limit` decimal(10,0) DEFAULT NULL COMMENT '前方限制',
  `back_limit` decimal(10,0) DEFAULT NULL COMMENT '后方限制',
  `training_mode` varchar(255) DEFAULT NULL COMMENT '训练模式',
  `consequent _force` int(10) unsigned DEFAULT NULL COMMENT '顺向力',
  `reverse _force` int(11) DEFAULT NULL COMMENT '反向力',
  `power` int(11) DEFAULT NULL COMMENT '功率',
  `fk_training_activity_name` varchar(255) DEFAULT NULL COMMENT '训练活动名',
  `device_name` varchar(255) DEFAULT NULL COMMENT '设备名',
  `device_order_number` int(10) unsigned DEFAULT NULL COMMENT '设备序号',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_member_id` (`fk_member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_system_setting
-- ----------------------------
DROP TABLE IF EXISTS `bdl_system_setting`;
CREATE TABLE `bdl_system_setting` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `organization_name` varchar(255) DEFAULT NULL COMMENT '机构名称',
  `organization_phone` varchar(255) DEFAULT NULL COMMENT '机构电话',
  `organization_address` varchar(255) DEFAULT NULL COMMENT '机构地址',
  `ip_address` varchar(255) DEFAULT NULL COMMENT 'ip地址',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_training_activity_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_activity_record`;
CREATE TABLE `bdl_training_activity_record` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_training_course_record_id` int(10) unsigned NOT NULL COMMENT '外键训练课程记录id',
  `activity_name` varchar(255) NOT NULL COMMENT ' 训练活动名：力量循环或者力量耐力循环',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_training_course_record_id` (`fk_training_course_record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_training_course
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_course`;
CREATE TABLE `bdl_training_course` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_training_plan_id` int(10) unsigned NOT NULL COMMENT '外键训练计划id',
  `rest_days` int(10) unsigned NOT NULL COMMENT '休息天数（间隔）',
  `target_course_count` int(10) unsigned NOT NULL COMMENT '目标课程轮次计数=前端课程天',
  `current_course_count` int(10) unsigned DEFAULT '0' COMMENT '当前课程轮次计数',
  `start_date` date DEFAULT NULL COMMENT '起始日期',
  `end_date` date DEFAULT NULL COMMENT '预计结束日期=起始日期+休息天数*课程天数',
  `current_end_date` date DEFAULT NULL COMMENT '当前进度预计结束日期.更新完成状态时，根据计数和间隔更新此日期',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_training_plan_id` (`fk_training_plan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_training_course_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_course_record`;
CREATE TABLE `bdl_training_course_record` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_training_course_id` int(11) NOT NULL COMMENT '外键训练课程id',
  `course_id` int(11) NOT NULL COMMENT '当前课程轮次=插入时训练课程表的当前课程计数',
  `is_complete` tinyint(3) unsigned DEFAULT '0' COMMENT '是否完成 默认0:未完成。1:完成)',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_training_course_id` (`fk_training_course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_training_device_record
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_device_record`;
CREATE TABLE `bdl_training_device_record` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_training_activity_record_id` int(10) unsigned NOT NULL COMMENT '外键训练活动记录id',
  `device_order_number` int(10) unsigned NOT NULL COMMENT '设备在循环中的序号',
  `device_name` varchar(255) NOT NULL COMMENT '设备名',
  `activity_name` varchar(255) NOT NULL COMMENT '训练活动名',
  `fk_member_id` varchar(255) NOT NULL COMMENT '外键会员id',
  `training_mode` varchar(255) NOT NULL COMMENT '训练模式',
  `consequent _force` int(10) unsigned DEFAULT NULL COMMENT '最终顺向力',
  `reverse _force` int(10) unsigned DEFAULT NULL COMMENT '最终反向力',
  `power` int(10) unsigned DEFAULT NULL COMMENT '功率',
  `count` int(10) unsigned DEFAULT NULL COMMENT '训练个数',
  `speed` decimal(10,0) unsigned DEFAULT NULL COMMENT '速度 1位小数 千米每时',
  `distance` decimal(10,0) unsigned DEFAULT NULL COMMENT '距离 千米，两位小数',
  `energy` decimal(10,0) DEFAULT NULL COMMENT '训练总耗能 单位卡路里',
  `training_time` int(10) unsigned DEFAULT NULL COMMENT '训练时间 单位秒',
  `avg_heart_rate` int(10) unsigned DEFAULT NULL COMMENT '平均心率',
  `max_heart_rate` int(10) unsigned DEFAULT NULL COMMENT '最大心率',
  `min_heart_rate` int(10) unsigned DEFAULT NULL COMMENT '最小心率',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_training_activity_record_id` (`fk_training_activity_record_id`) USING BTREE,
  KEY `fk_member_id` (`fk_member_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bdl_training_plan
-- ----------------------------
DROP TABLE IF EXISTS `bdl_training_plan`;
CREATE TABLE `bdl_training_plan` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `fk_member_id` int(10) unsigned NOT NULL COMMENT '外键会员id',
  `title` varchar(255) DEFAULT NULL COMMENT '训练标题',
  `start_date` date DEFAULT NULL COMMENT '起始日期',
  `training_target` varchar(255) DEFAULT NULL COMMENT '训练目标',
  `is_deleted` tinyint(4) unsigned DEFAULT '0' COMMENT '是否删除 1:删除;0:未删除',
  `gmt_create` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `gmt_modified` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间',
  PRIMARY KEY (`id`),
  KEY `fk_member_id` (`fk_member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_auth
-- ----------------------------
DROP TABLE IF EXISTS `t_auth`;
CREATE TABLE `t_auth` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键自增id',
  `username` varchar(255) DEFAULT NULL COMMENT '用户名',
  `password` varchar(255) DEFAULT NULL COMMENT '密码',
  `authid` varchar(255) DEFAULT NULL COMMENT '手环或卡的openID',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
