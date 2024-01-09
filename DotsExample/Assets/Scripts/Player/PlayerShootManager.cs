using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    public static PlayerShootManager Instance {  get; private set; }
    [SerializeField]
    private GameObject _shootPopUpPrefab;
    private void Awake()
    {
        Instance = this;
    }
    /*
    private void Start()
    {
        PlayerShoutingSystem playerShoutingSystem=
            World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShoutingSystem>();

        playerShoutingSystem.OnShoot += playerShoutingSystem_OnShoot;
    }

    private void playerShoutingSystem_OnShoot(object sender,EventArgs e)
    {
       Entity playerEntity=(Entity)sender;
       LocalTransform localTransform = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(playerEntity);
        Instantiate(_shootPopUpPrefab, localTransform.Position, Quaternion.identity);
       
    }
    */
    public void PlayerShoot(Vector3 playerPosition)
    {
        Instantiate(_shootPopUpPrefab, playerPosition,Quaternion.identity);
    }
}
