using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarships
{
    class Student
    {
        private String firstName;
        private String familyName;
        private String group;
        private int numGradePoints;
        private int[] gradePoints;

        public Student() { }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Group { get => group; set => group = value; }
        public int NumGradePoints { get => numGradePoints; set => numGradePoints = value; }
        public int[] GradePoints { get => gradePoints; }

        public void setGradePoints(String strGradePoints)
        {
            String[] arrS = strGradePoints.Split(new Char[] { ' ' });
            gradePoints = new int[arrS.Length];
            for (int i = 0; i < arrS.Length; i++)
            {
                gradePoints[i] = Convert.ToInt32(arrS[i]);
            }
        }

        public Boolean isScholarship(Filter filter)
        {
            double ave = 0;
            for (int i = 0; i < gradePoints.Length; i++)
            {
                if (gradePoints[i] <= 4)
                { // min grade
                    return false;
                }
                ave += gradePoints[i];
            }
            return ave / gradePoints.Length > filter.GradePointAve;
        }

        public Boolean isAdvanced()
        {
            foreach (int p in gradePoints)
            {
                if (p * 1.0 <= 8)
                {
                    return false;
                }
            }
            return true;
        }

        public int compare(Student student)
        {
            int flag = student.isAdvanced().CompareTo(isAdvanced());
            if (flag == 0)
            {
                flag = compareString(familyName, student.familyName);
            }
            if (flag == 0)
            {
                flag = compareString(firstName, student.firstName);
            }
            return flag;
        }

        private int compareString(String s1, String s2)
        {
            int length = s1.Length > s2.Length ? s2.Length : s1.Length;
            for (int i = 0; i < length; i++)
            {
                if (s1[i] > s2[i])
                    return 1;
                else if (s1[i] < s2[i])
                    return -1;
            }
            return s1.Length.CompareTo(s2.Length);
        }
    }
}
