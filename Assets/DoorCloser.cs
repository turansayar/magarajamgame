using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorCloser : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Close");
            doorLeft.transform.DOLocalMoveX(0, 3.5f);
            doorRight.transform.DOLocalMoveX(0, 3.5f);
        }
    }
}
