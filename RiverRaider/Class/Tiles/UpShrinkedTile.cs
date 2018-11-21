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
            boundingBoxes = new List<Rectangle>();

            // Left side
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y, 192, 192));
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y+ 192, 128, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y + 288, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 192, (int)pos.Y, 64, 96));

            // Right side
            boundingBoxes.Add(new Rectangle((int)pos.X + 448, (int)pos.Y, 192, 192));
            boundingBoxes.Add(new Rectangle((int)pos.X + 512, (int)pos.Y + 192, 128, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 576, (int)pos.Y + 288, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 384, (int)pos.Y, 64, 96));
        }
    }
}
