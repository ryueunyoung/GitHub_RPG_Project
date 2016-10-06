using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour
{
    public float jump = 3f;
    public bool isground = false;
    public float speed;
    public float rotSpeed = 150f;
    private Vector3 newPosition;
    private Transform tr;
    // private NavMeshAgent navi = null;
    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X") * 1.5f);
        //navi.SetDestination(newPosition);
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

        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hit))
            //{
            //    newPosition = hit.point;
            //    transform.position = newPosition;
            //}
            LocatePosition();
        }
        movePosition();
    }

    void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            newPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            //transform.position = newPosition;
        }
    }
    
    void movePosition()
    {
        if(Vector3.Distance(transform.position, newPosition) > 1)
        {
            Quaternion newRot = Quaternion.LookRotation(newPosition - transform.position, Vector3.forward);

            newRot.x = 0f;
            newRot.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * 10);
            // this.transform.Translate(transform.forward * speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
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
