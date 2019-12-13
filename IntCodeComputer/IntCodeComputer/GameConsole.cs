using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntCodeComputer {
    public class GameConsole {
        Computer computer;

        public Dictionary<Tuple<long, long>, long> gameGrid;

        bool finished = false;
        long score = 0;

        long ballX = 0;
        long paddleX = 0;
        int inputDir = 0;

        public GameConsole(Computer computer) {
            this.computer = computer;
            gameGrid = new Dictionary<Tuple<long, long>, long>();
        }

        public void Run() {
            if (!finished) {
                var userInput = new List<int> { inputDir };

                var x = computer.Calculate(userInput, returnOnOutPut: true);
                var y = computer.Calculate(userInput, returnOnOutPut: true);
                var tile = computer.Calculate(userInput, returnOnOutPut: true);

                var coords = new Tuple<long, long>(x.output, y.output);

                if (coords.Item1 == -1 && coords.Item2 == 0) { // show score
                    score = tile.output;
                    //Console.WriteLine("Score: " + score);
                }
                else {
                    if (!gameGrid.ContainsKey(coords)) {
                        gameGrid.Add(coords, tile.output);
                    }
                    else {
                        gameGrid[coords] = tile.output;
                    }
                }

                if (tile.output == 4) {
                    ballX = x.output;
                }

                if (tile.output == 3) {
                    paddleX = x.output;
                }

                Draw();

                if (paddleX > ballX) inputDir = -1;
                if (paddleX < ballX) inputDir = 1;
                if (paddleX == ballX) inputDir = 0;

                if (x.finished || y.finished || tile.finished) finished = true;
            }
        }

        public void Draw() {
            long gridStartX = gameGrid.First().Key.Item1;
            long gridEndX = gameGrid.First().Key.Item1;
            long gridStartY = gameGrid.First().Key.Item2;
            long gridEndY = gameGrid.First().Key.Item2;
            foreach (var key in gameGrid.Keys) {
                if (key.Item1 < gridStartX) gridStartX = key.Item1;
                if (key.Item1 > gridEndX) gridEndX = key.Item1;
                if (key.Item1 < gridStartY) gridStartY = key.Item2;
                if (key.Item1 > gridEndY) gridEndY = key.Item2;
            }

            var tileCount = 0;
            for (long y = gridStartY; y < gridEndY + 1; y++) {
                for (long x = gridStartX; x < gridEndX + 1; x++) {
                    var coords = new Tuple<long, long>(x, y);

                    if (gameGrid.ContainsKey(coords)) {
                        Console.Write(gameGrid[coords]);

                        if (gameGrid[coords] == 2)
                            tileCount++;
                    }
                    else {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(tileCount);
        }

        public void DrawMono(SpriteBatch spriteBatch, Texture2D texture, int ts) {
            long gridStartX = gameGrid.First().Key.Item1;
            long gridEndX = gameGrid.First().Key.Item1;
            long gridStartY = gameGrid.First().Key.Item2;
            long gridEndY = gameGrid.First().Key.Item2;
            foreach (var key in gameGrid.Keys) {
                if (key.Item1 < gridStartX) gridStartX = key.Item1;
                if (key.Item1 > gridEndX) gridEndX = key.Item1;
                if (key.Item1 < gridStartY) gridStartY = key.Item2;
                if (key.Item1 > gridEndY) gridEndY = key.Item2;
            }

            var tileCount = 0;
            for (long y = gridStartY; y < gridEndY + 1; y++) {
                for (long x = gridStartX; x < gridEndX + 1; x++) {
                    var coords = new Tuple<long, long>(x, y);

                    if (gameGrid.ContainsKey(coords)) {
                        if(gameGrid[coords] == 3) {
                            spriteBatch.Draw(texture, new Rectangle((int)x * ts, (int)y * ts, ts, ts / 2), Color.White);
                        }
                        else if (gameGrid[coords] == 4) {
                            spriteBatch.Draw(texture, new Rectangle((int)x * ts, (int)y * ts, ts / 2, ts / 2), Color.White);
                        }
                        else if (gameGrid[coords] != 0) {
                            spriteBatch.Draw(texture, new Rectangle((int)x * ts, (int)y * ts, ts, ts), Color.White);
                        }

                        if (gameGrid[coords] == 2)
                            tileCount++;
                    }
                }
            }
        }
    }
}
