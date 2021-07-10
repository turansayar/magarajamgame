using UnityEngine;

public class Controller : MonoBehaviour
{
    Cast csCast;
    CinemachineSwitcher csCinemachineSwitcher;

    private void Start()
    {
        csCast = GetComponent<Cast>();
        csCinemachineSwitcher = GameObject.Find("CineManager").GetComponent<CinemachineSwitcher>();
    }

    private void Update()
    {
        // E tuşu fps ve secCam arasında geçiş sağlar
        if (Input.GetKeyDown(KeyCode.E))
        {
            csCast.CastRay();
        }

        // X tuşu secCam'lerin kendi arasında geçişini sağlar
        if (Input.GetKeyDown(KeyCode.X) && !csCinemachineSwitcher.fpsCamera)
        {
            if (csCinemachineSwitcher.secCam1.Priority == 1)
            {
                csCinemachineSwitcher.SwitchPriority(0, 0, 1);
                csCinemachineSwitcher.secCam1.Priority = 0;
            }
            else
            {
                csCinemachineSwitcher.SwitchPriority(0, 1, 0);
                csCinemachineSwitcher.secCam1.Priority = 1;
            }
        }
    }
}
