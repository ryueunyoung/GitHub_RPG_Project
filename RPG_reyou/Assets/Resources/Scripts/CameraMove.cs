using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float rotSpeed = 100f;
    public GameObject player = null;
    Vector3 oriPos = Vector3.zero;
    public Transform tr;
    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
        oriPos = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        //int mask = -1 << LayerMask.NameToLayer("Ground");
        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    player.transform.position = hit.transform.position + new Vector3(0f, 1f, 0f);
        //}
        this.transform.position = oriPos + player.transform.position;
	}
}
