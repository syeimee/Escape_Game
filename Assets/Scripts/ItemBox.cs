using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //slotsに要素をコードから入れる方法
    [SerializeField] Slot[] slots;
    Slot selectedSlot = null;
    //どこでも実行できるやつ
    public static ItemBox instance;
    private void Awake(){
        if(instance == null){
            instance = this;
            slots = GetComponentsInChildren<Slot>();
        }
    }
    //PickupObjがクリックされたら、スロットにアイテムを入れる
    public void SetItem(Item item){
        foreach(Slot slot in slots){
            if(slot.IsEmpty()){
                slot.SetItem(item);
                break;
            }
        }
    }

    public void OnSelectSlot(int position){
        //一旦全てのスロットの選択パネルを非表示
        foreach(Slot slot in slots){
            slot.HideBGPanel();
        }
        //選択されたスロットの選択パネルを表示
        if(slots[position].OnSelected()){
            selectedSlot = slots[position];
        };

    }
    //アイテムの使用を試みて使えるなら使う
    public bool TryUseItem(Item.Type type){
        //選択スロットがあるかどうか
        if(selectedSlot == null){
            return false;
        }
        if(selectedSlot.GetItem().type == type){
            
            selectedSlot.SetItem(null);//アイテムの消去
            selectedSlot.HideBGPanel();//背景パネルの削除
            selectedSlot = null; //選択アイテムの消去
            return true;
        }
        return false;

    }



}
