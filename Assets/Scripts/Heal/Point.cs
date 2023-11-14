using UnityEngine;
using System;

public class Point : MonoBehaviour
{
	public static event Action PointTaken;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			PointTaken?.Invoke();
			Destroy(gameObject);
		}
	}
}
