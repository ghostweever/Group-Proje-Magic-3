 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpellImages : MonoBehaviour
{
    //Changes spell images based on whats pressed

    public Image originalPrimary;
    public Sprite[] sprites;

    public Image originalSecondary;
    public Sprite[] spritesSecondary;

    public Image originalCombo;
    public Sprite[] spritesCombo;


    void Start()
    {
        originalPrimary.sprite = sprites[2];
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCombo();
    }

    public void ChangePrimary()
    {
        if (originalPrimary.sprite == sprites[0])
        {
            originalPrimary.sprite = sprites[1];
        }
        else if (originalPrimary.sprite == sprites[1])
        {
            originalPrimary.sprite = sprites[2];
        }
        else if (originalPrimary.sprite == sprites[2])
        {
            originalPrimary.sprite = sprites[0];
        }
    }

    public void ChangeSecondary()
    {
        if (originalSecondary.sprite == sprites[0])
        {
            originalSecondary.sprite = sprites[1];
        }
        else if (originalSecondary.sprite == sprites[1])
        {
            originalSecondary.sprite = sprites[2];
        }
        else if (originalSecondary.sprite == sprites[2])
        {
            originalSecondary.sprite = sprites[0];
        }
    }

    public void ChangeCombo()
    {
        if (originalSecondary.sprite == sprites[0] && originalPrimary.sprite == sprites[0])
        {
            originalCombo.sprite = spritesCombo[4];
        }
        if (originalSecondary.sprite == sprites[1] && originalPrimary.sprite == sprites[1])
        {
            originalCombo.sprite = spritesCombo[3];
        }
        if (originalSecondary.sprite == sprites[2] && originalPrimary.sprite == sprites[2])
        {
            originalCombo.sprite = spritesCombo[2];
        }
        if ((originalSecondary.sprite == sprites[0] && originalPrimary.sprite == sprites[1]) || ( originalSecondary.sprite == sprites[1] && originalPrimary.sprite == sprites[0]))
        {
            originalCombo.sprite = spritesCombo[0];
        }
        if (originalSecondary.sprite == sprites[1] && originalPrimary.sprite == sprites[2] || (originalSecondary.sprite == sprites[2] && originalPrimary.sprite == sprites[1]))
        {
            originalCombo.sprite = spritesCombo[1];
        }
        if (originalSecondary.sprite == sprites[0] && originalPrimary.sprite == sprites[2] || (originalSecondary.sprite == sprites[2] && originalPrimary.sprite == sprites[0]))
        {
            originalCombo.sprite = spritesCombo[5];
        }
    }
}
