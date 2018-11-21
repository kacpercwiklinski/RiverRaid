using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.userInterface {
    class UI {
        Texture2D uiBackgroundTexture { get; set; }
        Texture2D fuelBarTexture { get; set; }
        SpriteFont scoreFont { get; set; }

        public UI(ContentManager theContent ) {
            uiBackgroundTexture = Game1.textureManager.uiBackground;
            fuelBarTexture = Game1.textureManager.fuelBar;
        }

        public void drawUI(SpriteBatch theBatch) {
            theBatch.Draw(uiBackgroundTexture, new Vector2(0, Game1.HEIGHT - uiBackgroundTexture.Height), Color.White);
            theBatch.Draw(fuelBarTexture, new Vector2(Game1.WIDTH/2 - fuelBarTexture.Width/2, Game1.HEIGHT - uiBackgroundTexture.Height/1.5f), Color.White);
        }
    }
}
