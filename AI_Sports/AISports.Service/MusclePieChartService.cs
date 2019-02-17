using AI_Sports.AISports.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    class MusclePieChartService
    {
        MusclePieChartDAO musclePieChartDAO = new MusclePieChartDAO();
        public int selectAbdomenTraining()
        {
            return musclePieChartDAO.selectAbdomenTraining();
        }

        public int selectchestTraining()
        {
            return musclePieChartDAO.selectchestTraining();
        }

        public int selectLegTraining()
        {
            return musclePieChartDAO.selectLegTraining();
        }

        public int selectArmTraining()
        {
            return musclePieChartDAO.selectArmTraining();
        }

        public int selectTrunkTraining()
        {
            return musclePieChartDAO.selectTrunkTraining();
        }

        public int selectchestEnduranceTraining()
        {
            return musclePieChartDAO.selectchestEnduranceTraining();
        }

        public int selectLegEnduranceTraining()
        {
            return musclePieChartDAO.selectLegEnduranceTraining();
        }

        public int selectEnduranceArmTraining()
        {
            return musclePieChartDAO.selectEnduranceArmTraining();
        }

        public int selectTrunkEnduranceTraining()
        {
            return musclePieChartDAO.selectTrunkEnduranceTraining();
        }
    }
}
