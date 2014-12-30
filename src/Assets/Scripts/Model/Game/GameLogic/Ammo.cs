using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ammo : MonoBehaviour 
{
    public Warrior owner;
    public static Ammo Create()
    {
        return ResourceManager.Load("Prefab/Game/Ammo").GetComponent<Ammo>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Floor")
        {
            GameObject.Destroy(this.GetComponent<ConstantForce>());
            GameObject.Destroy(this.GetComponent<BoxCollider>());
            GameObject.Destroy(this.GetComponent<Rigidbody>());
            BattleField.Instance.AddTrash(this.gameObject);
        }
        else
        {
            this.rigidbody.useGravity = true;
            BattleField.Instance.AttackerAmmoList.Remove(this);
            BattleField.Instance.DefenderAmmoList.Remove(this);
            Warrior warrior = collision.collider.GetComponent<Warrior>();
            if (warrior != null)
            {
                List<Warrior> sponsors = new List<Warrior>() { owner };
                List<Warrior> responders = new List<Warrior>() { warrior };
                BattleEventMessage msg = new BattleEventMessage();
                BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
                if (!msg.ContinueAction)
                {
                    return;
                }
                BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
    }
    void Update()
    {

    }
}
