﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cityMain : MonoBehaviour {

    TextMesh text;

    public GameObject other_city;

    public int cityNum = 0;
    public bool isTarget = false;
    public float peoples = 50;

    public bool pro_crash = false;
    public bool pro_house = false;
    public bool pro_road = false;
    public bool pro_env = false;

    scr_managerMain managerMain;
    scr_managerCity managerCity;

    private void OnMouseUp()
    {
        if (managerMain.thisCity)
        {
            other_city = managerMain.thisCity;
            MovePeople(35/(managerCity.cityAmount + 1));
            managerMain.thisCity = null;
        }
    }

    private void OnMouseEnter()
    {
        managerMain.thisCity = gameObject;
    }

    private void OnMouseExit()
    {
        managerMain.thisCity = null;
    }

    private void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMesh>();
        managerMain = GameObject.Find("MainManager").GetComponent<scr_managerMain>();
        managerCity = GameObject.Find("CityManager").GetComponent<scr_managerCity>();
    }

    private void Update()
    {
        if (isTarget)
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        else
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        text.text = peoples + "%";
    }

    public void MovePeople(int scale)
    {
        StartCoroutine("MovePeopleC", scale);
    }

    IEnumerator MovePeopleC(int scale)
    {
        scr_cityMain other_cityMain = other_city.GetComponent<scr_cityMain>();
        other_city = null;

        for (int i = 0; i < scale; i++)
        {
            if (peoples >= 1)
            {
                peoples--;
                other_cityMain.peoples++;
            }
            yield return new WaitForSeconds(0.06f);
        }
    }
}
