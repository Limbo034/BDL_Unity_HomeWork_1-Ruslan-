using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_UI : MonoBehaviour
{
	private int _buildIndexSceneMenu = 0;

	[SerializeField]private GameObject _mainDance;
	[SerializeField]private GameObject _removedFromButtonDance;
	[SerializeField]private GameObject _removedFromButtonMenu;


	public void ExitGame()
		{
			SceneManager.LoadScene(_buildIndexSceneMenu);
		}
	
	public void OpenDancePanel()
		{
			_mainDance.SetActive(true);
			_removedFromButtonDance.SetActive(false);
			_removedFromButtonMenu.SetActive(false);
		}
	
	public void CloseDancePanel()
		{
			_mainDance.SetActive(false);
			_removedFromButtonDance.SetActive(true);
			_removedFromButtonMenu.SetActive(true);
		}
}
