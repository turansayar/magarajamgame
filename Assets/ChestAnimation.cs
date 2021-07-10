using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestAnimation : MonoBehaviour
{
    public GameObject leftBlock;
    public GameObject rightBlock;
    public GameObject leverBlock;
    public GameObject lever;
    bool isActivated = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Activate()
    {
        if (!isActivated)
        {
            leftBlock.transform.DOLocalMoveX(-0.350f, 1f);
            rightBlock.transform.DOLocalMoveX(0.350f, 1f);
            leverBlock.transform.DOLocalMoveY(1.5f, 2.5f).OnComplete(()=>lever.GetComponent<BoxCollider>().enabled=true);
            isActivated = true;
        }
    }
}
