DVDPlayer dvd = new();
IPlayable playable = new DVDPlayer();

dvd.Pause();
dvd.Play();
playable.Stop();

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
