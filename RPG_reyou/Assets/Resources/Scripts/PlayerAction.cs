using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    public enum State
    {
        사용안함 = -1,
        이동 = 0,
        점프,
        사망
    }
    public State state = State.사용안함;
    public float MoveSpeed = 3f;
    Vector3 lookDirection;
    public float jump = 3f;
    public float rotSpeed = 150f;
    public bool isground = false;
    private Transform tr;
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X") * 1.5f);

        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow)
            )
        {
           float xx = Input.GetAxisRaw("Vertical");
            float zz = Input.GetAxisRaw("Horizontal");
           lookDirection = xx * Vector3.back + zz * Vector3.left;

           this.transform.rotation = Quaternion.LookRotation(lookDirection);
            this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
           
        }
        if (isground == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //바닥에 붙어 있는 상태에서 점프키가 눌렸다면 점프상태로 처리한다.
                Rigidbody r = (Rigidbody)GetComponent(typeof(Rigidbody));
                r.velocity = Vector3.up * jump;

                isground = false;
            }
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