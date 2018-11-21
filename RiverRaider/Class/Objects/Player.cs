using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RiverRaider.Class.MapScripts;
using RiverRaider.Class.Tiles;

namespace RiverRaider.Class.Objects {
    class Player : GameObject {
        float speed = 200f;
        public static List<Bullet> bullets;
        float shootCooldown = 0.2f;
        float acceleration = 400f;

        public Player(string labels, Texture2D texture, Vector2 position) : base(labels, texture, position) {
            bullets = new List<Bullet>();
        }

        public void update(GameTime theTime) {
            // Handle shooting timer
            handleShootCooldown(theTime);

            // Handle player movement
            handleMovement(theTime);

            // Update player boundingBox
            updateBoundingBox();

            // Update bullets
            bullets.ForEach((bullet) => bullet.updateBullet(theTime));
            bullets = bullets.FindAll((bullet) => bullet.isDrawable);

            // Handle tiles collisions
            handleTilesCollisions();

        }

        private void updateBoundingBox() {
            boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        private void handleTilesCollisions() {
            Tile currentTile = Map.tiles.Find((tile) => pos.Y + texture.Height/2 + 5 >= tile.pos.Y && pos.Y <= (tile.pos.Y + tile.texture.Height));

            if (currentTile != null) {
                currentTile.setupBoundingBoxes();
                currentTile.boundingBoxes.ForEach((otherBoundingBox) => {       // TU SKONCZYLEM
                    if (otherBoundingBox.Intersects(boundingBox)) {
                            if ((boundingBox.Center.Y <= (otherBoundingBox.Center.Y - otherBoundingBox.Height / 2)) ||
                            (boundingBox.Center.Y >= (otherBoundingBox.Y + otherBoundingBox.Height / 2))) {
                            Debug.WriteLine("Uderzono z gory");
                            } else {
                            Debug.WriteLine("Uderzono z boku");
                        }
                        
                    }
                });
            }
        }

        private void handleMovement(GameTime theTime) {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.A) && this.pos.X > Game1.WIDTH/4 + 8 + this.texture.Width/2) {
                this.texture = Game1.textureManager.player_left;
                this.pos.X += -1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.D) && this.pos.X < Game1.WIDTH - Game1.WIDTH/ 4 - 8 - this.texture.Width / 2) {
                this.texture = Game1.textureManager.player_right;
                this.pos.X += 1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else {
                this.texture = Game1.textureManager.player;
            }

            if (kstate.IsKeyDown(Keys.W) && Map.mapMovingSpeed <= Map.maxMovingSpeed) {
                Map.mapMovingSpeed += acceleration * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.S) && Map.mapMovingSpeed >= Map.minMovingSpeed) {
                Map.mapMovingSpeed -= acceleration * (float)theTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && this.shootCooldown <= 0) {
                shoot();
                this.shootCooldown = 0.2f;
            }
        }

        private void handleShootCooldown(GameTime theTime) {
            if(this.shootCooldown > 0) {
                this.shootCooldown -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void shoot() {
            bullets.Add(new Bullet("Bullet",Game1.textureManager.bullet,this.pos));
        }

        public void drawPlayer(SpriteBatch theBatch) {
            theBatch.Draw(this.texture, new Vector2(this.pos.X-this.texture.Width/2,pos.Y), Color.White);

            bullets.ForEach((bullet) => bullet.drawBullet(theBatch));

        }

        public void resetPlayerPos() {
            this.pos = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 1.45f);
        }
    }
}
