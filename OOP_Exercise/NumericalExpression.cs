using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercise
{
    class NumericalExpression
    {
        private ulong _number;
        private int _len;
        public string FullNumberExpression { get; private set; }
        public NumericalExpression(ulong number)
        {
            _number = number;
            _len = (int)(Math.Log10(number) + 1);
        }
        public string ExpressNumber()
        {
            int typeTens = _len;
            if (_len > 6) //not hundrends
            {
                while (typeTens % 3 != 0)
                    typeTens--; //find the type of the trio by position in number
            }
            if (_len <= 6 && _len >= 4)
            {
                typeTens = 4; //thousands
            }
            //long calcTypeTens = (int)Math.Pow(10, typeTens - 1);
            ulong calcTypeTens = 1;
            for (int i = 0; i < typeTens; i++)
            {
                calcTypeTens *= 10; //calc the max number in this type 
            }
            ulong numberProcess = _number;


            //run on every trio, express the number and determine which type of number by position in full number
            for (ulong i = calcTypeTens; i >= 1; i /= 1000)
            {
                ulong num = numberProcess;
                if (i >= 1000) //trio calc
                {
                    num = numberProcess / i; //three digit number
                }
                string numString = GetValueMatchThreeDigitsPattern(num, i);
                FullNumberExpression += numString;
                numberProcess %= i; //moving to the next trio
            }
            return FullNumberExpression;
        }

        //public string GetValue()
        //{
        //   return ToString();
        //}
    
        public override string ToString()
        {
            return ExpressNumber();
        }
        public string GetValue()
        {
            return this.ToString();
        }
        private string GetValueMatchThreeDigitsPattern(ulong numberThreeDigits, ulong typeTens)
        {
            //calc digits
            int firstDigit = (int)numberThreeDigits / 100;
            int secondDigit = (int)numberThreeDigits % 100 / 10;
            int thirdDigit = (int)numberThreeDigits % 10;

            if (firstDigit == 0 &&
                secondDigit == 0 &&
                thirdDigit == 0)
                return "";

            string firstDigitStr = "";
            string secondDigitStr = "";
            string thirdDigitStr = "";

            Expressions expressions = new Expressions();

            if (firstDigit != 0)
            {
                firstDigitStr = expressions.OnesDict[firstDigit] + expressions.MultiplerTensBaseAccordingToPlace[100];
            }

            //in case there is unity
            if (secondDigit == 1 && thirdDigit != 0) //that means there are no tens
            {
                secondDigitStr = expressions.TenToTwentyDict[secondDigit * 10 + thirdDigit];
            }
            else
            {
                secondDigitStr = expressions.TensDict[secondDigit * 10]; //tens number
                thirdDigitStr = expressions.OnesDict[thirdDigit]; //unity number
            }
            string strNumber = firstDigitStr + secondDigitStr + thirdDigitStr +
                                expressions.MultiplerTensBaseAccordingToPlace[typeTens]; //full 
            return strNumber;
        }
    }
}
