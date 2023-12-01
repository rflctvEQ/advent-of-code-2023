class Utils {
  private static Dictionary<string, int> wordToNumberMap = new Dictionary<string, int>
  {
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
  };

  static int? FindSpelledInteger(string input, Dictionary<string, int> wordToNumberMap)
  {
    foreach (var kvp in wordToNumberMap)
    {
      if (input.Contains(kvp.Key))
      {
        return kvp.Value;
      }
    }

    return null;
  }

  public static string GetFirstNumber(string input)
  {
    string first = "";

    foreach (char c in input ) {
      first = new string(first + c);

      if (first.Any(char.IsDigit))
      {
        first = new string(first.Where(char.IsDigit).ToArray());
        break;
      }
      else
      {
        int? res = FindSpelledInteger(first, wordToNumberMap);

        if (res.HasValue && res != null)
        {
          first = res.Value.ToString();
          break;
        }
      }
    }

    return first;
  }

  public static string GetLastNumber(string input)
  {
    string last = "";

    foreach (char c in input.Reverse())
    {
      last = new string(last + c);

      if (last.Any(char.IsDigit))
      {
        last = new string(last.Where(char.IsDigit).ToArray());
        break;
      }
      else
      {
        int? res = FindSpelledInteger(last, wordToNumberMap);

        if (res.HasValue && res != null)
        {
          last = res.Value.ToString();
          break;
        }
      }
    }

    return last;
  }
}