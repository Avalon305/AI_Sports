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

        public int? selectsittingChestPusher(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectsittingChestPusher(currentCourseCount, memberId);
        }

        public int? selectSittingRower(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectSittingRower(currentCourseCount, memberId);
        }

        public int? selectsittingBackStretcher(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectsittingBackStretcher(currentCourseCount, memberId);
        }

        public int? selectAbdominalMuscleTraining(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectAbdominalMuscleTraining(currentCourseCount, memberId);
        }

        public int? selectSittingLegStretching(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectSittingLegStretching(currentCourseCount, memberId);
        }

        public int? selectSittingCurvingLeg(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectSittingCurvingLeg(currentCourseCount, memberId);
        }

        public int? selectExerciseBike(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectExerciseBike(currentCourseCount, memberId);
        }

        public int? selectEllipticalTreadmill(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectEllipticalTreadmill(currentCourseCount, memberId);
        }

        public int? selectSittinglatissimusDorsiElevator(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectSittinglatissimusDorsiElevator(currentCourseCount, memberId);
        }

        public int? selectTricepsTrainingMachine(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectTricepsTrainingMachine(currentCourseCount, memberId);
        }

        public int? selectLegBender(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectLegBender(currentCourseCount, memberId);
        }

        public int? selectLeg(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectLeg(currentCourseCount, memberId);
        }

        public int? selectButterflyMachine(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectButterflyMachine(currentCourseCount, memberId);
        }

        public int? selectReversebutterflyMachine(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectReversebutterflyMachine(currentCourseCount, memberId);
        }

        public int? SittingBack(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectSittingBack(currentCourseCount, memberId);
        }

        public int? selectTrunkTorsionCombination(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectTrunkTorsionCombination(currentCourseCount, memberId);
        }

        public int? selectLegPusher(string currentCourseCount, string memberId)
        {
            return muscleDAO.selectLegPusher(currentCourseCount, memberId);
        }
       
    }
}
