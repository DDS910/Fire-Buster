using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Asisttant : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Canvas storyCanvas;
    string message;
    [SerializeField] private TextWriter textWriter;

    private void Start()
    {
        message = messageText.text;
        if(storyCanvas.enabled)
        {
            textWriter.AddWriter(messageText, message,.1f);
        }
    }


}
