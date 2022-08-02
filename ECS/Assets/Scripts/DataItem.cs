#region   数据模板
public class DataCfg
{
    public int id;
    public string name;
    public string icon;

    public int isUse;
    public int isSell;
    public int isEquip;
}

public class DataItem
{
    public DataCfg cif;

    public DataItem(int id)
    {
        cif = new DataCfg();
        cif.id = id;
        cif.name = id.ToString();
        cif.icon = id.ToString();
        switch (id)
        {
            case 1:
                cif.isUse = 0;
                cif.isSell = 1;
                break;
            case 2:
                cif.isUse = 1;
                cif.isSell = 0;
                break;
            case 3:
                cif.isUse = 1;
                cif.isSell = 1;
                cif.isEquip = 1;
                break;
            default:
                break;
        }
    }

    public DataItem GetItemDataById(int id)
    {
        DataItem data = new DataItem(id);
        return data;
    }
}
#endregion   