using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 1;
    public int armor = 0;
    public int reactionTime = 3;
    public int attackDamage = 1;

    private int attackTime;
    private GameObject player;
    // Start is called before the first frame update
    void Start() {
        attackTime = reactionTime;
        player = GameObject.Find("Player");

        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator Attack() {
        while(true) {
            yield return new WaitForSeconds(1);
            if(attackTime <= 1) {
                player.GetComponent<PlayerScript>().GetAttacked(attackDamage);
                attackTime = reactionTime;
                Debug.Log(this.gameObject.name + " attacks for " + attackDamage + " damage");
            }
            else {
                attackTime--;
            }
        }
    }

    public void GetAttacked(int damage) {
        Debug.Log(this.gameObject.name + " took " + damage + " damage");
        if(armor > 0) {
            armor -= damage;
        }
        else {
            health -= damage;
        }
        if(health == 0) {
            Die();
        }
    }

    void Die() {
        GameScript.CurrentNumberOfEnemies--;
        Debug.Log(this.gameObject.name + " dies");
        Destroy(this.gameObject);
    }
}
