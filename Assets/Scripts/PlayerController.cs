using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    float baseSpeed;
    float boostSpeed;
    [SerializeField] float boostSpeedIncrease = 10f;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector2D.speed;
        boostSpeed = surfaceEffector2D.speed + boostSpeedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls() {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            surfaceEffector2D.speed = boostSpeed;
        } else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    public bool getCanMove() {
        return canMove;
    }
}
