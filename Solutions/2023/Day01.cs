using AdventOfCode.Common;

namespace AdventOfCode.Solutions._2023;

public class Day01: BaseDay
{
    public override string Question01()
    {
        var file =  nameof(Day01) + "_01.txt";
        var inputValues = ReadFile(file);
        return GetTotal(inputValues);
    }

    private static string GetTotal(List<string> inputValues)
    {
        var total = inputValues.Sum(GetLineDigit);
        return total.ToString();
    }

    // result - 55017
    private static int GetLineDigit(string line)
    {
        var numberList = new List<int>();
        foreach (var digit in line)
        {
            var isNumber = char.IsNumber(digit);
            if (isNumber) numberList.Add( Convert.ToInt32(digit.ToString()));
        }

        var lineValue = numberList.First().ToString() + numberList.Last().ToString();
        return Convert.ToInt32(lineValue);
    }
    
    // result 53539
    public override string Question02()
    {
        var file =  nameof(Day01) + "_01.txt";
        var inputValues = ReadFile(file);

        var convertedFirstNumberLines = ReplaceFirstNumbers(inputValues);
        var convertedLastNumberLines = ReplaceLastNumbers(convertedFirstNumberLines);
        
        return GetTotal(convertedLastNumberLines);
    }

    private List<string> ReplaceFirstNumbers(List<string> inputValues)
    {
        var convertedValues = new List<string>();
        foreach (var line in inputValues)
        {
            var convertedString = string.Empty;
            for (var i = 0; i < line.Length; i++)
            {
                var a = line[..i];
                 (var isNumberString, convertedString) = IsNumberString(a);
                convertedString += line[i..];
                if (isNumberString)
                {
                    break;
                }
            }
            
            convertedValues.Add(convertedString);
        }

        return convertedValues;
    }
    
    private List<string> ReplaceLastNumbers(List<string> inputValues)
    {
        var convertedValues = new List<string>();
        foreach (var line in inputValues)
        {
            var convertedString = string.Empty;
            for (var i = line.Length -1 ; i >= 0 ; i--)
            {
                var a = line[i..];
                (var isNumberString, convertedString) = IsNumberString(a);
                convertedString = line[..i] + convertedString;
                if (isNumberString)
                {
                    break;
                }
            }
            
            convertedValues.Add(convertedString);
        }

        return convertedValues;
    }

    private (bool, string) IsNumberString(string substring)
    {
        var numbersInString = new Dictionary<string, string>
        {
            { "one", "o1e" }, 
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };
        
        foreach (var key in numbersInString.Keys)
        {
            if (substring.Contains(key))
            {
                return (true, substring.Replace(key, numbersInString[key]));
            }
        }

        return (false, substring);
    }
}