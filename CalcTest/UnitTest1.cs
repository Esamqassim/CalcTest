using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CalcTest
{
    public class CalcTests : IEnumerable<object[]>
    {
        [Theory]
        [ClassData(typeof(CalcTests))]//Data type changed to class name
        //[InlineData(2, -6, -4)]
        // InlineData(2,-6, -4)]
        //[InlineData(double.MinValue, -1, double.MaxValue)]

        public void AddTest(double num1, double num2, double expectedValue)
        {
           
            //var num1 = 2.9;
             //var num2 = 3.1;
            //var expectedValue = 6;
           
             var sum = Add(num1, num2);
             Assert.Equal(expectedValue, sum);   

        }

        public IEnumerator<object[]> GetEnumerator()
        {
           // throw new NotImplementedException();

            yield return new object[] { 2,-6 , -4};
            yield return new object[] { -3, 0.1, -2.9 };
            yield return new object[] { 0.2, -3, -2.8 };
           // yield return new object[] { double.MinValue, -1, double.MaxValue };
        }

        double Add(double n1, double n2)//method to test
        {
            return n1 + n2;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /*************************************End AddTest*****************************************************/

        [Theory]
        [InlineData(2, -2, 4)]
        [InlineData(0.2, 6, -5.8)]
        [InlineData(-2, 0.4, -2.4)]


        public void SubTest(double num1, double num2, double expectedValue)
        {
            var sub = Sub(num1, num2);
            Assert.Equal(expectedValue, sub);
        }
        private double Sub(double n1, double n2)
        {
            return n1 - n2;
        } //End Sub test

        [Theory]
        [InlineData(2, -2, -4)]
        [InlineData(4, -0.2, -0.8)]
        [InlineData(-2, 0.4, -0.8)]
        //[InlineData(double.MinValue, 0, double.MaxValue)]

        public void MultiplyTest(double num1, double num2, double expectedValue)
        {
            var mul = Multiply(num1, num2);
            Assert.Equal(expectedValue, mul);
        }
        private double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }//End multiply test


        [Theory]
        [InlineData(2, 4, 0.5)]
        [InlineData(-6, -3, 2)]
        [InlineData(-0.3, -1, 0.3)]

        public void DividTest(double num1, double num2, double expectedValue)
        {
            var divison = Divid(num1, num2);

            Assert.Equal(expectedValue, divison);

        }

        private double Divid(double n1, double n2)
        {

            try // Program stop 
            {
                if (n2 == 0)
                    throw new DivideByZeroException();


                return n1 / n2;
            }

            catch (DivideByZeroException e)
            {
                throw new ArgumentException("Argument n2 must be non zero.", e);
            }


        }//End Divid test
        /****************************Array Test*******************************************/
        [Theory]
        [MemberData(nameof(GetDouble))]// It take the name of our interface function


        public void AddTest2(List<double> num1, double expectedValue)
        {
            
            List<double> list = new List<double>(num1);
           
            var sum = Add(list);

            Assert.Equal(expectedValue, sum);


        }

        private double Add(List<double> n1)//Add overloaded
        {


            double tot = 0;
            for (int i = 0; i < n1.Count; i++)
                tot += n1[i];

            return tot;
        }
        public static IEnumerable<object[]> GetDouble()//Interface for second test
        {
            // throw new NotImplementedException();

            yield return new object[] {
                new List<double>() { 12.2, 22.2 }, 34.4  };//Two elements
            yield return new object[] {
                new List<double>() { -12.2, -22.2 }, -34.4  };//Two elements
            yield return new object[] {
                new List<double>() { 0.2, 0.3 ,0.4}, 0.9};//Two elements
        }//End AddTest2

        /*************************************************************/

        [Theory]
        [MemberData(nameof(GetSubtruction))]// It take the name of our interface function

        public void SubTest2(List<double> num1, double expectedValue)
        {
            List<double> list = new List<double>(num1);
            // var sum = num1.Sum();//But we does not test our method!!!!??
            var sub = Sub(list);
            // sum = 10 - sum;//Identical to our method 
            Assert.Equal(expectedValue, sub);
        }
        private double Sub(List<double> n1)//Overload Sub
        {
            double tot = 0;
            for (int i = 0; i < n1.Count; i++)
                tot += n1[i];
            double sub = 10 - tot;
            return sub;
        }

        public static IEnumerable<object[]> GetSubtruction()//Interface for Sub array test
        {
            // throw new NotImplementedException();

            yield return new object[] {
                new List<double>() { 12.2, 22.2 }, -24.4  };//Two elements
            yield return new object[] {
                new List<double>() { -12.2, -22.2 }, 44.4  };//Two elements
            yield return new object[] {
                new List<double>() { 0.2, 0.4 ,0.4}, 9 };//Two elements
        }




    }//End class
}//end namespace
