using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 3f;
    Vector3 lookDirection;
    public float jump = 3f;
    public float rotSpeed = 150f;
    public bool isground = false;
    private Transform tr;
    private Animator animator = null;
    private Quaternion toRotation;
    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow)
            )
        {
           //animator.SetBool("walk", true);
            float xx = Input.GetAxisRaw("Vertical");
            float zz = Input.GetAxisRaw("Horizontal");
            lookDirection = xx * Vector3.back + zz * Vector3.left;       

            this.transform.rotation = Quaternion.LookRotation(lookDirection);
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
          //  animator.SetBool("walk", false);
        }
        //Vector3 movedir = (Vector3.back * v) + (Vector3.left * h);

        //tr.Translate(movedir.normalized * Time.deltaTime * MoveSpeed, Space.World);
        if (isground == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("jump");
                //바닥에 붙어 있는 상태에서 점프키가 눌렸다면 점프상태로 처리한다.
                Rigidbody r = (Rigidbody)GetComponent(typeof(Rigidbody));
                r.velocity = Vector3.up * jump;

                isground = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("attack1");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("attack2");
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Ground")
        {
            isground = true;
        }
    }
}
