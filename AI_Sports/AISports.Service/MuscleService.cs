using AI_Sports.AISports.Dao;
using AI_Sports.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    class MuscleService
    {
        MuscleDAO muscleDAO = new MuscleDAO();

        public int selectsittingChestPusher(string currentCourseCount)
        {
            return muscleDAO.selectsittingChestPusher(currentCourseCount);
        }

        public int selectSittingRower(string currentCourseCount)
        {
            return muscleDAO.selectSittingRower(currentCourseCount);
        }

        public int selectsittingBackStretcher(string currentCourseCount)
        {
            return muscleDAO.selectsittingBackStretcher(currentCourseCount);
        }

        public int selectAbdominalMuscleTraining(string currentCourseCount)
        {
            return muscleDAO.selectAbdominalMuscleTraining(currentCourseCount);
        }

        public int selectSittingLegStretching(string currentCourseCount)
        {
            return muscleDAO.selectSittingLegStretching(currentCourseCount);
        }

        public int selectSittingCurvingLeg(string currentCourseCount)
        {
            return muscleDAO.selectSittingCurvingLeg(currentCourseCount);
        }

        public int selectExerciseBike(string currentCourseCount)
        {
            return muscleDAO.selectExerciseBike(currentCourseCount);
        }

        public int selectEllipticalTreadmill(string currentCourseCount)
        {
            return muscleDAO.selectEllipticalTreadmill(currentCourseCount);
        }

        public int selectSittinglatissimusDorsiElevator(string currentCourseCount)
        {
            return muscleDAO.selectSittinglatissimusDorsiElevator(currentCourseCount);
        }

        public int selectTricepsTrainingMachine(string currentCourseCount)
        {
            return muscleDAO.selectTricepsTrainingMachine(currentCourseCount);
        }

        public int selectLegBender(string currentCourseCount)
        {
            return muscleDAO.selectLegBender(currentCourseCount);
        }

        public int selectLeg(string currentCourseCount)
        {
            return muscleDAO.selectLeg(currentCourseCount);
        }

        public int selectButterflyMachine(string currentCourseCount)
        {
            return muscleDAO.selectButterflyMachine(currentCourseCount);
        }

        public int selectReversebutterflyMachine(string currentCourseCount)
        {
            return muscleDAO.selectReversebutterflyMachine(currentCourseCount);
        }

        public int SittingBack(string currentCourseCount)
        {
            return muscleDAO.selectSittingBack(currentCourseCount);
        }

        public int selectTrunkTorsionCombination(string currentCourseCount)
        {
            return muscleDAO.selectTrunkTorsionCombination(currentCourseCount);
        }

        public int selectLegPusher(string currentCourseCount)
        {
            return muscleDAO.selectLegPusher(currentCourseCount);
        }
       
    }
}
