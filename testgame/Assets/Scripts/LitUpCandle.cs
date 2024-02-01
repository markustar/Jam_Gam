using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitUpCandle : MonoBehaviour
{
    public AudioSource LitUpCandleSound;
    public event EventHandler OnLit;
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
            LitUpCandleSound.Play(0);
            meshFilter.mesh = newMesh;
            LitUp.transform.localPosition = new Vector3(0, 10f, 0);
            LitUp.intensity = 80f;
            LitUp.spotAngle = 180f;
            LitUp.color = Health.Instance.playerLight.color;
            CandleIsLitUp = true;
            HealZone.SetActive(true);
            OnLit?.Invoke(this, EventArgs.Empty);
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
