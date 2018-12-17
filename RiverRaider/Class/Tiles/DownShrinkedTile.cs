using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using RiverRaider.Class.MapScripts;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedTile : Tile {

        public static List<MapObject> mapObjects = new List<MapObject>();

        public DownShrinkedTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.downShrinked;
            tileType = TileType.DownShrinked;
            base.setupBoundingBox();
            base.getColorData();

        }

       










    }
}
