using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class edit : MonoBehaviour
{
     edit instance;
    
    public Playeractionkey control;

    public Camera mainCam;
    public Camera editCam;
    public GameObject prefab1;
    public GameObject prefab2;
     GameObject item;
    public bool editMode = false;
    bool instantiated = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
    private void switchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editCam.enabled = !editCam.enabled;

    }
    private void addItem(int id)
    {
        if (editMode && !instantiated)
        {
            switch (id)
            {
                case 1:
                    item = Instantiate(prefab1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    break;
                default:
                    break;

            }
        }
        instantiated = true;
    }
    private void dropitme()
    {

    }
    void Awake()
    {
       // control = playercontroler.instance.controls;
       if(instance ==null)
        {
            instance = this;
        }
        control = new Playeractionkey();
        control.editer.enableEditer.performed += cntxt => switchCamera();
        control.editer.addItem.performed += cntxt => addItem(1);
        control.editer.dropItem.performed += cntxt => dropitme();
        editMode = false;
        mainCam.enabled = true;
        editCam.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        

        if(mainCam.enabled == false && editCam.enabled ==true)
        {
            editMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
