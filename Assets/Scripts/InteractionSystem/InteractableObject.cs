using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using NaughtyAttributes;

public class InteractableObject : MonoBehaviour
{

    public ObjectList objectId;

    [BoxGroup("Task Item")]
    public bool isTaskItem = false;
    /*
    [ShowIf("isTaskItem")]
    [BoxGroup("Task Item")] public PuzzleID puzzleID;
    [ShowIf("isTaskItem")]
    [BoxGroup("Task Item")] public PuzzleStageName puzzleStage;
*/
    [BoxGroup("Inspectable Object")]
    public bool isInspectableObject;

    [BoxGroup("Portable Object")]
    public bool isPortableObject = false;

    [BoxGroup("Attacher  Object")]
    public bool isAttacherObject = false;
    [BoxGroup("Attacher  Object")]
    [ShowIf("isAttacherObject")]
    public ObjectList attachmentOne;
    [BoxGroup("Attacher  Object")]
    [ShowIf("isAttacherObject")]
    public ObjectList attachmentTwo;

    
    [BoxGroup("Attachment Object")] 
    public bool isObjectAttachment;
    [ShowIf("isObjectAttachment")]
    [BoxGroup("Attachment Object")] 
    public Vector3 objectRotation;
        
        
    bool isObjectAttached = false;
    [HideInInspector]
    public bool isTaken = false;

    [BoxGroup("Subtitle")]
    public bool isTriggerSubtitle;

    [ShowIf("isTriggerSubtitle")]
    [BoxGroup()] public ScriptableObject subtitleData;

    Rigidbody rb;

    private bool canAttachObject = true; 
    public bool IsObjectAttached { get => isObjectAttached; set => isObjectAttached = value; }

    public bool CanAttachObject
    {
        get => canAttachObject;
        set => canAttachObject = value;
    }

    private void Awake()
    {
        if (isInspectableObject)
        {
            gameObject.layer = 6;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isAttacherObject)
        {
            if (gameObject.transform.childCount > 0)
            {
                CanAttachObject = false;
            }
            else
                CanAttachObject = true;

        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        StartCoroutine(MakeKinematic());
    //    }
    //}

    IEnumerator MakeKinematic()
    {
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
    }
}
