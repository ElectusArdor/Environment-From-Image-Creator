using System;

public static class Tests
{
    static string[,] strings = new string[2, 5];

    public static void Main()
    {
        for (int i = 0; i < strings.GetLength(0); i++)
        {
            for(int j = 0; j < strings.GetLength(1); j++)
            {
                strings[i, j] = "1";
            }
        }
    }
}
