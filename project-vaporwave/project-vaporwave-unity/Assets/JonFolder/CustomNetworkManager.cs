using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	Color[] playerColors = new Color[] {Color.red, Color.blue};

	public override void OnServerAddPlayer(
		NetworkConnection conn, 
		short playerControllerId
	){
		//print(playerControllerId);
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<Player>().setColor(playerColors[playerControllerId]);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
