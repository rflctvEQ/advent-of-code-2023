string[] lines = Input.InputStr.Split(
  new string[] { Environment.NewLine },
  StringSplitOptions.None
);

// part 1
int total = 0;

for (int i = 0; i < lines.Length; i++)
{
  string line = lines[i];
  string numbersStr = new(line.Where(char.IsDigit).ToArray());

  string firstAndLast = new(numbersStr.Substring(0, 1) + numbersStr.Substring(numbersStr.Length - 1, 1));
  total += int.Parse(firstAndLast);
}

// Answer to part 1: 55386
Console.WriteLine($"Part 1 total: {total}");

// part 2
total = 0;

for (int i = 0; i < lines.Length; i++) {
  string line = lines[i];

  string firstNumber = Utils.GetFirstNumber(line);
  string lastNumber = Utils.GetLastNumber(line);

  string firstAndLast = new(firstNumber + lastNumber);

  total += int.Parse(firstAndLast);
}

// Answer to part 2: 54824
Console.WriteLine($"Part 2 total: {total}");

