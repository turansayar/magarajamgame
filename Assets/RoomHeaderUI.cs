using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening;

public class RoomHeaderUI : MonoBehaviour
{
    public TextMeshProUGUI mainTextGUI;
    public TextMeshProUGUI descTextGUI;
    string mainText;
    string descriptionText;
    public Image bgImage;
    public string roomID;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (roomID == "Ra")
        {
            mainTextGUI.text = "Room of Ra";
            descTextGUI.text = "LET THE SUN GUIDE YOU";
            StartCoroutine(ActivateRaRoom());
        }
        if (roomID == "Maat")
        {
            mainTextGUI.text = "Room of Maat";
            descTextGUI.text = "ONLY INNOCENTS";
            StartCoroutine(ActivateMaatRoom());
        }
        if (roomID == "Desert")
        {
            mainTextGUI.text = "Egypt";
            descTextGUI.text = "VALLEY OF THE KINGS";
            StartCoroutine(ActivateDesert());
        }
    }

    public IEnumerator ActivateRaRoom()
    {
        bgImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        mainTextGUI.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        mainTextGUI.transform.DOScale(1.5f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        descTextGUI.GetComponent<CanvasGroup>().DOFade(1, 0.55f);
        yield return new WaitForSeconds(0.55f);
        bgImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.5f);
        mainTextGUI.transform.parent.GetComponent<CanvasGroup>().DOFade(0, 0.55f);
    }

    public IEnumerator ActivateMaatRoom()
    {
        bgImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        mainTextGUI.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        mainTextGUI.transform.DOScale(1.5f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        descTextGUI.GetComponent<CanvasGroup>().DOFade(1, 0.55f);
        yield return new WaitForSeconds(0.55f);
        bgImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.5f);
        mainTextGUI.transform.parent.GetComponent<CanvasGroup>().DOFade(0, 0.55f);
    }
    
    public IEnumerator ActivateDesert()
    {
        bgImage.GetComponent<CanvasGroup>().DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        mainTextGUI.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        mainTextGUI.transform.DOScale(1.5f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        descTextGUI.GetComponent<CanvasGroup>().DOFade(1, 0.55f);
        yield return new WaitForSeconds(0.55f);
        bgImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.5f);
        mainTextGUI.transform.parent.GetComponent<CanvasGroup>().DOFade(0, 0.55f);
    }
}
