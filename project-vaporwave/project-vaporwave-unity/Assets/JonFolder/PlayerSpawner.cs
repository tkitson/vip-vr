using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawner : NetworkBehaviour {

	public GameObject playerPrefab;

	// Use this for initialization
	public override void OnStartClient () {
		ClientScene.RegisterPrefab(playerPrefab);
	}
	
	[Server]
	public void ServerSpawnPlayer(Vector3 pos, Quaternion rot) {
		var player = (GameObject) Instantiate(playerPrefab, pos, rot);
		NetworkServer.Spawn(player);
	}
}
