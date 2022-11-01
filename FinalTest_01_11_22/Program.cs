using System;
using static System.Net.Mime.MediaTypeNames;

bool isPrime(int number)
{
    bool prime = true;
    int upper = (int)Math.Sqrt(number);
    for (int i = 2; i <= upper; i++)
    {
        if ((number % i) == 0)
        {
            prime = false;
            return prime;
        }
    }
    return prime;

}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]+"\t");
        }
        Console.WriteLine();
    }
}

int[,] GenerateArray(int n)
{
    int[,] array = new int[n,n];
    Random random = new Random();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i,j] = random.Next(100);
        }
    }
    return array;
}

void WriteArray(string path,int[,] array)
{
    StreamWriter writer = new StreamWriter(path);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            writer.Write(array[i,j]+' ');
             
        }
        writer.WriteLine();
    }
    writer.Close();
}

int [,] ReadArray(string path)
{
    string[] lines = File.ReadAllLines(path); 
    int[,] num = new int[lines.Length,lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] temp = lines[i].Split(' ');
        for (int j = 0; j < temp.Length; j++)
            num[i, j] = Convert.ToInt32(temp[j]);
    }
    return num;
}

//string path = @"D:\test_final.txt";
int n = int.Parse(Console.ReadLine());
//WriteArray(path,GenerateArray(n));
//PrintArray(ReadArray(path));

//Сгенерировать матрицу из простых чисел ( 2.. 1 000 000)

Random random = new Random();
int [,]array_simple = new int[n,n];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        array_simple[i, j] = random.Next(100);
        while (!(isPrime(array_simple[i, j])))
        {
            array_simple[i,j]=random.Next(100);
        }
    }
}

//Поменять строку с минимальных числом со строкой с максимальным числом  

int[,] ExchangeMinAndMaxRows (int[,] array)
{
    {
        int idx_max = 0;
        int max_value = int.MinValue;
        int idx_min = 0;
        int min_value = int.MaxValue;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > max_value)
                {
                    idx_max = i;
                    max_value = array[i, j];
                }
                if (array[i, j] < min_value)
                {
                    idx_min = i;
                    min_value = array[i, j];
                }
            }
        }

        for (int j = 0; j < array.GetLength(1); j++)
        {
            int temp = array[idx_max, j];
            array[idx_max, j] = array[idx_min, j];
            array[idx_min, j] = temp;
        }
        return array;
    }
}

// Узнать есть ли симметричный столбец и посчитать его сумму.

int GetPalindromeColumnSum(int[,] array)
{
    int column_sum;
    bool is_palindrome;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        column_sum = 0;
        is_palindrome = true;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            column_sum += array[i, j];
            if (array[i, j] != array[array.GetLength(0) - i - 1, j])
            {
                is_palindrome = false;
                break;
            }
        }
        if (is_palindrome)
            return column_sum;
    }

    return 0;
}

//Найти максимальное и минимальное числа. 

int MaxNumber(int[,] array)
{
    int max=int.MinValue;
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] > max)
            {
                max = array[i, j];            }
        }
    }
    return max;
}

int MinNumber(int[,] array)
{
    int min = int.MaxValue;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] <min)
            {
                min = array[i, j];
            }
        }
    }
    return min;
}

