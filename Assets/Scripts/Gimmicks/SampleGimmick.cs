using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGimmick : MonoBehaviour
{
    //アイテムを持っている状態で、クリックされたら消える
    //クリック判定
    public void OnClickObj(){
        Debug.Log("クリックされたぜ");
        bool clear = ItemBox.instance.TryUseItem(Item.Type.Cube);

        if(clear == true){
            Debug.Log("ギミック解除");
            gameObject.SetActive(false);
        }

        //アイテム持ってますよ判定
    }

}
