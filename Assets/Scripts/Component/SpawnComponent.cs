using UnityEngine;

namespace Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject[] _prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            int i = Random.Range(0, _prefab.Length-1);
            var instantiate = Instantiate(_prefab[i], _target.position, Quaternion.identity);
            instantiate.transform.localScale = _target.lossyScale;
        }
    }
}