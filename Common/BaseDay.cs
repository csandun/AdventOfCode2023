namespace AdventOfCode.Solutions;

public class BaseDay
{
    protected List<string> ReadFile(string fileName)
    {
        return File.ReadAllLines(Path.Combine("Inputs/2023", fileName)).ToList();
    }
}