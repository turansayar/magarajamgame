using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using System;
using VHS;

namespace PlayerControllerScripts
{
    public class ObjectInteraction : MonoBehaviour
    {
        [SerializeField]
        Transform eyePosition;
        [SerializeField]
        Transform objPosition;
        [SerializeField]
        Texture2D cursorImage;

        int objectMask = 1 << 6;

        bool isHandEmpty = true;
        bool canInspect = false;

        GameObject interactedObj;
        GameObject objectAtHand;
        private FirstPersonController fpsController;

        RaycastHit hit;

        private List<string> objectsTaken = new List<string>();

        public List<string> ObjectsTaken { get => objectsTaken; set => objectsTaken = value; }

        private void Start()
        {
            fpsController = GetComponent<FirstPersonController>();
            //Cursor.visible = false;
            Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
        }
        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance._playerStates != GameManager.PlayerStates.Inspect)
            {
                fpsController.enabled = true;
            }
            else
            {
                fpsController.enabled = false;
            }
            Cursor.lockState = CursorLockMode.Locked;

            //Debug.DrawRay(eyePosition.position, eyePosition.forward*5);
            if (Physics.Raycast(eyePosition.position, eyePosition.transform.forward, out hit, 3, objectMask))
            {
                if (GameManager.Instance._playerStates != GameManager.PlayerStates.Inspect)
                    Cursor.visible = true;
                if (Input.GetButtonDown("Fire1"))
                {
                    Interact();
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    TakeAttachedObject();
                }
            }
            else
            {
                Cursor.visible = false;
            }
            if (!isHandEmpty)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    ReleaseObject();
                }
            }

            if (GameManager.Instance._playerStates == GameManager.PlayerStates.Inspect)
            {
                if (canInspect)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        interactedObj.transform.Rotate((Input.GetAxis("Mouse X") * -50 * Time.deltaTime), 0, (Input.GetAxis("Mouse Y") * -50 * Time.deltaTime), Space.World);
                    }
                    if (interactedObj.GetComponent<InteractableObject>().isTaskItem && !interactedObj.GetComponent<InteractableObject>().isTaken)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Debug.Log("ObjectTaken");
                            ObjectsTaken.Add(interactedObj.GetComponent<InteractableObject>().objectId.ToString());
                            interactedObj.GetComponent<InteractableObject>().isTaken = true;
                            TakeObject();
                        }
                    }
                }
            }
        }

        void Interact()
        {
            interactedObj = hit.transform.gameObject;
            if (interactedObj.GetComponent<InteractableObject>().isAttacherObject)
            {
                if (!isHandEmpty)
                {
                    if ( interactedObj.GetComponent<InteractableObject>().CanAttachObject )
                    {
                        if (interactedObj.GetComponent<InteractableObject>().attachmentOne == objectAtHand.GetComponent<InteractableObject>().objectId || interactedObj.GetComponent<InteractableObject>().attachmentTwo == objectAtHand.GetComponent<InteractableObject>().objectId)
                        {
                            
                            objectAtHand.transform.parent = interactedObj.transform;
                            objectAtHand.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
                            objectAtHand.transform.DOLocalRotate(objectAtHand.GetComponent<InteractableObject>().objectRotation, 0.5f);
                            objectAtHand.GetComponent<BoxCollider>().enabled = true;
                            objectAtHand.GetComponent<InteractableObject>().IsObjectAttached = true;
                            isHandEmpty = true;
                        }
                        
                    }
                }
            }
            else
            {
                if (isHandEmpty)
                {
                    
                    if (!interactedObj.GetComponent<InteractableObject>().IsObjectAttached)
                    {
                        GameManager.Instance._playerStates = GameManager.PlayerStates.Inspect;
                        interactedObj.GetComponent<Collider>().enabled = false;
                        interactedObj.GetComponent<Rigidbody>().isKinematic = true;
                        interactedObj.transform.DOMove((objPosition.transform.position + interactedObj.transform.position) / 2, 0.5f).OnComplete(() =>
                        {
                            if (interactedObj.GetComponent<InteractableObject>().isPortableObject)
                            {
                                GameManager.Instance._playerStates = GameManager.PlayerStates.Transport;
                            }
                           
                            canInspect = true;
                        });
                        Cursor.visible = false;
                        isHandEmpty = false;
                        objectAtHand = interactedObj;
                        if (interactedObj.GetComponent<InteractableObject>().isPortableObject)
                        {
                            //GameManager.Instance._playerStates = GameManager.PlayerStates.Transport;
                            interactedObj.transform.parent = objPosition.transform;
                        }
                        else
                        {
                            GameManager.Instance._playerStates = GameManager.PlayerStates.Inspect;
                        }
                    }
                }
            }
        }

        void TakeAttachedObject()
        {
            interactedObj = hit.transform.gameObject;
            if (interactedObj.GetComponent<InteractableObject>().IsObjectAttached && isHandEmpty)
            {
                interactedObj.GetComponent<Collider>().enabled = false;
                interactedObj.GetComponent<Rigidbody>().isKinematic = true;
                interactedObj.transform.DOMove((objPosition.transform.position + interactedObj.transform.position) / 2, 0.5f).
                    OnComplete(() =>
                    {
                        canInspect = true;
                        interactedObj.GetComponent<InteractableObject>().IsObjectAttached = false;
                    }
                    );
                Cursor.visible = false;
                isHandEmpty = false;
                objectAtHand = interactedObj;
                if (interactedObj.GetComponent<InteractableObject>().isPortableObject)
                {
                    GameManager.Instance._playerStates = GameManager.PlayerStates.Transport;
                    interactedObj.transform.parent = objPosition.transform;
                }
                else
                {
                    GameManager.Instance._playerStates = GameManager.PlayerStates.Inspect;
                }
            }
        }
        private void ReleaseObject()
        {
            if (!objectAtHand.GetComponent<InteractableObject>().IsObjectAttached)
            {
                if (objectAtHand.GetComponent<InteractableObject>().isPortableObject)
                {
                    objectAtHand.transform.parent = null;
                }
                GameManager.Instance._playerStates = GameManager.PlayerStates.Idle;
                objectAtHand.GetComponent<Collider>().enabled = true;
                objectAtHand.GetComponent<Rigidbody>().isKinematic = false;
                objectAtHand = null;
                isHandEmpty = true;
            }
        }

        private void TakeObject()
        {
            Destroy(interactedObj);
            GameManager.Instance._playerStates = GameManager.PlayerStates.Idle;
            interactedObj = null;
            isHandEmpty = true;
        }
    }
}