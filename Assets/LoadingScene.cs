using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScene : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;
    public string sceneManager;

    public float totalAssetSizeMB = 100;

    public void LoadScene(int index)
    {
        StartCoroutine(Loadscene_Coroutine());
    }
    
    public IEnumerator Loadscene_Coroutine()
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneManager);
        asyncOperation.allowSceneActivation = false;

        float estimatedLoadingTime = totalAssetSizeMB / GetStorageSpeedMBperSec();

        float elapsedTime = 0;
        //float progress = 0;

        while (!asyncOperation.isDone)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / estimatedLoadingTime);
            progressSlider.value = progress;
            //progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            //progressSlider.value = progress;

            if(progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                //progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    private float GetStorageSpeedMBperSec()
    {
        return 50;
    }



}
