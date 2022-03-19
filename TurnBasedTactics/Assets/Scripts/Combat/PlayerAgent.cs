using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour
{
    public int hasGone;
    public int health;
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        hasGone = 0;
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Deals damage to targeted agent
    void Attack(GameObject target)
    {
        target.GetComponent<EnemyAgent>().health -= 1;
        Debug.Log("I have attacked!");
    }


    //Searchs the game for agents of other team, attacks all seen targets
    public void FindTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length !=  0)
        {
            Debug.Log("Target found!");
            foreach (GameObject i in targets)
            {
                Attack(i);
            }
        }
        else
        {
            Debug.Log("No targets found!");
        }
            
    }
}
