using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollerBackGround : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeedBackGround;
    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = moveSpeedBackGround * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
