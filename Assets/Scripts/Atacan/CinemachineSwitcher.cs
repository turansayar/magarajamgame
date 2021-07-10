using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera fpsCam;
    public CinemachineVirtualCamera secCam1;
    public CinemachineVirtualCamera secCam2;
    
    [HideInInspector]
    public bool fpsCamera = true;

    // fps + 2 secCam'e geçiş işlemi
    public void SwitchPriority(int fps, int sec1, int sec2)
    {
        fpsCam.Priority = fps;
        secCam1.Priority = sec1;
        secCam2.Priority = sec2;
    }
}
