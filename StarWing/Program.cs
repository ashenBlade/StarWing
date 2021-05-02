namespace StarWing
{
    public static class Program
    {
        static void Main(string[] args)
        {
            using (var game = new StarWing())
            {
                game.Run();
            }
        }
    }
}