using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBack;
    public int row, column, value;
    public ImgType m_imgType { get; set; }
    public ItemType m_tagType { get; set; }
   
    [SerializeField]
    private GameObject curSor;


   // private GameControllerClone gameController;

    public enum ImgType
    {
        IMAGE,
        TEXT
    }

    public enum ItemType
    {
        BABY,
        MOM,
        DAD
    }

    public Items(ItemType tagType )
    {
        m_tagType = tagType;
    }

    public void OnMouseDown()
    {
        
    }

    private void Start()
    {
       
    }



}
