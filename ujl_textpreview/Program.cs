namespace ujl_textpreview
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                using (var game = new Game1(args[0]))
                {
                    game.Run();
                }
            }
        }
    }
}