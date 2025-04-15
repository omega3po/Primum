using UnityEngine;

public class Npc : Object
{
    protected override void Awake()
    {
        base.Awake();
        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer on NPC: " + gameObject.name);
        }
    }

    protected override void Update()
    {
        base.Update();
    }
}