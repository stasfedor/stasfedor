using UnityEngine.Tilemaps;
using UnityEngine;

namespace Tetris1 {
    public enum Tetris
    {
        I,
        O,
        T,
        J,
        L,
        S,
        Z,
    }

    [System.Serializable]
    public struct TetrisData 
    {
        public Tetris tetris;
        public Tile tile;
        public Vector2Int[] cells { get; private set; }

        public void Initialize()
        {
            this.cells = Data.Cells[this.tetris];
        }
    }    
}