using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeSystem : MonoBehaviour
{

    Ray ray;
    RaycastHit hitInfo;
    Vector3 forwardVector;
    float counter = 0;
    private Image loadingImage;
   
    public GameObject reticle;
    float GazeTriggerTime;

    Transform currentChild;

    void Start()
    {
        GazeTriggerTime = 3f;
        forwardVector = Camera.main.transform.forward;
       
    }
      
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, forwardVector, out hitInfo, 500))
        {          
            
                reticle.GetComponent<Renderer>().material.color = Color.red;
                currentChild=hitInfo.collider.gameObject.transform.GetChild(0);
                currentChild.gameObject.SetActive(true);
                loadingImage = currentChild.gameObject.GetComponentInChildren<Image>();
                PerformAnimation(hitInfo.collider.tag);
        }
        else
        {
            counter = 0;
            reticle.GetComponent<Renderer>().material.color = Color.white;
            if(currentChild)
            {
                currentChild.gameObject.SetActive(false);
            }
            
        }
    }

    private void PerformAnimation(string tag)
    {
       
        counter += Time.deltaTime;
        loadingImage.fillAmount = counter / GazeTriggerTime;
        if (counter > GazeTriggerTime)
        {
            ManageScene(tag);
        }

    }

    private void ManageScene(string scene)
    {
        switch(scene)
        {
            case "HomeButton":
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                break;
            case "MenuButtons":
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                break;
            case "ExitButton":
                Application.Quit();
                break;
        }
    }
}
