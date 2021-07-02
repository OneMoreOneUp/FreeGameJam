// Dirt block Class
// Author : Jared Lawson.524

using FreeGameJam.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FreeGameJam.GameObjects.Blocks
{
    public class TopGrass : IBlock
    {
        private readonly ISprite sprite;
        private Point position;
        private readonly bool rigid;
        private readonly int width, height;
        private readonly float layer;

        public TopGrass(Point position, float layer, bool rigid = true)
        {
            sprite = SpriteFactory.Instance.CreateSprite("TopGrass");
            this.position = position;
            this.rigid = rigid;
            this.layer = layer;
            //TODO: Add way to get width and height
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, position, color, layer);
        }

        public Rectangle GetHitbox()
        {
            return new Rectangle(position.X - (width / 2), position.Y - (height / 2), width, height);
        }

        public bool IsRigid()
        {
            return rigid;
        }
    }
}
