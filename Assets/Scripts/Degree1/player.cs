using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class Snake : MonoBehaviour
{
    public Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private bool isfacingRight = true;
    
    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    void Update()
    {
        HandleInput();
        HandleGridMovement();
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {

                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {

                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (gridMoveDirection.x != 1)
            {

                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (gridMoveDirection.x != -1)
            {

                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }
        // flip();
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            if (isfacingRight)
            {
                isfacingRight = !isfacingRight;
                Vector3 kichthuoc = transform.localScale;
                kichthuoc.x = kichthuoc.x * -1;
                transform.localScale = kichthuoc;
            }
            transform.position = new Vector3(gridPosition.x, gridPosition.y);


        }


    }
    void flip()
    {

        if ((isfacingRight && Input.GetAxis("Horizontal") < 0) || (!isfacingRight && Input.GetAxis("Horizontal") > 0))
        {
            isfacingRight = !isfacingRight;
            Vector3 kichthuoc = transform.localScale;
            kichthuoc.x = kichthuoc.x * -1;
            transform.localScale = kichthuoc;
        }
    }
}
