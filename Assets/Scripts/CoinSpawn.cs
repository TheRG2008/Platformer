
using UnityEngine;

public class CoinSpawn : Factory
{
    private float _randY;
    

    public override void Spawn()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randX = Random.Range(-17.60f, 13.70f);
            _randY = Random.Range(5.1f, -6.57f);
            _whereToSpawn = new Vector2(_randX, _randY);
            Instantiate(_spawnObject, _whereToSpawn, Quaternion.identity);
        }
    }
}
