using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public float speed = 10f;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int dash_time = 5;
    [SerializeField] GameObject deadEffect;
    InventoryController inventoryController;
    CharacterBuff characterBuff;
    UIController uicontroller;
    NewMap newMap;
    void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
        uicontroller = FindObjectOfType<UIController>();
        characterBuff = FindObjectOfType<CharacterBuff>();
        newMap = FindObjectOfType<NewMap>();
    }

    
    void Update()
    {
        float x= Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");
        
        Camera.main.transform.position = new Vector3(transform.position.x,40f,transform.position.z-20f);
        Camera.main.transform.LookAt(transform);
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle , Vector3.up);

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.green);
          

        Vector3 move = new Vector3(x,0,z);
        transform.Translate(move*speed*Time.deltaTime,Space.World);

        if(playerHealth <=0){
            Instantiate(deadEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }

        if(Input.GetMouseButtonDown(1) && inventoryController.inventory.Count > 0){
            inventoryController.useAbility();
        }
        if(Input.GetKeyDown(KeyCode.Space) && dash_time == 5){            
            StartCoroutine(nameof(dash));
            InvokeRepeating(nameof(DashTime),0,1f);
        }
        if(dash_time <=5){
            uicontroller.dash_image.GetComponent<Image>().fillAmount += 1/4f * Time.deltaTime;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        
        print(newMap.currentMap.name);
        if(other.gameObject.tag.Equals("Buff")){
            characterBuff.buffActiveded(other.gameObject.name);
            Destroy(other.gameObject,0.2f);
        }
        if(other.gameObject.name.Equals("Chest")){
            FindObjectOfType<NewMap>().IsChestOpen = true;
        }
        if(other.gameObject.name.Equals(newMap.currentMap.name)){
            newMap.mapChangeUpdate();

        }
    }

    void DashTime(){
        if(dash_time != 5){
            dash_time++;
            
        } 
        else CancelInvoke(nameof(DashTime));
    }

    IEnumerator dash(){
        int count = 0;
        dash_time = 0;
        uicontroller.dash_image.GetComponent<Image>().fillAmount = 0;
        while(count < 10)
        {
            count++;
            transform.position = Vector3.MoveTowards(transform.position,transform.position + transform.forward,Time.deltaTime*10000f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
