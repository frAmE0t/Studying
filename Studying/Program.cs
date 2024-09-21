DVDPlayer dvd = new();
IPlayable playable = new DVDPlayer();

Console.WriteLine("Class instance:");
dvd.Pause();
dvd.Play();
//dvd.Stop(); ERROR

Console.WriteLine();

Console.WriteLine("Interface instance:");
playable.Stop();
playable.Pause();
playable.Play();

interface IPlayable
{
    void Play();
    void Pause();

    void Stop()
    {
        Console.WriteLine("Default implementation of Stop");
    }
}

class DVDPlayer : IPlayable
{
    public void Pause()
    {
        Console.WriteLine("DVD player is pausing");
    }

    public void Play()
    {
        Console.WriteLine("DVD player is playing");
    }
}
