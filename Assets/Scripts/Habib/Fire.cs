using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private List<Vector3> positions = new List<Vector3>();
    [SerializeField] private float healthPoint = 3f;
    private bool isTouchingWater = false;
    private float remainingHealth;
    int fireCount;
    IndicatorsController indicators;

    // Start is called before the first frame update
    void Start()
    {
        GenerateFire();

        UnityEngine.Random.InitState((DateTime.Now.ToString("hh:mm:ss")).GetHashCode());

    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchingWater)
        {
            if (remainingHealth <= 0f)
            {
                ExtinguishFire();
            }
            else
            {
                remainingHealth -= Time.deltaTime;
            }
        }
    }

    void GenerateFire()
    {
        fireCount = UnityEngine.Random.Range(1, 3);
        for (int i = 0; i < fireCount; i++)
        {
            GameObject fire = Instantiate(firePrefab, transform.position + positions[i], transform.rotation, transform);
        }
    }

    void ExtinguishFire()
    {
        fireCount -= 1;
        if(fireCount == 0)
        {
            indicators.fireUpdate++;
            Destroy(gameObject);
        }
        else
        {
            remainingHealth = healthPoint;
            transform.GetChild(fireCount).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isTouchingWater = true;
            remainingHealth = healthPoint;
            print("water touch");
        }
        print("touch");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isTouchingWater = false;
        }
    }
}
