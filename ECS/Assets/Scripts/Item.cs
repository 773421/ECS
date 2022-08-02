#region   数据实体
using System.Collections.Generic;

public enum ShowType//显示的位置
{
    nullType = -1,
    bag,
    shop,
    Max = 99
}
public enum ComponentType//组件的类型
{
    nullType = -1,
    use,
    sell,
    equip,
    Max = 99
}

public class Item//Item的数据的实例  Entity
{
    public ShowType show = ShowType.bag;//默认是背包层显示
    public Dictionary<ComponentType, ComponentBase> dic = new Dictionary<ComponentType, ComponentBase>();
    public DataItem data;//数据


    static public Item CreateEntityByID(int id, ShowType type = ShowType.bag)//根据ID生成一个实例数据
    {
        Item item = new Item();
        item.CreateByID(id, type);
        return item;//返回数据实例
    }

    public void CreateByID(int id, ShowType type = ShowType.bag)//根据ID生成数据
    {
        data = new DataItem(id);//创建一个数据实例
        InjectAction(type);//注入方法
    }

    public void InjectAction(ShowType type)
    {
        show = type;//更新显示层

        if (data.cif.isUse == 1)//判断是否显示使用
        {
            Use use = new Use();//实例使用组件  //Component
            dic.Add(ComponentType.use, use);//加入字典，后面一致
        }
        if (data.cif.isSell == 1)
        {
            Sell sell = new Sell(); //Component
            dic.Add(ComponentType.sell, sell);
        }
        if (data.cif.isEquip == 1)
        {
            Equip equip = new Equip(); //Component
            dic.Add(ComponentType.equip, equip);
        }
    }

    
}

#endregion