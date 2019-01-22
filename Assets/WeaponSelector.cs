using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrimaryWeapon
{
    BasicBeam,
    FireBeam,
    IceBeam
}

public enum SecondaryWeapon
{
    Fireball,
    LightningBolt,
}

public class WeaponSelector : MonoBehaviour
{
    public PrimaryWeapon primaryWeapon;
    public SecondaryWeapon secondaryWeapon;
    //Enum that determines weapon
    //Player input selects weapon
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
