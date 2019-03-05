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

        public List<ProcessVO> selectStrength()
        {
            return processDAO.selectStrength();
        }

        public List<double> selectAvgValue()
        {
            return processDAO.selectAvgValue();
        }

        public int selectCount()
        {
            return processDAO.selectCount();
        }

        public List<DateTime> selectStrengthCreateTime()
        {
            return processDAO.selectStrengthCreateTime();
        }

        public List<double> selectavgStrengthValue()
        {
            return processDAO.selectavgStrengthValue();
        }

        public List<DateTime> selectAerobicCreateTime()
        {
            return processDAO.selectAerobicCreateTime();
        }

        public List<double> selectavgAerobicValue()
        {
            return processDAO.selectavgAerobicValue();
        }
    }
}
