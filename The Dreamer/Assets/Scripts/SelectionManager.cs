using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
	[SerializeField]private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
    [SerializeField] private Material passingMaterial;

    public float invincibleForSeconds;

    private Transform _selection;


	private void Update()
    {
        if (_selection != null)
        {
			var selectionRenderer = _selection.GetComponent<Renderer>();
            if(selectionRenderer.transform.tag == "Passable")
                selectionRenderer.material = passingMaterial;
            else
			    selectionRenderer.material = defaultMaterial;

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit ))
        {
            var selection = hit.transform;
            if(selection.CompareTag( selectableTag ))
            {
				var selectionRenderer = selection.GetComponent<Renderer>();
				if(selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
				if(Input.GetMouseButtonDown( 0 ))
				{
                    selection.gameObject.tag = "Passable";

				}
				_selection = selection;
			}
        }
    }
}
