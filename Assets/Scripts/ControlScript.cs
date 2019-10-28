using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControlScript : MonoBehaviour
    ///////make sure the name of the script in unity matches the class name!!!!
{
    
    private MLInputController _controller;
    private bool TriggerCrossedThreshold =false;
    public String whohit = "";
    public GameObject art1_desc;///a field will appear in unity inspector!
    public GameObject art2_desc;///a field will appear in unity inspector!
    public GameObject art3_desc;///a field will appear in unity inspector!
    public GameObject art4_desc;///a field will appear in unity inspector!
   

    void Start()
    {
     
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;//attach OnButtonDown func
        MLInput.OnControllerButtonUp += OnButtonUp; //attach OnButtonUp func
        _controller = MLInput.GetController(MLInput.Hand.Left);//attach one controller, defauld=left
    }

    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
        //quit all controller functions when we close app
    }

    void Update()
    {
        transform.position = _controller.Position;
        transform.rotation = _controller.Orientation;

        //30 time a sec, check......
        CheckControl();
    }

    void CheckControl()
    {
        if (_controller.TriggerValue > 0.3f && TriggerCrossedThreshold==false)
            //sensitivity threshold. 0 to 1
        {
            TriggerCrossedThreshold = true;//set to "triggered already"
            //Debug.Log("TriggerPulled!");

            ///here you put a function/stuff to do when trigger pulled!
           if (whohit=="art1")
            {
                Debug.Log("TriggerPulled over art 1!");
                art1_desc.SetActive(true);
            }

            if (whohit == "art2")
            {
                Debug.Log("TriggerPulled over art 2!");
                art2_desc.SetActive(true);
            }
            if (whohit=="art3")
            {
                Debug.Log("TriggerPulled over art 3!");
                art3_desc.SetActive(true);
            }

            if (whohit == "art4")
            {
                Debug.Log("TriggerPulled over art 4!");
                art4_desc.SetActive(true);
            }



        }

        if (_controller.TriggerValue < 0.3f && TriggerCrossedThreshold == true)
        //sensitivity threshold. 0 to 1
        {
            TriggerCrossedThreshold = false;//set to "triggered released"
            Debug.Log("Triggerreleased!");

            ///here you put a function/stuff to do when trigger released!
            art1_desc.SetActive(false);
            art2_desc.SetActive(false);
            art3_desc.SetActive(false);
            art4_desc.SetActive(false);
        }

    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        ///this function is for detecting buttons down press (bumper or home)     

        ////detect bumper down
        if ((button == MLInputControllerButton.Bumper))
        {
            ///here you put a function/stuff to do when bumper is down!
             Debug.Log("bumper is down!");
        }

        ////detect home down
        if ((button == MLInputControllerButton.HomeTap))
        {
            ///here you put a function/stuff to do when home is down!
            Debug.Log("home is down!");
        }

    }

    void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        ///this function is for detecting buttons UP, released (bumper or home)


        ////detect bumper UP
        if ((button == MLInputControllerButton.Bumper))
        {
            ///here you put a function/stuff to do when bumper is UP!
            Debug.Log("bumper is up!");
        }

        ////detect home down
        if ((button == MLInputControllerButton.HomeTap))
        {
            ///here you put a function/stuff to do when home is UP!
            Debug.Log("home is UP!");
        }
    }


    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("boom");

        if (col.gameObject.name == "art1")
        {
            whohit = "art1";
            Debug.Log(whohit);
        }


        if (col.gameObject.name == "art2")
        {

            whohit = "art2";
            Debug.Log(whohit);
        }

        if (col.gameObject.name == "art3")
        {
            whohit = "art3";
            Debug.Log(whohit);
        }


        if (col.gameObject.name == "art4")
        {

            whohit = "art4";
            Debug.Log(whohit);
        }

        
    
    }




}
