using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
	public class SceneController : MonoBehaviour {

		[SerializeField]
		private String CurrentAdditiveSceneName;
		private void Start()
		{
			Fading.BeginFade(-1);

		}

		public void RestartScene()
		{

			StartCoroutine(waitAndRestartScene());
		}

		public void GoToScene(string sceneName)
		{

			StartCoroutine(waitAndLoadScene(sceneName));

		}

		public void switchLoadSceneAdditive(string SceneName) {

		UnloadCurrentSceneAdditive(CurrentAdditiveSceneName);
		LoadSceneAdditive(SceneName);

		}

		public void LoadSceneAdditive(string sceneName)
		{
			CurrentAdditiveSceneName = sceneName;
			StartCoroutine(waitAndLoadSceneAdditive(sceneName));

		}

		public void UnloadCurrentSceneAdditive(string sceneName)
		{
			StartCoroutine(waitAndUnloadSceneAdditive(CurrentAdditiveSceneName));
			CurrentAdditiveSceneName = "";
		}


		IEnumerator waitAndLoadScene(string sceneName)
		{
			Fading.BeginFade(1);
			yield return new WaitForSeconds(1);
			SceneManager.LoadScene(sceneName);
			SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		}
		IEnumerator waitAndLoadSceneAdditive(string sceneName)
		{
			Fading.BeginFade(1);
			yield return new WaitForSeconds(1);
			SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
			Fading.BeginFade(-1);

		}

		IEnumerator waitAndUnloadSceneAdditive(string sceneName)
		{
			CurrentAdditiveSceneName = sceneName;
			Fading.BeginFade(1);
			yield return new WaitForSeconds(1);
			SceneManager.UnloadSceneAsync(sceneName);
			Fading.BeginFade(-1);

		}

		IEnumerator waitAndRestartScene()
		{
			Fading.BeginFade(1);
			yield return new WaitForSeconds(1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}
}
