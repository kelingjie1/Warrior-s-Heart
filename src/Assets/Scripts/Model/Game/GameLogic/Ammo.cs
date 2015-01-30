using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ammo : MonoBehaviour 
{
    public Warrior owner;
    public HitEventMessage msg = new HitEventMessage();
    public static Ammo Create()
    {
        Ammo ammo = ResourceManager.LoadGameObject("Prefab/Game/Ammo").GetComponent<Ammo>();
        return ammo;
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
                msg.ammo = this;
                BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
                if (!msg.ContinueAction)
                {
                    return;
                }
                BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);
            }
        }
    }
    void Update()
    {

    }
}
