using System;

namespace ExampleWalkingOnMap.Components.Map
{
    /// <summary>
    ///     Contains a simple created map.
    /// </summary>
    internal class MapHelper
    {
        internal static GroundTile[,] CreateMap(int size)
        {
            GroundTile[,] map = new GroundTile[size, size];

            for (int iY = 0; iY < map.GetLength(0); iY++)
            {
                for (int iX = 0; iX < map.GetLength(1); iX++)
                {
                    map[iY, iX] = GetMappingGroundTile(0);
                }
            }

            return map;
        }


        internal static GroundTile[,] CreateMap()
        {
            int[][] map = new int[10][];

            // a simple visual reading map
            // 0 = grass
            // 1 = sand
            // 2 = water
            // 3 = stone
            map[0] = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2 };
            map[1] = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2 };
            map[2] = new int[10] { 1, 1, 1, 1, 1, 1, 1, 0, 2, 2 };
            map[3] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 2, 2 };
            map[4] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 2, 2 };
            map[5] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 2, 2 };
            map[6] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 2, 2 };
            map[7] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
            map[8] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 3, 3 };
            map[9] = new int[10] { 0, 0, 0, 0, 0, 0, 1, 0, 3, 0 };

            // map the number to the target object
            GroundTile[,] groundTiles = new GroundTile[10, 10];

            for (int iY = 0; iY < 10; iY++)
            {
                for (int iX = 0; iX < 10; iX++)
                {
                    groundTiles[iY, iX] = GetMappingGroundTile(map[iY][iX]);
                }
            }

            return groundTiles;
        }

        /// <summary>
        ///     Map the number to the ground object.
        /// </summary>
        /// <param name="groundTile">Number information</param>
        /// <returns>Return the ground with tile information.</returns>
        private static GroundTile GetMappingGroundTile(int groundTile)
        {
            switch (groundTile)
            {
                case 0:
                    return new GroundTile(0, 0, 64, 64);
                case 1:
                    return new GroundTile(64, 0, 64, 64);
                case 2:
                    return new GroundTile(0, 64, 64, 64);
                case 3:
                    return new GroundTile(64, 64, 64, 64);
            }

            throw new ArgumentException("groundTile can be only 0, 1, 2 and 3");
        }
    }
}
