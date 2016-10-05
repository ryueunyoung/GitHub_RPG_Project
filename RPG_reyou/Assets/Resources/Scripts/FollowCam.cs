using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour
{

    public Transform targetTr;      //추적할 타깃 게임오브젝트의 Transform 변수
    public float dist = 10.0f;      //카메라와의 일정 거리
    public float height = 3.0f;     //카메라의 높이 설정
    public float dampTrace = 20.0f; //부드러운 추적을 위한 변수.
    private Transform tr;   //카메라 자신의 Transform 변수
    //Vector3 oriPos = Vector3.zero;
    //public GameObject player;
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        //oriPos = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //카메라의 위치를 추적대상의 dist 변수만큼 뒤쪽으로 배치하고 
        //height 변수만큼 위로 올림
        tr.position = Vector3.Lerp(tr.position, targetTr.position - (targetTr.forward * dist) + (Vector3.up * height),
                                                                                          Time.deltaTime * dampTrace);
        //카메라가 타깃 게임오브젝트를 바라보게 설정.
        tr.LookAt(targetTr.position);
        //this.transform.position = player.transform.position + oriPos; 
    }
}
