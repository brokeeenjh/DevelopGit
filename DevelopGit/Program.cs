public class Program
{
    public static event Action<int, int> Calc;
    public static void Main(string[] args)
    {
        Calc += Calculate;
        
        Calc?.Invoke(3,2);
    }

    public static void Calculate(int a, int b)
    {
        Console.WriteLine(a + b);
    }
    
}