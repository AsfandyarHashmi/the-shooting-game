using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health = 5;
    public int armor = 0;
    public int attackDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAttacked();
    }

    public void GetAttacked(int damage) {
        Debug.Log("Player took " + damage + " damage");
        CameraScript.Shake(0.5f, 0.5f);
        if(armor > 0) {
            armor  -= damage;
        }
        else {
            health -= damage;
        }
        if(health == 0) {
            Die();
        }
    }

    void Die() {
         Destroy(this.gameObject);
    }

    void CheckIfAttacked() {
        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
                GameObject enemy = hit.transform.gameObject;
                if (enemy.GetComponent<EnemyScript>() != null) {
                    Debug.Log(this.gameObject.name + " attacks " + hit.transform.name + " for " + attackDamage + " damage");
                    enemy.GetComponent<EnemyScript>().GetAttacked(attackDamage);
                }  
            }  
        }
    }
}
