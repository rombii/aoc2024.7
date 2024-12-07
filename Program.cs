using var inputReader = new StreamReader(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
int[] members;
long part1Answer = 0, part2Answer = 0;
while (!inputReader.EndOfStream)
{
    var line = await inputReader.ReadLineAsync();
    if (line != null)
    {
        var result = long.Parse(line.Split(':')[0]);
        members = line.Split(':')[1].Split(' ').Skip(1).Select(int.Parse).ToArray(); //Skip 1 to skip first empty string
        part1Answer = IsResultPossible(result, members[0]) ? part1Answer + result : part1Answer;
        part2Answer = IsResultPossibleWithConc(result, members[0]) ? part2Answer + result : part2Answer;
    }
}

Console.WriteLine($"First part: {part1Answer}");
Console.WriteLine($"Second part: {part2Answer}");
return;

bool IsResultPossible(long expectedResult, long previousResult, int pointer = 1)
{
    if (pointer >= members.Length) return previousResult == expectedResult;
    return IsResultPossible(expectedResult, previousResult * members[pointer], pointer + 1) ||
           IsResultPossible(expectedResult, previousResult + members[pointer], pointer + 1);
}

bool IsResultPossibleWithConc(long expectedResult, long previousResult, int pointer = 1)
{
    if (pointer >= members.Length) return previousResult == expectedResult;
    return IsResultPossibleWithConc(expectedResult, previousResult * members[pointer], pointer + 1) ||
           IsResultPossibleWithConc(expectedResult, previousResult + members[pointer], pointer + 1) ||
           IsResultPossibleWithConc(expectedResult, long.Parse(previousResult.ToString() + members[pointer]), pointer + 1);
}
