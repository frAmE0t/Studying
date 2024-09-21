Console.WriteLine("Explicit and implicit interface realisation");

public interface IGamePlayer
{
    void Lose();
}

public interface IKeyHolder
{
    void Lose();
}

public class Person : IGamePlayer, IKeyHolder
{
    public void Lose() // explicit realisation
    {
        //Realisation
    }

    void IKeyHolder.Lose() //implicit realisation
    {
        //Realisatin
    }
}
