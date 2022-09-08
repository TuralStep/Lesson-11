namespace Lesson_11;

delegate void Func(string s);

class MyClass
{

    private string S { get; set; }

    public MyClass(string s)
    {
        S = s;
    }


    public void Space(string s)
    {
        for (int i = 0; i < s.Length - 1; i++)
        {
            Console.Write(s[i]);
            Console.Write('_');
        }
        Console.WriteLine(s[s.Length - 1]);
    }

    public void Reverse(string s)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
    }


    public Func GetDelegate()
    {
        Func func = Space;
        func += Reverse;
        return func;
    }

}

class Run
{
    public void runFunc(Func f, string s)
    {
        foreach (Func item in f.GetInvocationList())
        {
            f.DynamicInvoke(s);
        }
    }
}

class Program
{
    static void Main()
    {

        Console.Write("Enter string : ");
        var str = Console.ReadLine() ?? "NULL";

        MyClass cls = new(str);

        Func funcDell = new(cls.GetDelegate());

        Run run = new();
        run.runFunc(funcDell, str);

    }
}