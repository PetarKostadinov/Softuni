using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
   public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>(); 
        }

        public int Capacity { get; set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
               
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder result = new StringBuilder();
   
            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");

            bool isInside = false;
 
                foreach (var person in students.Where(x => x.Subject == subject))
                {
                     isInside = true;
                    result.AppendLine($"{person.FirstName} { person.LastName}");
                }

            if (isInside)
            {
                return result.ToString().TrimEnd();
            } 
            return "No students enrolled for the subject";    
        }
        public int GetStudentsCount()
        {
            return students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

                return student;   
        }
    }
}
