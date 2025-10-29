using UnityEngine;
using TMPro;
using System.Collections;


public class Datos2 : MonoBehaviour
{
    
    

    public int vidas;

    public static Datos2 Instance;
    public int puntos;



    private void Awake(){
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        
            
    }

    

    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
