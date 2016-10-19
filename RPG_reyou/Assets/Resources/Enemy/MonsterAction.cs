using UnityEngine;
using System.Collections;

public class MonsterAction : MonoBehaviour
{
    public int giveExp = 0;
    public float statHP = 0f;
    public float maxHP = 0f;
    public int statAttack = 0;          // 공격력
    public float speed = 5f;
    public GameObject player;
    // Use this for initialization
    void Start ()
    {
        player = player.GetComponentInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "asbow")
        {
            Destroy(this.gameObject);
        }
    }
}
