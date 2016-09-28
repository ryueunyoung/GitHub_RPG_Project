using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public GameObject player = null;
    Vector3 oriPos = Vector3.zero;
	// Use this for initialization
	void Start ()
    {
        oriPos = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = oriPos + player.transform.position;
	}
}
