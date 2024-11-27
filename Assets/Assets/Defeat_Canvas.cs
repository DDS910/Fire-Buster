using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Defeat_Canvas : MonoBehaviour
{
    public GameObject defeat_canvas;
    public AudioSource defeatSound;
    public AudioClip[] defeatEffect;
    public Button[] buttons;
    public string[] NowScene;
    public string Scene_TryAgain;
    public string Scene_Exit;


    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
        defeat_canvas.SetActive(false);
    }
    public void OnClickButtonTryAgain()
    {
        SceneManager.LoadScene(Scene_TryAgain);
    }

    public void OnClickButtonExit()
    {
        SceneManager.LoadScene(Scene_Exit);
    }

    public void handledeathSound()
    {
        if(defeat_canvas.activeSelf)
        {
            AudioClip randomSFX = defeatEffect[Random.Range(0, defeatEffect.Length)];
            defeatSound.PlayOneShot(randomSFX);
        }
        StartCoroutine(showButtonAfterSound());
    }

    private IEnumerator showButtonAfterSound()
    {
        while (defeatSound.isPlaying)
        {
            yield return null;
        }

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
}
