using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public void setColor(Color color) {
        //find the renderer for this Player
        Renderer rend = GetComponent<MeshRenderer>();

        //find the material for this Player, and adjust its color
        //to match the given color
        rend.material.color = color;
    }

    public Color getColor(){
        //find the renderer for this Player
        Renderer rend = GetComponent<MeshRenderer>();
        //and return its colour
        return rend.material.color;
    }

    public override void OnStartLocalPlayer()
    {
        
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}