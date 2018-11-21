using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.Objects;
using RiverRaider.Class.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.MapScripts {
    class Map {

        Random r;

        public const int maxMovingSpeed = 1000;
        public const int minMovingSpeed = 0;

        Tile firstTile;
        public static List<Tile> tiles;
        Tile currentTile;

        public static List<MapObject> mapObjects;
        public static float mapMovingSpeed = 100f;
        
        public Map(ContentManager theContent, int tilesNumber) {
            r = new Random();

            mapObjects = new List<MapObject>();
            tiles = new List<Tile>();
            firstTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0));
            tiles.Add(firstTile);

            currentTile = firstTile;
            generateMap(tilesNumber);
        }

        private void generateMap(int tilesNumber) {
            for (int i = 1; i <= tilesNumber; i++) {
                Tile nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0));

                if (currentTile.tileType == TileType.FullTile) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new UpShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.UpShrinked) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new DownShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new DownShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.DownShrinked) {
                    int random = r.Next(0, 3);
                    if (random == 0) {
                        nextTile = new UpShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.fullTile.Height - 1));
                    } else if (random == 2) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.UpShrinked_mid_obstacle) {
                    nextTile = new DownShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked.Height - 1));
                } else if (currentTile.tileType == TileType.DownShrinked_mid_obstacle) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.fullTile.Height - 1));
                    } else if (random == 1) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    } 
                }

                tiles.Add(nextTile);
                currentTile = nextTile;
            }
        }

        public void updateMap(GameTime theTime) {

            // Remove bullets above the screen
            removeHiddenBullets();

            // Move and remove objects below screen
            mapObjects.ForEach((mapobject) => {
                mapobject.updateObject(theTime);
                if (mapobject.pos.Y > Game1.HEIGHT + 10) {
                    mapobject.onScreen = false;
                }
                mapobject.pos.Y += mapMovingSpeed * (float)theTime.ElapsedGameTime.TotalSeconds;
            });

            // Move and remove tiles below screen
            tiles.ForEach((tile) => {
                if (tile.pos.Y > Game1.HEIGHT) {
                    tile.onScreen = false;
                }

                tile.pos.Y += mapMovingSpeed * (float)theTime.ElapsedGameTime.TotalSeconds;
            });

            mapObjects = mapObjects.FindAll((mapObject) => mapObject.onScreen);
            tiles = tiles.FindAll((tile) => tile.onScreen);
        }

        public void drawMap(SpriteBatch theBatch) {
            tiles.ForEach((tile) => {
                tile.drawTile(theBatch);
                    tile.boundingBoxes.ForEach((bb) => {
                        // Draw debug point at bounding box position
                        theBatch.Draw(Game1.textureManager.debugPoint, new Vector2(bb.X,bb.Y), Color.White);
                    });
                });
        }

        private void removeHiddenBullets() {
            Player.bullets = Player.bullets.FindAll((bullet) => bullet.pos.Y > -200);
        }
    }
}
