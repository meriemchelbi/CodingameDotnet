using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

[assembly: InternalsVisibleTo("CodingameTests")]
namespace Codingame.Model
{
    internal class GameState
    {
        internal int MapWidth { get; set; }
        internal int MapHeight { get; set; }
        internal Cell[,] CellMap { get; set; }
        internal List<Sector> SectorMap
        {
            get
            {
                if (!(_sectorMap is null))
                {
                    return _sectorMap;
                }
                else
                {
                    LoadSectors();
                    return _sectorMap;
                }
            }
        }
        private List<Sector> _sectorMap;
        internal Cell MyCoordinates { get; set; }
        internal int MyLife { get; set; }
        internal Sector EnemySector { get; set; }
        internal int EnemyLife { get; set; }
        internal bool PlayerStartsFirst { get; set; }


        internal GameState()
        {
        }

        internal void LoadSectors()
        {
            // Implement when you need it!
        }
    }
}
