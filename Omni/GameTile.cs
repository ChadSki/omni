﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni
{
    class GameTile
    {
        public int X;
        public int Y;
        public string Biome;
        public List<Unit> Units = new List<Unit>();
        public Terrain Terrain;
        public Building Building;

        public GameTile(int X, int Y, string Biome)
        {
            this.X = X;
            this.Y = Y;
            this.Biome = Biome;
        }
        public bool IsPathable()
        {
            return ((Terrain == null || Terrain.pathable)
                    && (Building == null || Building.pathable));
        }
    }
}
