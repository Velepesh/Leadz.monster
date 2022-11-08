using UnityEngine;

public class BlockGenerator : ObjectPool
{
    [SerializeField] private Block _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime = 0f;

    private void OnValidate()
    {
        _secondsBetweenSpawn = Mathf.Clamp(_secondsBetweenSpawn, 0f, float.MaxValue);
    }

    public override void StartGenerate()
    {
        Init(_template.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject block))
            {
                _elapsedTime = 0f;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                block.SetActive(true);
                block.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}