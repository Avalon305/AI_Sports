using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    class ProcessService
    {
        ProcessDAO processDAO = new ProcessDAO();
        public List<DateTime> selectCreateTime()
        {
            return processDAO.selectCreateTime();

        }

        public List<double> selectAvgValue(string trainingCourseId)
        {
            return processDAO.selectAvgValue(trainingCourseId);
        }

        public int selectCount()
        {
            return processDAO.selectCount();
        }

        public List<DateTime> selectStrengthCreateTime()
        {
            return processDAO.selectStrengthCreateTime();
        }

        public List<double> selectavgStrengthValue(string trainingCourseId)
        {
            return processDAO.selectavgStrengthValue(trainingCourseId);
        }

        public List<DateTime> selectAerobicCreateTime()
        {
            return processDAO.selectAerobicCreateTime();
        }

        public List<double> selectavgAerobicValue(string trainingCourseId)
        {
            return processDAO.selectavgAerobicValue(trainingCourseId);
        }
    }
}
