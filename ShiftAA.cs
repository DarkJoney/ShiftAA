using UnityEngine;
using System.Collections;
//Note: reuires 60+ FPS for the stable work. Any drop will cause vision artifacts.
public class ShiftAA : MonoBehaviour
{
  
    private Vector3 offset = new Vector3(0, 0.012f, 0.012f);
    private Vector3 offset2 = new Vector3(0, 0, 0);
    Camera cam;
    int checkvalue;
    


    void Start()
    {
        cam = GetComponent<Camera>();

    }

    void LateUpdate()
    {
        if (checkvalue == 0)
        {
            Vector3 camoffset = new Vector3(-offset.x, -offset.y, offset.z);
            Matrix4x4 m = Matrix4x4.TRS(camoffset, Quaternion.identity, new Vector3(1, 1, -1));
            cam.worldToCameraMatrix = m * transform.worldToLocalMatrix;
            checkvalue = 1;

        }
        else if (checkvalue == 1)
        {
            cam.ResetWorldToCameraMatrix();
            checkvalue = 0;
        }

    }
}