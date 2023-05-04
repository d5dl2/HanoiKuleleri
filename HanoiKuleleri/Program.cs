// CONSTS
const int SOURCE = 0;
const int TARGET = 1;
const int boncukAdedi = 20;

// SETUP
List<Stack<int>> kuleler = new List<Stack<int>>(3);
for (int i = 0; i < 3; i++)
{
    kuleler.Add(new Stack<int>());
}
for (int i = boncukAdedi; i > 0; i--)
{
    kuleler[SOURCE].Push(i);
}

// RUN
nLiCozum(SOURCE, TARGET, boncukAdedi);
KuleleriGoster();

Console.ReadLine();

void ucluCozum(int source, int target)
{
    var mid = getMid(source, target);
    kuleler[target].Push(kuleler[source].Pop());
    kuleler[mid].Push(kuleler[source].Pop());
    kuleler[mid].Push(kuleler[target].Pop());
    kuleler[target].Push(kuleler[source].Pop());
    kuleler[source].Push(kuleler[mid].Pop());
    kuleler[target].Push(kuleler[mid].Pop());
    kuleler[target].Push(kuleler[source].Pop());
}

void nLiCozum(int source, int target, int n)
{
    var mid = getMid(source, target);

    if (n < 3)
        throw new Exception("Not Enough Boncuk");

    if (n == 3)
    {
        ucluCozum(source, target);
        return;
    }

    nLiCozum(source, mid, n - 1);
    kuleler[target].Push(kuleler[source].Pop());
    nLiCozum(mid, target, n - 1);
}


void KuleleriGoster()
{
    for (int i = 0; i < kuleler.Count; i++)
    {
        foreach (var boncuk in kuleler[i])
        {
            Console.Write($"{i + 1}. Kule Boncuk: " + boncuk + " - ");
        }
        Console.WriteLine();
    }
}

int getMid(int source, int target)
{
    return Enumerable.Range(0, 3).First(x => x != source && x != target);
}
