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
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
