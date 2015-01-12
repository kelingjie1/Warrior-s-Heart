using UnityEngine;
using System.Collections;

public class Buff 
{
    public Warrior owner;
	public virtual void Attach(Warrior warrior)
    {
        owner = warrior;
    }

    public virtual void Detach()
    {

    }

    public virtual void Update()
    {

    }
}
