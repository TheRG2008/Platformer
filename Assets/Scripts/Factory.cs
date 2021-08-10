
using UnityEngine;


public class Factory : MonoBehaviour
{
    [SerializeField] protected GameObject _spawnObject;
    public float _randX;
    public Vector2 _whereToSpawn;
    public float _spawnRate;
    protected float _nextSpawn = 0f;

    private void Update()
    {
        Spawn();

    }

    public virtual void Spawn()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randX = Random.Range(-16.84f, 12.12f);
            _whereToSpawn = new Vector2(_randX, transform.position.y);
            Instantiate(_spawnObject, _whereToSpawn, Quaternion.identity);
        }
    }


}
