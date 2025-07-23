using System.Xml.Xsl;

namespace Calculator;

public class Expression
{
    private static string number1; 
    private static string number2; 
    private static string number3;

    private static int left;
    private static int right;
    
    private string expression;
    private int firstValue;
    private int result;
    private List<char> characters;


    public Expression(string expression)
    {
        this.expression = expression;
        characters = expression.ToList();
        Calculate();
    }
    
    private void Calculate()
    {  
        while (Contains('*') || Contains('/'))
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i] == '*')
                {
                    Multiply(i);
                    break;
                }
                else if (characters[i] == '/')
                {
                    Devide(i);
                    break;
                }
            }
        }
        
        while (Contains('+') || Contains('-'))
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i] == '+')
                {
                    Sum(i);
                    break;
                }
                else if (characters[i] == '-')
                {
                    Minus(i);
                    break;
                }
            }
        }
        result = int.Parse(new string(characters.ToArray()));
    }

    private int Sum(int index)
    {
        var (leftNum, rightNum) = FindNumbersAroundSign(index);
        
        result = int.Parse(leftNum) + int.Parse(rightNum);
        
        ClearAllNumbers();
        
        characters.RemoveRange(left+1,right-left-1);
        characters.InsertRange(left + 1, result.ToString());
        
        RemoveNumbers();
        
        return result;
    }
    private int Minus(int index)
    {
        var (leftNum, rightNum) = FindNumbersAroundSign(index);
        
        result = int.Parse(leftNum) - int.Parse(rightNum);
        
        ClearAllNumbers();
        
        characters.RemoveRange(left+1,right-left-1);
        characters.InsertRange(left + 1, result.ToString());
        
        RemoveNumbers();
        
        return result;
    }
    
    private int Multiply(int index)
    {
        var (leftNum, rightNum) = FindNumbersAroundSign(index);
        
        result = int.Parse(leftNum) * int.Parse(rightNum);
        
        ClearAllNumbers();
        
        characters.RemoveRange(left+1,right-left-1);
        characters.InsertRange(left + 1, result.ToString());
        
        RemoveNumbers();
        
        return result;
    }
    
    private int Devide(int index)
    {
        var (leftNum, rightNum) = FindNumbersAroundSign(index);
        
        result = int.Parse(leftNum) / int.Parse(rightNum);
        
        ClearAllNumbers();
        
        characters.RemoveRange(left+1,right-left-1);
        characters.InsertRange(left + 1, result.ToString());
        
        RemoveNumbers();
        
        return result;
    }

    private (string leftNumber, string rightNumber) FindNumbersAroundSign(int index)
    {
        left = index - 1;
        right = index + 1;
        while (left >= 0 && char.IsDigit(characters[left])){
            number1 += characters[left];
            left--;
        }
        
        while (right < characters.Count && char.IsDigit(characters[right])){
            number2 += characters[right];
            right++;
        }

        for (int i = number1.Length - 1; i >= 0; i--)
        {
            number3 += number1[i];
        }
        return (number3, number2);
    }

    private static void ClearAllNumbers()
    {
        number1 = "";
        number2 = "";
        number3 = "";
    }

    private static void RemoveNumbers()
    {
        left = 0;
        right = 0;
    }

    private bool Contains(char op)
    {
        return characters.Contains(op);
    }
    
    
    public void Print()
    {
        Console.WriteLine(result);
    }

}