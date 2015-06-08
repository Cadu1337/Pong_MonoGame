using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jogo.classes
{
    public class Ball : GameObject
    {
        public Vector2 velocidade;
        public Random aleatorio;
        public float speed = 1.0f;
        
        public Ball()
        {
            aleatorio = new Random();
        }
        public void Launch(float speed) 
        {
            Position = new Vector2(Game1.ScreenWidht/2 - Texture.Width/2, Game1.ScreenHeight/2 -  Texture.Height);
            float rotation = (float)(Math.PI / 2 + (aleatorio.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            velocidade.X = (float)Math.Sin(rotation);
            velocidade.Y = (float)Math.Cos(rotation);

            if (aleatorio.Next(2) == 1)
            {
                velocidade.X *= -1;
            }

            velocidade *= speed;
            }

            public void CheckWallCollision() { 
        
            if( Position.Y  < 0){
                Position.Y = 0;
                velocidade.Y *= -1;
        
            }

            if(Position.Y + Texture.Height > Game1.ScreenHeight){
                    Position.Y = Game1.ScreenHeight - Texture.Height;
                    velocidade.Y *= -1;
            
            }
                if(Position.Y == Game1.player1.Position.Y + 192){
                    velocidade.Y *= -1;
                }
             }
            public void CheckPlayerCollision(Player player){
                   
                if ((Position.X < player.Position.X + player.Texture.Width) &&
                    (Position.Y > player.Position.Y) && (Position.Y < player.Position.Y + player.Texture.Height))
                {
                   velocidade.X *= -1;
                }
            }

            public void CheckPlayer2Collision(Player player){

                if ((Position.X > player.Position.X - player.Texture.Width) &&
                    (Position.Y > player.Position.Y) && (Position.Y < player.Position.Y + player.Texture.Height))
                {
                    velocidade.X *= -1;
                }
            }
            public override void Move(Vector2 amount){

                base.Move(amount); 
            }

            public void Update(GameTime gameTime){
                Position += velocidade * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                speed *= 0.5f;
                System.Diagnostics.Debug.WriteLine("SPEED " + speed);
                
            }
         
        
    }
}
