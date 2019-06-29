﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni
{
    class GameTile
    {
        private Point coordinates;
        public string Biome;
        public Unit Unit;
        public Terrain Terrain;
        public Building Building;

        public GameTile(Point coordinates, string Biome)
        {
            this.coordinates = coordinates;
            this.Biome = Biome;
        }

        public Point Coordinates
        {
            get { return coordinates; }
        }

        public bool IsPathable()
        {
            return ((Terrain == null || Terrain.pathable)
                    && (Building == null || Building.pathable)
                    && (Unit == null || Unit.pathable));
        }
    }
}
