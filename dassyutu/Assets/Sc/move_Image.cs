using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Image : MonoBehaviour
{
    [Header("�G���A")]
    [SerializeField] GameObject this_Area;
    [SerializeField] GameObject next_Area;

    [Header("�t�F�[�h�C��/�A�E�g�p")]
    [SerializeField] GameObject this_Area_Image; // �����̃I�u�W�F�N�g�擾�p�ϐ�
    [SerializeField] GameObject next_Area_Image;
    [SerializeField] bool fadeOut_bool = false;
    [SerializeField] bool fadeIn_bool = false;
    [SerializeField] float fadeSpeed = 1f; // �t�F�[�h���x�w��

    void Start()
    {
        fadeOut_bool = false;
        fadeIn_bool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut_bool)
        {
            fade_Out();
        }else if(fadeIn_bool)
        {
            fade_In();
        }
    }
    public void Move_Image()
    {
        Debug.Log("Move_Image()");
        fadeOut_bool = true;
    }
    void fade_Out()
    {
        if (this_Area_Image.GetComponent<SpriteRenderer>().color.a > 255)
        {
            UnityEngine.Color tmp = this_Area_Image.GetComponent<SpriteRenderer>().color;
            tmp.a = tmp.a - (Time.deltaTime * fadeSpeed);
            this_Area_Image.GetComponent<SpriteRenderer>().color = tmp;
        }else
        {
            this_Area.SetActive(false);
            fadeOut_bool = false;
            fadeIn_bool = true;
            next_Area.SetActive(true);

            Color tmp_A = next_Area_Image.GetComponent<SpriteRenderer>().color;
            tmp_A.a = 0f;
            next_Area_Image.GetComponent<SpriteRenderer>().color = tmp_A;
        }
    }
    void fade_In()
    {
        if (next_Area_Image.GetComponent<SpriteRenderer>().color.a < 255)
        {
            UnityEngine.Color tmp = next_Area_Image.GetComponent<SpriteRenderer>().color;
            tmp.a = tmp.a + (Time.deltaTime * fadeSpeed);
            next_Area_Image.GetComponent<SpriteRenderer>().color = tmp;
        }else
        {
            fadeIn_bool = false ;
        }
    }
}
