using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//List�� Jason���� �����Ҽ� �ְԵ����ִ� Class
[System.Serializable]
public class Serialization<T>
{
    public Serialization(List<T> _target) => target = _target; 
    public List<T> target;
}

//Item ������ ���̽�
[System.Serializable]
public class Item
{
    //������ ����
    public Item(int _key, string _type, string _name, string _content, bool _isUsing, int _indexNum)
    {
        key = _key; type = _type; name = _name; content = _content; isUsing = _isUsing; indexNum = _indexNum; 
    }

    public int key, indexNum;
    public string type, name, content;
    public bool isUsing;
}

//Clue ������ ���̽�
[System.Serializable]
public class Clue
{
    //������ ����
    public Clue(int _key, string _type, string _name, string _content, bool _isUsing, int _indexNum)
    {
        key = _key; type = _type; name = _name; content = _content; isUsing = _isUsing; indexNum = _indexNum;
    }

    public int key, indexNum;
    public string type, name, content;
    public bool isUsing;
}

public class ObjectManager : MonoBehaviour
{
    //Item
    #region 
    //������ ������ ���� ��� txt����
    public TextAsset itemDataBase;
    //Item Ŭ���� ���� ������ �����͵��� ����Ʈȭ ��Ų ��
    public List<Item> allItemList;
    
    //���� �������� ������ ����Ʈ
    public List<Item> myItemList;

    //���Կ��� ������ ������ ����Ʈ
    public List<Item> curItemList;
    #endregion

    //�ܼ� ������ ���� ��� txt����
    public TextAsset clueDataBase;

    //Clue Ŭ���� ���� �ܼ� �����͵��� ����Ʈȭ ��Ų��
    public List<Clue> allClueList;

    //���� �������� �ܼ� ����Ʈ
    public List<Clue> myClueList;

    //���Կ��� ������ �ܼ� ����Ʈ
    public List<Clue> curClueList;

    //������ Json�� ����� ��ġ
    public string itemfilePath;

    //�ܼ� Json�� ����� ��ġ
    public string cluefilePath;

    //ó���� ������ ������Ʈ Ÿ��
    public string curType = "Item";

    //����
    public GameObject[] slot;

    //������϶� �̹���
    public GameObject[] usingImage;

    //������Ʈ �̹���
    public Image[] objectImage;

    //�ΰ��� �̹����� �迭�� �ε����� ������Ʈ���� �ε��� ���� ��ġ�ؾ��Ѵ�.
    //������ �̹���
    public Sprite[] itemSprite;
    //�ܼ� �̹���
    public Sprite[] clueSprite;

    //���� �������� ������Ʈ�� �̹���
    public Image equitObjectSprite;

    //������Ʈ ������ ǥ�õǴ� �ؽ�Ʈ
    public Text contentText;

    // Start is called before the first frame update
    void Start()
    {
        //��ü ������ ����Ʈ �ҷ�����
        #region
        //String �迭 line�ȿ� itemDataBase ���� �������� 0���� itemDataBase.text.Length���� �޾ƿµ� ���͸� �������� �迭�� ������ ����
        //ex) line.length = ItemDataBase ���� �ڵ��� �� ����
        string[] itemline = itemDataBase.text.Substring(0, itemDataBase.text.Length).Split('\n');
        
        // ItmeDataBasse ���� �������� Tab�� �������� ������ ����
        // ex) row[0] = key, row[1] = ObjectType, row[2] = Name, row[3] = Content, row[4] = isUsing, row[5] = IndexNum
        for(int i = 0; i< itemline.Length; i++)
        {
            string[] row = itemline[i].Split('\t');
            
            //allItemList�� ���� �߰�
            allItemList.Add(new Item(int.Parse(row[0]), row[1], row[2], row[3], row[4] == "TRUE", int.Parse(row[5])));
        }
        #endregion

        //��ü �ܼ� ����Ʈ �ҷ�����
        #region
        //�ܼ� �����ͺ��̽� �ؽ�Ʈ ���Ͼ��� �� ������ŭ�� ũ�⸦ ���� �迭 clueline ����
        string[] clueline = clueDataBase.text.Substring(0, clueDataBase.text.Length).Split('\n');

        for(int i = 0; i<clueline.Length; i++)
        {
            //TabŰ�� ���� �������� �����͵��� ��� �迭�� ����
            string[] row = clueline[i].Split('\t');

            allClueList.Add(new Clue(int.Parse(row[0]), row[1], row[2], row[3], row[4] == "TRUE", int.Parse(row[5])));
        }
        #endregion

        //������ Json ������ ����� ��ġ
        itemfilePath = Application.persistentDataPath + "/MyItemText.txt";

        //�ܼ� Json ������ ����� ��ġ
        cluefilePath = Application.persistentDataPath + "/MyClueText.txt";

        Save();
        Load();

        ////�ش� Ű���� ���� ������Ʈ ���
        //GetItem(1000);
        //GetItem(1001);
        //GetItem(1002);

        //GetClue(2003);
        //GetClue(2002);
        //GetClue(2001);
        //GetClue(2000);

        ////�ش� Ű ���� ���� ������Ʈ ����
        //RemoveClue(2000);
        //RemoveItem(1000);

        //������ �� �⺻���� �����ֱ�
        TabClick(curType);
    }

    //������Ʈ ���� Ŭ����
    public void SlotClick(int slotNum)
    {
        //������Ʈ Ÿ���� �������� ���
        if (curType == "Item")
        {
            Item curItem = curItemList[slotNum];
            Item usingItem = curItemList.Find(x => x.isUsing == true);

            //������� �������� ������ �����۵��� ����� false�� �ٲ�
            if (usingItem != null) usingItem.isUsing = false;
            {
                curItem.isUsing = true;

                //���õ� �����۾��� ���� ǥ���ϱ�
                contentText.text = curItem.content;

                //���õ� �̹��� �Ű��ֱ�
                equitObjectSprite.sprite = itemSprite[curItem.indexNum];
            }

            //������� �ܼ��� �ִٸ� usingClue�� ��ڴ�.
            Clue usingClue = curClueList.Find(x => x.isUsing == true);

            //���� ������� �ܼ��� �־��ٸ� �� ���� false�� �ٲٰڴ�.
            if(usingClue != null)
            {
                usingClue.isUsing = false;
            }

        }

        //������Ʈ Ÿ���� �ܼ��� ���
        else if (curType == "Clue")
        {
            Clue curClue = curClueList[slotNum];
            Clue usingClue = curClueList.Find(x => x.isUsing == true);

            if (usingClue != null) usingClue.isUsing = false;
            {
                curClue.isUsing = true;

                //���õ� �ܼ����� ���� ǥ���ϱ�
                contentText.text = curClue.content;

                //����������� ���� ���õ� �ܼ� �̹����� �ٲ��ֱ�
                equitObjectSprite.sprite = clueSprite[curClue.indexNum];
            }

            //������� �������� �ִٸ� usingItem�� ��ڴ�.
            Item usingItem = curItemList.Find(x => x.isUsing == true);

            //���� ������� �������� �־��ٸ� �� �������� isUsing�� false�� �ٲٰڴ�.
            if(usingItem != null)
            {
                usingItem.isUsing = false;
            }
        }

        Save();
    }
    
    //������Ʈ â������ Tab Ŭ��
    public void TabClick(string tabName)
    {
        //Ŭ���� Ÿ�Կ� ���缭 ������Ʈ ����Ʈ �ҷ�����
        curType = tabName;
       
        if (curType == "Item")
        {
            //Text���̱�
            for (int i = 0; i < slot.Length; i++)
            {
                //������ �����ϴ��� Ȯ��
                bool isExist = i < curItemList.Count;
                slot[i].SetActive(isExist);
                slot[i].GetComponentInChildren<Text>().text = isExist ? curItemList[i].name : "";

                //������ �����Ѵٸ�
                if (isExist)
                {
                    //�̹�����ü
                    objectImage[i].sprite = itemSprite[allItemList.FindIndex(x => x.name == curItemList[i].name)];
                    usingImage[i].SetActive(curItemList[i].isUsing);
                }
            }
        }
        
        else if (curType == "Clue")
        {
            //Text���̱�
            for (int i = 0; i < slot.Length; i++)
            {
                //������ �����ϴ��� Ȯ��
                bool isExist = i < curClueList.Count;
                slot[i].SetActive(isExist);
                slot[i].GetComponentInChildren<Text>().text = isExist ? curClueList[i].name : "";

                //������ �����Ѵٸ�
                if(isExist)
                {
                    //�̹�����ü
                    objectImage[i].sprite = clueSprite[allClueList.FindIndex(x => x.name == curClueList[i].name)];
                    usingImage[i].SetActive(curClueList[i].isUsing);
                }
            }
        }
    }

    //Data ����
    void Save()
    {
        //Json ������ ������ ����
        string jItemdata = JsonUtility.ToJson(new Serialization<Item>(allItemList));

        //json ������ ���� ����
        File.WriteAllText(itemfilePath, jItemdata);

        //Json �ܼ� ������ ����
        string jCluedata = JsonUtility.ToJson(new Serialization<Clue>(allClueList));

        //json �ܼ� ���� ����
        File.WriteAllText(cluefilePath, jCluedata);

        //���� �������� ������ ����Ʈ �ҷ�����
        TabClick(curType);
    }

    //Data �ҷ�����
    void Load()
    {
        //������ Json ������ ����
        string jItemdata = File.ReadAllText(itemfilePath);
        //������ Json���Ϸκ��� ������ ������ȭ(Load)
        myItemList = JsonUtility.FromJson<Serialization<Item>>(jItemdata).target;

        //���� �������� ������ ����Ʈ �ҷ�����
        TabClick(curType);

        //�ܼ� Json ������ ����
        string jCluedata = File.ReadAllText(cluefilePath);
        //�ܼ� Json���Ϸκ��� ������ ������ȭ(Load)
        myClueList = JsonUtility.FromJson<Serialization<Clue>>(jCluedata).target;
    }

    //Key�� ���ؼ� ������ ���
    public void GetItem(int _key)
    {
        curItemList.Add(myItemList.Find(x => x.key == _key));
        TabClick(curType);
    }

    //Key�� ���ؼ� ������ ����
    public void RemoveItem(int _key)
    {
        curItemList.Remove(myItemList.Find(x => x.key == _key));
        TabClick(curType);
    }

    //Key�� ���ؼ� �ܼ� ���
    public void GetClue(int _key)
    {
        curClueList.Add(myClueList.Find(x => x.key == _key));
        TabClick(curType);
    }

    //Key�� ���ؼ� �ܼ� ����
    public void RemoveClue(int _key)
    {
        curClueList.Remove(myClueList.Find(x => x.key == _key));
        TabClick(curType);
    }
}
