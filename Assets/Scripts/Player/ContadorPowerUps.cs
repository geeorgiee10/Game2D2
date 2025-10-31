using UnityEngine;

public class ContadorPowerUps : MonoBehaviour
{

    public int powerUps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUps = FindObjectsByType<PowerUp>(FindObjectsSortMode.None).Length;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
