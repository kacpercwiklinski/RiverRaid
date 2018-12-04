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

    public enum HorizontalCollision {  Left,Right, None }

    class Player : GameObject {
        float speed = 200f;
        public static List<Bullet> bullets;
        float shootCooldown = 0.2f;
        float acceleration = 400f;
        HorizontalCollision horizontalCollision = HorizontalCollision.None;


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

            // Handle tiles collisions
            handleTilesCollisions();

            // Update bullets
            bullets.ForEach((bullet) => bullet.updateBullet(theTime));
            bullets = bullets.FindAll((bullet) => bullet.isDrawable);
        }

        private void updateBoundingBox() {
            boundingBox = new Rectangle((int)this.pos.X- Game1.textureManager.player.Width/2, (int)this.pos.Y, Game1.textureManager.player.Width, Game1.textureManager.player.Height);
        }

        private void handleTilesCollisions() {
            List<Rectangle> currentBoundingBoxes = new List<Rectangle>();

            Tile currentTile = Map.tiles.Find((tile) => (pos.Y + texture.Height + 5) >= tile.pos.Y && pos.Y <= (tile.pos.Y + tile.texture.Height));
            Tile nextTile = Map.tiles.Find((tile) => tile.pos.Y <= currentTile.pos.Y - tile.texture.Height + 10 && tile.pos.Y >= currentTile.pos.Y - tile.texture.Height - 10);

            if (currentTile != null && nextTile != null) {
                currentTile.setupBoundingBoxes();
                nextTile.setupBoundingBoxes();

                currentBoundingBoxes.AddRange(currentTile.boundingBoxes);
                currentBoundingBoxes.AddRange(nextTile.boundingBoxes);

                currentBoundingBoxes.ForEach((otherBoundingBox) => {
                    if (otherBoundingBox.Intersects(boundingBox)) {
                        if ((this.boundingBox.Center.Y <= (otherBoundingBox.Center.Y - otherBoundingBox.Height / 2)) ||
                        (this.boundingBox.Center.Y >= (otherBoundingBox.Center.Y + otherBoundingBox.Height / 2))) {
                            // TODO: Plane explode
                            Debug.WriteLine("Bum");
                        } else {
                            if (this.boundingBox.Left < otherBoundingBox.Right && this.boundingBox.Left > otherBoundingBox.Left) {
                                this.horizontalCollision = HorizontalCollision.Left;
                            } else if (this.boundingBox.Right > otherBoundingBox.Left && this.boundingBox.Right < otherBoundingBox.Right) {
                                this.horizontalCollision = HorizontalCollision.Right;
                            }
                        }
                    }
                });
            }
            
        }

        private void handleMovement(GameTime theTime) {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.A) && this.pos.X > Game1.WIDTH/4 + 8 + this.texture.Width/2 && this.horizontalCollision != HorizontalCollision.Left) {
                this.texture = Game1.textureManager.player_left;
                this.pos.X += -1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.D) && this.pos.X < Game1.WIDTH - Game1.WIDTH/ 4 - 8 - this.texture.Width / 2 && this.horizontalCollision != HorizontalCollision.Right) {
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


            horizontalCollision = HorizontalCollision.None;
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
          //  LineBatch.drawBoundingBox(this.boundingBox, theBatch);

            bullets.ForEach((bullet) => bullet.drawBullet(theBatch));

        }

        public void resetPlayerPos() {
            this.pos = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 1.45f);
        }
    }
}
