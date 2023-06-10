using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetris1 {
    public class Board : MonoBehaviour
    {
        public TetrisData[] tetris;
        public Peace activePeace { get; private set; }
        public Tilemap tilemap { get; private set; }
        public Vector3Int spawnPosition;
        
        private void Awake()
        {
            this.tilemap = GetComponentInChildren<Tilemap>();
            this.activePeace = GetComponentInChildren<Peace>();
            
            for (int i = 0; i < this.tetris.Length; i++)
            {
                this.tetris[i].Initialize();
            }
        }

        private void Start()
        {
            SpawnPeace();
        }

        public void SpawnPeace()
        {
            int random = UnityEngine.Random.Range(0, this.tetris.Length);
            TetrisData data = this.tetris[random];
            
            this.activePeace.Initialize(this, this.spawnPosition, data);
        }

        public void Set(Peace peace)
        {
            for (int i = 0; i < peace.cells.Length; i++)
            {
                Vector3Int tilePosition = peace.cells[i] + peace.position;
                this.tilemap.SetTile(tilePosition, peace.data.tile);
            }
        }
    }
    
    
}