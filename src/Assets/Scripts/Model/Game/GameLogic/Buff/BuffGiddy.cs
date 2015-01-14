using UnityEngine;
using System.Collections;

public class BuffGiddy : Buff
{
    GameObject go;
    public float restTime;
    public override void Attach(Warrior warrior)
    {
        base.Attach(warrior);
        go = new GameObject();
        UISprite sprite = go.AddComponent<UISprite>();
        sprite.atlas = ResourceManager.Load("Animation/giddy").GetComponent<UIAtlas>();
        sprite.spriteName = "0";
        sprite.depth = 20;
        UISpriteAnimation animation = go.AddComponent<UISpriteAnimation>();
        animation.framesPerSecond = 20;
        warrior.gameObject.AddChild(go);
        go.transform.localPosition = new Vector3(0, warrior.GetComponent<UISprite>().height + 10, 0);
        warrior.attackState = AttackState.None;
        if (warrior.moveState == MoveState.Move)
        {
            warrior.moveState = MoveState.Idle;
        }
        
        warrior.attackLock++;
        warrior.moveLock++;
    }

    public override void Detach()
    {
        base.Detach();
        GameObject.Destroy(go);

        owner.attackLock--;
        owner.moveLock--;
    }

    public override void Update()
    {
        base.Update();
        restTime -= Time.deltaTime;
        if (restTime<=0)
        {
            owner.RemoveBuff(this);
        }
    }
}
