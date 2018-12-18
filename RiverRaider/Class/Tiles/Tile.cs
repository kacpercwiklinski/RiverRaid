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
        public Rectangle boundingBox;
        public Boolean onScreen = true;
        public TileType tileType;
        public Color[] colorData;

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

        public void generateEnemyShip(Vector2 vector2)
        {
                Ship ship;
                ship = new Ship(vector2);
                Map.mapObjects.Add(ship);
        }

        public void genreateEnemyHeli(Vector2 vector2)
        {
            Helicopter helicopter;
            helicopter = new Helicopter(vector2);
            Map.mapObjects.Add(helicopter);
        }


        public void generateFuel(Vector2 vector2)
        {
            Fuel fuel;
            fuel = new Fuel(vector2);
            Map.mapObjects.Add(fuel);
            
        }


        public virtual void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, Game1.textureManager.fullTile.Width, Game1.textureManager.fullTile.Height);
        }

        public void drawTile(SpriteBatch theBatch) {
            theBatch.Draw(Game1.textureManager.fullTile, this.pos, Color.White);
            theBatch.Draw(this.texture, this.pos, Color.White);
          //  LineBatch.drawBoundingBox(this.boundingBox, theBatch);
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
