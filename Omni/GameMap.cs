﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni
{
    class GameMap
    {

        private List<Entity> entities = new List<Entity>();
        private List<Entity> terrain = new List<Entity>();
        private List<Entity> buildings = new List<Entity>();
        private List<Entity> units = new List<Entity>();

        public Point MapDimensions;
        public GameTile[,] game_tiles;

        public GameMap(Point MapDimensions)
        {
            this.MapDimensions = MapDimensions;


        }
        public void GenerateMapArray()
        {
            game_tiles = new GameTile[MapDimensions.Y, MapDimensions.X];
            for (int y = 0; y < MapDimensions.Y; y++)
            {
                for (int x = 0; x < MapDimensions.Y; x++)
                {
                    GameTile gameTile = new GameTile(new Point(x, y), "Grass");
                    game_tiles[y, x] = gameTile;
                }
            }
        }
        public void PrimitiveMapGen()
        {
            Random random = new Random();
            int num_trees = random.Next(200, 210);
            for (int t = 0; t < num_trees; t++)
            {
                int tries = 0;
                int rand_x = random.Next(0, MapDimensions.X - 1);
                int rand_y = random.Next(0, MapDimensions.Y - 1);

                while (game_tiles[rand_y, rand_x].Terrain != null)
                {
                    rand_x = random.Next(0, MapDimensions.X - 1);
                    rand_y = random.Next(0, MapDimensions.Y - 1);
                    tries += 1;
                }
                Tree newTree = new Tree(new Point(rand_x, rand_y));

                terrain.Add(newTree);
                game_tiles[rand_y, rand_x].Terrain = newTree;

            }
        }
        public bool IsPointInside(Point mapCoordinates)
        {
            if (mapCoordinates.X >= 0
                && mapCoordinates.X < MapDimensions.X
                && mapCoordinates.Y >= 0
                && mapCoordinates.Y < MapDimensions.Y)
            {
                return true;
            }
            return false;
        }
        public List<Point> GetValidNeighbors(Point coordinates)
        {
            List<Point> validNeighbors = new List<Point>();
            List<Point> candidateNeighbors = new List<Point>()
            {
                new Point(-1, -1),
                new Point(0, -1),
                new Point(1, -1),
                new Point(-1, 0),
                new Point(1, 0),
                new Point(-1, 1),
                new Point(0, 1),
                new Point(1, 1)
            };
            foreach (Point altPoint in candidateNeighbors)
            {
                if (coordinates.X + altPoint.X >= 0
                    && coordinates.X + altPoint.X < MapDimensions.X
                    && coordinates.Y + altPoint.Y >= 0
                    && coordinates.Y + altPoint.Y < MapDimensions.Y)
                {
                    validNeighbors.Add(coordinates + altPoint);
                }
            }
            return validNeighbors;
        }
        public List<Entity> GetTerrain()
        {
            return terrain;
        }
        public List<Entity> GetBuildings()
        {
            return buildings;
        }
        public List<Entity> GetUnits()
        {
            return units;
        }
    }
}
