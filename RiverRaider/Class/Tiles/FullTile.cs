using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRaider.Class.Tiles {
    class FullTile : Tile {
        public FullTile(Vector2 position) : base(position) {
            this.texture = Game1.textureManager.fullTile;
            tileType = TileType.FullTile;
            
            setupBoundingBoxes();
        }

        public override void setupBoundingBoxes() {
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, (int)texture.Width, (int)texture.Height);
        }
    }
}
