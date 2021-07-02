// SpriteFactory Class
//
// @author Brian Sharp and Benjamin J Nagel

using FreeGameJam.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace FreeGameJam.Sprite
{
    class SpriteFactory
    {
        private Dictionary<string, Texture2D> spriteSheets;
        private readonly XmlDocument spriteData;

        public static SpriteFactory Instance { get; } = new SpriteFactory();

        /// <summary>
        /// Private consuctor so that only one instance is created.
        /// </summary>
        private SpriteFactory()
        {
            spriteSheets = new Dictionary<string, Texture2D>();
            spriteData = new XmlDocument();
        }

        public void LoadAllTextures(ContentManager content)
        {
            //Load spritesheets
            spriteSheets.Add("Forest_Tileset", content.Load<Texture2D>("forest_tileset.png"));
            spriteSheets.Add("Forest_BG_Day1", content.Load<Texture2D>("forest_bg_day1.png"));
            spriteSheets.Add("Forest_BG_Day2", content.Load<Texture2D>("forest_bg_day2.png"));
            spriteSheets.Add("Forest_BG_Day3", content.Load<Texture2D>("forest_bg_day3.png"));
            spriteSheets.Add("Forest_BG_Night1", content.Load<Texture2D>("forest_bg_night1.png"));
            spriteSheets.Add("Forest_BG_Night2", content.Load<Texture2D>("forest_bg_night2.png"));
            spriteSheets.Add("Forest_BG_Night3", content.Load<Texture2D>("forest_bg_night3.png"));
            spriteSheets.Add("Forest_BG_Trees", content.Load<Texture2D>("forest_bg_trees.png"));
            spriteSheets.Add("Forest_Trees", content.Load<Texture2D>("forest_trees.png"));
            spriteSheets.Add("Heavy_Bandit", content.Load<Texture2D>("HeavyBandit.png"));
            spriteSheets.Add("Light_Bandit", content.Load<Texture2D>("LightBandit.png"));
            spriteSheets.Add("Warrior", content.Load<Texture2D>("Warrior_Sheet-Effect.png"));

            //Load sprite data
            spriteData.Load(@"../../../Sprites/SpriteData.xml");
        }

        private Texture2D GetSpriteSheet(string name)
        {
            return spriteSheets[name];
        }

        private static void AddFrame(XmlNode frame, List<Rectangle> frameList)
        {
            IFormatProvider format = CultureInfo.CurrentCulture;

            int x = int.Parse(frame.ChildNodes[0].InnerXml, format);
            int y = int.Parse(frame.ChildNodes[1].InnerXml, format);
            int width = int.Parse(frame.ChildNodes[2].InnerXml, format);
            int height = int.Parse(frame.ChildNodes[3].InnerXml, format);

            frameList.Add(new Rectangle(x, y, width, height));
        }

        public ISprite CreateSprite(string name, Direction? facing = null)
        {
            // Get the xml node corresponding to the given name
            XmlNode node = spriteData.DocumentElement.SelectSingleNode("sprite[@name = \"" + name + "\"]");

            // Variables for creating the sprite
            ISprite sprite;
            List<Rectangle> frameList = new List<Rectangle>();
            bool fixedCenter = false, bottomRightOrigin = false;

            // Set the spriteSheet to be used
            Texture2D spriteSheet = GetSpriteSheet(node.FirstChild.InnerText);

            // Iterate over all the frame nodes 
            for (int i = 1; i < node.ChildNodes.Count; i++)
            {
                XmlNode frameNode = node.ChildNodes[i];
                XmlAttribute direction = (XmlAttribute)frameNode.Attributes.GetNamedItem("direction");

                // Only add frame nodes that have no direction or are matching the given direction
                if (facing == null || direction.Value == facing.ToString())
                {
                    AddFrame(frameNode, frameList);

                    XmlAttribute fixedCenterAttribute = (XmlAttribute)frameNode.Attributes.GetNamedItem("fixedCenter");
                    fixedCenter = fixedCenterAttribute != null && fixedCenterAttribute.Value == "true";

                    XmlAttribute bottomRightOriginAttribute = (XmlAttribute)frameNode.Attributes.GetNamedItem("bottomRightOrigin");
                    bottomRightOrigin = bottomRightOriginAttribute != null && bottomRightOriginAttribute.Value == "true";
                }
            }

            // Create the sprite object
            if (frameList.Count == 1)
            {
                sprite = new StaticSprite(spriteSheet, frameList[0]);
            }
            else
            {
                sprite = new AnimatedSprite(spriteSheet, frameList, fixedCenter, bottomRightOrigin);
            }

            return sprite;
        }
    }
}

