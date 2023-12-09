string[] games = Input.InputStr.Split(
  new string[] { Environment.NewLine },
  StringSplitOptions.None
);

// part 1
int total = 0;

for (int i = 0; i < games.Length; i++)
{
  int id = i + 1;

  string setsStr = games[i].Split(":")[1];
  string[] sets = setsStr.Split(";");

  // check if all sets pass
  bool setsPassConstraints = Utils.CheckSets(sets);

  // if all sets pass, add id to total
  if (setsPassConstraints) {
    total += id;
  }
}

Console.WriteLine($"Part 1 total: {total}");

// part 2
total = 0;

for (int i = 0; i < games.Length; i++)
{
  string setsStr = games[i].Split(":")[1];
  string[] sets = setsStr.Split(";");

  int power = Utils.GetPower(sets);
  
  total += power;
}

Console.WriteLine($"Part 2 total: {total}");
