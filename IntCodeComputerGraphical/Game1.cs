﻿using IntCodeComputer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntCodeComputerGraphical {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Textures
        Texture2D pixel;
        SpriteFont gameFont;

        //Computer stuff
        public GameConsole gameConsole;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 800;
            this.IsMouseVisible = true;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize() {
            var input = new long[] { 2, 380, 379, 385, 1008, 3031, 179032, 381, 1005, 381, 12, 99, 109, 3032, 1101, 0, 0, 383, 1102, 1, 0, 382, 20102, 1, 382, 1, 21002, 383, 1, 2, 21101, 0, 37, 0, 1105, 1, 578, 4, 382, 4, 383, 204, 1, 1001, 382, 1, 382, 1007, 382, 46, 381, 1005, 381, 22, 1001, 383, 1, 383, 1007, 383, 26, 381, 1005, 381, 18, 1006, 385, 69, 99, 104, -1, 104, 0, 4, 386, 3, 384, 1007, 384, 0, 381, 1005, 381, 94, 107, 0, 384, 381, 1005, 381, 108, 1106, 0, 161, 107, 1, 392, 381, 1006, 381, 161, 1102, 1, -1, 384, 1106, 0, 119, 1007, 392, 44, 381, 1006, 381, 161, 1101, 1, 0, 384, 21001, 392, 0, 1, 21102, 24, 1, 2, 21101, 0, 0, 3, 21101, 138, 0, 0, 1106, 0, 549, 1, 392, 384, 392, 20101, 0, 392, 1, 21101, 24, 0, 2, 21102, 3, 1, 3, 21101, 0, 161, 0, 1106, 0, 549, 1101, 0, 0, 384, 20001, 388, 390, 1, 21001, 389, 0, 2, 21101, 180, 0, 0, 1106, 0, 578, 1206, 1, 213, 1208, 1, 2, 381, 1006, 381, 205, 20001, 388, 390, 1, 21001, 389, 0, 2, 21101, 0, 205, 0, 1105, 1, 393, 1002, 390, -1, 390, 1102, 1, 1, 384, 20102, 1, 388, 1, 20001, 389, 391, 2, 21101, 0, 228, 0, 1105, 1, 578, 1206, 1, 261, 1208, 1, 2, 381, 1006, 381, 253, 21002, 388, 1, 1, 20001, 389, 391, 2, 21102, 253, 1, 0, 1105, 1, 393, 1002, 391, -1, 391, 1101, 0, 1, 384, 1005, 384, 161, 20001, 388, 390, 1, 20001, 389, 391, 2, 21101, 0, 279, 0, 1106, 0, 578, 1206, 1, 316, 1208, 1, 2, 381, 1006, 381, 304, 20001, 388, 390, 1, 20001, 389, 391, 2, 21102, 304, 1, 0, 1106, 0, 393, 1002, 390, -1, 390, 1002, 391, -1, 391, 1102, 1, 1, 384, 1005, 384, 161, 21002, 388, 1, 1, 20102, 1, 389, 2, 21101, 0, 0, 3, 21102, 1, 338, 0, 1105, 1, 549, 1, 388, 390, 388, 1, 389, 391, 389, 21002, 388, 1, 1, 21002, 389, 1, 2, 21101, 0, 4, 3, 21101, 0, 365, 0, 1105, 1, 549, 1007, 389, 25, 381, 1005, 381, 75, 104, -1, 104, 0, 104, 0, 99, 0, 1, 0, 0, 0, 0, 0, 0, 324, 21, 21, 1, 1, 23, 109, 3, 21201, -2, 0, 1, 22101, 0, -1, 2, 21102, 0, 1, 3, 21101, 0, 414, 0, 1106, 0, 549, 21201, -2, 0, 1, 22102, 1, -1, 2, 21102, 1, 429, 0, 1106, 0, 601, 2102, 1, 1, 435, 1, 386, 0, 386, 104, -1, 104, 0, 4, 386, 1001, 387, -1, 387, 1005, 387, 451, 99, 109, -3, 2105, 1, 0, 109, 8, 22202, -7, -6, -3, 22201, -3, -5, -3, 21202, -4, 64, -2, 2207, -3, -2, 381, 1005, 381, 492, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 481, 21202, -4, 8, -2, 2207, -3, -2, 381, 1005, 381, 518, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 507, 2207, -3, -4, 381, 1005, 381, 540, 21202, -4, -1, -1, 22201, -3, -1, -3, 2207, -3, -4, 381, 1006, 381, 529, 21202, -3, 1, -7, 109, -8, 2106, 0, 0, 109, 4, 1202, -2, 46, 566, 201, -3, 566, 566, 101, 639, 566, 566, 2101, 0, -1, 0, 204, -3, 204, -2, 204, -1, 109, -4, 2106, 0, 0, 109, 3, 1202, -1, 46, 594, 201, -2, 594, 594, 101, 639, 594, 594, 20102, 1, 0, -2, 109, -3, 2105, 1, 0, 109, 3, 22102, 26, -2, 1, 22201, 1, -1, 1, 21101, 601, 0, 2, 21102, 815, 1, 3, 21101, 0, 1196, 4, 21101, 0, 630, 0, 1105, 1, 456, 21201, 1, 1835, -2, 109, -3, 2106, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 0, 0, 2, 0, 2, 2, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 2, 0, 0, 2, 2, 0, 2, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 0, 2, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 0, 0, 2, 2, 0, 2, 2, 2, 2, 0, 1, 1, 0, 2, 0, 0, 2, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 2, 0, 2, 2, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 0, 0, 1, 1, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 0, 1, 1, 0, 2, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 2, 0, 0, 2, 2, 2, 0, 0, 2, 0, 0, 2, 2, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 2, 2, 0, 1, 1, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 2, 2, 0, 0, 2, 0, 2, 0, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 2, 0, 0, 1, 1, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 0, 0, 2, 2, 2, 2, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 0, 2, 0, 2, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 2, 0, 2, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 2, 0, 0, 2, 2, 2, 0, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 1, 1, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 2, 0, 2, 2, 0, 0, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 0, 2, 2, 2, 0, 1, 1, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 2, 2, 2, 0, 0, 0, 0, 0, 2, 0, 0, 2, 2, 2, 0, 2, 2, 0, 0, 2, 2, 0, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 1, 1, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 2, 0, 0, 2, 2, 0, 0, 2, 0, 0, 0, 0, 1, 1, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 2, 2, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 0, 1, 1, 0, 2, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 2, 2, 2, 0, 0, 2, 0, 0, 0, 2, 0, 2, 2, 2, 0, 0, 0, 2, 2, 0, 0, 0, 2, 2, 0, 0, 2, 2, 2, 0, 2, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 94, 84, 7, 6, 83, 20, 72, 3, 78, 13, 11, 21, 96, 9, 37, 43, 14, 37, 93, 70, 55, 53, 86, 83, 69, 6, 8, 95, 92, 4, 13, 65, 73, 23, 56, 5, 94, 21, 87, 34, 29, 67, 41, 80, 63, 65, 30, 50, 5, 82, 52, 16, 6, 91, 54, 6, 48, 64, 78, 92, 96, 46, 27, 31, 22, 53, 89, 86, 33, 82, 49, 46, 91, 51, 72, 34, 25, 6, 91, 65, 75, 83, 48, 60, 92, 87, 64, 69, 26, 64, 94, 70, 42, 10, 76, 96, 2, 38, 37, 84, 18, 55, 23, 85, 20, 88, 29, 12, 50, 11, 91, 13, 95, 70, 81, 89, 96, 70, 95, 84, 90, 36, 35, 81, 24, 5, 10, 55, 11, 41, 48, 95, 79, 63, 89, 90, 11, 91, 51, 13, 12, 9, 94, 68, 96, 8, 18, 38, 13, 93, 55, 43, 78, 94, 20, 10, 69, 47, 94, 5, 54, 58, 18, 87, 13, 56, 87, 82, 51, 57, 61, 41, 52, 16, 92, 88, 23, 88, 10, 23, 28, 30, 91, 96, 21, 64, 30, 26, 87, 14, 41, 58, 32, 59, 92, 88, 79, 66, 32, 87, 9, 2, 76, 4, 76, 56, 96, 20, 60, 33, 9, 58, 20, 1, 31, 45, 91, 15, 92, 70, 65, 7, 32, 29, 81, 50, 42, 83, 11, 97, 40, 42, 97, 78, 98, 69, 46, 55, 51, 17, 12, 15, 58, 81, 87, 97, 18, 73, 3, 7, 56, 79, 39, 70, 41, 90, 10, 35, 19, 24, 7, 8, 76, 75, 38, 24, 31, 33, 4, 29, 68, 77, 21, 6, 23, 95, 3, 89, 27, 4, 6, 11, 57, 19, 47, 65, 42, 51, 17, 86, 30, 85, 57, 31, 92, 47, 12, 26, 9, 1, 83, 11, 48, 25, 91, 37, 66, 57, 53, 98, 89, 10, 86, 77, 65, 31, 31, 17, 10, 34, 47, 43, 46, 77, 95, 23, 77, 90, 53, 19, 66, 48, 60, 91, 67, 30, 42, 94, 63, 37, 44, 40, 32, 50, 31, 53, 88, 72, 76, 34, 26, 63, 71, 13, 78, 30, 2, 25, 35, 37, 39, 79, 71, 91, 5, 17, 89, 50, 52, 53, 7, 64, 60, 53, 15, 62, 39, 43, 86, 18, 42, 93, 57, 81, 50, 32, 59, 59, 90, 29, 85, 18, 20, 78, 39, 73, 13, 91, 17, 64, 13, 18, 39, 14, 94, 56, 57, 68, 95, 10, 92, 91, 62, 40, 40, 15, 5, 33, 86, 53, 73, 65, 96, 92, 8, 12, 62, 22, 24, 95, 2, 28, 34, 27, 10, 16, 89, 49, 34, 46, 93, 58, 33, 5, 68, 62, 27, 16, 98, 62, 13, 19, 5, 11, 96, 25, 21, 10, 72, 16, 6, 23, 44, 80, 4, 95, 40, 33, 24, 28, 15, 13, 25, 97, 47, 43, 38, 34, 98, 54, 17, 29, 63, 48, 6, 24, 98, 34, 58, 13, 19, 15, 21, 10, 23, 63, 9, 67, 32, 21, 37, 1, 4, 54, 25, 91, 18, 9, 81, 52, 93, 22, 55, 98, 5, 87, 55, 46, 12, 7, 81, 95, 1, 44, 4, 32, 46, 29, 60, 95, 87, 25, 95, 59, 47, 11, 46, 16, 14, 42, 5, 98, 93, 7, 93, 52, 97, 2, 76, 11, 25, 8, 28, 5, 90, 71, 64, 98, 69, 78, 70, 17, 55, 87, 97, 90, 61, 39, 83, 94, 65, 58, 10, 82, 76, 26, 32, 83, 55, 1, 29, 72, 13, 13, 95, 78, 53, 38, 95, 81, 93, 82, 4, 76, 17, 24, 19, 34, 80, 26, 92, 20, 81, 82, 22, 51, 4, 25, 92, 50, 84, 5, 18, 77, 26, 56, 52, 69, 14, 83, 6, 34, 64, 2, 55, 43, 2, 58, 71, 79, 22, 72, 91, 70, 19, 79, 26, 1, 34, 72, 22, 44, 58, 97, 1, 30, 29, 31, 50, 9, 90, 64, 81, 48, 7, 85, 32, 32, 66, 96, 60, 17, 61, 72, 42, 35, 28, 97, 66, 86, 33, 35, 69, 88, 17, 84, 29, 16, 5, 27, 16, 96, 95, 97, 53, 94, 77, 59, 11, 41, 54, 21, 25, 77, 11, 94, 44, 40, 29, 26, 64, 56, 72, 61, 48, 64, 48, 88, 92, 75, 64, 43, 62, 17, 49, 22, 94, 63, 45, 32, 39, 95, 71, 89, 55, 72, 18, 58, 14, 48, 41, 54, 81, 14, 63, 57, 63, 67, 29, 90, 39, 54, 33, 62, 89, 6, 20, 42, 29, 39, 85, 52, 98, 18, 84, 5, 58, 22, 66, 77, 37, 35, 25, 14, 82, 14, 61, 57, 9, 32, 90, 5, 47, 96, 19, 28, 83, 90, 40, 62, 61, 48, 52, 80, 34, 77, 38, 30, 14, 40, 10, 36, 94, 53, 58, 69, 60, 5, 77, 89, 68, 52, 2, 36, 93, 14, 14, 60, 47, 17, 1, 86, 38, 52, 93, 46, 96, 29, 21, 78, 12, 80, 70, 68, 7, 53, 21, 34, 41, 56, 83, 4, 76, 75, 85, 64, 32, 41, 83, 77, 7, 3, 58, 87, 87, 53, 40, 21, 19, 72, 39, 48, 83, 91, 95, 59, 59, 79, 77, 55, 64, 47, 91, 73, 57, 63, 62, 80, 61, 56, 50, 39, 90, 32, 20, 89, 47, 33, 78, 55, 14, 90, 10, 60, 92, 87, 96, 42, 76, 39, 88, 20, 7, 77, 79, 83, 53, 91, 39, 42, 42, 72, 21, 60, 3, 71, 21, 64, 22, 14, 27, 30, 64, 95, 60, 76, 78, 98, 8, 60, 17, 21, 33, 74, 7, 55, 29, 49, 29, 72, 69, 84, 75, 32, 71, 29, 62, 51, 98, 79, 63, 59, 50, 92, 66, 89, 59, 87, 58, 28, 29, 47, 69, 83, 62, 67, 31, 67, 89, 82, 4, 71, 70, 31, 43, 20, 92, 88, 82, 46, 95, 34, 41, 97, 57, 17, 46, 98, 92, 64, 23, 65, 35, 95, 6, 34, 64, 59, 7, 47, 31, 20, 20, 90, 27, 60, 33, 45, 7, 18, 55, 58, 76, 35, 95, 55, 89, 4, 55, 10, 49, 57, 33, 70, 46, 88, 95, 44, 74, 3, 95, 4, 37, 12, 35, 20, 41, 66, 47, 31, 94, 8, 39, 65, 6, 23, 16, 34, 10, 13, 85, 72, 73, 68, 97, 62, 43, 9, 36, 53, 94, 32, 40, 59, 25, 33, 35, 13, 26, 16, 32, 95, 12, 23, 59, 31, 60, 85, 95, 53, 23, 20, 59, 78, 8, 91, 66, 93, 42, 84, 51, 51, 73, 90, 78, 55, 3, 22, 28, 20, 15, 21, 1, 38, 32, 56, 85, 3, 85, 82, 97, 45, 79, 10, 90, 84, 70, 33, 1, 42, 39, 56, 47, 41, 96, 15, 19, 71, 93, 59, 64, 24, 60, 87, 12, 95, 41, 68, 63, 80, 95, 42, 57, 61, 28, 15, 22, 45, 55, 3, 86, 7, 27, 39, 49, 9, 34, 13, 12, 2, 49, 65, 94, 39, 56, 88, 1, 70, 68, 54, 74, 35, 5, 80, 42, 59, 49, 77, 60, 80, 1, 11, 70, 18, 40, 23, 36, 45, 20, 37, 66, 40, 88, 85, 31, 69, 40, 17, 24, 18, 79, 63, 47, 47, 83, 39, 179032 };
            Computer computer = new Computer(input);
            
            gameConsole = new GameConsole(computer);

            base.Initialize();
        }
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            pixel = Content.Load<Texture2D>("Pixel");
            gameFont = Content.Load<SpriteFont>("Font1");
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameConsole.Run();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);


            spriteBatch.Begin();

            gameConsole.DrawMono(spriteBatch, pixel, 20);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
