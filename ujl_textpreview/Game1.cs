using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ujl_textpreview
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Dictionary<string, Letter> letter = new Dictionary<string, Letter>();
        string hex = "";
        string[] morehex;
        int textIndex = -1;
        int indexBg = 1;
        bool keySpaceIsPressed = false;
        bool keyLeftIsPressed = false;
        bool keyRightIsPressed = false;
        public static bool all = false;
        public static bool isRus = false;
        Texture2D alfaFont;
        Texture2D rusFont;
        Texture2D bg1;
        Texture2D bg2;
        Texture2D bg3;
        SpriteFont spriteFont;
        Texture2D fontBg;

        private void LetterInit()
        {
            letter.Add("0A", new Letter(2));
            letter.Add("20", new Letter(3));

            letter.Add("2C", new Letter(0, new Rectangle(7, 0, 7, 15))); //,
            letter.Add("2E", new Letter(0, new Rectangle(14, 0, 6, 15))); //.
            letter.Add("3F", new Letter(0, new Rectangle(26, 0, 10, 15))); //?
            letter.Add("21", new Letter(0, new Rectangle(36, 0, 8, 15))); //!
            letter.Add("5E", new Letter(0, new Rectangle(44, 0, 10, 15), 2)); //^
            letter.Add("28", new Letter(0, new Rectangle(52, 0, 11, 15), 2)); //(
            letter.Add("29", new Letter(0, new Rectangle(63, 0, 10, 15))); //)
            letter.Add("27", new Letter(0, new Rectangle(73, 0, 4, 15))); //'
            letter.Add("22", new Letter(0, new Rectangle(77, 0, 7, 15))); //"
            letter.Add("2D", new Letter(0, new Rectangle(84, 0, 7, 15))); //-
            letter.Add("24", new Letter(0, new Rectangle(91, 0, 9, 15))); //$
            letter.Add("25", new Letter(0, new Rectangle(100, 0, 11, 15))); //%
            letter.Add("23", new Letter(0, new Rectangle(111, 0, 13, 15))); //#
            letter.Add("26", new Letter(0, new Rectangle(124, 0, 11, 15))); //&
            letter.Add("2A", new Letter(0, new Rectangle(135, 0, 10, 15))); //*
            letter.Add("40", new Letter(0, new Rectangle(0, 75, 13, 15))); //@
            letter.Add("3B", new Letter(0, new Rectangle(18, 75, 9, 15))); //;
            letter.Add("3A", new Letter(0, new Rectangle(27, 75, 7, 15))); //:

            letter.Add("30", new Letter(0, new Rectangle(145, 0, 10, 15))); //0
            letter.Add("31", new Letter(0, new Rectangle(155, 0, 6, 15))); //1
            letter.Add("32", new Letter(0, new Rectangle(161, 0, 9, 15), 2)); //2
            letter.Add("33", new Letter(0, new Rectangle(170, 0, 9, 15))); //3
            letter.Add("34", new Letter(0, new Rectangle(179, 0, 9, 15))); //4
            letter.Add("35", new Letter(0, new Rectangle(188, 0, 10, 15))); //5
            letter.Add("36", new Letter(0, new Rectangle(198, 0, 10, 15))); //6
            letter.Add("37", new Letter(0, new Rectangle(208, 0, 9, 15))); //7
            letter.Add("38", new Letter(0, new Rectangle(217, 0, 10, 15))); //8
            letter.Add("39", new Letter(0, new Rectangle(227, 0, 8, 15))); //9

            letter.Add("E1", new Letter(0, new Rectangle(229, 30, 9, 15))); //э
            letter.Add("E0", new Letter(0, new Rectangle(238, 30, 10, 15))); //ф
            letter.Add("E9", new Letter(0, new Rectangle(19, 45, 9, 15))); //Ч
            letter.Add("E8", new Letter(0, new Rectangle(28, 45, 9, 15))); //Ц
            letter.Add("EA", new Letter(0, new Rectangle(38, 45, 10, 15))); //Х
            letter.Add("EB", new Letter(0, new Rectangle(48, 45, 11, 15))); //Д
            letter.Add("ED", new Letter(0, new Rectangle(59, 45, 7, 15))); //х
            letter.Add("EC", new Letter(0, new Rectangle(66, 45, 9, 15))); //Я
            letter.Add("EE", new Letter(0, new Rectangle(75, 45, 9, 15))); //У
            letter.Add("EF", new Letter(0, new Rectangle(84, 45, 9, 15))); //Ъ
            letter.Add("F3", new Letter(0, new Rectangle(93, 45, 8, 15))); //Ь
            letter.Add("F2", new Letter(0, new Rectangle(101, 45, 10, 15))); //Э
            letter.Add("F4", new Letter(0, new Rectangle(111, 45, 9, 15))); //Т
            letter.Add("F6", new Letter(0, new Rectangle(120, 45, 10, 15))); //Л
            letter.Add("FA", new Letter(0, new Rectangle(130, 45, 9, 15))); //С
            letter.Add("F9", new Letter(0, new Rectangle(139, 45, 10, 15))); //ю
            letter.Add("E7", new Letter(0, new Rectangle(179, 45, 9, 15))); //З
            letter.Add("DF", new Letter(0, new Rectangle(213, 45, 12, 15))); //Ы
            letter.Add("9C", new Letter(0, new Rectangle(225, 45, 13, 15))); //Щ
            letter.Add("C0", new Letter(0, new Rectangle(28, 60, 12, 15))); //Ю

            letter.Add("41", new Letter(0, new Rectangle(236, 0, 10, 15))); //A
            letter.Add("61", new Letter(1, new Rectangle(245, 15, 9, 15), 1)); //a
            letter.Add("42", new Letter(0, new Rectangle(245, 0, 9, 15), 1)); //B
            letter.Add("62", new Letter(1, new Rectangle(0, 30, 9, 15))); //b
            letter.Add("43", new Letter(0, new Rectangle(0, 15, 9, 15))); //C
            letter.Add("63", new Letter(1, new Rectangle(8, 30, 9, 15), 1)); //c
            letter.Add("44", new Letter(0, new Rectangle(8, 15, 10, 15), 1)); //D
            letter.Add("64", new Letter(1, new Rectangle(17, 30, 11, 15))); //d
            letter.Add("45", new Letter(0, new Rectangle(18, 15, 10, 15), 1)); //E
            letter.Add("65", new Letter(1, new Rectangle(28, 30, 8, 15), 1)); //e
            letter.Add("46", new Letter(0, new Rectangle(28, 15, 12, 15), 1)); //F
            letter.Add("66", new Letter(1, new Rectangle(36, 30, 10, 15))); //f
            letter.Add("47", new Letter(0, new Rectangle(40, 15, 9, 15), 2)); //G
            letter.Add("67", new Letter(1, new Rectangle(46, 30, 9, 15), 2)); //g
            letter.Add("48", new Letter(0, new Rectangle(49, 15, 11, 15), 1)); //H
            letter.Add("68", new Letter(1, new Rectangle(55, 30, 8, 15), 2)); //h
            letter.Add("49", new Letter(0, new Rectangle(60, 15, 10, 15), 1)); //I
            letter.Add("69", new Letter(1, new Rectangle(63, 30, 7, 15))); //i
            letter.Add("4A", new Letter(0, new Rectangle(70, 15, 10, 15), 1)); //J
            letter.Add("6A", new Letter(1, new Rectangle(70, 30, 8, 15), 1)); //j
            letter.Add("4B", new Letter(0, new Rectangle(80, 15, 10, 15), 1)); //K
            letter.Add("6B", new Letter(1, new Rectangle(78, 30, 9, 15))); //k
            letter.Add("4C", new Letter(0, new Rectangle(90, 15, 8, 15), 1)); //L
            letter.Add("6C", new Letter(1, new Rectangle(87, 30, 7, 15), 1)); //l
            letter.Add("4D", new Letter(0, new Rectangle(98, 15, 13, 15))); //M
            letter.Add("6D", new Letter(1, new Rectangle(94, 30, 11, 15), 1)); //m
            letter.Add("4E", new Letter(0, new Rectangle(112, 15, 10, 15), 1)); //N
            letter.Add("6E", new Letter(1, new Rectangle(105, 30, 8, 15))); //n
            letter.Add("4F", new Letter(0, new Rectangle(122, 15, 10, 15), 1)); //O
            letter.Add("6F", new Letter(1, new Rectangle(113, 30, 8, 15))); //o
            letter.Add("50", new Letter(0, new Rectangle(132, 15, 11, 15), 1)); //P
            letter.Add("70", new Letter(1, new Rectangle(121, 30, 9, 15))); //p
            letter.Add("51", new Letter(0, new Rectangle(143, 15, 11, 15), 1)); //Q
            letter.Add("71", new Letter(1, new Rectangle(130, 30, 8, 15))); //q
            letter.Add("52", new Letter(0, new Rectangle(154, 15, 9, 15), 1)); //R
            letter.Add("72", new Letter(1, new Rectangle(138, 30, 8, 15))); //r
            letter.Add("53", new Letter(0, new Rectangle(163, 15, 9, 15), 1)); //S
            letter.Add("73", new Letter(1, new Rectangle(146, 30, 8, 15))); //s
            letter.Add("54", new Letter(0, new Rectangle(172, 15, 9, 15), 1)); //T
            letter.Add("74", new Letter(1, new Rectangle(154, 30, 8, 15))); //t
            letter.Add("55", new Letter(0, new Rectangle(181, 15, 10, 15), 2)); //U
            letter.Add("75", new Letter(1, new Rectangle(162, 30, 8, 15), 1)); //u
            letter.Add("56", new Letter(0, new Rectangle(191, 15, 10, 15), 1)); //V
            letter.Add("76", new Letter(1, new Rectangle(170, 30, 8, 15))); //v
            letter.Add("57", new Letter(0, new Rectangle(201, 15, 13, 15))); //W
            letter.Add("77", new Letter(1, new Rectangle(178, 30, 11, 15))); //w
            letter.Add("58", new Letter(0, new Rectangle(214, 15, 11, 15), 2)); //X
            letter.Add("78", new Letter(1, new Rectangle(189, 30, 9, 15))); //x
            letter.Add("59", new Letter(0, new Rectangle(225, 15, 9, 15), 1)); //Y
            letter.Add("79", new Letter(1, new Rectangle(198, 30, 10, 15))); //y
            letter.Add("5A", new Letter(0, new Rectangle(234, 15, 11, 15), 1)); //Z
            letter.Add("7A", new Letter(1, new Rectangle(208, 30, 9, 15))); //z
        }
        void LetterDraw(SpriteBatch sprite)
        {
            int yOffset = 193;

            List<int> totalLenght = new List<int>();
            List<Letter> letterList = new List<Letter>();
            if (textIndex == -1)
            {
                hex = hex.Replace("-", "");
                int count = 0;
                int lenght = 0;
                for (int i = 0; i < hex.Length / 2; i++)
                {
                    Letter let;
                    if (letter.TryGetValue(hex.Substring(i * 2, 2), out let))
                    {
                        switch (let.L_SpecialChar)
                        {
                            case 0 or 1:
                                lenght += let.L_Rectangle.Width - let.L_Offset;
                                break;
                            case 2:
                                totalLenght.Add(lenght);
                                lenght = 0;
                                count = 0;
                                break;
                            case 3:
                                lenght += 8;
                                break;
                        }
                        letterList.Add(let);
                        count++;
                    }
                }
                totalLenght.Add(lenght);
            }
            else if(textIndex >= 0)
            {
                string hexId = morehex[textIndex].Replace("-", "");
                int count = 0;
                int lenght = 0;
                for (int i = 0; i < hexId.Length / 2; i++)
                {
                    Letter let;
                    if (letter.TryGetValue(hexId.Substring(i * 2, 2), out let))
                    {
                        switch (let.L_SpecialChar)
                        {
                            case 0 or 1:
                                lenght += let.L_Rectangle.Width - let.L_Offset;
                                break;
                            case 2:
                                totalLenght.Add(lenght);
                                lenght = 0;
                                count = 0;
                                break;
                            case 3:
                                lenght += 8;
                                break;
                        }
                        letterList.Add(let);
                        count++;
                    }
                }
                totalLenght.Add(lenght);
            }


            int startPosition = 160 - (totalLenght[0] / 2);
            int line = 1;
            foreach (Letter letter in letterList)
            {
                switch (letter.L_SpecialChar)
                {
                    case 0:
                        if(isRus == true)
                        {
                            sprite.Draw(rusFont, new Vector2(startPosition - letter.L_Offset, yOffset), letter.L_Rectangle, Color.White);
                        }
                        else
                        {
                            sprite.Draw(alfaFont, new Vector2(startPosition - letter.L_Offset, yOffset), letter.L_Rectangle, Color.White);
                        }
                        startPosition += letter.L_Rectangle.Width - letter.L_Offset;
                        break;
                    case 1:
                        if (isRus == true)
                        {
                            sprite.Draw(rusFont, new Vector2(startPosition - letter.L_Offset, yOffset + 1), letter.L_Rectangle, Color.White);
                        }
                        else
                        {
                            sprite.Draw(alfaFont, new Vector2(startPosition - letter.L_Offset, yOffset + 1), letter.L_Rectangle, Color.White);
                        }
                        startPosition += letter.L_Rectangle.Width - letter.L_Offset;
                        break;
                    case 2:
                        startPosition = 160 - (totalLenght[0 + line] / 2);
                        line++;
                        yOffset += 15;
                        break;
                    case 3:
                        startPosition += 8;
                        break;
                }
            }
        }
        public Game1(string text = null, string[] moreText = null)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 320;
            _graphics.PreferredBackBufferHeight = 240;
            if(text != null)
            {
                hex = text;
            }
            if(moreText != null)
            {
                morehex = moreText;
                textIndex = 0;
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            LetterInit();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            alfaFont = Content.Load<Texture2D>("alfa-font");
            rusFont = Content.Load<Texture2D>("rus-font");
            bg1 = Content.Load<Texture2D>("bg1");
            bg2 = Content.Load<Texture2D>("bg2");
            bg3 = Content.Load<Texture2D>("bg3");
            spriteFont = Content.Load<SpriteFont>("File");
            fontBg = Content.Load<Texture2D>("fontBg");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && keySpaceIsPressed == false)
            {
                if (indexBg == 3)
                {
                    indexBg = 1;
                }
                else
                {
                    indexBg++;
                }
                keySpaceIsPressed = true;
            }
            else if(Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                keySpaceIsPressed = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && keyLeftIsPressed == false && textIndex != -1)
            {
                keyLeftIsPressed = true;
                if (textIndex == 0)
                {
                    textIndex = morehex.Length - 1;
                }
                else
                {
                    textIndex--;
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Left) && textIndex != -1)
            {
                keyLeftIsPressed = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && keyRightIsPressed == false && textIndex != -1)
            {
                keyRightIsPressed = true;
                if (textIndex == morehex.Length - 1)
                {
                    textIndex = 0;
                }
                else
                {
                    textIndex++;
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Right) && textIndex != -1)
            {
                keyRightIsPressed = false;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

#if RELEASE
            switch (indexBg)
            {
                case 1:
                    _spriteBatch.Draw(bg1, new Vector2(0, 0), Color.White);
                    break;
                case 2:
                    _spriteBatch.Draw(bg2, new Vector2(0, 0), Color.White);
                    break;
                case 3:
                    _spriteBatch.Draw(bg3, new Vector2(0, 0), Color.White);
                    break;
            }
#endif
            if(textIndex != -1)
            {
                _spriteBatch.Draw(fontBg, new Vector2(0, 0), new Rectangle(0, 0, 126, 18), Color.White);
                _spriteBatch.DrawString(spriteFont, (textIndex + 1).ToString() +"of" + morehex.Length.ToString() + "; bg" + indexBg.ToString(), new Vector2(0, 0), Color.White);
            }
            else
            {
                _spriteBatch.Draw(fontBg, new Vector2(0, 0), new Rectangle(0, 0, 30, 18), Color.White);
                _spriteBatch.DrawString(spriteFont, "bg" + indexBg.ToString(), new Vector2(0, 0), Color.White);
            }
            LetterDraw(_spriteBatch);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}