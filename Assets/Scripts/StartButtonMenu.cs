using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUi;
    [SerializeField] private GameObject teleportation;
    [SerializeField] private float maxRayDistance = 5f;
    [SerializeField] private GameObject uiPointer;

    public Transform rayFromHand;


    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            menuUi.SetActive(!menuUi.activeInHierarchy);
        }
        OnMenuOpen();
    }

    private void OnMenuOpen()
    {
        if(menuUi.activeInHierarchy)
        {
            teleportation.SetActive(false);
            uiPointer.SetActive(true);

        }
        else
        {
            teleportation.SetActive(true);
            uiPointer.SetActive(false);

        }
    }
}
