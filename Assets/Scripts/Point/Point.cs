using UnityEngine;

public class Point : MonoBehaviour
{
	public delegate void PointTaken();
	public static event PointTaken OnPointTaken;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			OnPointTaken?.Invoke();
			Destroy(gameObject);
		}
	}
}
