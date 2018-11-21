using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Fuel : MapObject {
        

        public Fuel(Vector2 position) : base(position) {
            label = "Fuel";
            this.pos = position;
            texture = Game1.textureManager.fuel;
            resetPosition();
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);


            disappearTime = 1f;
            isHit = false;
        }

        public override void updateObject(GameTime theTime) {
            if (isHit) {
                changeTexture();
                disappearTime -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
            if (disappearTime <= 0f) {
                this.onScreen = false;
            }
        }

        private void changeTexture() {
            this.texture = Game1.textureManager.fuel_explosion;
        }
    }
}
