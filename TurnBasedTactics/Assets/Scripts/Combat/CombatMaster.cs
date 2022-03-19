using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMaster : MonoBehaviour
{

    public int turn; //Player turn = 0, enemy turn = 1
    public GameObject[] team1, team2; //Stores alive memebers of each team
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
        team1 = GameObject.FindGameObjectsWithTag("Ally");
        team2 = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeTurn(GameObject[] agents)
    {
        if (turn == 0)
        {
            foreach (GameObject i in agents)
            {
                i.GetComponent<PlayerAgent>().FindTarget();
            }
        }

        if (turn == 1)
        {
            foreach (GameObject i in agents)
            {
                i.GetComponent<EnemyAgent>().FindTarget();
            }
        }
    }

    public void CombatButton()
    {
        if (turn == 0)
        {
            Debug.Log("The Player is going!");
            team1 = GameObject.FindGameObjectsWithTag("Ally");
            takeTurn(team1);
            Debug.Log("The Player's turn is over!");
            turn = 1;
            return;
        }

        if (turn == 1)
        {
            Debug.Log("The Enemy is going!");
            team2 = GameObject.FindGameObjectsWithTag("Enemy");
            takeTurn(team2);
            Debug.Log("The Enemy's turn is over!");
            turn = 0;
            return;
        }
    }
       
}
