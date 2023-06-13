using System.Collections.Specialized;
using System.Diagnostics;
using static evalApp.StudentBase;

namespace evalApp
{
    public class StudentInFile : StudentBase
    {
        public const string fileName = "grades.txt";

        public event GradeAddedDelegate GradeAdded;
        public StudentInFile(string name, string surname, string sex)
            : base(name, surname, sex)
        {
            this.Name = surname;
            this.Surname = surname;
            this.Sex = sex;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Sex { get; private set; }



        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Value out of range");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                if (result >= 0 && result <= 100)
                {
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(result);

                        if (GradeAdded != null)
                        {
                            GradeAdded(this, new EventArgs());
                        }
                    }
                }
                else
                {
                    throw new Exception("Value out of range");
                }
            }
            else
            {
                if (char.TryParse(grade, out char charResult))
                {
                    switch (charResult)
                    {
                        case 'A':
                        case 'a':
                            //this.grades.Add(100);
                            using (var writer = File.AppendText(fileName))
                            {
                                writer.WriteLine(100);
                            }
                            break;
                        case 'B':
                        case 'b':
                            using (var writer = File.AppendText(fileName))
                            {
                                writer.WriteLine(80);
                            }
                            break;
                        case 'C':
                        case 'c':
                            using (var writer = File.AppendText(fileName))
                            {
                                writer.WriteLine(60);
                            }
                            break;
                        case 'D':
                        case 'd':
                            using (var writer = File.AppendText(fileName))
                            {
                                writer.WriteLine(40);
                            }
                            break;
                        case 'E':
                        case 'e':
                            using (var writer = File.AppendText(fileName))
                            {
                                writer.WriteLine(20);
                            }
                            break;
                        default:
                            throw new Exception("Wrong Letter");
                    }
                }
                else
                {
                    throw new Exception("String is not float");
                }
            }

        }

        public override void AddGrade(byte grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine((float)grade);
            }
        }

        public override void AddGrade(long grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine((float)grade);
            }
        }

        public override void AddGrade(double grade)
        {
            float gradeAsFloat = (float)grade;
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(gradeAsFloat);
            }
        }

        public override void AddGrade(int grade)
        {
            float gradeAsFloat = (float)grade;
            using (var writer = File.AppendText(fileName))
            {
                if (grade >= 0 && grade <= 100)
                {
                    writer.WriteLine(gradeAsFloat);
                }
                else
                {
                    throw new Exception("Value out of range");
                }
            }
        }

        public override void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(100);
                    }
                    break;
                case 'B':
                case 'b':
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(80);
                    }
                    break;
                case 'C':
                case 'c':
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(60);
                    }
                    break;
                case 'D':
                case 'd':
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(40);
                    }
                    break;
                case 'E':
                case 'e':
                    using (var writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(20);
                    }
                    break;
                default:
                    throw new Exception("Wrong Letter");
            }
        }

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}

