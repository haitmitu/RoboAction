using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10;
    private float speedSave;
    public float gravity = 9.81f;

    public float JumpPower = 10;

    //public Collider Col;
    public Collider Sword;

    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI ItemGetText;
    public Image ItemImage;

    public TextMeshProUGUI ExamineText;
    public TextMeshProUGUI AfterResearchText;
    public Image ExamineImage;

    private Vector3 moveDirection = Vector3.zero;

    private Animator animator;
    CharacterController controller;

    private Vector3 aim;
    private Quaternion playerRotation;

    float y;
    float x;
    float z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        speedSave = speed;

        playerRotation = transform.rotation;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection.z = z * speed;
            moveDirection.x = x * speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                y = JumpPower;
                moveDirection.y = y;
            }
        }

        if (!controller.isGrounded)
        {
            moveDirection.z = z * speed;
            moveDirection.x = x * speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15;
        }
        else
        {
            speed = speedSave;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))//|| = mataha
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
        //if (aim.magnitude > 0.5f)
        //{
        //  playerRotation = Quaternion.LookRotation(aim, Vector3.up);
        //}

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, playerRotation, 600 * Time.deltaTime); // 追記

        //if (velocity.magnitude > 0.1f)
        //{
        //  animator.SetBool("walking", true);
        //}
        //else
        //{
        //  animator.SetBool("walking", false);
        //}

        //GetComponent<Rigidbody>().velocity = velocity * speed;
    }

    //void OnCollisionEnter(Collision collision)//壁登りしようとしてできなかったやつ
    //{
    //collision.gameObject.CompareTag("canclimb");
    //moveDirection.y = y * speed;
    //}
}