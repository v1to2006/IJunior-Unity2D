using UnityEngine;
using System;

public class Point : MonoBehaviour
{
	public static Action OnPointTaken;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			OnPointTaken?.Invoke();
			Destroy(gameObject);
		}
	}
}
