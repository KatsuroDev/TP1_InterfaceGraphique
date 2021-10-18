using System.Collections.Generic;

namespace TP1_InterfaceGraphique
{
    public enum Semester
    {
        A21,
        H20,
        A20
    }

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class CoursePeriod
    {
        public DayOfWeek DayOfWeek;
        public int PeriodStart;
        public int PeriodLength;
    }

    public class Evaluation
    {
        public string Name;
        public int Value;
        public Dictionary<int, int> StudentResults;
    }

    public class Course
    {
        public string Id;
        public string Name;
        public Semester Semester;
        public int Group;
        public List<CoursePeriod> CoursePeriods;
        public int TeacherId;
        public List<int> StudentIds;
        public List<Evaluation> Evaluations;
    }
}
