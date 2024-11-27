using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public Playername_Manager playername;

    private void Start()
    {
        //storyText.text = storyText.text.Replace("<nama pemain>", playername.playerName);
    }

    
}
