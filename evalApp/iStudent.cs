using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evalApp
{
    public interface IStudent
    {
        string Name { get; }

        string Surname { get; }

        string Sex { get; }

        void AddGrade(float grade);

        void AddGrade(char grade);

        void AddGrade(byte grade);

        void AddGrade(long grade);

        void AddGrade(double grade);

        void AddGrade(int grade);

        void AddGrade(string grade);

        Statistics GetStatistics();
    }
}
