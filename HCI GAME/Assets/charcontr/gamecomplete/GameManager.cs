using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}
}