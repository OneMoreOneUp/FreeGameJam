using Microsoft.Xna.Framework;

namespace FreeGameJam.GameObjects.Player.States
{
    public interface IPlayerState
    {
        /// <summary>
        /// Updates the sprite
        /// </summary>
        public void Update(GameTime gameTime);

        public void GoLeft();
        public void GoRight();
        public void Jump();
    }
}
