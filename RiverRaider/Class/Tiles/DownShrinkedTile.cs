using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using RiverRaider.Class.MapScripts;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedTile : Tile {

        public List<Vector2> spawnPlaces;
        
        public static List<MapObject> mapObjects = new List<MapObject>();

        public DownShrinkedTile(Vector2 position) : base(position) {

            spawnPlaces = new List<Vector2>();
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2 + 100, this.pos.Y + texture.Height / 2 - 150));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2 - 100, this.pos.Y + texture.Height / 2 - 150));


            

            texture = Game1.textureManager.downShrinked;
            tileType = TileType.DownShrinked;
            base.setupBoundingBox();
            base.getColorData();

        }

       










    }
}
