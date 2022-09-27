using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroler : MonoBehaviour
{

   // public static playercontroler instance;
    public Playeractionkey controls;
    Vector2 move;
    Vector2 look;
    Vector3 camerarotate;
    private float walkspeed = 5f;

    public Camera playerCamera;
   

    Rigidbody rb;
    private float groundDistance;
    bool isGorunded = true;
    float jump = 10f;
    Animator playeranimator;
    private bool iswalking = false;

    public GameObject bullet;
    public Transform bulletPos;
    // Start is called before the first frame update
    private void OnEnable()
    {
        controls.player.Enable();
    }
    private void OnDisable()
    {
        controls.player.Disable();
    }
    private void Jump()
    {
        if (isGorunded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGorunded = false;
        }
    }
    private void Shot()
    {
        Rigidbody bulletRB = Instantiate(bullet, bulletPos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRB.AddForce(transform.up * 5f, ForceMode.Impulse);
  
    }
    void Awake()
    {
       //if(!instance)
       //{
       //    instance = this;
       //}
        controls = new Playeractionkey();
        rb = GetComponent<Rigidbody>();

        //moving
        controls.player.movement.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        controls.player.movement.canceled += cntxt => move = Vector2.zero;
        //jump
        controls.player.jump.performed += cntxt => Jump();
        controls.player.shoot.performed += cntxt => Shot();
        


        groundDistance = GetComponent<Collider>().bounds.extents.y;//height check
        //looking
      
        controls.player.look.performed += cntxt => look = cntxt.ReadValue<Vector2>();
        controls.player.look.canceled += cntxt => look = Vector2.zero;
        camerarotate = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        //animetion
        playeranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkspeed, Space.Self); 
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkspeed, Space.Self);
        //looking
        camerarotate = new Vector3(camerarotate.x+look.y, camerarotate.y+look.x, transform.rotation.z);
        playerCamera.transform.rotation = Quaternion.Euler(camerarotate);
        transform.eulerAngles = new Vector3(transform.rotation.x, camerarotate.y, transform.rotation.z);


        isGorunded = Physics.Raycast(transform.position, Vector3.down, groundDistance);

    }
}
