using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] PlayerInput Player;


    void LateUpdate()
    {
        if (Player != null) 
        {
            transform.position = new Vector3(0, 10, Player.transform.position.z - 10f);
        }
    }
}
