﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            /*int index = (int)(Students.Count * 0.20);
            int countHigherAverage = 0;
            foreach(var student in Students)
            {
                if(Math.Min(averageGrade,student.AverageGrade)==averageGrade)
                {
                    countHigherAverage++;
                }
            }
            int indexAverageGrade = countHigherAverage;
            if(index >= indexAverageGrade)
            {
                return 'A';
            }*/

            var treshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
           
            if(grades[treshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if(grades[(treshold * 2) -1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(treshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(treshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
