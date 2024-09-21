Person p = new();
p.Lose();
((IKeyHolder)p).Lose();

IKeyHolder p2 = p as IKeyHolder;
p2.Lose();

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
