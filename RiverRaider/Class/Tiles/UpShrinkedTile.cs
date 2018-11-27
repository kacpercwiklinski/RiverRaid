using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class UpShrinkedTile : Tile {
        public UpShrinkedTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.upShrinked;
            tileType = TileType.UpShrinked;

            setupBoundingBoxes();
        }

        public override void setupBoundingBoxes() {
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}
