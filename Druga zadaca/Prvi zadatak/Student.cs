using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi_zadatak
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   Name == student.Name &&
                   Jmbag == student.Jmbag &&
                   Gender == student.Gender;
        }

        public override int GetHashCode()
        {
            var hashCode = 430495180;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Jmbag);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return (obj1.Name == obj2.Name
                    && obj1.Gender == obj2.Gender
                    && obj1.Jmbag == obj2.Jmbag);
        }

                    public static bool operator !=(Student obj1, Student obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
