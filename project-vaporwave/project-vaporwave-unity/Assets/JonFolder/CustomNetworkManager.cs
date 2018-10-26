using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

	Stack<Color> playerColors = new Stack<Color>();

	//[SyncVar]
	private short playerCount = 0;

	private void initStack(){
		playerColors.Push(Color.black);
		playerColors.Push(Color.green);
		playerColors.Push(Color.red);
		playerColors.Push(Color.blue);
		playerColors.Push(Color.magenta);
	}

	public override void OnServerAddPlayer(
		NetworkConnection conn, 
		short playerControllerId
	){
		//print(playerControllerId);

		//push a new round of colours to the stack if it's empty
		if (playerColors.Count == 0){
			initStack();
		}

		//create a player object and give it the next available playerColor
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		
		Color color= playerColors.Pop();
		Debug.Log(color);
		player.GetComponent<Player>().RpcSetColor(color);

		//keep count of how many players we have
		//playerCount++;
	}

	public override void OnServerRemovePlayer(
		NetworkConnection conn,
		PlayerController playerController
	){
		GameObject player = playerController.gameObject;
        Color color = player.GetComponent<Player>().getColor();
        //NetworkServer.RemovePlayerForConnection(conn, player, playerControllerId);

		//get rid of the player's game object; they are DEAD to us
		Destroy(player, 0.0f);

		//make the old color available again
		playerColors.Push(color);
	}
}
