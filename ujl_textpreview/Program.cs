namespace ujl_textpreview
{
    public static class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            using(var game = new Game1("54-65-73-74"))
            {
                game.Run();
            }
#else

            switch (args.Length)
            {
                case 1:
                    using (var game = new Game1(args[0]))
                    {
                        game.Run();
                    }
                    break;
                case 2:
                    if (args[0] == "rus")
                    {
                        Game1.isRus = true;
                        using (var game = new Game1(args[1]))
                        {
                            game.Run();
                        }
                    }
                    else if (args[0] == "all")
                    {
                        using (var game = new Game1(moreText: args[1].Split('`')))
                        {
                            game.Run();
                        }
                    }
                    break;
                case 3:
                    if (args[0] == "all" & args[1] == "rus")
                    {
                        Game1.isRus = true;
                        using (var game = new Game1(moreText: args[2].Split('`')))
                        {
                            game.Run();
                        }
                    }
                    break;
            }
#endif
        }
    }
}