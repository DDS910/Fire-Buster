using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncLoader : MonoBehaviour
{
    [Header ("Menu Screen")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    public void StarButton(string Scene)
    {
        mainMenu.SetActive (false);
        LoadingScreen.SetActive (true);

        StartCoroutine(LoadLevelAsync(Scene));
    }

    IEnumerator LoadLevelAsync(string LevelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LevelToLoad);
        
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }

    }

}
