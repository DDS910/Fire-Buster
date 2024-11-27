using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_terlihat : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public float jaraklihat = 5f;
    //public float textHeight = 1.5f;

    private TextMeshPro textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        textMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float jarakplayer = Vector3.Distance(transform.position, playerTransform.position);

        if (jarakplayer <= jaraklihat)
        {
            textMesh.enabled = true;

            Vector3 playerDirection = playerTransform.position - transform.position;
            playerDirection.y = 0f;
            Quaternion rotationToPlayer = Quaternion.LookRotation(playerDirection);

            Quaternion currentRotation = transform.rotation;

            rotationToPlayer *= Quaternion.Euler(0, 180, 0);

            transform.rotation = Quaternion.Slerp(currentRotation, rotationToPlayer, Time.deltaTime * 5f);

            //Vector3 posisi = transform.position;
            //posisi.y = transform.position.y + textHeight;
            //textMesh.transform.position = posisi;
        }
        else
        {
            textMesh.enabled = false;
        }
    }
}
