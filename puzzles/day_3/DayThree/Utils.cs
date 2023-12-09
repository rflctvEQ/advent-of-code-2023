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

  private static bool CheckCurrentRow (KeyValuePair<int, string> numObj, string current)
  {
    bool specialFound = false;

    // check char before number idx
    if (numObj.Key - 1 >= 0)
    {
      // if neighbor char before is special
      if (current[numObj.Key - 1] != '.' && !char.IsDigit(current[numObj.Key - 1]))
      {
        // Console.WriteLine("special in neighbor before idx");
        specialFound = true;
      }
    }

    // check char after number idx
    if (numObj.Key + numObj.Value.Length <= 139)
    {
      // if neighbor char after is special
      if (current[numObj.Key + numObj.Value.Length] != '.' && !char.IsDigit(current[numObj.Key + numObj.Value.Length]))
      {
        // Console.WriteLine("special in neighbor after idx");
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
}
