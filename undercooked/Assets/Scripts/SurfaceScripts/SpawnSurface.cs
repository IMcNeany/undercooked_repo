﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSurface : ItemSurface {

    private SpawnObject spawn_object_script;

    public void Start()
    {
        spawn_object_script = GetComponent<SpawnObject>();
    }
    public override bool AddItem(GameObject obj)
    {
        //dont wanna add items to a item spawn, only take so we take away base.additem
        return false;
    }

    public override bool Interact(GameObject obj)
    {
        current_item = spawn_object_script.SpawnItem();
        return base.Interact(obj);
    }



}
