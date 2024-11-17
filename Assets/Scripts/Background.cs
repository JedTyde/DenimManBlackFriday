using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public MeshRenderer[] meshRenderer1;

    public float variable;

    private void Awake()
    {
        
    }

    private void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        //foreach (var renderer in meshRenderer1)
        //{
        //    renderer.material.mainTextureOffset += (Vector2.right * speed * Time.deltaTime)/10;
        //}
        for (var i = 0; i < meshRenderer1.Length; i++)
        {
            if(GameManager.Instance.gameSpeed != 0) 
            {
                speed--;
            }
            
            meshRenderer1[i].material.mainTextureOffset += (Vector2.right * speed * Time.deltaTime)/ variable;
            
            Debug.Log(speed);
        }
        //meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
