using Microsoft.Xna.Framework;
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
        int maxEnemies = 3;
        public Texture2D texture;
        public Vector2 pos;
        public List<Rectangle> boundingBoxes = new List<Rectangle>();
        public Boolean onScreen = true;
        public TileType tileType;

        public Tile(Texture2D texture,Vector2 position, TileType tileType) {
            pos = position;
            this.texture = texture;
            this.tileType = tileType;
        }

        public Tile(Vector2 position) {
            pos = position;
            this.texture = Game1.textureManager.fullTile;
            this.tileType = TileType.FullTile;
        }

        public void generateEnemies() {
            for (int i = 0; i < random.Next(0, maxEnemies+1); i++) {
                // TODO: SPAWN ENEMIES
            }
        }

        public virtual void setupBoundingBoxes() {

        }

        public void drawTile(SpriteBatch theBatch) {
            theBatch.Draw(this.texture, this.pos, Color.White);
           // boundingBoxes.ForEach((bb) => LineBatch.drawBoundingBox(bb, theBatch));
        }

    }
}
