using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody player;
    public Vector3 previousMousePosition;
    public float speed;
    public float sensitivity;
    public GameState GameState;

    private CanvasControler canvasControler;

    private void Awake()
    {
        canvasControler = FindObjectOfType(typeof(CanvasControler)) as CanvasControler;
    }

    private void FixedUpdate()
    {
        if (canvasControler.IsPlayin)
        {
            Moving(player);

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - previousMousePosition;
                player.velocity = new Vector3(delta.x * sensitivity, 0.0f, speed);
            }

            previousMousePosition = Input.mousePosition;
        }
    }

    public void Moving(Rigidbody rb)
    {
        rb.velocity = Vector3.forward * speed;
    }

    public void Die()
    {
        canvasControler.LoseGame();
        GameState.OnPlayerDie();
        player.velocity = Vector3.zero;
    }
}
