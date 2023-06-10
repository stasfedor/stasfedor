using UnityEngine;

namespace Tetris1
{
    public class Peace : MonoBehaviour
    {
        public Board board { get; private set; }
        public TetrisData data { get; private set; }
        public Vector3Int [] cells { get; private set; }
        public Vector3Int position { get; private set; }
        
        public void Initialize(Board board, Vector3Int position, TetrisData data)
        {
            this.board = board;
            this.position = position;
            this.data = data;

            if (this.cells == null)
            {
                this.cells = new Vector3Int[data.cells.Length];
            }

            for (int i = 0; i < data.cells.Length; i++)
            {
                this.cells[i] = (Vector3Int) data.cells[i];
            }
        }
    }
}