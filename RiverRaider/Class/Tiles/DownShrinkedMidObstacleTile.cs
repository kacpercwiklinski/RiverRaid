using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedMidObstacleTile : Tile
    {
        public List<Vector2> spawnPlacesHeli;

        public DownShrinkedMidObstacleTile(Vector2 position) : base(position) {

            spawnPlacesHeli = new List<Vector2>();
            spawnPlacesHeli.Add(new Vector2(this.pos.X + texture.Width / 2 + 50, this.pos.Y + texture.Height / 2));
            spawnPlacesHeli.Add(new Vector2(this.pos.X + texture.Width / 2 - 50, this.pos.Y + texture.Height / 2));

            texture = Game1.textureManager.downShrinked_mid_obstacle;
            tileType = TileType.DownShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
            
        }
    }
}
