using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Saiyuki_VS_Skywalker
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        Labels label;
        Labels label2;
        Labels label3;
        Labels omaewamoushindeiru;
        Labels sasukekun;

       

        SkywalkerStuff TheForce;
        Ryu ryu;
        Chun_LiStuff chunli;
        MBison mbison;

        Texture2D backgroundimage;
        Vector2 backgroundposition;
        Color backgroundcolor;

        public static Viewport Viewport { get { return temp; } }
        public static Viewport Viewport2 { get { return temp; } }
        public static Viewport Viewport3 { get { return temp; } }
        private static Viewport temp;
        private static Viewport temp2;
        private static Viewport temp3;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundimage = Content.Load<Texture2D>("background2");
            backgroundposition = new Vector2(0, 0);
            backgroundcolor = Color.White;
            temp = GraphicsDevice.Viewport;
            temp2 = GraphicsDevice.Viewport;
            temp3 = GraphicsDevice.Viewport;
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            label = new Labels(Color.Black, new Vector2(10, 10), Content.Load<SpriteFont>("font"), "Ryu's Health");
            label2 = new Labels(Color.Black, new Vector2(270, 10), Content.Load<SpriteFont>("font"), "MBison's Health");
            label3 = new Labels(Color.Black, new Vector2(550, 10), Content.Load<SpriteFont>("font"), "Chun-Li's Health");
            sasukekun = new Labels(Color.Red, new Vector2(200, 200), Content.Load<SpriteFont>("font"), "bakugo x kirishima");
           omaewamoushindeiru = new Labels(Color.Red, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Content.Load<SpriteFont>("font"), "OMAE WA MOU SHINDEIRU");
            TheForce = new SkywalkerStuff(Content.Load<Texture2D>("skywalker"), new Vector2(600, 500), new Vector2(3), Color.White, new List<Frame>());
            ryu = new Ryu(Content.Load<Texture2D>("ryu"), new Vector2(400, 400), new Vector2(3), Color.White, new List<Frame>());
            chunli = new Chun_LiStuff(Content.Load<Texture2D>("chun-li"), new Vector2(600, 400), new Vector2(3), Color.White, new List<Frame>());
            mbison = new MBison(Content.Load<Texture2D>("mbison"), new Vector2(200, 400), new Vector2(3), Color.White, new List<Frame>());

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// chun-li

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit


            TheForce.Update(gameTime, Keyboard.GetState());
            ryu.Update(gameTime, Keyboard.GetState());
            chunli.Update(gameTime, Keyboard.GetState());
            mbison.Update(gameTime, Keyboard.GetState());

            base.Update(gameTime);

            // THIS IS CHUN LI ATTACK STUFF
            if (chunli.punch == true)
            {
                if (chunli.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health + 0;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health + 0;
                    }
                    else
                    {
                        ryu.health--;
                        ryu.hithigh = true;
                       
                    }


                }
                else if (chunli.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health + 0;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health + 0;
                    }
                    else
                    {
                        mbison.health--;
                        mbison.hithigh = true;
                    }

                }
            }
            if (chunli.regkick == true)
            {
                if (chunli.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 1;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 2;
                    }
                    else
                    {
                        ryu.health = ryu.health - 2;
                    }

                }
                else if (chunli.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 2;
                    }
                    else
                    {
                        mbison.health = mbison.health - 2;
                        mbison.hithigh = true;
                    }
                }
            }
            if (chunli.spinkick == true)
            {
                if (chunli.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 1;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 3;
                    }
                    else
                    {
                        ryu.health = ryu.health - 3;
                        ryu.hithigh = true;
                    }

                }
                else if (chunli.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 3;
                    }
                    else
                    {
                        mbison.health = mbison.health - 3;
                        mbison.hithigh = true;
                    }

                }
            }
            if (chunli.jumpkick == true)
            {
                if (chunli.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 1;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 2;
                    }
                    else
                    {
                        ryu.health = ryu.health - 2;
                        ryu.hithigh = true;
                    }

                }
                else if (chunli.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 2;
                    }
                    else
                    {
                        mbison.health = mbison.health - 2;
                        mbison.hithigh = true;
                    }
                }
            }
            //END OF CHUN-LI ATTACK STUFF

            //START OF RYU ATTACK STUFF

            if (ryu.punch == true)
            {
                if (ryu.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 2;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health + 0;
                    }
                    else
                    {
                        mbison.health = mbison.health - 3;
                    }
                }
                else if (ryu.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 0;
                    }
                    else
                    {
                        chunli.health = chunli.health - 3;
                    }

                }
            }
            if (ryu.kick == true)
            {
                if (ryu.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 2;
                    }
                    else
                    {
                        mbison.health = mbison.health - 2;
                    }

                }
                else if (ryu.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 2;
                    }
                    else
                    {
                        chunli.health = chunli.health - 2;
                    }

                }
            }
            if (ryu.jumppunch == true)
            {
                if (ryu.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 3;
                    }
                    mbison.health = mbison.health - 3;
                }
                else if (ryu.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 3;
                    }
                    else
                    {
                        chunli.health = chunli.health - 3;
                    }

                }
            }
            if (ryu.jumpkick == true)
            {
                if (ryu.Hitbox.Intersects(mbison.Hitbox))
                {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 1;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 2;
                    }
                    else
                    {
                        mbison.health = mbison.health - 2;
                    }

                }
                else if (ryu.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 2;
                    }
                    else
                    {
                        chunli.health = chunli.health - 2;
                    }
                }

                
            }
            if (ryu.hadouken == true)
            {
                if (ryu.Hitbox.Intersects(mbison.Hitbox))
               {
                    label2.text = $"MBison's Health: {mbison.health}";
                    if (mbison.block == true)
                    {
                        mbison.health = mbison.health - 9000;
                    }
                    else if (mbison.crouch == true)
                    {
                        mbison.health = mbison.health - 9000;
                    }
                    else
                    {
                        mbison.health = mbison.health - 9000;
                    }
                }
                else if (ryu.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 9000;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 9000;
                    }
                    else
                    {
                        chunli.health = chunli.health - 9000;
                    }
                }
            }
            //END OF RYU ATTACK STUFF

            //START OF MBISON ATTACK STUFF
            if (mbison.punch == true)
            {
                if (mbison.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 2;
                    }
                    else
                    {
                        chunli.health = chunli.health - 2;
                    }
                }
                else if (mbison.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";

                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 1;
                    }
                    else if (ryu.crouch == true)
                    {//rawrXD
                        ryu.health = ryu.health - 0;
                    }//rawrXD
                    else
                    {
                        ryu.health = ryu.health - 2;
                    }
                }
            }
            if (mbison.hardpunch == true)
            {
                if (mbison.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 2;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else
                    {
                        chunli.health = chunli.health - 3;
                    }

                }
                else if (mbison.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 2;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 1;
                    }
                    else
                    {
                        ryu.health = ryu.health - 3;
                    }

                }
            }
            if (mbison.kick == true)
            {
                if (mbison.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 1;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 2;
                    }
                    else
                    {
                        chunli.health = chunli.health - 2;
                    }
                }
                else if (mbison.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 2;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 3;
                    }
                    else
                    {
                        ryu.health = ryu.health - 3;
                    }
                }
            }
            if (mbison.spinkick == true)
            {
                if (mbison.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 3;
                    }
                    else if (chunli.crouch == true)
                    {
                        chunli.health = chunli.health - 4;
                    }
                    else
                    {
                        chunli.health = chunli.health - 4;
                    }
                }
                else if (mbison.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 3;
                    }
                    else if (ryu.crouch == true)
                    {
                        ryu.health = ryu.health - 4;
                    }
                    else
                    {
                        ryu.health = ryu.health - 4;
                    }
                }
            }
            
            if (mbison.psychothingy == true)
            {
                if (mbison.Hitbox.Intersects(chunli.Hitbox))
                {
                    label3.text = $"Chun-li's Health: {chunli.health}";
                    if (chunli.block == true)
                    {
                        chunli.health = chunli.health - 400000000;
                    }
                    else
                    {
                        chunli.health = chunli.health - 20;
                    }

                }
                if (mbison.Hitbox.Intersects(ryu.Hitbox))
                {
                    label.text = $"Ryu's Health: {ryu.health}";
                    if (ryu.block == true)
                    {
                        ryu.health = ryu.health - 400000000;
                    }
                    ryu.health = ryu.health - 20;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            //GraphicsDevice.Clear(Color.OliveDrab);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundimage, backgroundposition, backgroundcolor);
            TheForce.Draw(spriteBatch);
            ryu.Draw(spriteBatch, pixel);
            chunli.Draw(spriteBatch, pixel);
            mbison.Draw(spriteBatch, pixel);
           label.Draw(spriteBatch);
            label2.Draw(spriteBatch);
            label3.Draw(spriteBatch);
           
                omaewamoushindeiru.Draw(spriteBatch);
            
            //omaewamoushindeiru.Draw(spriteBatch);
            sasukekun.Draw(spriteBatch);


            spriteBatch.Draw(pixel, new Rectangle(10, 40, ryu.health, 20), Color.Goldenrod);
            spriteBatch.Draw(pixel, new Rectangle(280, 40, mbison.health, 20), Color.Goldenrod);
            spriteBatch.Draw(pixel, new Rectangle(570, 40, chunli.health, 20), Color.Goldenrod);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
