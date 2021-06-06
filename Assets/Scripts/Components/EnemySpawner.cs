using System;
using System.Collections;
using Characters;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private BasicMonster.Factory _basicMonsterFactory;
    private CharacterConfig _config;
    private MainCharacter _player;
    private Camera _camera;

    [Inject]
    public void Init(BasicMonster.Factory factory, CharacterConfig config, Camera camera, MainCharacter player)
    {
        _basicMonsterFactory = factory;
        _config = config;
        _camera = camera;
        _player = player;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_config.BasicMonsterRespawnTime);

            var randomPoint = new Vector2(Random.value, Random.value);
            Vector3 spawnPoint;
            if (Random.value >= 0.5)
            {
                spawnPoint = new Vector2(Mathf.RoundToInt(randomPoint.x), randomPoint.y);
            }
            else
            {
                spawnPoint = new Vector2(randomPoint.x, Mathf.RoundToInt(randomPoint.y));
            }

            spawnPoint = _camera.ViewportToWorldPoint(spawnPoint);
            spawnPoint = spawnPoint + Vector3.forward * 10;

            _basicMonsterFactory.Create(new BasicMonster.BasicMonsterInfo
            {
                StartPosition = spawnPoint
            });
        }
    }
}