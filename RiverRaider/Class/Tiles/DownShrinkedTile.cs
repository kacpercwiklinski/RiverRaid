using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedTile : Tile {
        public DownShrinkedTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.downShrinked;
            tileType = TileType.DownShrinked;
        }
    }
}
