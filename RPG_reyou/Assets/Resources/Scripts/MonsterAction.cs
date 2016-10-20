using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterAction : MonoBehaviour
{
    public int giveExp = 0;
    public float statHP = 0f;
    public float maxHP = 0f;
    public int statAttack = 0;          // 공격력
    public float speed = 5f;
    public Transform tr;
    
    // Use this for initialization
    void Start ()
    {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "asbow")
        {
            Destroy(this.gameObject);
        }
    }
}
