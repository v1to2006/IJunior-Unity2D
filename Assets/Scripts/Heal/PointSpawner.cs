using UnityEngine;

public class PointSpawner : MonoBehaviour
{
	[SerializeField] private Point _prefab;
	[SerializeField] private Transform[] _spawnPoints;

	private void Awake()
	{
		Point.PointTaken += SpawnPoint;
		SpawnPoint();
	}

	private void SpawnPoint()
	{
		Instantiate(_prefab,
					_spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position,
					Quaternion.identity);
	}

	private void OnDestroy()
	{
		Point.PointTaken -= SpawnPoint;
	}
}
