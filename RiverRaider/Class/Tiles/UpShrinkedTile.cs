using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {


    class UpShrinkedTile : Tile {

        public List<Vector2> spawnPlacesHeli;
        public List<Vector2> spawnPlacesShip;

        public UpShrinkedTile(Vector2 position) : base(position) {


            spawnPlacesHeli = new List<Vector2>();
            spawnPlacesHeli.Add(new Vector2(this.pos.X + texture.Width / 2 + 30, this.pos.Y + texture.Height / 2 - 200));
            
            spawnPlacesShip = new List<Vector2>();
            spawnPlacesShip.Add(new Vector2(this.pos.X + texture.Width / 2 - 40, this.pos.Y + texture.Height / 2  -150));
            

            texture = Game1.textureManager.upShrinked;
            tileType = TileType.UpShrinked;
            base.setupBoundingBox();
            base.getColorData();
            
        }
    }
}
