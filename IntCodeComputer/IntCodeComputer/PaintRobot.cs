using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace IntCodeComputer {
    public class PaintRobot {
        Computer computer;
        
        int direction = 0;
        int dirClamp = 0;

        int posX = 100;
        int posY = 100;

        public List<Tuple<int, int>> panelsDrawn;

        public List<List<string>> panels;
        int panelsWidth = 200;
        int panelsHeight = 200;

        CalculationResult calculationResult1;
        CalculationResult calculationResult2;

        public PaintRobot(Computer computer, List<int> userInputs = null) {
            this.computer = computer;

            calculationResult1 = computer.Calculate(userInputs, returnOnOutPut: true);
            calculationResult2 = computer.Calculate(returnOnOutPut: true);

            panelsDrawn = new List<Tuple<int, int>>();

            panels = new List<List<string>>();
            for(int y = 0; y < panelsHeight; y++) {
                panels.Add(new List<string>());
                for(int x = 0; x < panelsWidth; x++) {
                    panels[y].Add(".");
                }
            } 
        }

        public void Run() {            
            if (!calculationResult1.finished && !calculationResult2.finished) {                
                PaintPanel((int)calculationResult1.output);

                Move((int)calculationResult2.output);

                var colorOfCurrentPos = panels[posY][posX] == "." ? 0 : 1;
                calculationResult1 = computer.Calculate(new List<int> { colorOfCurrentPos }, true);
                calculationResult2 = computer.Calculate(new List<int> { colorOfCurrentPos }, true);
            }            
        }

        public void PaintPanel(int color) {
            if(color == 0) {
                panels[posY][posX] = ".";
            } else {
                panels[posY][posX] = "#";
            }

            var drawPosTuple = new Tuple<int, int>(posX, posY);
            if (!panelsDrawn.Contains(drawPosTuple)) {
                panelsDrawn.Add(drawPosTuple);
            }
        }

        public void Move(int dir) {
            if(dir == 0) {
                direction += 90;
            } else {
                direction -= 90;
            }

            dirClamp = direction % 360;
            if(dirClamp < 0) {
                dirClamp = 360 + dirClamp;
            }

            switch (dirClamp) {
                case 0: // UP
                    posY -= 1;
                    break;

                case 90: // LEFT
                    posX -= 1;
                    break;

                case 180: // DOWN
                    posY += 1;
                    break;

                case 270: // RIGHT
                    posX += 1;
                    break;
            }
        }

        public void PaintGrid() {
            //Console.Clear();            
            for (int y = 0; y < panels.Count; y++) {
                var gridRow = "";
                for(int x = 0; x < panels[y].Count; x++) {
                    if (x == posX && y == posY) {
                        switch (dirClamp) {
                            case 0: // UP
                                gridRow += "^";
                                break;

                            case 90: // LEFT
                                gridRow += "<";
                                break;

                            case 180: // DOWN
                                gridRow += "v";
                                break;

                            case 270: // RIGHT
                                gridRow += ">";
                                break;

                            default:
                                gridRow += "X";
                                Console.WriteLine(direction);
                                Console.WriteLine(dirClamp);
                                break;
                        }
                    }
                    else {
                        gridRow += panels[y][x];
                    }
                }
                Console.WriteLine(gridRow);
            }
            Console.WriteLine("PosX: " + posX + " PosY: " + posY);
        }

        public void PaintGridMono(SpriteBatch spritebatch, Texture2D texture, int ts) {                    
            for (int y = 0; y < panels.Count; y++) {                
                for (int x = 0; x < panels[y].Count; x++) {
                    if (x == posX && y == posY) {
                        spritebatch.Draw(texture, new Rectangle(x * ts, y * ts, ts, ts), Color.Red);
                    }
                    else {
                        if (panels[y][x] == ".") {
                            spritebatch.Draw(texture, new Rectangle(x * ts, y * ts, ts, ts), Color.Black);
                        } else {
                            spritebatch.Draw(texture, new Rectangle(x * ts, y * ts, ts, ts), Color.White);
                        }

                    }
                }
            }
        }
    }
}
