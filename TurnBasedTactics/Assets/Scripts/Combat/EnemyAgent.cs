using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    public int hasGone;
    public int health;
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        hasGone = 0;
        health = 5;
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
        target.GetComponent<PlayerAgent>().health -= 1;
        Debug.Log("I have attacked!");
    }

    //Searchs the game for agents of other team, attacks all seen targets
    public void FindTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Ally");
        if (targets.Length != 0)
        {
            Debug.Log("Target found!" + targets);
            foreach (GameObject i in targets)
            {
                Attack(i);
            }
        }
        else
        {
            Debug.Log("Target no targets found!");
        }

    }
}
