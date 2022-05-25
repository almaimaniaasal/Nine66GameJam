using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeMaterial : MonoBehaviour
{
    Renderer cubeRenderer;

    [SerializeField] Texture[] textures; 
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text cubeNumber = gameObject.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
        if (cubeNumber.text == "2")
		{
            cubeRenderer.material.mainTexture = textures[0];
		}
        if (cubeNumber.text == "4")
        {
            cubeRenderer.material.mainTexture = textures[1];
        }
        if (cubeNumber.text == "8")
        {
            cubeRenderer.material.mainTexture = textures[2];
        }
        if (cubeNumber.text == "16")
        {
            cubeRenderer.material.mainTexture = textures[3];
        }
        if (cubeNumber.text == "32")
        {
            cubeRenderer.material.mainTexture = textures[4];
        }
        if (cubeNumber.text == "64")
        {
            cubeRenderer.material.mainTexture = textures[5];
        }
        if (cubeNumber.text == "128")
        {
            cubeRenderer.material.mainTexture = textures[6];
        }
        if (cubeNumber.text == "256")
        {
            cubeRenderer.material.mainTexture = textures[7];
        }
        if (cubeNumber.text == "512")
        {
            cubeRenderer.material.mainTexture = textures[8];
        }
        if (cubeNumber.text == "1024")
        {
            cubeRenderer.material.mainTexture = textures[9];
        }
        if (cubeNumber.text == "2048")
        {
            cubeRenderer.material.mainTexture = textures[10];
        }
        if (cubeNumber.text == "4096")
        {
            cubeRenderer.material.mainTexture = textures[11];
        }
    }
}
