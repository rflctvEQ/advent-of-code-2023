class Utils {
  private static string GetFirstFullNumber (string input)
  {
    return string.Concat(input.SkipWhile(c => !char.IsDigit(c))
        .TakeWhile(c => char.IsDigit(c)));
  }

  public static List<object> GetNumbers (string input) {
    List<object> numbers = new List<object>();

    int index = 0;
    while (index < input.Length)
    {
        // Skip non-digit characters
        while (index < input.Length && !char.IsDigit(input[index]))
        {
            index++;
        }

        if (index < input.Length)
        {
            // Find the first full number
            string numStr = GetFirstFullNumber(input.Substring(index));
            int indexOfFirstNumber = input.IndexOf(numStr, index);

            // Create obj to store number and its location in the original input string
            var numObj = new Dictionary<int, string>
            {
                { indexOfFirstNumber, numStr }
            };

            // Store number in the return variable
            numbers.Add(numObj);

            // Move the index beyond the current number
            index = indexOfFirstNumber + numStr.Length;
        }
    }

    return numbers;
  }

// return true if char special
  private static bool CheckCurrentRow (KeyValuePair<int, string> numObj, string current)
  {
    bool specialFound = false;

    // check char before number idx
    if (numObj.Key - 1 >= 0)
    {
      // if neighbor char before is special
      if (current[numObj.Key - 1] != '.' && !char.IsDigit(current[numObj.Key - 1]))
      {
        specialFound = true;
      }
    }

    // check char after number idx
    if (numObj.Key + numObj.Value.Length <= 139)
    {
      // if neighbor char after is special
      if (current[numObj.Key + numObj.Value.Length] != '.' && !char.IsDigit(current[numObj.Key + numObj.Value.Length]))
      {
        specialFound = true;
      }
    }


    return specialFound;
  }

  private static bool CheckNeighborRow (KeyValuePair<int, string> numObj, string neighbor)
  {
    bool specialFound = false;

    // check neighbor char before number idx
    if (numObj.Key - 1 >= 0)
    {
      // if neighbor char before is special
      if (neighbor[numObj.Key - 1] != '.' && !char.IsDigit(neighbor[numObj.Key - 1]))
      {
        // Console.WriteLine("special in neighbor before idx");
        specialFound = true;
      }
    }

    // check neighbor char after number idx
    if (numObj.Key + numObj.Value.Length <= 139)
    {
      // if neighbor char after is special
      if (neighbor[numObj.Key + numObj.Value.Length] != '.' && !char.IsDigit(neighbor[numObj.Key + numObj.Value.Length]))
      {
        // Console.WriteLine("special in neighbor after idx");
        specialFound = true;
      }
    }

    for (int i = numObj.Key; i < numObj.Key + numObj.Value.Length; i++)
    {
      if (neighbor[i] != '.' && !char.IsDigit(neighbor[i]))
      {
        // Console.WriteLine("special in neighbor somewhere within idx range");
        specialFound = true;
      }
    }

    return specialFound;
  }

  public static int? CheckWhetherNumberTouches (KeyValuePair<int, string> numObj, int idx, string current, string? prev, string? next)
  {
    bool currentRowHasSpecial = CheckCurrentRow(numObj, current);
    bool prevRowHasSpecial = false;
    bool nextRowHasSpecial = false;

    if (prev != null) {
      // Console.WriteLine("checking prev");
      prevRowHasSpecial = CheckNeighborRow(numObj, prev);
    }

    if (next != null) {
      // Console.WriteLine("checking next");
      nextRowHasSpecial = CheckNeighborRow(numObj, next);
    }

    if (currentRowHasSpecial || prevRowHasSpecial || nextRowHasSpecial)
    {
      return int.Parse(numObj.Value);
    } else {
      return 0;
    }
  }


  public static List<int> GetAsteriskIndexes (string input)
  {
    List<int> asterisks = new List<int>();

    int index = 0;
    while (index < input.Length)
    {
      while (index < input.Length && input[index] != '*')
      {
        index ++;
      }

      if (index < input.Length)
      {
        if (input[index] == '*') {
          asterisks.Add(index);
        }

        index++;
      }
    }

    return asterisks;
  }

  public static int CheckForGears (int idx, string current, string? prev, string? next)
  {
    List<int> touchingNumbers = new List<int>();

    // check current row to see if there's a number on either side
    List<object> currentRowNumbers = GetNumbers(current);

    foreach (Dictionary<int, string> num in currentRowNumbers)
    {
      foreach(var kvp in num)
      {
      if (kvp.Key + (kvp.Value.Length - 1) == idx - 1 || kvp.Key == idx + 1)
      {
        touchingNumbers.Add(int.Parse(kvp.Value));
      }
      }
    }

    if (prev != null)
    {
      List<object> prevRowNumbers = GetNumbers(prev);

      foreach (Dictionary<int, string> num in prevRowNumbers)
      {
        foreach (var kvp in num)
        {
          if (kvp.Key + (kvp.Value.Length - 1) >= idx - 1 && kvp.Key <= idx + 1)
          {
            touchingNumbers.Add(int.Parse(kvp.Value));
          }
        }
      }
    }

    if (next != null)
    {
      List<object> nextRowNumbers = GetNumbers(next);

      foreach (Dictionary<int, string> num in nextRowNumbers)
      {
        foreach (var kvp in num)
        {
          if (kvp.Key + (kvp.Value.Length - 1) >= idx - 1 && kvp.Key <= idx + 1)
          {
            touchingNumbers.Add(int.Parse(kvp.Value));
          }
        }
      }
    }


    if (touchingNumbers.Count == 2)
    {
     return touchingNumbers[0] * touchingNumbers[1];
    }
    else
    {
     return 0;
    }
  }
}
