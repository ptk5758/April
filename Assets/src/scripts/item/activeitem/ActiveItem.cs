using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveItem : ItemDefault
{
    /// <summary>
    /// 아이템 사용효과
    /// </summary>
    public abstract void UseItem();
}
