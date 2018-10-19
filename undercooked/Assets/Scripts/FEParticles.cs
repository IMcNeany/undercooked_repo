using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEParticles : MonoBehaviour {

    private ParticleSystem ps;
    private List<ParticleCollisionEvent> collision_events;

    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
        collision_events = new List<ParticleCollisionEvent>();
    }

    public void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collision_events);

        if (other.GetComponent<ItemSurface>())
        {
            ItemSurface surface = other.GetComponent<ItemSurface>();
            if(surface.fire)
            {
                Destroy(surface.fire);
            }
        }
        if (other.GetComponent<Player>())
        {
            Vector3 force = transform.position - other.transform.position;
            other.GetComponent<Rigidbody2D>().AddForce(-force.normalized * 5000);
        }
        
    }
}
