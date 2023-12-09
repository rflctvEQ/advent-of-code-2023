class Utils {
  private static Dictionary<string, int> gameConstraints = new Dictionary<string, int>
  {
    {"red", 12},
    {"green", 13},
    {"blue", 14}
  };

  private static int GetQuantity (string input)
  {
    return int.Parse(
      input.SkipWhile(c => !char.IsDigit(c))
        .TakeWhile(c => char.IsDigit(c))
        .ToArray()
    );
  }

  public static bool CheckSets(string[] sets)
  {
    // default true; set to false only if some quantity exceeds constraints
    bool passesConstraints = true;

   foreach (string set in sets)
   {
    string[] results = set.Split(",");

    // foreach result, check if it contains key in dictionary and compare to see if number is greater than value in dictionary
    foreach (string result in results)
    {
      int quantity = GetQuantity(result);

      // fail game if result quantity exceeds constraint in dictionary
      foreach (var kvp in gameConstraints)
      {
        if (result.Contains(kvp.Key)) {
          if (quantity > kvp.Value)
          {
            passesConstraints = false;
          }
        }
      }
    }
   }

   return passesConstraints;
  }

  public static int GetPower(string[] sets)
  {
    List<int> redValues = [];
    List<int> greenValues = [];
    List<int> blueValues = [];

    foreach (string set in sets)
    {
      string[] results = set.Split(",");

      foreach (string result in results)
      {
        int quantity = GetQuantity(result);

        if (result.Contains("red"))
        {
          redValues.Add(quantity);
        }
        else if (result.Contains("green"))
        {
          greenValues.Add(quantity);
        }
        else
        {
          blueValues.Add(quantity);
        }
      }
    }

    return redValues.Max() * greenValues.Max() * blueValues.Max();
  }
}