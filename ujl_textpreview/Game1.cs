using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using System.Collections.Generic;

namespace ujl_textpreview
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Dictionary<string, Letter> letter = new Dictionary<string, Letter>();
        string hex = "";
        Texture2D font;
        Texture2D alfafont;
        Texture2D BG;
        Texture2D BG1;

        private void LetterInit()
        {
            letter.Add("0A", new Letter(2));
            letter.Add("20", new Letter(3));

            letter.Add("41", new Letter(0, new Rectangle(236, 0, 10, 15))); //A
            letter.Add("61", new Letter(1, new Rectangle(245, 15, 9, 15), 1)); //a
            letter.Add("42", new Letter(0, new Rectangle(245, 0, 9, 15), 1)); //B
            letter.Add("62", new Letter(1, new Rectangle(0, 30, 9, 15), 0)); //b
            letter.Add("43", new Letter(0, new Rectangle(0, 15, 9, 15))); //C
            letter.Add("63", new Letter(1, new Rectangle(8, 30, 9, 15), 1)); //c
            letter.Add("44", new Letter(0, new Rectangle(8, 15, 10, 15), 1)); //D
            letter.Add("64", new Letter(1, new Rectangle(17, 30, 11, 15), 0)); //d
            letter.Add("45", new Letter(0, new Rectangle(18, 15, 10, 15), 1)); //E
            letter.Add("65", new Letter(1, new Rectangle(28, 30, 8, 15), 1)); //e
            letter.Add("46", new Letter(0, new Rectangle(28, 15, 12, 15), 1)); //F
            letter.Add("66", new Letter(1, new Rectangle(36, 30, 10, 15), 0)); //f
            letter.Add("47", new Letter(0, new Rectangle(40, 15, 9, 15), 2)); //G
            letter.Add("67", new Letter(1, new Rectangle(46, 30, 9, 15), 2)); //g
            letter.Add("48", new Letter(0, new Rectangle(49, 15, 11, 15), 1)); //H
            letter.Add("68", new Letter(1, new Rectangle(55, 30, 8, 15), 2)); //h
            letter.Add("49", new Letter(0, new Rectangle(60, 15, 10, 15), 1)); //I
            letter.Add("69", new Letter(1, new Rectangle(63, 30, 7, 15), 0)); //i
            letter.Add("4A", new Letter(0, new Rectangle(70, 15, 10, 15), 1)); //J
            letter.Add("6A", new Letter(1, new Rectangle(70, 30, 8, 15), 1)); //j
            letter.Add("4B", new Letter(0, new Rectangle(80, 15, 10, 15), 1)); //K
            letter.Add("6B", new Letter(1, new Rectangle(78, 30, 9, 15), 0)); //k
            letter.Add("4C", new Letter(0, new Rectangle(90, 15, 8, 15), 1)); //L
            letter.Add("6C", new Letter(1, new Rectangle(87, 30, 7, 15), 1)); //l
            letter.Add("4D", new Letter(0, new Rectangle(98, 15, 13, 15), 0)); //M
            letter.Add("6D", new Letter(1, new Rectangle(94, 30, 11, 15), 1)); //m
            letter.Add("4E", new Letter(0, new Rectangle(112, 15, 10, 15), 1)); //N
            letter.Add("6E", new Letter(1, new Rectangle(105, 30, 8, 15), 0)); //n
            letter.Add("4F", new Letter(0, new Rectangle(122, 15, 10, 15), 1)); //O
            letter.Add("6F", new Letter(1, new Rectangle(113, 30, 8, 15), 0)); //o
            letter.Add("50", new Letter(0, new Rectangle(132, 15, 11, 15), 1)); //P
            letter.Add("70", new Letter(1, new Rectangle(121, 30, 9, 15), 0)); //p
            letter.Add("51", new Letter(0, new Rectangle(143, 15, 11, 15), 1)); //Q
            letter.Add("71", new Letter(1, new Rectangle(130, 30, 8, 15), 0)); //q
            letter.Add("52", new Letter(0, new Rectangle(154, 15, 9, 15), 1)); //R
            letter.Add("72", new Letter(1, new Rectangle(138, 30, 8, 15), 0)); //r
            letter.Add("53", new Letter(0, new Rectangle(163, 15, 9, 15), 1)); //S
            letter.Add("73", new Letter(1, new Rectangle(146, 30, 8, 15), 0)); //s
            letter.Add("54", new Letter(0, new Rectangle(172, 15, 9, 15), 1)); //T
            letter.Add("74", new Letter(1, new Rectangle(154, 30, 8, 15), 0)); //t
            letter.Add("55", new Letter(0, new Rectangle(181, 15, 10, 15), 2)); //U
            letter.Add("75", new Letter(1, new Rectangle(162, 30, 8, 15), 1)); //u
            letter.Add("56", new Letter(0, new Rectangle(191, 15, 10, 15), 1)); //V
            letter.Add("76", new Letter(1, new Rectangle(170, 30, 8, 15), 0)); //v
            letter.Add("57", new Letter(0, new Rectangle(201, 15, 13, 15), 0)); //W
            letter.Add("77", new Letter(1, new Rectangle(178, 30, 11, 15), 0)); //w
            letter.Add("58", new Letter(0, new Rectangle(214, 15, 11, 15), 2)); //X
            letter.Add("78", new Letter(1, new Rectangle(189, 30, 9, 15), 0)); //x
            letter.Add("59", new Letter(0, new Rectangle(225, 15, 9, 15), 1)); //Y
            letter.Add("79", new Letter(1, new Rectangle(198, 30, 10, 15), 0)); //y
            letter.Add("5A", new Letter(0, new Rectangle(234, 15, 11, 15), 1)); //Z
            letter.Add("7A", new Letter(1, new Rectangle(208, 30, 9, 15), 0)); //z
        }
        void LetterDraw(SpriteBatch sprite)
        {
            hex = hex.Replace("-", "");

            int yOffset = 193;

            List<int> totalLenght = new List<int>();
            List<Letter> letterList = new List<Letter>();

            int count = 0;
            int lenght = 0;
            for (int i = 0; i < hex.Length / 2; i++)
            {
                Letter let = null;
                if(letter.TryGetValue(hex.Substring(i * 2, 2),out let))
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
                            lenght += 9;
                            break;
                    }
                    letterList.Add(let);
                    count++;
                }
            }
            totalLenght.Add(lenght);

            int startPosition = 160 - (totalLenght[0] / 2);
            int line = 1;
            foreach (Letter letter in letterList)
            {
                switch (letter.L_SpecialChar)
                {
                    case 0:
                        sprite.Draw(alfafont, new Vector2(startPosition - letter.L_Offset, yOffset), letter.L_Rectangle, Color.White);
                        startPosition += letter.L_Rectangle.Width - letter.L_Offset;
                        break;
                    case 1:
                        sprite.Draw(alfafont, new Vector2(startPosition - letter.L_Offset, yOffset + 1), letter.L_Rectangle, Color.White);
                        startPosition += letter.L_Rectangle.Width - letter.L_Offset;
                        break;
                    case 2:
                        startPosition = 160 - (totalLenght[0 + line] / 2);
                        line++;
                        yOffset += 15;
                        break;
                    case 3:
                        startPosition += 9;
                        break;
                }
            }
        }
        public Game1(string text)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 320;
            _graphics.PreferredBackBufferHeight = 240;
            hex = text;
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
            font = Content.Load<Texture2D>("font");
            alfafont = Content.Load<Texture2D>("alfa-font");
            BG = Content.Load<Texture2D>("bg");
            BG1 = Content.Load<Texture2D>("bg1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(BG, new Vector2(0, 0), Color.White);

            LetterDraw(_spriteBatch);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}