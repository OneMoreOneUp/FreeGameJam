using FreeGameJam.GameObjects.Player.States;
using FreeGameJam.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeGameJam.GameObjects.Player
{
    public class Player : IPlayer
    {
        private IPlayerState state;
        private ISprite sprite;
        private Point position;

        public Player (Point position)
        {
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, position, color, 0f);
        }

        public void MoveLeft()
        {
            state.GoLeft();
        }

        public void MoveRight()
        {
            state.GoRight();
        }

        public void Jump()
        {
            state.Jump();
        }

        protected internal bool UpdateSprite()
        {
            return sprite.UpdateFrame();
        }

        protected internal void SetSprite(ISprite newSprite)
        {
            sprite = newSprite;
        }

        protected internal void SetState(IPlayerState newState)
        {
            state = newState;
        }

        public void UpdateLocation(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }

        public Rectangle GetHitbox()
        {
            return Rectangle.Empty;
            //return new Rectangle(position.X - (width / 2), position.Y - (height / 2), width, height);
        }

        public Point GetLocation()
        {
            return position;
        }

        public ISprite GetSprite()
        {
            return sprite;
        }
    }
}
