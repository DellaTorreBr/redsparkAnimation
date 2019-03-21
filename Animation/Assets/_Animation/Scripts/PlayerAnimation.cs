using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{

    public float rotationSpeed = 25.0f;

    private Animator animator;

    // Start is called before the first frame update
    void Start() {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update() {
        
        if(Input.GetButtonDown("Jump")){
            animator.SetTrigger("jump");
        }

        float verticalValue = Input.GetAxis("Vertical");
        if (verticalValue != 0) {
            animator.SetBool("walking", true);
            animator.SetFloat("walkingSpeed", verticalValue);
            transform.Translate(Vector3.forward * verticalValue * Time.deltaTime);
        } else {
            animator.SetBool("walking", false);
        }

        float horizontalValue = Input.GetAxis("Horizontal");
        if (horizontalValue != 0) {
            transform.Rotate(Vector3.up, rotationSpeed * horizontalValue * Time.deltaTime);
        }

        if (Input.GetButtonDown("Run")) {
            animator.SetBool("running", true);
        }

        if (Input.GetButtonUp("Run")) {
            animator.SetBool("running", false);
        } 

        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("slice");
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            animator.SetTrigger("death");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            animator.SetTrigger("respawn");
        }
    }
}
