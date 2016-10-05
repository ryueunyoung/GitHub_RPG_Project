using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour
{
    public float speed;
    private Vector3 newPosition;
    // Use this for initialization
    void Start ()
    {
        newPosition = transform.position;

    }

    // Update is called once per frame
    void Update ()
    {
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
}
