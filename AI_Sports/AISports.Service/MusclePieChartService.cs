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
        public int? selectAbdomenTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectAbdomenTraining(trainingCourseId);
        }

        public int? selectchestTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectchestTraining(trainingCourseId);
        }

        public int? selectLegTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectLegTraining(trainingCourseId);
        }

        public int? selectArmTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectArmTraining(trainingCourseId);
        }

        public int? selectTrunkTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectTrunkTraining(trainingCourseId);
        }

        public int? selectchestEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectchestEnduranceTraining(trainingCourseId);
        }

        public int? selectLegEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectLegEnduranceTraining(trainingCourseId);
        }

        public int? selectEnduranceBackTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectEnduranceBackTraining(trainingCourseId);
        }

        public int? selectTrunkEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartDAO.selectTrunkEnduranceTraining(trainingCourseId);
        }
    }
}
