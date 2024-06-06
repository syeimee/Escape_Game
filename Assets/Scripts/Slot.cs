using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item;
    [SerializeField] Image image;
    [SerializeField] GameObject backgroundPanel;

    private void Awake(){
        // image = GetComponent<Image>();
    }
    private void Start(){
        backgroundPanel.SetActive(false);
    }
    public bool IsEmpty(){
        if( item == null){
            return true;
        }else{
            return false;
        }
    }

    public void SetItem(Item item){
        this.item = item;
        UpdateImage(item);
    }
    public Item GetItem(){
        return item;
    }
    //アイテムを受けっとたらその画像をスロットに表示させる
    void UpdateImage(Item item){
        image.sprite = item.sprite;
    }

    public bool OnSelected(){
        if( item == null ){
            return false;
        }
        backgroundPanel.SetActive(true);
        return true;
    }
    public void HideBGPanel(){
        backgroundPanel.SetActive(false);
    }

}
