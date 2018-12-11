using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedMidObstacleTile : Tile {
        public DownShrinkedMidObstacleTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.downShrinked_mid_obstacle;
            tileType = TileType.DownShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
