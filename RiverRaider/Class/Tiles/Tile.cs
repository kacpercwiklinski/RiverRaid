﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.MapScripts;
using RiverRaider.Class.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TileType { UpShrinked, FullTile, DownShrinked, UpShrinked_mid_obstacle, DownShrinked_mid_obstacle }

namespace RiverRaider.Class.Tiles {
    class Tile {
        Random random = new Random();
        public int maxEnemies = 5;
        public Texture2D texture;
        public Vector2 pos;
        public Rectangle boundingBox;
        public Boolean onScreen = true;
        public TileType tileType;
        public Color[] colorData;
        public List<Vector2> spawnPlaces;

        public Tile(Texture2D texture,Vector2 position, TileType tileType) {
            pos = position;
            this.texture = texture;
            this.tileType = tileType;
            spawnPlaces = new List<Vector2>();
        }

        public Tile(Vector2 position) {
            pos = position;
            this.texture = Game1.textureManager.fullTile;
            this.tileType = TileType.FullTile;
            spawnPlaces = new List<Vector2>();
        }

        public void generateMapObject(Vector2 vector2)
        {
            int r = random.Next(0, 3);

            switch (r) {
                case 0:
                    Map.mapObjects.Add(new Ship(vector2));
                    break;
                case 1:
                    Map.mapObjects.Add(new Helicopter(vector2));
                    break;
                case 2:
                    Map.mapObjects.Add(new Fuel(vector2));
                    break;
            }
        }

        public virtual void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, Game1.textureManager.fullTile.Width, Game1.textureManager.fullTile.Height);
        }

        public void drawTile(SpriteBatch theBatch) {
            theBatch.Draw(Game1.textureManager.fullTile, this.pos, Color.White);
            theBatch.Draw(this.texture, this.pos, Color.White);
        }

        public void updateBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, Game1.textureManager.fullTile.Width, Game1.textureManager.fullTile.Height);
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }

    }
}
