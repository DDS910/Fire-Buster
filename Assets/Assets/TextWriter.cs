using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string texttoWrite;
    private int CharacterIndex;
    private float timePerCharacter;
    private float timer;

    public void AddWriter(TextMeshProUGUI uitext, string texttoWrite, float timePerCharacter)
    {
        this.uiText = uitext;
        this.texttoWrite = texttoWrite;
        this.timePerCharacter = timePerCharacter;
        CharacterIndex = 0;
    }

    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                //Display next character
                timer += timePerCharacter;
                CharacterIndex++;
                uiText.text = texttoWrite.Substring(0, CharacterIndex);

                if(CharacterIndex >= texttoWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}
