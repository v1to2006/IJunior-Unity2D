using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Player>(out Player player))
		{
			const string SceneMain = "MainScene";

			SceneManager.LoadScene(SceneMain);
		}
	}
}
