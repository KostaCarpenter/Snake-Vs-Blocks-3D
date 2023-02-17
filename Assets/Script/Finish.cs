using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private CanvasControler canvasControler;

    private void Awake()
    {
        canvasControler = FindObjectOfType<CanvasControler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasControler.WinGame();
        }
    }
}
