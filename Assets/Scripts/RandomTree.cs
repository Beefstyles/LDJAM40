using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour {

    public Sprite[] Trees;
    private SpriteRenderer sr;

	void Start ()
    {
        Trees = Resources.LoadAll<Sprite>("Trees");
        sr = GetComponent<SpriteRenderer>();
        int randomTree = Random.Range(0, Trees.Length - 1);
        sr.sprite = Trees[randomTree];
    }
}
