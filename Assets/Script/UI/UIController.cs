using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] Slider slider;
    public Text dash_text,game_time_text;
    public Image dash_image;
    public GameObject chestUI;

    public float game_time;
    playerMove playerMove;
    bullet bullet;
    NewMap newMap;
    void Start()
    {
        game_time = 0;
        playerMove = FindObjectOfType<playerMove>();
        newMap = FindObjectOfType<NewMap>();
        bullet = FindObjectOfType<bullet>();
        slider.maxValue = playerMove.playerMaxHealth;
        slider.value = playerMove.playerHealth;
        InvokeRepeating(nameof(timer),0,1);
    }

    
    void Update()
    {
        slider.value = playerMove.playerHealth;
        if(FindObjectOfType<playerMove>())
            dash_text.text = FindObjectOfType<playerMove>().dash_time.ToString();
        
        game_time_text.text = "Time: "+game_time.ToString();        
    }

    void timer(){
        game_time += newMap.isMapNext ? 1:0;
    }

    public void ChestBuff(string name){
        switch (name)
        {
            case "AttackBuff":
                bullet.bulletDamage +=20;
                break;
            case "SpeedBuff":
                playerMove.speed +=10;
                break;
            case "HealthBuff":
                playerMove.playerMaxHealth +=50;
                slider.maxValue = playerMove.playerMaxHealth;
                playerMove.playerHealth = playerMove.playerMaxHealth;
                break;       
        }
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>().interactable = false;
        chestUI.SetActive(false);
        Time.timeScale = 1;
    }
    

    
}
