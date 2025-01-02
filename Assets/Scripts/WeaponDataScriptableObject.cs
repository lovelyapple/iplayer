using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponFireMode
{
    Single,
    SemiAuto,
    FullAuto,
    SingleReload,
}
[Serializable]
public class WeaponData
{
    public long Code;
    public string Name;
    public int Damage;
    public int Range;
    public int FireRateMilSec;
    public int Accuracy;
    public int MaxMagazine;
    public int ReloadSpeedMilSec;
    public List<WeaponFireMode> WeaponFireModes;
}
[CreateAssetMenu(fileName = "WeaponData", menuName = "Custom/CreateWeaponData")]
public class WeaponDataScriptableObject : ScriptableObject
{
    public List<WeaponData> WeaponDatas;
}
