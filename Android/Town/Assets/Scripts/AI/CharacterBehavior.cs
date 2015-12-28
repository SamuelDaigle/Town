using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AI
{
	public class CharacterBehavior : MonoBehaviour
	{
        public Text debugText;
        private Character character;
	    private Transform target;
	
	    // Use this for initialization
	    void Start()
	    {
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
            Debug.Assert(debugText != null);
            debugText.transform.position = transform.position + Vector3.up * transform.localScale.y;
            DebugText text = character.GetDebugText();
            debugText.text = text.ClassText + "\n" + text.StateText + "\n" + text.ResourceCountText;
        }

        public void MoveToTarget()
        {
            Debug.Assert(target != null);
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime);
        }

        public Transform GetTransform()
        {
            return transform;
        }
	
	    public void SetTarget(string _tag)
	    {
	        target = AISight.GetObjects(transform, _tag)[0].transform;
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
