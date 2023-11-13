using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterController : MonoBehaviour
{
    [SerializeField] private float CharacterHeight = 1f;
    [SerializeField] private GameObject BattleModel;
    [SerializeField] private AimController AimController;

    public void Awake()
    {
        BattleModel.transform.localPosition = Vector3.up * CharacterHeight;
        AimController.Initialize(BattleModel.transform);
    }
}

