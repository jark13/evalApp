using System.Runtime.Intrinsics.X86;

namespace evalApp.Test
{
     public class TypeTests
    {
        [Test]
        public void TestForInts()
        {
            //arrange
            int number1 = 3;
            int number2 = 7;
            
            //assert         
            Assert.AreNotEqual(number1, number2);
        }

        [Test]
        public void TestForStrings()
        {
            //arrange
            string number1 = "Adam";
            string number2 = "Adam";

            //assert
            Assert.AreEqual(number1, number2);
        }

        [Test]
        public void GetUserShouldReturnDifferentObjects()
        {
            //arrange
            var user1 = new StudentInMemory("Marek", "Nowak", "33");
            var user2 = new StudentInMemory("Marek", "Nowak", "33");


            //Assert.AreEqual(user1.Age, user2.Age);
            Assert.AreNotEqual(user1, user2);
        }


        [Test]
        public void WhenUserColletsPoints_ShouldReturnCorrectMin()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Woman");
            student.AddGrade(25);
            student.AddGrade(3);
            student.AddGrade(10);
            student.AddGrade(15);
            student.AddGrade(7);

            //act
            //var statistics = user.AddGrade;

            var statistics = student.GetStatistics();

            //assert
            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void WhenUserColletsPoints_ShouldReturnCorrectAverages()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Fimale");
            student.AddGrade(25);
            student.AddGrade(3);
            student.AddGrade(10);
            student.AddGrade(15);
            student.AddGrade(7);
            student.AddGrade(2);
            student.AddGrade(2);
            student.AddGrade(6);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.AreEqual(8.75, statistics.Average);
            //Assert.AreEqual(Math.Round(3.33, 2), Math.Round(statistics.Average, 2));
        }

        [Test]
        public void WhenUserColletsPoints_ShouldReturnCorrectMax()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Fimale");
            student.AddGrade(25);
            student.AddGrade(3);
            student.AddGrade(10);
            student.AddGrade(15);
            student.AddGrade(7);

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.AreEqual(25, statistics.Max);
        }

        [Test]
        public void WhenUserExpressedByLetterColletsPoints_ShouldReturnCorrectMax()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Fimale");
            student.AddGrade('a');
            student.AddGrade('b');
            student.AddGrade('c');
            student.AddGrade('d');
            student.AddGrade('e');

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.AreEqual(100, statistics.Max);
        }

        [Test]
        public void WhenUserExpressedByLetterColletsPoints_ShouldReturnCorrectMin()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Fimale");
            student.AddGrade('A');
            student.AddGrade('B');
            student.AddGrade('C');
            student.AddGrade('D');
            student.AddGrade('E');

            //act
            var statistics = student.GetStatistics();

            //assert
            Assert.AreEqual(20, statistics.Min);
        }


        [Test]
        public void WhenUserExpressedByLetterColletsPoints_ShouldReturnCorrectAverage()
        {
            //arrange
            var student = new StudentInMemory("Anna", "Nowak", "Fimale");
            student.AddGrade('A');
            student.AddGrade('B');
            student.AddGrade('C');
            student.AddGrade('D');
            student.AddGrade('E');

            //student.AddGrade(53.0f);
            //student.AddGrade('B');
            //student.AddGrade(9);
            //student.AddGrade('a');


            //act
            var statistics = student.GetStatistics();

            //assert
            //Assert.AreEqual(60.5, statistics.Average);
            Assert.AreEqual(60, statistics.Average);
        }
    }
}