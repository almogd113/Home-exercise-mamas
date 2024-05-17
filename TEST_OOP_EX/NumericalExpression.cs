using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercise
{
    class NumericalExpression
    {
        private long _number;
        private int _len;
        //private bool _isNegative;

        private Func<string> FullNumberWords;

        private Func<int, string> UnitysTranslator;
        private Func<int, string> TensTranslator;
        private Func<int, string> TenToTwentyTranslator;
        private Func<long, string> TensMultiplersByPositionInNumber;
        public string FullNumberExpression { get; private set; }
        public NumericalExpression(long number)
        {
            _number = number;
            _len = (int)(Math.Log10(number) + 1);
          //  _isNegative = isNegative;
            //default functions:
            this.FullNumberWords = this.ExpressNumber;

            //default functions - translators
            Expressions expressions = new Expressions();
            this.UnitysTranslator = expressions.UnitysTranslator;
            this.TensTranslator = expressions.TensTranslator;
            this.TenToTwentyTranslator = expressions.TenToTwentyTranslator;
            this.TensMultiplersByPositionInNumber = expressions.TensMultiplersByPositionInNumber;
        }
        public void SetFullNumberWords(Func<string> numberExpressWords)
        {
            this.FullNumberWords = numberExpressWords;
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
            long calcTypeTens = 1;
            for (int i = 0; i < typeTens; i++)
            {
                calcTypeTens *= 10; //calc the max number in this type 
            }
            long numberProcess = _number;

            if (numberProcess < 0)
                FullNumberExpression += "minus ";
            numberProcess = Math.Abs(numberProcess);
            //run on every trio, express the number and determine which type of number by position in full number
            for (long i = calcTypeTens; i >= 1; i /= 1000)
            {
                long num = numberProcess;
                if (i >= 1000) //trio calc
                {
                    num = numberProcess / i; //three digit number
                }
                if (i == 100)
                    i = 1;
                string numString = GetValueMatchThreeDigitsPattern(num, i);
                FullNumberExpression += numString;
                numberProcess %= i; //moving to the next trio
            }
            return FullNumberExpression;
        }
        public override string ToString()
        {
            return FullNumberWords();
        }
        public long GetValue()
        {
            return _number;
        }
        private string GetValueMatchThreeDigitsPattern(long numberThreeDigits, long typeTens)
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

            long  hundrends = 100;
            Expressions expressions = new Expressions();

            if (firstDigit != 0)
            {
                firstDigitStr = this.UnitysTranslator(firstDigit) + this.TensMultiplersByPositionInNumber(hundrends);
                //firstDigitStr = expressions.OnesDict[firstDigit] + expressions.MultiplerTensBaseAccordingToPlace[100];
            }

            //in case there is unity
            if (secondDigit == 1 && thirdDigit != 0) //that means there are no tens
            {
                secondDigitStr = this.TenToTwentyTranslator(secondDigit * 10 + thirdDigit);
                //secondDigitStr = expressions.TenToTwentyDict[secondDigit * 10 + thirdDigit];
            }
            else
            {
                secondDigitStr =TensTranslator(secondDigit * 10); //tens number
                thirdDigitStr = UnitysTranslator(thirdDigit); //unity number
            }
            string strNumber = firstDigitStr + secondDigitStr + thirdDigitStr +
                               this.TensMultiplersByPositionInNumber(typeTens); //full 
            return strNumber;
        }
        public static int SumLetters(long number)
        {
            NumericalExpression numericalExpression = new NumericalExpression(number);
            string expressedNumber = numericalExpression.ToString().Replace(" ", "");
            int count = expressedNumber.Length;
            if (number > 0)
                return count + SumLetters(number - 1);
            return count;
        }

        //overloading  - allows a class to have multiple methods with the same name but different parameters
        //here, we have two methods that do the same thing but has different parameters.
        public static int SumLetters(NumericalExpression numericalExpression)
        {
            string expressedNumber = numericalExpression.ToString().Replace(" ", "");
            int count = expressedNumber.Length;
            if (numericalExpression.GetValue() > 0)
                return count + SumLetters(new NumericalExpression(numericalExpression.GetValue() - 1));
            return count;
        }

    }
}
