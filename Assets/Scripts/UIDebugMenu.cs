using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIDebugMenu : MonoBehaviour
{
    public CommonBattleCharacter TargetChara;
    public void OnClickInit()
    {
        var weaponDataScripts = Resources.Load<WeaponDataScriptableObject>("WeaponData");
        TargetChara.Init(weaponDataScripts.WeaponDatas.First());
    }
    public void OnClickFire()
    {
        TargetChara.RequestFire();
    }
}
