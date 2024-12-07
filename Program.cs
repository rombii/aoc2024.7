using var inputReader = new StreamReader(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
int[] members;
long answer = 0;
while (!inputReader.EndOfStream)
{
    var line = await inputReader.ReadLineAsync();
    if (line != null)
    {
        var result = long.Parse(line.Split(':')[0]);
        members = line.Split(':')[1].Split(' ').Skip(1).Select(int.Parse).ToArray(); //Skip 1 to skip first empty string
        answer = IsResultPossible(result, members[0]) ? answer + result : answer;
    }
}

Console.WriteLine(answer);
return;

bool IsResultPossible(long expectedResult, long previousResult, int pointer = 1)
{
    if (pointer >= members.Length) return previousResult == expectedResult;
    return IsResultPossible(expectedResult, previousResult * members[pointer], pointer + 1) ||
           IsResultPossible(expectedResult, previousResult + members[pointer], pointer + 1) ||
           IsResultPossible(expectedResult, long.Parse(previousResult.ToString() + members[pointer]), pointer + 1);
}
