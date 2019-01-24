﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractable : MonoBehaviour
{
    protected Vector3 interactorHitPosition = Vector3.zero;
    private Animator anim;
    public float swimSpeed = 5.0f;
    private Vector3 camPosition;
    private Vector3 whalePosition;
    private Vector3 originOfWhale;
    private bool notBack = false;


    // Start is called before the first frame update

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        originOfWhale = this.transform.position;
    }

    private void Update()
    {
        camPosition = Camera.main.gameObject.transform.position;
        whalePosition = this.transform.position;
        float deltaDistanceFromOrigin = Vector3.Distance(camPosition, originOfWhale);
        float deltaDistanceFromWhale = Vector3.Distance(camPosition, whalePosition);

        if (deltaDistanceFromOrigin <= 8 && deltaDistanceFromWhale <= 12)
        {
            this.transform.position += this.transform.forward * Time.deltaTime * swimSpeed;
        }
        // This keeps track of the distance from the whale and the origin in real time
        float whaleOffset = Vector3.Distance(originOfWhale, whalePosition);

        if (deltaDistanceFromOrigin >= 8 && deltaDistanceFromWhale >= 7.8f) {
            this.transform.position -= this.transform.forward * Time.deltaTime * swimSpeed; 
        }
    }

    public virtual void OnSelectEnter()
    {
        anim.SetBool("Gaze", true);
    }

    public virtual void OnSelectExit()
    {
    
        anim.SetBool("Gaze", false);
    }



    public virtual void InteractorPosition(Vector3 position)
    {
        interactorHitPosition = position;
    }

    public virtual void OnInteract()
    {
        return;
    }

}
