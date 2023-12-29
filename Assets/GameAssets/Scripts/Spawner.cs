using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Range(1f,5f)] private float _spawnCooldown;
    [SerializeField] private GameObject _unitToSpawn;
    [SerializeField] private Transform[] _spawnTransforms;

    private void OnEnable()
    {
        GameAssets.Instance.castle.GetComponent<ICastle>().Kill += StopSpawningUnits;
    }

    private void OnDisable()
    {
        GameAssets.Instance.castle.GetComponent<ICastle>().Kill -= StopSpawningUnits;
    }

    private void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    private void StopSpawningUnits()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnUnit()
    {
        yield return new WaitForSeconds(_spawnCooldown);
        int randomTransforn = Random.Range(0, _spawnTransforms.Length);

        Instantiate(_unitToSpawn, _spawnTransforms[randomTransforn].position, Quaternion.identity);

        StartCoroutine(SpawnUnit());
    }
}
