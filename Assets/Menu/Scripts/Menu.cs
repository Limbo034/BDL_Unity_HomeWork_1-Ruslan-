using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	private int _buildIndexSceneGame = 1;

	[SerializeField]private GameObject _mainMenu;
	[SerializeField]private GameObject _options;

	public void StartGame()
		{
			SceneManager.LoadScene(_buildIndexSceneGame);
		}

	public void ExitGame()
		{
			Application.Quit();
		}

	public void OpenOptions()
		{
			_options.SetActive(true);
			_mainMenu.SetActive(false);
		}

	public void CloseOptions()
		{
			_options.SetActive(false);
			_mainMenu.SetActive(true);

		}
}
