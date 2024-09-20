string str = foo(1) switch
{
    0 => "zero",
    3 => "three",
    _ => "default case"
};

Console.WriteLine(str);

static int foo(int x) => x * 3;
