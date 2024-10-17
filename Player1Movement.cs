using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    //This script is set up so that it can be applied to both players. Player1 should have the boolean set to on for
    //their controls, and player2 should have the boolean off to use its controls.

    public Vector3 leftMoveForce;
    public Vector3 rightMoveForce;
    public Vector3 jumpForce;

    public bool canJump;
    public bool doubleJump;

    public GameObject leftProjectilePrefab;
    public GameObject rightProjectilePrefab;
    public int playerFacing;

    public Vector3 leftProjectileOffset;
    public Vector3 rightProjectileOffset;

    //This bool will determine which controls are on and which are off.
    public bool thisIsPlayer1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement code for player 1
        //This code only works if the bool is set to true (set it to true on player 1, should be false on player 2)
        if(thisIsPlayer1 == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerFacing = 1;
                GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerFacing = -1;
                GetComponent<Rigidbody2D>().AddForce(leftMoveForce);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (canJump == true)
                {
                    canJump = false;
                    GetComponent<Rigidbody2D>().AddForce(jumpForce);
                }
                else if (doubleJump == true)
                {

                    GetComponent<Rigidbody2D>().AddForce(jumpForce);
                    doubleJump = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (playerFacing == 1)
                {
                    Instantiate(rightProjectilePrefab, GetComponent<Transform>().position + rightProjectileOffset,
                    Quaternion.identity);
                }

                if (playerFacing == -1)
                {
                    Instantiate(leftProjectilePrefab, GetComponent<Transform>().position + leftProjectileOffset,
                        Quaternion.identity);
                }
            }    
        
        }

        //Movement code for Player 2
        //This code only works if the bool is set to false (make it true on player 1, make false on player 2)
        else if(thisIsPlayer1 == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerFacing = 1;
                GetComponent<Rigidbody2D>().AddForce(rightMoveForce);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerFacing = -1;
                GetComponent<Rigidbody2D>().AddForce(leftMoveForce);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (canJump == true)
                {
                    canJump = false;
                    GetComponent<Rigidbody2D>().AddForce(jumpForce);
                }
                else if (doubleJump == true)
                {

                    GetComponent<Rigidbody2D>().AddForce(jumpForce);
                    doubleJump = false;
                }
            }

            //Allows player 2 to shoot
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (playerFacing == 1)
                {
                    Instantiate(rightProjectilePrefab, GetComponent<Transform>().position + rightProjectileOffset,
                    Quaternion.identity);
                }

                if (playerFacing == -1)
                {
                    Instantiate(leftProjectilePrefab, GetComponent<Transform>().position + leftProjectileOffset,
                        Quaternion.identity);
                }
            }
        }

        //Makes you lose if you fall off
        if (GetComponent<Transform>().position.y <= -5f)
        {
            Debug.Log("You Lose!");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This code is so you can only jump when touching the floor
        if(collision.gameObject.tag == "Floor")
        {
            canJump = true;
            doubleJump = true;
        }
    }
}
