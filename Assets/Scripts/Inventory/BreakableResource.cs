using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableResource : MonoBehaviour {

    public int maxHealth;
    int health;
    public GameObject dropOnBreak;
    public int dropCount;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            for (int i = 0; i < dropCount; i++)
            {
                Instantiate(dropOnBreak, transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
