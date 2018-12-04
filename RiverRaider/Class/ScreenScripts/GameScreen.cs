using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using RiverRaider.Class.Objects;
using RiverRaider.Class.userInterface;
using RiverRaider.Class.MapScripts;

namespace RiverRaider.Class.ScreenScripts {
    class GameScreen : Screen {
        
        Player player;
        Map map;
        UI ui;
        Texture2D debugCenterLine;
        MapObject fuel;
        MapObject fuel1;
        MapObject fuel2;
        
        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            //Load the background texture for the screen
            // mGameScreenBackground = theContent.Load<Texture2D>("textures/background/gameBackground");
            fuel = new Fuel(new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 2));
            fuel1 = new Fuel(new Vector2(Game1.WIDTH / 2 - 150, Game1.HEIGHT / 2 - 100));
            fuel2 = new Fuel(new Vector2(Game1.WIDTH / 2 + 150, Game1.HEIGHT / 2 - 200));

            player = new Player("Player", Game1.textureManager.player, new Vector2(0,0));
            ui = new UI(theContent);
            map = new Map(theContent,25);

            Map.mapObjects.Add(fuel);
            Map.mapObjects.Add(fuel1);
            Map.mapObjects.Add(fuel2);

            debugCenterLine = Game1.textureManager.centerLine;
        }

        public override void Update(GameTime theTime) {
            var kstate = Keyboard.GetState();

            player.update(theTime);
            map.updateMap(theTime);

            

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {
            

            //Draw Map
            map.drawMap(theBatch);

            // Draw player texture
            player.drawPlayer(theBatch);

            // Debug
            theBatch.Draw(debugCenterLine, new Vector2(Game1.WIDTH/2,0), Color.White);

            // Draw UI
            ui.drawUI(theBatch);

            base.Draw(theBatch);
        }
        
        public void StartGame() {
            player.resetPlayerPos();

        }
    }
}

