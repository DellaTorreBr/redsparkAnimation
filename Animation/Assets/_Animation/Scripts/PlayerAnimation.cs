using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start() {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update() {

        foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode))) {
            if(Input.GetKey(keyCode)) {
                Debug.Log(keyCode);
            }
        }
        
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

    }
}
