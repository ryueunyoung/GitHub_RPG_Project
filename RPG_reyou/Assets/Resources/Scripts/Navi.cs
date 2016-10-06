using UnityEngine;
using System.Collections;

public class Navi : MonoBehaviour
{
    private NavMeshAgent navi = null;
    private Vector3 newPosition;
    // Use this for initialization
    void Start ()
    {
        navi = GetComponent<NavMeshAgent>();
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        navi.SetDestination(newPosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                newPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                //transform.position = newPosition;
            }
        }
    }
}
