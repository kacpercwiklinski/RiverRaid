using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRaider.Class.Tiles {
    class FullTile : Tile {

        public List<Vector2> spawnPlaces;
        public List<Vector2> spawnPlacesShip;

        public FullTile(Vector2 position) : base(position) {

            spawnPlaces = new List<Vector2>();
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width/2 , this.pos.Y + texture.Height/2 - 150));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2 + 100, this.pos.Y + texture.Height / 2 - 150));
            

            spawnPlacesShip = new List<Vector2>();
            spawnPlacesShip.Add(new Vector2(this.pos.X + 155, this.pos.Y + texture.Height / 2 - 80));
            spawnPlacesShip.Add(new Vector2(this.pos.X  + 255, this.pos.Y + texture.Height / 2 - 80));





            this.texture = Game1.textureManager.fullTile;
            tileType = TileType.FullTile;
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
