using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeLogs : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] changelogs;

 [SerializeField]   int activeNumber;
    private void Start()
    {
        changelogs = GetComponentsInChildren<TextMeshProUGUI>();


        foreach (var item in changelogs)
        {
            item.gameObject.SetActive(false);
        }
        activeNumber = changelogs.Length - 1;
        changelogs[activeNumber].gameObject.SetActive(true);
        
    }

    public void NextPage()
    {
        changelogs[activeNumber].gameObject.SetActive(false);

        if (activeNumber >= changelogs.Length -1)
        {
            activeNumber = -1;
        }

        activeNumber += 1;
        changelogs[activeNumber].gameObject.SetActive(true);
    }
    public void PreviousPage()
    {
        changelogs[activeNumber].gameObject.SetActive(false);

        if(activeNumber == 0)
        {
            activeNumber = changelogs.Length;
        }

        activeNumber -= 1;
        changelogs[activeNumber].gameObject.SetActive(true);
    }
}
