using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    public class NumericalExpression
    {
        private ulong _number;
        private int _len;
        private string _fullNumberExpression;
        private Expressions _expressions;
        public NumericalExpression(ulong number)
        {
            _fullNumberExpression = "";
            _expressions = new Expressions();
            _number = number;
            _len = (int)(Math.Log10(number) + 1);
        }
        public void expressNumber()
        {
            //int numberInTens = (int)Math.Pow(10, _len - 1);
            int typeTens = _len;
            if (_len > 6) //not hundrends
            {
                while (typeTens % 3 != 0)
                    typeTens--; //find the type of the trio by position in number
            }
            if (_len <= 6 &&  _len >= 4)
            {
                typeTens = 4;
            }
            //long calcTypeTens = (int)Math.Pow(10, typeTens - 1);
            ulong calcTypeTens = 1;
            for (int i = 0; i < typeTens; i++)
            {
                calcTypeTens *= 10; //calc the max number in this type 
            }
            ulong numberProcess = _number; 

            //run on every trio, express the number and determine which type of number by position in full number
            for (ulong i = calcTypeTens; i >=1; i /= 1000)
            {
                ulong num =numberProcess;
                if (i >= 1000) //trio calc
                {
                    num = numberProcess / i; //three digit number
                }
                string numString = GetValueMatchThreeDigitsPattern(num, i);
                _fullNumberExpression += numString;
                numberProcess %= i; //moving to the next trio
            }
  
        }

        //public string GetValue()
        //{
        //   return ToString();
        //}
        public override string ToString()
        {
           this.expressNumber();
            return _fullNumberExpression;
        }
        public string GetValue()
        {
             return this.ToString();
        }
        private string GetValueMatchThreeDigitsPattern(ulong numberThreeDigits, ulong typeTens)
        {
            //calc digits
            int firstDigit = (int)numberThreeDigits / 100;
            int secondDigit = (int) numberThreeDigits % 100 / 10;
            int thirdDigit = (int)numberThreeDigits % 10;

            if (firstDigit == 0 &&
                secondDigit == 0 &&
                thirdDigit == 0)
                return "";

            string firstDigitStr = "";
            string secondDigitStr = "";
            string thirdDigitStr = "";

            if (firstDigit != 0)
            {
                firstDigitStr = _expressions.OnesDict[firstDigit] + _expressions.MultiplerTensBaseAccordingToPlace[100];
            }

            //in case there is unity
            if (secondDigit == 1 && thirdDigit != 0) //that means there are no tens
            {
                secondDigitStr = _expressions.TenToTwentyDict[secondDigit * 10 + thirdDigit];
            }
            else
            {
                secondDigitStr = _expressions.TensDict[secondDigit*10]; //tens number
                thirdDigitStr = _expressions.OnesDict[thirdDigit]; //unity number
            }
            string strNumber = firstDigitStr + secondDigitStr +  thirdDigitStr + 
                _expressions.MultiplerTensBaseAccordingToPlace[typeTens]; //full 
            return strNumber;
        }

        public static int SumLetters(ulong number)
        {
            NumericalExpression numericalExpression = new NumericalExpression(number);
            int count = numericalExpression.GetValue().Trim().Length;
            if (number > 0)
                return count + SumLetters(number - 1);
            return count;
        }

    }
}
