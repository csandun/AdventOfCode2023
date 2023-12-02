namespace AdventOfCode.Common;

public abstract class BaseDay
{
    protected static List<string> ReadFile(string fileName)
    {
        return File.ReadAllLines(Path.Combine("Inputs/2023", fileName)).ToList();
    }

    public abstract string Question01();

    public abstract string Question02();

}