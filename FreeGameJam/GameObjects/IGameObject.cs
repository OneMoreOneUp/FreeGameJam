using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeGameJam.GameObjects
{
    public interface IGameObject
    {
        public void Update(GameTime gametime);
        public void Draw(SpriteBatch spriteBatch, Color color);
        public Rectangle GetHitbox();
    }
}