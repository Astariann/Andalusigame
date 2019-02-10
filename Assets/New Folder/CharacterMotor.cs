using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{

    //Animations du perso
    Animation animations;

    //Vitesse de déplacement
    public float walkSpeed, runSpeed, turnSpeed;

    //Inputs 
    public string inputFront, inputBack, inputLeft, inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;



    // Use this for initialization
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool isGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        //si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("walk");
        }

        //si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animations.Play("run");
        }

        //si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("walk");
        }

        //rotation à gauche
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        //rotation à droite
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        //si on ne se déplace pas
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
        {
            animations.Play("idle");
        }
        /**
        //Pour sauter
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            //Préparation du saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            // Saut
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }**/
    }
}