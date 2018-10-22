using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SyncVar]
    public Color color;

    public void setColor(Color color) {
        this.color = color;

        //find the renderer for this Player
        Renderer rend = GetComponent<Renderer>();

        //find the shader for this Player, and adjust its color
        //to match the given color
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.red);
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