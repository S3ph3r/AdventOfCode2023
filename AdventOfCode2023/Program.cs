using System.Text.RegularExpressions;

AoC3();
Console.ReadLine();

void AoC3()
{
    string input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
    string[] lines = input.Split("\r\n");
    char[,] chars = new char[lines.Length, lines[0].Length];
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            chars[i, j] = lines[i][j];
        }
    }

    int partNumberSum = 0;
    for (int i = 0; i < chars.GetLength(0); i++)
    {
        string number = "";
        bool isPartNumber = false;
        for (int j = 0; j < chars.GetLength(1); j++)
        {
            if (chars[i, j] >= 48 && chars[i, j] <= 57)
            {
                number += chars[i, j];
                isPartNumber = CheckPosition(chars, i, j);
            }
            else
            {
                if (isPartNumber)
                {
                    partNumberSum += int.Parse(number);
                }
                number = "";
                isPartNumber = false;
            }
        }
    }

    Console.WriteLine(partNumberSum);
}

bool CheckPosition(char[,] chars, int i, int j)
{
    if (IsSymbol(chars[Math.Max(0, i - 1), Math.Max(0, j - 1)]))
    {
        return true;
    }
    if (IsSymbol(chars[Math.Max(0, i - 1), j]))
    {
        return true;
    }
    if (IsSymbol(chars[Math.Max(0, i - 1), Math.Min(chars.GetLength(1), j + 1)]))
    {
        return true;
    }
    if (IsSymbol(chars[i, Math.Max(0, j - 1)]))
    {
        return true;
    }
    if (IsSymbol(chars[i, j]))
    {
        return true;
    }
    if (IsSymbol(chars[i, Math.Min(chars.GetLength(1), j + 1)]))
    {
        return true;
    }
    if (IsSymbol(chars[Math.Min(0, i + 1), Math.Max(0, j - 1)]))
    {
        return true;
    }
    if (IsSymbol(chars[Math.Min(0, i + 1), j]))
    {
        return true;
    }
    if (IsSymbol(chars[Math.Min(0, i + 1), Math.Min(chars.GetLength(1), j + 1)]))
    {
        return true;
    }
    return false;
}

bool IsSymbol(char character)
{
    return character != 46 && (character < 48 || character > 57);
}

void AoC2()
{
    string input = @"Game 1: 5 red, 1 green, 2 blue; 2 green, 8 blue, 6 red; 8 red, 3 blue, 2 green; 6 red, 1 green, 19 blue; 1 red, 17 blue
Game 2: 4 red, 5 green, 2 blue; 7 red, 14 green, 3 blue; 2 green, 5 blue, 11 red; 10 blue, 3 green; 9 green, 6 blue, 13 red; 7 red, 5 green, 9 blue
Game 3: 9 green, 18 blue, 1 red; 6 red, 10 blue, 5 green; 4 blue, 4 red, 15 green
Game 4: 1 red, 13 green; 10 green, 2 red; 3 red, 4 green, 2 blue
Game 5: 4 red, 2 green, 1 blue; 4 red, 9 blue; 4 green, 1 red, 6 blue; 3 blue, 2 green, 6 red; 5 red, 4 green, 1 blue
Game 6: 6 red, 3 green, 6 blue; 3 green, 5 blue, 12 red; 3 green, 9 blue, 3 red; 13 red, 8 blue
Game 7: 3 blue, 1 red; 3 blue, 10 green; 4 green, 5 blue
Game 8: 11 green, 4 blue; 4 red, 4 blue, 11 green; 4 green, 3 blue; 1 blue, 6 red, 12 green
Game 9: 1 blue, 4 green, 1 red; 5 green, 3 blue; 9 green, 4 blue; 3 blue, 1 red, 10 green; 6 green, 2 blue
Game 10: 5 green, 6 red, 7 blue; 7 green, 5 blue, 5 red; 8 red, 6 blue, 8 green; 2 blue, 8 green, 6 red; 6 blue, 8 red, 4 green
Game 11: 1 blue, 10 red, 10 green; 11 green, 2 blue, 16 red; 4 blue, 7 red, 14 green
Game 12: 8 green, 9 red, 12 blue; 2 green, 4 blue, 7 red; 1 red, 9 blue, 7 green; 8 green, 2 red, 10 blue; 1 green, 5 red, 5 blue; 6 green, 5 red, 1 blue
Game 13: 3 green, 1 blue, 6 red; 1 green, 10 red; 1 blue, 15 red, 2 green
Game 14: 2 green, 6 blue; 1 green, 2 blue, 2 red; 5 blue, 1 green, 2 red; 4 green, 5 blue, 4 red; 4 red, 5 green, 4 blue; 1 red, 5 green, 6 blue
Game 15: 12 green, 7 blue; 19 green; 11 blue, 16 green, 1 red; 1 red, 2 green, 3 blue; 8 blue, 1 red, 19 green; 14 blue, 3 green, 1 red
Game 16: 2 green, 13 blue, 3 red; 5 red, 12 blue; 6 blue, 8 red; 4 red, 1 green, 4 blue; 1 green, 15 blue; 4 blue, 2 green, 1 red
Game 17: 11 blue, 7 green, 2 red; 12 red, 8 green, 8 blue; 2 red, 6 blue, 6 green
Game 18: 1 green, 2 blue; 2 green, 1 blue, 4 red; 3 green, 16 red; 2 red, 3 green
Game 19: 11 blue, 3 green, 3 red; 11 blue, 5 green; 3 green, 3 red, 8 blue
Game 20: 1 green, 6 blue; 4 blue, 6 green; 1 red, 10 green; 12 green; 5 blue, 1 red, 4 green; 1 green, 5 blue
Game 21: 7 green, 3 blue; 1 red, 5 blue, 6 green; 1 red, 11 green; 8 blue, 1 red, 10 green; 1 red, 5 blue, 3 green
Game 22: 3 red, 1 blue; 3 green, 1 red, 1 blue; 7 green, 2 blue
Game 23: 12 green, 1 red, 2 blue; 10 blue, 1 green, 1 red; 9 blue, 8 green
Game 24: 5 blue, 6 green, 6 red; 3 blue, 1 red; 8 blue, 2 green, 12 red; 1 green, 2 blue, 14 red; 2 blue, 5 green, 15 red
Game 25: 6 red, 13 green; 1 blue, 1 red, 3 green; 1 blue, 12 red, 10 green
Game 26: 16 red, 2 blue, 7 green; 1 blue, 7 green, 8 red; 1 blue, 3 red, 9 green
Game 27: 4 blue, 15 green; 6 green, 2 blue, 1 red; 9 blue, 10 green, 4 red; 3 red, 3 green, 6 blue; 11 blue, 7 red, 11 green; 6 red, 5 green, 13 blue
Game 28: 10 blue, 8 red, 10 green; 4 blue, 11 red, 6 green; 8 red, 9 green, 10 blue; 4 red, 9 green, 2 blue
Game 29: 4 red, 9 green, 7 blue; 10 blue, 6 green, 4 red; 1 green, 2 red, 10 blue; 3 green, 9 blue
Game 30: 6 blue, 9 green, 10 red; 6 blue, 4 red; 5 green, 2 blue; 5 green, 2 red, 2 blue; 6 blue, 8 green
Game 31: 7 blue; 2 green, 6 blue; 1 red, 9 blue, 5 green
Game 32: 8 blue, 2 red, 4 green; 6 red, 2 blue, 1 green; 14 blue, 8 green, 8 red
Game 33: 1 green, 1 red, 1 blue; 2 blue, 1 green, 12 red; 1 green, 1 red; 1 blue, 2 red, 1 green; 7 red, 2 green, 2 blue
Game 34: 3 blue; 2 blue; 10 red, 1 blue, 1 green; 5 red; 1 green, 1 red, 1 blue; 1 green, 2 red
Game 35: 10 green, 1 red, 16 blue; 4 red, 10 blue, 9 green; 1 green, 7 blue, 5 red
Game 36: 1 blue, 3 red, 16 green; 1 blue, 3 red, 1 green; 9 green, 3 red, 8 blue; 14 green, 6 blue, 3 red; 3 red, 12 green, 4 blue
Game 37: 11 red, 3 blue; 15 red, 8 blue, 6 green; 6 green, 19 red, 11 blue; 1 green, 4 blue, 14 red; 12 blue, 5 red, 8 green; 4 blue, 9 red
Game 38: 4 green, 10 blue, 3 red; 1 green, 1 red, 11 blue; 2 red, 12 blue
Game 39: 3 green, 1 red, 4 blue; 9 green, 1 red, 18 blue; 4 red, 4 green, 17 blue; 4 red, 10 blue, 14 green
Game 40: 5 red, 4 green, 8 blue; 1 green, 9 blue; 9 blue, 3 red, 6 green; 8 red, 9 blue, 9 green
Game 41: 1 blue, 9 red, 3 green; 9 red, 10 green, 15 blue; 13 red, 8 green, 8 blue; 19 red, 6 blue, 2 green; 7 green, 5 blue, 12 red
Game 42: 15 blue; 1 red, 1 green, 9 blue; 6 blue, 1 red; 1 green, 4 blue
Game 43: 1 green, 8 blue, 2 red; 1 red, 1 green, 6 blue; 7 blue; 7 blue, 3 red, 1 green; 2 red, 5 blue
Game 44: 7 green, 11 blue, 6 red; 9 green, 8 blue; 4 red, 15 green; 12 green, 14 blue, 8 red
Game 45: 4 red, 4 green; 14 green; 4 green, 2 blue; 1 blue, 12 red, 5 green; 3 red, 6 green; 11 red, 1 green
Game 46: 2 blue, 1 green, 1 red; 1 blue, 6 green, 1 red; 2 blue, 1 red, 1 green; 5 green
Game 47: 1 blue, 1 red; 14 red; 3 green, 2 blue, 17 red; 4 green
Game 48: 1 red, 11 green, 2 blue; 1 red, 11 green, 6 blue; 13 green, 1 blue, 3 red; 3 green, 4 red, 6 blue; 12 green, 5 blue, 1 red; 2 red, 4 green, 4 blue
Game 49: 5 blue, 3 green; 2 green, 8 blue; 5 blue; 4 green, 5 blue, 1 red; 4 green, 7 blue; 1 green, 3 blue
Game 50: 3 red, 5 green, 2 blue; 9 green, 7 red, 4 blue; 3 blue, 6 red, 13 green; 6 blue, 8 red, 9 green
Game 51: 2 green, 11 red, 7 blue; 5 blue, 13 red; 1 green, 2 blue, 3 red; 6 blue, 8 red; 11 red, 2 green, 4 blue
Game 52: 15 blue, 1 green, 4 red; 4 green, 10 blue, 2 red; 6 red, 18 blue, 1 green
Game 53: 2 red, 10 green, 6 blue; 4 green, 3 blue, 3 red; 17 blue, 19 green, 5 red; 6 blue, 6 green, 9 red; 5 blue, 17 green, 7 red
Game 54: 9 blue, 8 red, 6 green; 6 red, 8 green; 1 green, 6 blue, 1 red; 5 red, 4 green, 9 blue; 5 blue, 2 green, 5 red
Game 55: 8 blue, 8 red, 10 green; 3 red, 4 green, 9 blue; 4 red, 3 green, 7 blue
Game 56: 3 red, 6 green, 1 blue; 5 green, 1 blue, 1 red; 1 red, 2 green; 10 green
Game 57: 1 green, 4 blue, 12 red; 17 red, 7 blue, 10 green; 17 red, 5 blue, 3 green
Game 58: 1 red, 5 green, 14 blue; 5 green, 6 red, 7 blue; 4 blue, 8 green; 3 red, 9 green, 7 blue; 8 blue, 8 green, 6 red; 8 green, 7 blue, 5 red
Game 59: 3 green, 5 red; 2 red, 13 green, 1 blue; 19 green, 1 red, 1 blue; 19 green, 1 blue; 18 green, 1 blue, 5 red; 6 red, 9 green
Game 60: 5 red, 1 green, 6 blue; 8 red, 6 blue, 14 green; 8 green, 8 red, 3 blue; 2 blue, 5 green, 3 red; 4 blue, 1 red, 14 green
Game 61: 7 red, 4 blue, 2 green; 2 green, 8 red, 9 blue; 5 blue, 2 green, 8 red; 8 red, 1 green, 8 blue
Game 62: 6 red, 3 blue; 1 blue, 2 red, 2 green; 3 red, 1 blue
Game 63: 2 red, 1 blue, 2 green; 1 blue, 1 green; 2 green, 4 red; 3 green, 2 red; 2 green
Game 64: 5 green, 6 blue, 7 red; 2 red, 5 green, 8 blue; 7 green, 9 blue, 1 red; 4 green, 5 blue; 19 blue, 5 green, 13 red
Game 65: 3 red, 1 blue, 4 green; 5 green, 3 blue; 9 green, 1 red, 10 blue
Game 66: 6 red, 13 green, 2 blue; 2 blue, 5 red, 9 green; 18 red; 2 green, 1 blue, 1 red; 19 red, 10 green; 1 blue, 15 green, 13 red
Game 67: 8 blue, 3 red; 1 red, 12 green, 7 blue; 4 red, 6 blue, 5 green; 11 green, 10 blue, 7 red; 5 red, 9 green, 14 blue
Game 68: 1 red, 3 green; 10 blue, 1 red, 3 green; 1 green, 17 blue; 16 blue; 6 blue
Game 69: 11 green, 5 blue, 8 red; 2 red, 5 green, 1 blue; 10 green, 2 blue; 11 green, 7 red, 4 blue
Game 70: 2 green, 1 blue, 13 red; 16 green, 20 red, 4 blue; 10 red
Game 71: 10 blue, 6 green, 7 red; 5 red, 5 green, 2 blue; 7 green, 4 red, 5 blue; 1 red, 8 blue; 5 red, 1 blue, 8 green; 5 blue, 1 red, 5 green
Game 72: 2 red, 4 green; 2 green, 2 red, 1 blue; 3 blue, 3 green, 2 red; 2 green
Game 73: 5 red, 19 blue; 12 blue, 4 green, 16 red; 14 red, 11 blue, 1 green
Game 74: 2 red, 1 green, 9 blue; 5 blue, 1 green, 2 red; 2 green, 1 red, 13 blue; 2 green, 1 red, 3 blue
Game 75: 7 blue, 1 red, 18 green; 17 green, 8 red, 13 blue; 15 blue, 4 red
Game 76: 1 green, 12 red, 13 blue; 5 green, 11 blue, 12 red; 10 red, 1 green; 10 red, 2 blue; 5 red, 2 green; 2 green, 17 blue, 3 red
Game 77: 2 blue, 1 red, 1 green; 7 red; 7 red, 3 blue, 2 green; 10 green, 1 red; 3 red, 7 blue, 6 green
Game 78: 10 red, 2 blue, 2 green; 1 blue, 6 red, 4 green; 12 red, 8 green; 6 green, 8 red, 7 blue; 11 green, 5 blue, 6 red
Game 79: 7 green, 5 red; 6 blue, 2 green, 15 red; 9 blue, 2 red, 12 green; 1 blue, 4 red, 10 green; 4 blue, 12 green, 11 red; 5 green, 3 red, 5 blue
Game 80: 1 green, 13 blue, 2 red; 2 red, 1 green, 13 blue; 7 blue, 8 red
Game 81: 1 green, 2 red, 11 blue; 5 red, 3 blue; 1 green, 1 red; 14 red, 1 green
Game 82: 12 red, 3 blue, 8 green; 15 red, 9 blue, 8 green; 6 blue, 13 red, 8 green
Game 83: 4 blue, 6 green, 3 red; 7 red, 2 blue, 9 green; 6 green, 3 red
Game 84: 4 green; 3 red, 3 blue; 4 red, 1 blue, 2 green; 1 red, 5 green, 5 blue; 1 red, 5 blue, 3 green
Game 85: 3 red, 4 blue, 15 green; 9 green; 2 red, 4 blue, 6 green; 1 red, 4 green, 7 blue; 3 red, 10 green, 9 blue; 1 red, 13 green, 3 blue
Game 86: 8 red, 6 blue; 3 blue, 3 green, 15 red; 12 red, 6 green, 13 blue; 15 red, 6 green, 10 blue
Game 87: 4 red, 4 blue; 6 red, 2 blue; 5 blue, 3 green; 4 blue, 2 red
Game 88: 4 blue, 7 green; 2 blue, 7 green; 6 green, 4 blue; 1 red, 1 blue, 2 green; 11 green, 3 blue
Game 89: 1 blue, 12 green, 11 red; 3 red, 7 blue, 1 green; 7 green, 8 red; 6 blue, 2 green, 3 red; 7 red, 8 green; 11 blue, 5 red, 12 green
Game 90: 1 green, 12 red, 17 blue; 14 red, 17 blue, 9 green; 6 green, 9 red, 11 blue
Game 91: 3 green, 14 blue; 2 blue, 2 green, 6 red; 1 red, 11 blue, 1 green; 3 green, 4 red, 20 blue; 6 red, 2 green, 3 blue; 10 blue, 12 red
Game 92: 6 blue, 7 red; 2 blue, 4 red, 1 green; 4 red, 1 green, 3 blue; 2 red, 5 blue; 8 red, 6 blue; 1 green, 2 blue, 1 red
Game 93: 4 blue, 1 green, 4 red; 8 red, 4 green, 4 blue; 2 blue, 9 red; 1 blue, 4 red; 4 blue, 2 green, 11 red
Game 94: 5 blue, 1 green, 7 red; 1 green, 11 blue, 1 red; 1 green, 15 blue, 4 red
Game 95: 1 red, 3 blue; 1 red, 1 green, 8 blue; 3 red, 1 green, 3 blue; 3 red, 6 blue; 6 blue
Game 96: 4 green, 1 blue; 7 green, 3 red; 2 blue, 9 red, 16 green; 3 blue, 4 red, 11 green
Game 97: 6 green, 8 blue; 1 blue, 1 green; 3 green, 4 blue; 8 blue, 5 green, 2 red
Game 98: 18 blue, 6 green; 11 green, 3 blue, 7 red; 18 blue, 3 red, 7 green; 5 red, 5 green; 8 blue, 2 green, 11 red
Game 99: 3 red, 2 green, 3 blue; 1 red, 4 green, 1 blue; 2 green, 18 red; 15 red, 1 blue; 2 blue, 9 red, 2 green; 17 red, 3 blue, 4 green
Game 100: 9 blue, 8 red, 16 green; 3 red, 7 green, 8 blue; 1 green, 3 red, 12 blue; 3 green, 14 blue";
    string[] lines = input.Split("\r\n");
    int sum = 0;
    for(int i = 0; i < lines.Length; i++)
    {
        int reds = 0;
        int greens = 0;
        int blues = 0;
        string[] reveals = lines[i].Split(":")[1].Split(";");
        foreach(string reveal in reveals)
        {
            string[] colors = reveal.Split(",");
            foreach(string color in colors)
            {
                string[] colorInfo = color.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int number = int.Parse(colorInfo[0]);
                string colorName = colorInfo[1];
                switch (colorName)
                {
                    case "red":
                        if (number > reds)
                        {
                            reds = number;
                        }
                        break;
                    case "green":
                        if (number > greens)
                        {
                            greens = number;
                        }
                        break;
                    case "blue":
                        if (number > blues)
                        {
                            blues = number;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        sum += reds * greens * blues;
    }
    Console.WriteLine(sum);
}

void AoC1()
{
    string input = @"twovgtprdzcjjzkq3ffsbcblnpq
two8sixbmrmqzrrb1seven
9964pfxmmr474
46one
7fvfourgkfkkbloneeightdrfscspgkdrmzzt1
15two6six
htxxfmfd7nb
sixfivesixeight4pfsgxvn9sfjfk5
pmjjpggvhkrq2
tvbrkhlxdsnine65
four5gkrptqninenbdvffour1z
foursgnlxmjtcrrfour7
3onetwogkhmllzvrsqzhhnkvdg
nineninegxknqzpsix28
1seven85189mv
gtwonejcncdlhpsxjrxnmpvfgtdrcdtd2nm
1ninemxzntjptl
qcmqfour2onesgplvgzkdltqtvzhtb1
seventhreerxqvgkzqhfxfdhnp628zxtbjklkpdtwo
fjdsgcsqppzdthreefour3one3lvmpm
sixsevenfivefourxf4mzhmkztwonepzt
nineninesixskjkbhx6nineoneightj
four6nzqxhhnrg
86fiveone9dhrkkh6
8ninetvnsrcsbpn
two43one
8vfvbrnclnmthree8onetwoeightthree
one2czxjgbzsn46ktj8twones
qfnlfivemqninextzppkfkb8
ntvcmxsevengxdtc3five
8lsfkbbxkscc
seven5817smvjfpdktwo6mdfngz
92hqxbchfpnine
tvxbltz53oneninethreeonek9
hvvjhd1
six1six7sevensixqcvhsfour7
seventwo2
2svpbhrlhfjhbkf3fourvvspkfmbvztmtpcxndfnine9
fivefour42
sixvstzdtfive3qzmbbx
rfcxmthzlgxgrmjncszdvlnp6
lhlncfjlhrqrfzr1
cqnkmtfj5
tctfngvrxljlt53pntbcfrftjpjvzqbqxh
6fgcdfive
4834sevenvssix1eight
rpxcthbpmhgrcxk4
threecthhnine781
pppqkscmthreeseven1sixfive
2tgrmvxpthree6
7ckxjmlpkqqqjtfiveeightbmmdoneighttnv
six2two
lsshzhtdfour24
mrjjgzsb92fivetwoxh3
5fourcqhk3two85fiveeight
lsxpkxfmq97one
b87twosshtxkkplq5zkrrqcmfn
threeqsnd64hthreeldbtfkqpbqpdlmtwo
eight2one
14r
71fourzrmsevenseven9
threesixmmcjzzml4
stnmbsix41
cztnnflpcl4txplfour
five6six4kxv
5oneqmmbnvgvbq6vsncbrjrsix7eightpzkhvrjz
kflckfgxfeightlr37fourfiveseven
9three7three
rkxbqnine7onevvqgzcvvjthreendkddfournine
fzzfstwo44vm
19648
7fivesixhdxhlgmv9
six9hzlctfiveonefour
66eightthree4nine
jcgk8three
tbctwonefive2eightsixbntmjceight
ninemrqkzsevengvq6
rsmmpmrlmq92fourfour453four
6eightbmjhnpbgnccfninefonenineglkfgp
8onefive7kn
eightrgzfdksevenftbvkt455oneightnl
3vxtwogxpdhjmqskjc
shzvnlgvvvthreenkv14eightbcmjd
2sevenlbq
1zfjpz1mdfourstvj7zpfxxlqf
twogm22trvplbsk29rbjtvctqr
twoqpgcbskdgh2tktbbpnzll7twoxljpdhthree
5nineeight6
936
218ptffour
1clztnnsix1
bsevengsxbpjmbg5eight
1cpeighteightpb
vrlnveight2twopxmtwo
fgrjr8six
5sevenspppgjtxbtqlzt
5sixczhncsix2qcqsevenfive4
kgcdpqclsggzm79nine
eighteightone6sevensixthree
92eight7plhftxkntl1two
5dqrhhqrrgmvrqznbgx4three3
twoone953cdkm5stzdbdh
heightwothreennzljtptwo94
6sevensevenfoursix5nine
cnbslkngtk9five58xpqvgjpqrnpjnzbk
onebrcg1bnfivekftnzpclqxvhchloneightzrn
four855dpknm
4hkdseventggkffhrkvsixcrsqjsix9
8seventwo
two9sixthree9cdrmqntmcv
525tg4h
five7kxrlmq1bzhdmhtgglmvzrtfbqqd3
bnbbsbhlcbktsqlpq69ninesfxhq
gndxnlmnrmnk29qkfxfoursnnbvjtq
5bzppjrgcpk
2three79pmgtcgmtdf2fjh
sixmmpbmtznseven62
4rrm
ztlthreesix28ninesix
j7fourfourfbrlxplk
zjhrqtqsix1
4three6hhndrlszfrgphcbonenxfive
jmg8hfsxfsvdxz3four7jfbczjmdhbpn
39ptfzqjfpnpxrnf7eight
three6jrcrgpfxg8vxgk8
57kvbczxn5eightfour
8xbdbrbpjp
sixtrhhl2tktvvmkffl5
three6fgsjtmnine54sm5k
ninenine3stfpft2nine
one61onenrhmtwos
pzdq8
pltd9sjdkrscxr25
dzsldkmzd1
vlvpfmz24sevenshcrvx389one
1rfvlnmfkdbmdjj
sixbzzbftqggn8zggtbcd
hzxzjhkvd5twofivedxfdlrdeighttwo
six9nlgcdznskrsb
sixrxkfhvsjxzbt4fivenineninenine
dsbmqpgmf8nine634two
fourknfzpthpf1
two9twovbmldd
5zgnnrxtwo2two2
fivezfvzfdxkmrbvtpdhqbmdhcthreedvlstmq28
ppfqqq75seven954
sgtjpsix3
twospnc9cnchkzthreegj
3eightwoqs
goneightghmkgksqfk2two2six
sixthree6bjzpqlsbgq2rkbffxtmprpddkxv
rkv43
bzfnbq8onefourthree4
3mqvr
fiveninefflpllcqzonejqqbtwofive43
tvoneightfour3three5
mvhlv6bzbjggrsvvxh4dfcpmrnhnq4
fcrsmfmpnmkfs3fivekblglhqmvfourchc7
svfmfbdrgd81one4
mf7threetwo8nine1
qngfr4gnnxbszqzsixp
px5gfx7two5seven9
4gp
8lxkgvpzxch6
3mdgqrvtgnthqnhpxteightfour
onethree899btbpjnxxjhone
fnjdzx5vrzc
four5twofour
9fivetwo2
threezlpsdhxvdlfpsvkxxnnine3
hvnnq9two2fourpdjv
bvjkdg9four1
2412
threethreeszmhdndctj1eight8lcqtwo3
cdnmjmxqrz6vrkkxtfour8cc
njldrqggdnfsix5
9csxcksh6three697
92four2sr32
3jdpqdjjct44oneone75pjgkgv
576sreighttwosixxzqmj7
twoscdxdlfddmfive54
ninefiveznine33
threenffnvx3
916tpsgsxmtml8
6five3
fdztvpctnr5dmbjnrjslr
16four
4oneightk
three5fouronenm
threezrksvlbdb891zfbbcdrbpd7
five821ndfftdbmbr3nine
ninehvdxftmgcvnkrlrvmmbb4nine
xkkzphgfv1two
3pm
ninetwobtjxdvnhv12
fiverbkmfbx8fiveeightksjzphkrj23rdlrtnb
kseightwo2fivesix
5snpchthree3
71oneone
6frxncksfxboneftdpvmnfdfxreighthrmnqc8
two48mhgdtlp246four3
993three8
threenine7twohbmcrpd
9bpdccqbts
kptwonejntgcdqdfffour4twobvtxnhqkl7
1637sevenfour
soneight6lbcrzdmhltpbkbjfivechxzfrqqgfeight
99five3hjvjrdmgl
qncqlreighthkfmbbfqx87five3
7jqkdsfour
ninemmvcxlkcrg1
mkdhgzcvmseven3onesnkhtxbgf7threestvjqn
nttgqsmsl4five1eighttwo9zg
one2ninefour5
bdfbveightseven1lcrshdgxznineeight
qsnvsonezqhsjmfive9one
6kvdrgkgznf1cmklmxgnine6
xkmzzdpknl661
ninefoursix7gnbmzd37
mmxmfnsrmt2bnhkmftxnjsix
fmhsrdtnrxlqgjttlgvmqxgzpl756sixllmdvblrvrrzkqgb
7xmppbvd976dqt87
fourzdctfglzzf1xdbfmrbfeightwor
8thncgqzvr989lthreeseven
5qmrzeight169
4qgvkmninegcsdgcthsp62onehczjhdxcgm
25tlppkmctwo2
668four4
rjbxtvfktchflstwo639one4
seven6eight4onehfztk
five53
nine33threethree3pznjbtxjmrrxm
19six
fivethreefivegxcqflqhjrn3fivehcn
vpbntqnpkjfninesix6341
7eightb7
bktffkqsx6fzvpnjhk
38jrjprtwo628
77tplflrp7
4one9one6
pkdhkbxrbshccxgknrjgseven44
49rthxdvlmeight
5twodhkpfn1
znine2fbsmeighttwo7
5ninexvmg
dbjbfmqtkp66
mdsrdjdnxkzr3xfm
two9twofive3
9kfivetg2five18
6fivenine2
2dlgpxsq7sixone6
tnqxgjbnc9bhqbgtwodxssml
18sixcjthreetdtprgsix
65sevenfive9nine4seven
nine34fiveqjdqc
threetzvxrb5vspdhrmjcnhtrzkqhd4
67nine8jrxt39
443oneklzsrtwo4tbbvxblk
xp7fourseven
ktsrninemlldztwo5ghqfgh55
five6eighteight7mtstgjlqmngzonetwonec
rmfourseventwothreedjtvf9
rlsgqhhvcdvthreekzjdssslmsixfour5rxk5
sgnfjqm4fivefiveone87nine
6twoonefive
sevenrftrnqrjs1
bcfgjklzfbnineninefivesrpcqtwo4
threek7seven1fxslmvnhmffqqvbfbhlceight
sixxzqz9fivethjgdv2
nineonefivesixtcrjd5
5645ptsjfrszgr8
1threezkpgczxr8four3oneqm
tvlfrfcnlc56eight8ninesix7seven
7clvmrdvdgjg
7mcstlktwo
dlxlpchr3eight
3ninelrzgkhx85
jlkqzonefourrvlptlxxgrthree4six
rxhpprsqtd982t
six4671nineonesix9
eightsixtm9vngskjglgvrbsqgcmxczbqqvxqxfj
vxfmc1six1ninesixnine
39fivesixthreevmpm4
xllclztxcxjskgfourlvggrvr25fourthree9
31sevensixninedpfrvvfftc
three64ctshdpcsfdjth95
fourgcqf8sixfivepsrdqvrld
5nine1qldrqhvfour
5three1three
6hjbgdqjtlppzoneninesevenqlmvgkq
eight1three6sixthree5two9
17141oner
five1two7
sxcfxblvfbtdtlkdpnineztnsfdkmeightvrr7fivejj
eight183krc8nkqk
sixthree38fourkgfbbv2sixsix
922threeeight4moneightsm
3threefive8bdzjs
onechvnhrfthreebqfive9
8sixgkvzgnfkjrrxrxvbvgvx
meightwo1dnbbpzrxftwo8
253lqt1bzfpqznz
klsgclc549rbksgrbbh56
3xksqcrhdsthree
55nxbjvps3nbmf
7qzzfourtwo1688
h5skqsrnnpxdone5fivefourkffrsblv
3fourfive2
25stdpqvgmzg9qksix5three
fivenxhkvbscrxx1j4
dtszrbcgpgxbh1
fivefvrp159three
68mdjsggnbtwokmthtwo286
xtwone7bkhjqkmmdkxvqtxfkpmckj5
btwonetjkkdfqphr2gkknfz7one
ninejgnxcchjqsevennvdjvttnqqsix6
395seveneight
lfrsoneoneeightfour6
four9prvhcqdnrgjl
qhbkninefive73six8
sixkqjtrs1hrmnt
5lmctnqtqc49eightnt
sixghthgcnpfeightseventwo3
vvvjbvnjfeight41nine
9gkxpcrql9three4
65seven4eightmjnh2gbjjstdgb
8four68seventhree
19924nine1lxnfzgt
fgjtbsfour4nine4vqfznznqxnsevenvzn
fiveone9bzshjmdvdsixxknhmmqskone8
xqjzgmdmnfivefourthreemmksmdsix6cct
eightklfnlkb9
rmtsdblmcghszsfgd66seven1bct
twoseven6
psbfmmmrppdfm5ninetwosixnine
rkcgdnslc9pjtqvgdmbvpkbbksxgr
mxjpns69
rspjpcv4fourthreesixfourninevlfive
2dgjgdn
66five8qxeight
five93
six7twovssixsixztrmfdrrvgqtdhmh7
32sqltqgoneightd
4five8tns1six
277
pmrzrckf6
8rglvpcttwo1twofive
fivethree644hrphp
fdpjb6
dfkpmgxfgfmtklbffk4sevenfive
nhqfpnvpsqpffour6neightfour
threeseven9eight67three8five
txttqnnineonefiveninesixlbscpqp1
three2sixtwotwo7smkmq5
8bjzjrnpspnine5
5three659fourfour
qrdrk7fouroneseven
three7threevhct
mpjpgfbt8five6fqjbghvbpcnine
7zonesevenzmlvfvzn
2hzldqdntffxhfpxlghf6threeninejrxngnjq
dfppvqcvthreessnnm65tqtn
56nine75rdkxdcmj
8twozvjkdltz4sevensixfive6
vzpzllmbghcccksevenjgjghqjr98
fgjsgxlh48sixg3three8
4eightfbppqltgxttoneoneseven3
six1eightddcthzd
fiveggljcppdeightnine5hsbfrtninenine
2xrdtzfnhpvpgone
982
two7nine7eightnine4
one431
eight9fmbfqxgzlskgjrrksr8six
9zhvdllsszd
4pnkpxrgltkdbztlnz2
4ninebkh6ninefiveh
five9ninevrzxhfnggfourfoursevensixlncsfdvrz
rqhjjxzeightnineseven7fnmbkrtqgr
8xfmqdone
pnszhd1trqb71gfhpjpq
9htfkgbxlht
sevenoneqgx29three5six
fourdlscbpbpb9four5jbdjzqqdthreerhqdsbb
five31sevennbmrbhtthreebzqxvthree
one4c
three38183threesix
6rtdclcbfbbdbeight1
2one8xdeight
2sixsixtwo
nine3pcjthmlmtljkrzxcdxkbmgzneightzcmtwohpdpkvqg
9two81qlhsrnfpdksdkd
threejrgxc4seven26njlmtbheightwodjh
lrjzhghhpk342threeninejskdnjjltt6
46threegj
ninedgpkqblftq2b3four
3951sixssgmjj3
8jteight4
three6mdvfkgrxcjmfoureightfour3
hvbf28
9fournine713six3
four1seven
763twoseventwonine4
ctpfmnsvcthree9sevencbqtjc3
sevensqdhvxd36
fourninergfmdxpdbt1ninefour
2kptonesixzpqrsqzhv
h4qcscfxfctjbqnff1sevengxvjjc3
d8cnjksdf
hzcgnine35fcbxtlg8rjhzbjfkv
jdvoneightdpfvzvp758fourfour
four27jhrgqnrjnkzffour5
fivetwoszrxz2fzfrbgqntjf
onergnqpl3
ccfqnc5twothreefoureight
grgsgxsevenkvzfjppnzq2sztcfive
9two94onesix
nine7seven7
eight36
plgsevenvfljnqvtfq5two
threethxdbnz49two2vdxbpqtpb
cf9fkrbrvjhssptthree
one5lrcn3klrcphllmz9
onesix6seven8tzgfdbm
964khvfxtrljs88
trszhb48fmseven
tdfxvnhrzv8threesevenkgp
ninegnmjxzbtcb32four9mlpkbfqdxdkoneightg
sixnineeightnhlqfslb2v
one83fc7zs
pxfkljdbdqqqvnrfivefoursg5nine
2onevh
1fgjrsdlgnbmsbzsevenfive
3nine87pmsqqntwojtnrksdtwo
two59kltcxhzszhdtwo
6451
sevenzscjhgpfgsseven7threeseven4threedlbtxtcvl
eighteight8sfsvhbkf9jgfrddx
qlvdplcqtrcj2eight4
sixbcpxtjt4onetwothree69
91fourrbblcl
twozvqbsx4
twogfh73
onesixljjrlonethree3rxtwofive
onefour62
b7vfplpqnine5
67dgbmmjsevenfivedktq
7foureighttwo4
sevenctctvfg51tsbzqgcvpvslqb
mjkeightwo7eightsb6one5xzsix8
151dht66
93tkbs
29two
foursixtwo5gprqslprxkrbfbmsl1six5
one3six3
three66rbh82bgtfzsfrkhrv
2sixfivethreefiveseven
fcjttg4onesixtwofive
15seven54
5kjdkr9htl
gclrsklbvkfbdcb9seventvdtdmmmksh52xkxtpmfpvk
spone7eight5xzjrlxrnzjtqgpdcgrsjn
vs3fourdkdlhx7rb
9ldxtdk3
4dppnthreetwodvkhjjrqh1zbqxntvtxgchv1
1sevenmsdrjgqfivevphqmxzghktwo6fdvkvqhj
tbptrcvxhs9qcdxcpvp
8five2ssrrhgtxfone
3clvbm2g961
four2onegkhbdfive5vxvxvtxglg6hxrtlhzjh
kfhcmflznrg9qnkkxqcsm2vqqtrdg8tjkshzpnddvd
eighttwojfktjcrqthreepssfour39
359nine2fivevvscbvggjhbnnzqtxfsbpb
vvshjlcfqt6qjvfjsix2tgsjbdxgppq1jmr
ninehhmeightcvqskvjptz2kdnhpptvkz54
39threefourndztxcl
sevenfive7
csmmpzfsix41
9cgqxtpdxt2
3mpzvlxrzvhtj
fourkqhzsjjjvx3six1
52one
nineltplrl8tfzqmnqeight
sixfourdqrfvrvbvfzzgb6
mqnxglzjk6qqhzksklvsmthreesixmvhmhbdkqpnxcsgvcsl
65
zqconeone85three
rxnhdflsqdqglxdmfxlxponeseven4one
88nkgcglftwodfxfhzxbqdpfrqmtwonenf
jzoneight9htkkpszpcqvkmlvl
388xnq
9xhlrqnkjpthreedfknpmqqtwo
4onemfzjfvmhhfive3two5pjdcf
djqjglztxs5nineeight8jdzone
four35ninefourfivethreecnhntp8
gxqxl6fourlfdtndgdql
fivenine6
1pqctbpbbgrmgqfqbzbjjt6
xzvjjfnfr28jblqseight
ctwone23
6sevenqjtwo
8nineplhlmsgjvs1
lmjgmltfivenine9
8gxnnnjonesixtwotwo1
2seven678cdxhkflhj3eightthree
djzninefour3one
vbqhjjhpzg86rkzdjzfj
eight1twotthreeqqlr
bkxseventhreezcjvdkxzksxrznp6four8
five77xcvphzcnlfbgbxnqbhfrldg
71qxqdncxdjsix
eight6one6jnpspgmhngzrfneightzdnrdhj
xb9skhpnfjsmq
jxgtk618fiveone1zr
8dkdnbfr
3llplnp4dzdxfhbvbn7two
eighttcgrbhrspktwo6eightddxhqqbprrf
eight2mpmzsevenrcbmsqg2cxjvmblnqbqdjsl
seventwo54
koneightsix22three
zdsnjr5vxrhkthkr8qmddrzclmrkprmvbll
fbkmfxncztwohjbfgkhgvcdkrpnc5
ksprkgxkjnineseven3fivebjpqhrmbdtwo
fourpss5
1three9fbnnrjcgllkvcs6
oneone9kjchnfsv9ffcdspfive54
26ninejctplmsgb
9ftfjrmvjblzqqmrdczpone3bphtmmkm
7lpssdtbc67mhnthree9cndbsthree
fourfour49four
nineeight8bzeight
128zpqftnxnqz2threettrhscsll
1xdtxcg4tkxtsnl
hmxbjczvgmcrd9mqsfivefourninethree
5hseveneighttwomgxmlmskr8
zdtbtszzkbk5
eight5nine6xthreefour
9rbfcnjztthree4v9vn
voneightqdtnrtc4
86cnzxs2three5
eight9seventhree
tjmrjgcfldqtbrvnzzxshxkrs3onefour
2rxplslzcglskjxgthk76cczdbxrp
sevenpdvsbhkknxqkqxfcz6bhmkxmhdbvhcvvhpmv49
three1twotwopr2lctfjb
zrbrqmh87dmxzmtfvthreelsleight
34dcnd8eightwombx
two9xnqtcfgq8tsqzvd3three
nine5fq3
eightsixfivemtcgzlbkheight4
qlspgfndmx5twobtjgzgvzmcone
5zlldrzrffgggtwo648
seventbqtkpfivel6
hjqbmfnnqzmf4
fiveqhdfsnjvqtwo6two
jftwone7
4twolqvglgxcc
twoqjmgjtrrjjt1eightcpj
eight9sevenmlkpsbzmtnhdrkbmj
trrpdninesix8oneqxtrzf
5sixtsxqdbnczhbvmfkvkc
tvbf2
sixtwonjssgpljqrxhlstfx4xbhqzlqktsixfour
kfxccb45tzsftztxjhgnxqsxknl29
tworjdcgsgvsix6
eightjbqfive26gfspjh3nine
2sqhleight7cfkhzrsevensevenfive
kzpzjcrl98sfive
sevenrsgtnine4pbgvrbcpf8
25q3qkcxlvhrxdonednbtcrrvjlnngq
twothree4lffpxvfcgqrkvdgzdsdjxjsh
seventhree34seventwofive9ckm
three25skfkvqdmbmsixxgqx
three1eightthreesix4
threeftjlv9
6spbhfckxcdrxlcg6hxcfive6five
8drbfjrgzvs834slzhsbgrjm2seventwo
sixsevenfmrvpqbgx4ncrmvfkjx62
lqfsslkmstwo7rgnqeightthreetnlnonehszkrghlnt
5onethreebxxfstvd
djchrbjcrddcqfourmnninesevenrdlpfxthr2one
three3threeoneninepcrjr1
twothreernxmhmtbn2fourtccrqhqs
lzzdpfourtwo1six
two3one3
zzcnprtjdr22286
seven5qjlfrhj7seven8
seven99
mtztq6one37oneeight
mrfcssmzxpvcz2sevenfourfivelpzqkvvdxmmpmxqshskfnh
nine8rtx71
1llzpvcdgmvoneonepksninefourthree
gbbvkcfive18two8twonineseven
2fivenztsix2nine
gjqnnr422seven4ppbsqdbpcfour
fourtwo5one7qfgpmmphdtl
pglzjrr4fivebclpf
slrrcqxxhtwoeightseven6
dnknxxkbjplrkjone2threesix9
htctqnkcmfqdxrzd9eight9seveneight
8sevenfiveninermlrrzpcdxkjkczhgpx6eightone
eighthnfxhrtssbmfxv6v
6fp539
sixzmsfqjzpvxjkhfqcrbss7xgg15
nine5ninevddknzczpxgzjx
jbcsf3
jjbstlskzxc5nine
jlrvgcbch7tnpfjnczdsrgddrseven156fvdmfhtl
one89
three52sevenlxxskf7gxh3gb
eighttwo59mqzdlqjdkkxgjhnktwoone
519six
1onemneightsixdlqx7
7fgszpqcj
sbfjtrfvnv6four
qtwonedvkninercj8
ntrnzldltrvtcsh8eight77sprgsvfdljthreecndckrzmjl
gtspn2
54six6mkjznlb
sevenonethree3sbpjqgltv
four8two
xdzrskv3974mgvjlhzbkddhcxzzxv
6three1mtlxshtxfpnine
14threeseven6
37threeonefpfgmz9
three3sevensixeightfive1nkjtndgrd
2dsmr7qhmnrgbsrvjmsbctwovb
gkdsnnqzlzdvcgthree3fivedzvpcfive6one
3vkftsclsxtxmsjeight
sglkcnzgz4mnhgblxqgdv69
tpcjb4one73s4
sevenrvhhxjcfqgs32six1pjvltwo
8zmktmxkbc5mpgrtnxmnp35fttpmdbhfm
1sevengeight
hghs1sixvvjpmlcponethree8kckgkf
gkbpflqvh1cbddlvdkzhfmzcfourkmckngsevenxkjknplzv
5sevenfk5qgfshtqseven155
dfjdtxjxb8fivefivebjtbggkdlpxlmnrcdt4jrrpnbtvlthrhmczn
2fivefivejxhh6
41threehtwo4nhzdn2
2fzngnxvvpjrqxk6
53sdthreeninexrfone
6qmrthlzgqeightrzrdglxvscgr
snkmhszcbmthree5threejsvkpkknpeighthbv
cmgb9seveneight
5djnine3bcffxgjbrhxbfhgthxb
1flqjgsf2ms
fivefive7onefour
threeeightksmhj94jvfvqrsgqrsevenj
jttgbfmh9468ddshrxnjthsix3
25four
9sixseventhreefiveninefive
eight5twoqrfgpkbdfc3qxfmchrjx8kpp
nineftnvllx1rjzkkt
gmeightwothree1fgfivejldgmt
nine966fivethreeninecpmgsxsxz
77bfhphxczdg2eight
89hcgjjtchsix
1onexps1
3fourkgm
hjgnbninevxdtpnct7bmstnczzteight23
twoone1qt8
43744
fourtfgn2
sixppztkbvllkltbs51xknnfive
tqxoneight5
twong3zdrbpqnb
fivebcrxk198three
435sfddjvfg56vkddkzhhj3
qcnhlbzmbld2fivebsix
zfsrtwothree8
nineeightfivetwomcjm2seven1
3gbnxlzxhvzzgfjjhf44fgbccpthhnkpht
3ccmrkbfour68ninetwonebz
sevenrccgdjrqj9one
fourzgdfbsnlb66txclxgp7
jmzlbtgbtl8three
6nine32pr
sixffcsmhlfiveklbmgj8nine
psmjrt65tppjqeightzqvglglnine1seven
fourninehhzh8seventwoone
48two2vzbrl
mdlzptrcsix3three9
sevenlgr3t
7sevenpphjhvdhkheightwojv
seven3756
four85
4twoonettmxjncsqmgsrxsf
fivesix6twofvzqxpphzmlkj
eight1twojrzspbfbzkftwo
5eightthree5
31ninecjnsevenjvbsvpphpxxkcnine9
nine5vnine486vrhbkgl
sevennineeight97qpdlfbskz7sfbtm
onernqbxt8twoone
gftjrbmkmngtshchbgfc1nvvt5
four5dgvsixzhlxnnmjhkhkljcfdpeight3
ttmfdxhd3ninekzbtsixnfmvfour
8pfkhxhmh8xkghgdk
nhs4threemxjpbgsix1s
ghtwoz1
sixdthree7vlfbpzcm1ndbbczvc
ninetwo183
twofxsdt36fcthreethreeseven
7grvvzqhcbeightwopx
twoninevknhnkgdmhmlbxkeighttwonine4
4fourdmclrghj2
sevenmtgvr8four76fivekdqbsmmtq
klgpeight5sbknbhvsixfive6
2vddxlzfpsrqsbsixlgrfnhone
jxfhlzcp6qctpqhb1
eightd1162jsfcsplrctwogcpzlhqf
one4four7xx5
threebqmzstphclb5fiveninethree
bkxfxxms6eightwoxz
nineeight4four
sdsgszdznng4sctkfiveszkdknqjf8
vtzmnllvvhrcfdlxcxxlqvzst1
htzxcxpvqj91sevenxrggdtjzbrgcv
ldcnbzstq4ktzdxgmcl
twohshbblseven4grzpdtfmjn13cmg
cktjnhdnine1three9mjqvnjtkseven
891ninesevenxbdjs
kxjpngdtwomxttdqcdkhdj686sixl
hsninefourcxfj3five3eight2
6eightgkkr1one
658one
zqgrxfourfour8
twobbnfkdtb9five21zcfiveoneightjgt
79jsm55twonine5
eightftk2two
eightbjbvqscs5pvmb14lgvgfv
four4four
qmzheight5hgfourkgtqfhjfournine3
twofzdqtvssx2
1fivefivesixsevenone47
xhrjffnine8
oneseveneight72fqgzscqt5
nine7fours58
three2fourseventhree
35ninesix
qgjsrxgqb5
fiveqghjjvjthree4eightqfgrhblkjtwo
9mvcm
96fourqzdsix
vbzqmmzbvrbxltvlfmcpfvnddmgsbb6four7onegn
three3qnlxmkhpctwosevenfourvmqmqlgfrsn
2seven5one2six15vgnqzpggn
sixljtvqzlh1
45onesix
foursix44eightseventhree
djsix84rnx8z34
1mkgthree8two9956
psgnl6six5seventwoone
546cfgr2three
thtpczmkskptzn9pqzncp
31threeninesn7xhqvrsv
threehmjpvctfhnmhs57ninepzfvq
teightwothreesixdzqhvljk84nineninesevenb
gvptkx9rlsnmtwoonesqfxmzkv
7twojszdrxcxfour
3eight617npsbbrpkjtzsmeight
3sixqntvpttddsixninemtpb4
1onefiveseven2fourseventwo6
67foursevensixsix2
one7qeightonehckxhxdfjjzsrdnj
38onehzjxg
4splxs1zfvfksevenkrzfive
fourfournkcj9
1ljmbhcpttjnine
2xnvfpdgccxfivellztmtpnc
ljvlxplhxfsjqv6sevennine44nine
qdonefourlnrzrgthbt1
twothreehvvhsxzqz1chvbcsxtll
82vmfjbvssmlgk2dbsljgvd3
xzfbfmbbxfeightgfz3lvzpzbpmv1four
oneeightfd5ninetwo
ghddk7six7xqmglkvnqonesix
six1eight
7five5ptkbvvvfive
3hftgthreehcfrsnl1fivetwo
7six12onebhpz
mkqjv8bzdnt9sevenfourtwo
five3mzgqnm
sixtwocbjxlgvp1twoseven
dkfmbzmvxseven971
bninetwojnsnkc7
ninekzcpfive4five3phz3
eight8143
eightrzdmxzb8eight6
5pdjm22ninej37two
fourtwo8fivetwosixthreetwo
ncttc71fourfivejpjzcgzpj4
5882three8glcvgnfhscbtmnqmnh
ngxkxtwo9pltbbmxrknvjheighttwo53
twoninenpqqqgsbsq3fjdk
eightsevensixhtsjvxjc8jxftgnptgqsixvcncglzlgq
sjxtcnt8gpeight7cbgffmgqksix
fdsn9threenineninetthree37
19rrfdqtpmonetqjdcjtxlhkptccjn6mtztqhvvtqftbv
vrhprdjsfour28p4
eightfiveeightninevdvnmbv58vrs
qdzhzrhlfl7hhxqzxqdxeight
svnbzgbhxjcx26xclfgs
5lcggbhzrmnknine83txffvcdonecrqvvjf
six5fpncsbbqbbcczcmbgrqmndxmrxloneone
1one6
88gctsmp7eightrvshklprtm
xf874onehhcknx
sevenvvncrhvxjxnzsftkfhsktwo3eightfour
8ngprdqfour
98fmrxpxzzbrjpxzqdxmv
2zbxzsthreefivefhdbhvjjxv6btwonef
jzkjcvpn924qjcbr97h3twoneff
foursix3
9pmtdjvrxjrponetjlxbdzbvrcjtc77
52twoeight2fourh8
kpzfztlzlkdprbmrhsjcxfzsbch31
4fivebtfjmfive6seven
ccttxjmheight6twothreelnjmfoureightnvcvpmpc
6twoz1dzv95
threelsmgdnxcsevenqr4xrtthzgkqxsrdssmjqv
fourgpvjxdg4qpvfivefive8nine
9mncmnhrclsq
9zjfmctz
pndgptggnsthree8xlcctvpsix6three
98npgrlkqmcninethree
fivexp6fourdpckhqpcxczrfbr
six2xdgsqdpsbmgftzvqhnjg
7ninepqheight2eight7g
2zrsevennlpcljnp
twoonethreevvpfp1jrhsevenfour
threebzmggv7bjm6cczkbsronetwo4
three1foursgvfdrrqmk4two6
onengzkkjsxsjlxxxthpd7xfcvkthreefour
sixnine5sixeighthlvmf
63gkmbsdc3fourmgrjhrlbqgcfxf
2bmldthree7skhhpxfonenineone
b6seven7
seven39
twoffxbsgpcxctmmvb4kdhn89
seven1fmgtseven
ninegxbdmztzzbqq6lgcvsbhzplqt
7twoonev
24nine
tvjmbzlsjtrtdhdlvnffmcfoursix6sevenonebvq
5jpntjsthree1threetkbsh7
sixone423fourqnczdxcpmsvjpzhl
33zdfourseven3
77lltwo5nineseven7djjmdqkqfd
4xfnpfbtdl7
two5ninejbrfrsbrsvzfivenineseventwo
89znjldjptdnfkeightkpcxdxcc3bkmfhtzkkh
qlkxd1rv44qlhhpjrninetwo
6l2rfscvcgdm7
rhtsrbrmlnfvseven1eight23dd
7xcglznxrjzsmhqnkqjhbjqxnjpjx15six
fourfiveq1vcsnnsxkmrcjscn4sevendbbtjh
6qcvjplvnine91rfjk51
jmdsgfxd5
tlzpvtsvkdsixtwo95
8threeeighthvhlqss
threetpxxlmfrhpf15
4twoeightsix
rg8nvrtzxjvfddkeightwofzs
tggqninemk1
mlchhftqkxtbhfpjsixnine817
231rpkxcvcz5fcztnqskqtwo
five9hhrtmp9twosixthreeeightv
9threeschsm17
hhreightfour171dtbmhzhhjb9fgbg
bhgp6
fourztzlhdr2hbdlv8fivenine
fourseven8seven
eighttwo8eight
two12
threenine76ndvklb
twoseven9jxfcthreecnrpvglksc
84fivehmf
jpgbtnrsb15eightgdtqmk
34two8eightbxqvc5nine
four4hsgjmtbfrvfivenine
threecfcx8ninefive3xone
cvhtlnlnhh71
four9sevenonenine9ninejlgmtvxmxseven
vttchshfgfpdbmpmp338
nfcdnhq6nineeight79
rgltnqzrzfqdjsfrhzmfivetwogklxqdhzbjtwo5three
five3n69fiveninesixtwo
nfhheight12clcqcnpdbz6nineseven7
eightgxtmstbthreedvrqllvp1ljqstbjdhcmbmbeight
two26four7three
6rtninethreefive
vhnqgdzzbxr9two7mdjzsx3lf
twothreepzxljpd6sixcmsxkcqkfive
6threesevensevenjzkcqthfivegmjvstrsix
five7fivetwofour
onesixseven767
36onehxdpmcqxsfbfive
2hdvqrlhs5six
pjfcjrnjnk9four99nineskshccmmnvxzvhvqmcprkdqvhhk
4gronexqnzdfthreejgqt
kvrsixtwofive2
eightfourone4hone
cgbjtdbvptworbcz3
jpgmhfour1
ngbgjhlstwokxc8onejlhczxvnjbrkqzdl
chbmqrz3fourthree
rgvmkpeightqdssbcgf9fivefive
5vgrscgshtbfgbljt5
pxgq5kffxbdjgq5cjnpzfdt738six
meightsvfb47xcdfkhf5
clzqdc4five1onexfxlxnltfourfour1
fivesix3threeseven
tworgklxh1threefourcsrsbj5
3fivepdppjlmmb6fkgrcbldbxsdjpbvbqgpj1nine
9clvlvsckdmjsbxzrmrhfour
fourlptwofqspctl913
28foursevenrfjfive5qrfsl
gfhmkfln2jcqttonethreetbmcdhhvbnmqdgsbrrmpk8
eight35qvkxtwo3fivevfive
26fivegpcqqsjr7five
three1seven4
9fiveonevmxhtndtfzmnxvtjkmr51six
64vgrgtwofour
four9one
nxjtdt2three1three96lfzglzcfour
355six
9lvqslrvdrd8six
9threetwo35six
two57
phpkcmfxvt7gphd1qglpmckhnj
sixthree1ffrdbsix4two
spbscvjfl8vvkpjkshkx3
5nnjdbjj3
bmmqrrkdcfbctmsk124eight9one
4rxdpvqlhn
seven13glpzfknqtxdqjq3qblzcjvx9
8bnkbzszkxkrrfdmcstvfvp
nndndjrs1qd1421
twovn9four8five
eightrc1
ltjvtcqfzdfourseven8kvcx43
vn6ninelr8
2seven1
7rldpqrfoureightthreesfhz11six
56fourkmvl6threegzfqnlrlz
8mkpcsnzmknmzpjppf8two7
bzgvzcpkqxmbxcqsix4qjzt28eightwoj
threesixxqkshhnine7njtvvxfmjl8
5seven6vqcd62sixone
three552
hsslkhbd88zjhqvgtzpfour1
oneone96fvjbmcnzrr
pspndcdtctwo6
v3one9
fivefournmrfrzghdh7twoxmpgkps772
vdkqxqnsthreefive25
kgjsevenczqrqf14pjchtfbnnninexhgn8
lqkhzjzm3six1one3
1three3l61seven
1flsfhznl
r8hnbpbtrzkstdg
hhrmnkktv7seven29fourpvjceight
2mbft
954five9fivegbmlz5
dshbfdqdjjgtxffjmllgvxjfrstgldgdxjsfxbone9tgseven
fourseveneighttdgghnfive7pchxddgggcq
8zx5seven7pffldzjhdb8
bpqslhkt33sixnlxckbbr2
xqmxvjcplh4seven
jd9zxmz2two1kvsghkvkpz
9blk3
6rjvmrjk46
onetwo6ninehdrlnxgbc
6drvnkssqzv5jfnineseveneight
sevenmvxlzmtwox49one1
8fxnnjr18fivefcf
five98sixkblsvns7mgttvhhz
85qkkg463lxdhzdtllqtv3
fivethree5eightfivessrnhsmdrnvssxfgxmsix
xgmqjone7j
pkclcg54
dvllcqqghh891pdlqnbtb6183
2qbnqkgncqrvlfntwo
seven7qdfzfpfivepnbhrqx48
682sixqtwotbgnsspzqcntlrhpzcq
2sffrxkgmsixfivetwokfvnlhz
sv9klzvnzsgjmoneseven
bzbppxbdpxs9
68ninetwo99four5grdrrkpr
mtfcscprzkeightfzdbhdndqh1njdfourtdtflbfjrth
8nvdtbrfrvfivesixtwodzxfhgpzlk6cgkbr
3slmzvnine5fm
eightone16nine
kdzrjbh2txzz5hbone96one
17pgtwofl41
eightoneqjvzv3
fivetwocrhmvxqkvbeightfive1qzcxvds
2htzsvdhvqvdjv";
    string[] lines = input.Split("\r\n");
    int sum = 0;
    for (int i = 0; i < lines.Length; i++)
    {
        string line = ReplaceWordsWithNumbers(lines[i]);
        string numbers = string.Join("", Regex.Matches(line, "\\d").Cast<Match>().Select(m => m.Value));
        string number = numbers[0].ToString() + numbers[numbers.Length - 1].ToString();
        sum += int.Parse(number);
    }
    Console.WriteLine(sum);
}

string ReplaceWordsWithNumbers(string line)
{
    for (int i = 0;i < line.Length; i++)
    {
        var substring = line.Substring(0, i);
        var replaced = ReplaceDigits(substring);
        if (replaced.Length < substring.Length)
        {
            line = replaced + line.Substring(i);
            break;
        }
    }
    for (int i = line.Length - 1; i > 0; i--)
    {
        var substring = line.Substring(i);
        var replaced = ReplaceDigits(substring);
        if (replaced.Length < substring.Length)
        {
            line = line.Substring(0, i) + replaced;
            break;
        }
    }
    return line;
}

string ReplaceDigits(string line)
{
    string replaced = line.Replace("one", "o1e");
    replaced = replaced.Replace("two", "t2o");
    replaced = replaced.Replace("three", "t3e");
    replaced = replaced.Replace("four", "f4r");
    replaced = replaced.Replace("five", "f5e");
    replaced = replaced.Replace("six", "s6x");
    replaced = replaced.Replace("seven", "s7n");
    replaced = replaced.Replace("eight", "e8t");
    replaced = replaced.Replace("nine", "n9e");
    return replaced;
}