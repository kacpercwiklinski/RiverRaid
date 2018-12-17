using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class UpShrinkedMidObstacleTile : Tile {
        public UpShrinkedMidObstacleTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.upShrinked_mid_obstacle;
            tileType = TileType.UpShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
            
        }  
    }
}
