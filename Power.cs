using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) ); 
        }
    }

    IEnumerator Pickup(Collider player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        CapsuleCollider collide = player.GetComponent<CapsuleCollider>();
        if (stats.ecto >= 10)
        {
            // Hypothetically this should disable the collider so player can go through walls... it does not work tho
            collide.isTrigger = true;
            // For now health boost is just to make sure it's working
            stats.health *= 1.2f;
            stats.ecto -= 10;

            yield return new WaitForSeconds(4f);

            stats.health /= 1.2f;
            collide.isTrigger = false;

            Destroy(gameObject);
        }
    }
}
