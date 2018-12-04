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

            setupBoundingBoxes();
        }

        public override void setupBoundingBoxes() {
            boundingBoxes = new List<Rectangle>();

            // Left side
            boundingBoxes.Add(new Rectangle((int)pos.X, (int)pos.Y + 156, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 64, (int)pos.Y + 252, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 128, (int)pos.Y + 348, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 192, (int)pos.Y + 444, 64, 96));

            // Right side
            boundingBoxes.Add(new Rectangle((int)pos.X + 384, (int)pos.Y + 444, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 448, (int)pos.Y + 348, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 512, (int)pos.Y + 252, 64, 96));
            boundingBoxes.Add(new Rectangle((int)pos.X + 576, (int)pos.Y + 156, 64, 96));

            // Middle obstacle
            boundingBoxes.Add(new Rectangle((int)pos.X + 180, (int)pos.Y, 60, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 400, (int)pos.Y, 56, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 240, (int)pos.Y + 80, 160, 80));
            boundingBoxes.Add(new Rectangle((int)pos.X + 272, (int)pos.Y + 160, 92, 71));
        }
    }
}
