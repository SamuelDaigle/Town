﻿using UnityEngine;
using System.Collections;
using VillagerAI;

namespace Menu
{
	public class ChangeToKnight : MonoBehaviour
	{
	    private CharacterBehavior character;

	    void OnMouseDown()
	    {
            character = gameObject.transform.parent.gameObject.GetComponent<MenuController>().GetCharacter();
            character.SetClass(new Knight(character.GetCharacter()));
	    }
	}
}
