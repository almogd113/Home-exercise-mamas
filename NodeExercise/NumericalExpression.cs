using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    public class NumericalExpression
    {
        private ulong _number;
        private int _len;
        public string FullNumberExpression{ get; private set; }
        public NumericalExpression(ulong number)
        {
            _number = number;
            _len = (int)(Math.Log10(number) + 1);
        }
        public string GetValue()
        {

            //long numberToProcess = _number;
            //int baseToTenMultyplers = _len;
            //while (baseToTenMultyplers % 3 != 1)
            //    baseToTenMultyplers++;
            //int maxBase = (int)Math.Pow(10, baseToTenMultyplers - 1);

            //for (int i = maxBase; i >= 1; i /= 1000)
            //{
            //    int num = (int)numberToProcess;
            //    //if (i < 1000)
            //    //{
            //    //    num = (int)numberToProcess % i; // for cases houndrands only
            //    //}
            //    if (i >= 1000)
            //    {
            //        num = (int)numberToProcess / i; //three digit number
            //    }
            //    string numString = GetValueMatchThreeDigitsPattern(num, i);
            //    numberToProcess %= i;
            //    FullNumberExpression += numString;
            //}

            //return FullNumberExpression;

            //int numberInTens = (int)Math.Pow(10, _len - 1);
            int typeTens = _len;
            if (_len > 6) //not hundrends
            {
                while (typeTens % 3 != 0)
                    typeTens--;
            }
            if (_len <= 6 &&  _len >= 4)
            {
                typeTens = 4;
            }
            //long calcTypeTens = (int)Math.Pow(10, typeTens - 1);
            ulong calcTypeTens = 1;
            for (int i = 0; i < typeTens; i++)
            {
                calcTypeTens *= 10;
            }
            ulong numberProcess = _number;

            for (ulong i = calcTypeTens; i >=1; i /= 1000)
            {
                ulong num =numberProcess;
                //if (i < 1000)
                //{
                //    num = (int)numberProcess % i; // for cases houndrands only
                //}
                if (i >= 1000)
                {
                    num = numberProcess / i; //three digit number
                }
                string numString = GetValueMatchThreeDigitsPattern(num, i);
                FullNumberExpression += numString;
                numberProcess %= i;
            }
            return FullNumberExpression;


        }

        private string GetValueMatchThreeDigitsPattern(ulong numberThreeDigits, ulong typeTens)
        {
            int firstDigit = (int)numberThreeDigits / 100;
            int secondDigit = (int) numberThreeDigits % 100 / 10;
            int thirdDigit = (int)numberThreeDigits % 10;

            if (firstDigit == 0 &&
                secondDigit == 0 &&
                thirdDigit == 0)
                return "";

            string strNumber = "";
            string firstDigitStr = "";
            string secondDigitStr = "";
            string thirdDigitStr = "";

            
            Expressions expressions = new Expressions();
            if (firstDigit != 0)
            {
                firstDigitStr = expressions.OnesDict[firstDigit] + expressions.MultiplerTensBaseAccordingToPlace[100];
            }

            //in case there is unity
            if (secondDigit == 1 && thirdDigit != 0) //that means there is no tens
            {
                secondDigitStr = expressions.TenToTwentyDict[secondDigit * 10 + thirdDigit];
            }
            else
            {
                secondDigitStr = expressions.TensDict[secondDigit*10];
                thirdDigitStr = expressions.OnesDict[thirdDigit];
            }

            
            strNumber = firstDigitStr + secondDigitStr +  thirdDigitStr + expressions.MultiplerTensBaseAccordingToPlace[typeTens];
            return strNumber;

        }

    }
}
