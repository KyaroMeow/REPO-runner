using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float _speed;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private GameObject _coin;

    private void Start()
    {
        int randomPointIndex = Random.Range(0, _points.Count);
        var coin = Instantiate(_coin, _points[randomPointIndex].position, Quaternion.identity);
        coin.transform.SetParent(this.transform);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}
