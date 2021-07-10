using UnityEngine;

public class Cast : MonoBehaviour
{
    CinemachineSwitcher csCinemachineSwitcher;
    Vector3 offset = new Vector3(0, 0, 5);
    Transform tfTrash;
    private bool isHold;
    private void Start()
    {
        csCinemachineSwitcher = GameObject.Find("CineManager").GetComponent<CinemachineSwitcher>();
    }
    public void CastRay()
    {
        RaycastHit hit;

        // fpscam'deyse
        if (csCinemachineSwitcher.fpsCamera)
        {
            if (Physics.Raycast(transform.position, new Vector3(0, 0, 1), out hit))
            {
                if (hit.transform.CompareTag("SEC_Cam1"))
                {
                    // cam'e hitlersek o cam'e geç
                    csCinemachineSwitcher.SwitchPriority(0, 1, 0);
                    csCinemachineSwitcher.fpsCamera = false;
                }

                if (hit.transform.CompareTag("SEC_Cam2"))
                {
                    // cam'e hitlersek o cam'e geç
                    csCinemachineSwitcher.SwitchPriority(0, 0, 1);
                    csCinemachineSwitcher.fpsCamera = false;
                }

                //if (hit.transform.CompareTag("Trash") && !isHold)
                //{
                //    Debug.Log("Trash");
                //    tfTrash = hit.transform.GetComponent<Transform>();
                //    isHold = true;
                //}

                //if (isHold)
                //{
                //    isHold = false;
                //}
            }
        }
        else
        {
            // fpscam'de değilse security_cam'ler arasında geçiş yap
            csCinemachineSwitcher.SwitchPriority(1, 0, 0);
            csCinemachineSwitcher.fpsCamera = true;
        }
    }

    //private void Update()
    //{
    //    if (isHold)
    //    {
    //        tfTrash.position = transform.position + offset;
    //    }
    //}
}
