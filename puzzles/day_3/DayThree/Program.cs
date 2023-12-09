string[] lines = Input.InputStr.Split(
  new string[] { Environment.NewLine },
  StringSplitOptions.None
);

// Part 1
long? total = 0;

for (int i = 0; i < lines.Length; i++)
{
  List<Object> numbers = Utils.GetNumbers(lines[i]);

  foreach (var item in numbers)
  {
    if (item is Dictionary<int, string> numObj)
    {
      foreach (var pair in numObj)
      {
        // check whether number touches special character (and identify whether line of numbers is first, last, or middle)
        int? number = -1;
        if (i != 0 && i != (lines.Length - 1))
        {
          number = Utils.CheckWhetherNumberTouches(pair, i, lines[i], lines[i - 1], lines[i + 1]);
        }
        else if (i == 0)
        {
          number = Utils.CheckWhetherNumberTouches(pair, i, lines[i], null, lines[i + 1]);
        }
        else if (i == (lines.Length - 1))
        {
          number = Utils.CheckWhetherNumberTouches(pair, i, lines[i], lines[i - 1], null);
        }

        // if number, add to total
        if (number != 0)
        {
          Console.WriteLine($"Number {pair.Value} is special!");
          total += number;
        }
        else
        {
          Console.WriteLine($"Number {pair.Value} is NOT special! :(");
        }
      }
    }
  }
}

Console.WriteLine($"Part 1 total: {total}");

// part 2
total = 0;

for (int i = 0; i < lines.Length; i++){
  List<int> indexes = Utils.GetAsteriskIndexes(lines[i]);

  foreach (int idx in indexes)
  {
    
  }
}
