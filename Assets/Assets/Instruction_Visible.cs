using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Instruction_Visible : MonoBehaviour
{
    [SerializeField] private float Duration;
    [SerializeField] private float DelayShow;
    [SerializeField] private TextMeshProUGUI MoveTutorialText;
    [SerializeField] private TextMeshProUGUI InteractionTutorialText;
    [SerializeField] private TextMeshProUGUI InformationText;
    [SerializeField] private TextMeshProUGUI WarningText;
    [SerializeField] private GameObject Story;
    [SerializeField] private GameObject biodata;

    private Playername_Manager BiodataObj;

    private bool tutorialDisplayed = false;

    private void Start()
    {
        MoveTutorialText.enabled = false;
        InteractionTutorialText.enabled = false;
        InformationText.enabled = false;
        WarningText.enabled = false;

        BiodataObj = FindAnyObjectByType<Playername_Manager>();
    }

    private void Update()
    {
        if (!BiodataObj.biodata.activeSelf && !Story.activeSelf && !tutorialDisplayed)
        {
            StartCoroutine(DisplayInstructionForDuration(DelayShow, Duration));
        }
    }

    private IEnumerator DisplayInstructionForDuration(float showDelay, float duration)
    {
        tutorialDisplayed = true;
 
        //Show Move Key;
        MoveTutorialText.enabled = true;
        yield return new WaitForSeconds(duration);
        MoveTutorialText.enabled = false;

        //Show Interaction Key
        InteractionTutorialText.enabled = true;
        yield return new WaitForSeconds(duration);
        InteractionTutorialText.enabled = false;

        //Show Information
        InformationText.enabled = true;
        yield return new WaitForSeconds(duration);
        InformationText.enabled = false;

        //Show Warning
        WarningText.enabled = true;
        yield return new WaitForSeconds(duration);
        WarningText.enabled = false;

    }
}
