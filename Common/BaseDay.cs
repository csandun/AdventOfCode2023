namespace AdventOfCode.Common;

public class BaseDay
{
    protected static List<string> ReadFile(string fileName)
    {
        return File.ReadAllLines(Path.Combine("Inputs/2023", fileName)).ToList();
    }
}