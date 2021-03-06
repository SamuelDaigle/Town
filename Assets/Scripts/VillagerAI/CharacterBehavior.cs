﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace VillagerAI
{
    public class CharacterBehavior : Pathfinding // and MonoBehavior
    {
        public GameObject debugText;

        private TextMesh textMesh;
        private Character character;
        private Transform target;

        // Use this for initialization
        void Start()
        {
            textMesh = debugText.GetComponent<TextMesh>();
            character = new Character(this);
        }

        // Update is called once per frame
        void Update()
        {
            character.Update();
            ShowDebug();
        }

        private void ShowDebug()
        {
            Debug.Assert(textMesh != null);
            DebugText text = character.GetDebugText();
            textMesh.text = text.ClassText + "\n" + text.StateText + "\n" + text.ResourceCountText;
        }

        public void MoveToTarget()
        {
            Debug.Assert(target != null);
            /*Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime);*/
            if (Path.Count != 0)
            {
                Move();
            }
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void SetTarget(string _tag)
        {
            List<GameObject> sortedTargets = AISight.GetObjects(transform, _tag);
            if (sortedTargets.Count == 0)
            {
                target = transform;
            }
            else
            {
                target = sortedTargets[0].transform;
            }
            FindPath(transform.position, target.position);
        }

        public Transform GetTarget()
        {
            Debug.Assert(target != null);
            return target;
        }

        public Character GetCharacter()
        {
            return character;
        }

        public void SetClass(IClass _class)
        {
            character.SetClass(_class);
        }

        public void OnClassChanged(string _imagePath)
        {
            gameObject.GetComponent<MeshRenderer>().material = Resources.Load(_imagePath) as Material;
        }
    }
}
