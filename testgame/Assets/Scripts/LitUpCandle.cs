using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitUpCandle : MonoBehaviour
{
    public Mesh newMesh;
    public MeshFilter meshFilter;
    public bool PlayerIn = false;
    public GameObject HealZone;
    public Light LitUp;
    public bool CandleIsLitUp = false;

    private ThingsChanger thingsChanger;

    private void Start()
    {
        thingsChanger = ThingsChanger.Instance;
    }
    private void Update() {
        if(PlayerIn == true && Input.GetKeyDown(KeyCode.E) && thingsChanger.candleIsActive == true)
        {
            meshFilter.mesh = newMesh;
            LitUp.range = 7f;
            CandleIsLitUp = true;
            HealZone.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIn = false;
        }
    }
}
