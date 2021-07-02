using FreeGameJam.Sprite;
using Microsoft.Xna.Framework;

namespace FreeGameJam.GameObjects.Player
{
    public interface IPlayer : IGameObject
    {
        public void MoveLeft();
        public void MoveRight();

        public void Jump();

        /// <summary>
        /// Updates the location of the player
        /// </summary>
        /// <param name="x">Adds this to the old X value</param>
        /// <param name="y">Adds this to the old Y value</param>
        public void UpdateLocation(int x, int y);

        /// <summary>
        /// Gets the location of the player
        /// </summary>
        /// <returns>Returns the location of the player</returns>
        public Point GetLocation();

        public ISprite GetSprite();
    }
}
