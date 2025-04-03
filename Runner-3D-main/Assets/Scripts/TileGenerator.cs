using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private int _maxCount;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    [SerializeField] private Transform _tileHolder;

    private void Start()
    {
        _tiles.First()._speed = _speed;
        for(int i = 0; i < _maxCount; i++)
        {
            GenerateTile();
        }
    }

    private void Update()
    {
        if(_tiles.Count < _maxCount)
        {
            GenerateTile();
        }
    }

    private void GenerateTile()
    {
        Tile newTile = Instantiate(_tilePrefab, 
            _tiles.Last().transform.position + Vector3.forward * _tilePrefab.transform.localScale.z, 
            Quaternion.identity);
        newTile._speed = _speed;
        _tiles.Add(newTile);
        newTile.transform.SetParent(_tileHolder);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Tile tile))
        {
            _tiles.Remove(tile);
            Destroy(tile.gameObject);
        }
    }
}
