﻿using AI_Sports.Dao;
using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    class TrainingDeviceRecordService
    {
        private TrainingDeviceRecordDAO trainingDeviceRecordDAO = new TrainingDeviceRecordDAO();

        public List<TrainingDeviceRecordEntity> GetRecordByIdAndTime(string memberId)
        {
            return trainingDeviceRecordDAO.GetRecordByIdAndTime(memberId);
        }

        public int GetTrainActivityRecordIdById(long Id) {
            return trainingDeviceRecordDAO.GetTrainActivityRecordIdById(Id);
        }
        public int GetRecordCountByIdAndDeviceCode(string memberId, string Device_code) {
            return trainingDeviceRecordDAO.GetRecordCountByIdAndDeviceCode(memberId, Device_code);
        }

    }
}