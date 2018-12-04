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

            setupBoundingBoxes();
        }

        public override void setupBoundingBoxes() {
            boundingBoxes = new List<Rectangle>();

            // Left side
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y, 192, 192));
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y + 192, 128, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y + 288, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 192, (int)pos.Y, 64, 96));

            // Right side
            boundingBoxes.Add(new Rectangle((int)pos.X + 448, (int)pos.Y, 192, 192));
            boundingBoxes.Add(new Rectangle((int)pos.X + 512, (int)pos.Y + 192, 128, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 576, (int)pos.Y + 288, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 384, (int)pos.Y, 64, 96));

            // Middle obstacle
            boundingBoxes.Add(new Rectangle((int)pos.X + 180, (int)pos.Y + 460, 276, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 399, (int)pos.Y + 460, 57, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 240, (int)pos.Y + 380, 160, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 272, (int)pos.Y + 309, 92, 71));


        }
    }
}
