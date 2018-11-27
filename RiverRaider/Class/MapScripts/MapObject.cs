﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum MapObjectTexture { Plane, Helicopter, Ship, Fuel}

namespace RiverRaider.Class.MapScripts {

    class MapObject {
        public String label;
        public Vector2 pos;
        public Texture2D texture;
        public Rectangle boundingBox;
        public Boolean isTriggerable;
        public Boolean onScreen;
        public float disappearTime = 1f;
        public Boolean isHit = false;

        public MapObject(String label,Texture2D texture,Vector2 position) {
            this.label = label;
            this.pos = position;
            this.texture = texture;
            onScreen = true;
            isTriggerable = true;
        }

        public MapObject(Vector2 position) {
            this.label = "Default";
            this.pos = Vector2.Zero;
            this.texture = Game1.textureManager.fuel;
            onScreen = true;
            isTriggerable = true;
        }

        public void resetPosition() {
            this.pos.X = this.pos.X - this.texture.Width / 2;
        }

        public virtual void updateObject(GameTime theTime) {
            if (isHit) {
                disappearTime -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
            if(disappearTime <= 0f) {
                this.onScreen = false;
            }
        }

        public void draw(SpriteBatch theBatch) {
            if (this.onScreen) {
                theBatch.Draw(this.texture, this.pos, Color.White);
            }
        }


    }
}