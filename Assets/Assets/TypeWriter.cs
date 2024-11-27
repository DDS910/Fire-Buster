using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class TypeWriter : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private List<string> messages = new List<string>();
    private static TypeWriter instance;
    private float timer = 0;
    private int charIndex = 0;
    private string currentMsg;
    private float timeperChar = 0.5f; //speed untuk memperlihatkan kata

    [SerializeField] private Playername_Manager storyMsg;

    private void Start()
    {
        currentMsg = storyMsg.newMsg;
    }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (string.IsNullOrEmpty(currentMsg))
        {
            return;
        }

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer -= timeperChar;
            charIndex++;

            string tmpMessage = currentMsg.Substring(0, charIndex);
            currentMsg = tmpMessage;

            if(charIndex == currentMsg.Length) 
            { 
                currentMsg = null;
            }
        }
    }
}
