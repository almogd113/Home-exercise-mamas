using System;
using System.Collections.Generic;
using System.Text;

namespace NodeExercise
{
    class Expressions
    {
        public Dictionary<int, string> OnesDict { get; private set; } // 0-9
        public Dictionary<int, string> TensDict { get; private set; } //10-100 
        public Dictionary<int, string> TenToTwentyDict { get; private set; } // 11-19

        public Dictionary<ulong, string> MultiplerTensBaseAccordingToPlace { get; private set; } //houndrends, thousends....
        public Expressions()
        {
            OnesDict = new Dictionary<int, string>();
            OnesDict.Add(0, "");
            OnesDict.Add(1, "One ");
            OnesDict.Add(2, "Two ");
            OnesDict.Add(3, "Three ");
            OnesDict.Add(4, "Four ");
            OnesDict.Add(5, "Five ");
            OnesDict.Add(6, "Six ");
            OnesDict.Add(7, "Seven ");
            OnesDict.Add(8, "Eight ");
            OnesDict.Add(9, "Nine ");

            TensDict = new Dictionary<int, string>();
            TensDict.Add(0, "");
            TensDict.Add(10, "Ten ");
            TensDict.Add(20, "Twenty ");
            TensDict.Add(30, "Thirty ");
            TensDict.Add(40, "Forty ");
            TensDict.Add(50, "Fifty ");
            TensDict.Add(60, "Sixty ");
            TensDict.Add(70, "Seventy ");
            TensDict.Add(80, "Eighty ");
            TensDict.Add(90, "Ninety ");

            TenToTwentyDict = new Dictionary<int, string>();
            TenToTwentyDict.Add(11, "Eleven ");
            TenToTwentyDict.Add(12, "Twelve ");
            TenToTwentyDict.Add(13, "Thirteen ");
            TenToTwentyDict.Add(14, "Fourteen ");
            TenToTwentyDict.Add(15, "Fifteen ");
            TenToTwentyDict.Add(16, "Sixteen ");
            TenToTwentyDict.Add(17, "Seventeen ");
            TenToTwentyDict.Add(18, "Eighteen ");
            TenToTwentyDict.Add(19, "Nineteen ");

            MultiplerTensBaseAccordingToPlace = new Dictionary<ulong, string>();
            MultiplerTensBaseAccordingToPlace.Add(1, "");
            MultiplerTensBaseAccordingToPlace.Add(10, "");
            MultiplerTensBaseAccordingToPlace.Add(100, "Hundreds ");
            MultiplerTensBaseAccordingToPlace.Add(1000, "thousands ");
            MultiplerTensBaseAccordingToPlace.Add(1000000, "millions ");
            MultiplerTensBaseAccordingToPlace.Add(1000000000, "miliards ");
            MultiplerTensBaseAccordingToPlace.Add(1000000000000, "billions ");
            MultiplerTensBaseAccordingToPlace.Add(1000000000000000, "biliards ");
            MultiplerTensBaseAccordingToPlace.Add(1000000000000000000, "trillions ");
        }
    }
}
