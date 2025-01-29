using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 10;
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(ammoAmount);
    }
}
