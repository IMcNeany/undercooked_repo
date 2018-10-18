using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExstinguisher : Pickup {

    public ParticleSystem ps;

    public void UseItem()
    {
        ps.Play();
        
    }
}
