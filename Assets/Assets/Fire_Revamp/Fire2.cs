using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Fire2 : MonoBehaviour
{
    [SerializeField] private float BurnRadius; //Radius bakar antara Cell
    [SerializeField] private float BurnTimer;
    [SerializeField] private float BurnTime;
    [SerializeField] private float FireSourceRadius;
    [SerializeField] public float CellHealthPoint = 50;
    [SerializeField] private float BurnDamageToCell = 1.5f;
    [SerializeField] private GameObject cell;


    public bool isBurning = false; // Jika cell dibakar oleh FireSource.
    public bool neighborisBurn = false; // Cell dibakar oleh cell yang dibakar oleh FireSource
    
    public GameObject fireEffectPrefab;
    private Transform[] fireSource;
    private GameObject fireEffectIntance; //Clone dari FireSource
    private GameObject fireEffectNeighbor; //Chain Reaction dari cell ke cell



    private void Start()
    {
        //Mencari FireSource dengan tag Fire
        GameObject[] FireSource = GameObject.FindGameObjectsWithTag("Fire");
        fireSource = new Transform[FireSource.Length];

        for(int i = 0; i < FireSource.Length; i++)
        {
            fireSource[i] = FireSource[i].transform;
        }

    }
    private void Update()
    {
        if (!isBurning && fireSource != null && fireEffectPrefab.activeSelf)
        {
            foreach (Transform fire in fireSource)
            {
                if (fire != null && Vector3.Distance(transform.position, fire.position) <= FireSourceRadius)
                {
                    StartBurning();
                    break;
                }
            }
        }


        if (isBurning)
        {
            BurnTimer += Time.deltaTime;
            if(BurnTimer >= BurnTime)
            {
                SpreadFire();
                BurnTimer = 0f;
            }
        }

        burnDamage();
    }

    private void StartBurning()
    {
        isBurning = true;

        if (fireEffectIntance == null)
        {
            Quaternion fireEffectRotation = Quaternion.Euler(-90, 0, 0);
            fireEffectIntance = Instantiate(fireEffectPrefab, transform.position, fireEffectRotation);
            fireEffectIntance.transform.SetParent(transform);
        }
    }
    public void SpreadFire()
    {
        Vector3 position = transform.position;

        TryBurnCellAt(position + Vector3.forward);
        TryBurnCellAt(position + Vector3.back);
        TryBurnCellAt(position + Vector3.left);
        TryBurnCellAt(position + Vector3.right);
    }

    public void TryBurnCellAt(Vector3 position)
    {
        //float burnRadius = 1.0f;
        Collider[] colliders = Physics.OverlapSphere(position, BurnRadius);
        foreach (Collider col in colliders)
        {
            Fire2 cell = col.GetComponent<Fire2>();
            if (cell != null && !cell.isBurning)
            {
                cell.StartBurning();
                //neighborisBurn = true;
            }
        }

    }


    private void burnDamage()
    {
        if (isBurning)
        {
            CellHealthPoint -= BurnDamageToCell * Time.deltaTime;
        }

        if (CellHealthPoint <= 0)
        {
            isBurning = false;
            CellHealthPoint = 0;
            Destroy(cell);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Menggambar radius pembakaran antara cell (BurnRadius)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, BurnRadius);

        // Menggambar radius pembakaran dari FireSource (FireSourceRadius)
        if (fireSource != null)
        {
            //Gizmos.color = Color.blue;
            //Gizmos.DrawWireSphere(fireSource.position, FireSourceRadius);

            foreach (Transform fire in fireSource)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(fire.position, FireSourceRadius);
            }
        }
    }
}
