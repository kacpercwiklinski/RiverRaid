using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class UpShrinkedMidObstacleTile : Tile {

       
        public List<Vector2> spawnPlaces;

        public UpShrinkedMidObstacleTile(Vector2 position) : base(position) {

            spawnPlaces = new List<Vector2>();
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y + texture.Height / 2 - 300));


            

            texture = Game1.textureManager.upShrinked_mid_obstacle;
            tileType = TileType.UpShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
            
        }  
    }
}
