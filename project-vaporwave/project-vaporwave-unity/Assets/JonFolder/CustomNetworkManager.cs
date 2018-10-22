using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	Color[] playerColors = new Color[] {Color.red, Color.blue};

	//[SyncVar]
	private short playerCount = 0;

	public override void OnServerAddPlayer(
		NetworkConnection conn, 
		short playerControllerId
	){
		//print(playerControllerId);

		//create a player object and give it the next available playerColor
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<Player>().setColor(playerColors[playerCount]);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

		//keep count of how many players we have
		playerCount++;
	}
}
