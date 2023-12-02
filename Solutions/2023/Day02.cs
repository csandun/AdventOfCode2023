using AdventOfCode.Common;

namespace AdventOfCode.Solutions._2023;

public class Day02: BaseDay
{
    
    // result 2685
    public override string Question01()
    {
        var file =  nameof(Day02) + "_01.txt";
        var inputValues = ReadFile(file);

        var games = GetGameSetValues(inputValues);

        var total = games.Keys.Where(gameKey => games[gameKey].All(o => o.IsPossible)).Sum();

        return total.ToString();
    }

    public Dictionary<int, List<CubeSet>> GetGameSetValues(List<string> inputLines)
    {
        var games = new Dictionary<int, List<CubeSet>>();
        int i = 1;
        foreach (var line in inputLines)
        {
            var first = line.Split(":");
            var gameNumber = first[0];
            var sets = first[1].Split(";");
            var gameSet = new List<CubeSet>();
            foreach (var set in sets)
            {
                var cubeSet = new CubeSet();
                var cubeFormations = set.Split(",");
                foreach (var cubeFormation in cubeFormations)
                {
                    if (cubeFormation.Contains("blue"))
                    {
                        cubeSet.Blue = int.Parse(cubeFormation.Trim().Split(" ")[0].Trim());
                    }
                    
                    if (cubeFormation.Contains("green"))
                    {
                        cubeSet.Green = int.Parse(cubeFormation.Trim().Split(" ")[0].Trim());
                    }

                    if (cubeFormation.Contains("red"))
                    {
                        cubeSet.Red = int.Parse(cubeFormation.Trim().Split(" ")[0].Trim());
                    }
                }
                
                gameSet.Add(cubeSet);
            }

            games.Add(i, gameSet);
            i += 1;
        }

        return games;
    }
    
    
    // result 83707
    public override string Question02()
    {
        var file =  nameof(Day02) + "_01.txt";
        var inputValues = ReadFile(file);

        var games = GetGameSetValues(inputValues);
        var totalOfPower = 0;
        foreach (var game in games)
        {
            var maxBlue = game.Value.MaxBy(o => o.Blue)!.Blue;
            var maxGreen = game.Value.MaxBy(o => o.Green)!.Green;
            var maxRed = game.Value.MaxBy(o => o.Red)!.Red;
            var totalOfPowerOfGame = maxBlue * maxGreen * maxRed;
            totalOfPower += totalOfPowerOfGame;
        }

        return totalOfPower.ToString();
    }
}


public class CubeSet
{
    public int Blue { get; set; } = 0;
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;

    public bool IsPossible => Blue <= 14 && Red <= 12 && Green <= 13;

}