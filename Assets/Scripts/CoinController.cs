using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.AddCoin();
        Destroy(gameObject);
    }
}
