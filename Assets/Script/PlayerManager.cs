using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    RaycastHit hit;
  public  List<UnitController> selectedUnit = new List<UnitController>();
   public GameObject[] Player;
    bool isDragging = false;
   public bool StartRound = false;
    public int Count2;
    Vector3 mousePosition;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Count2 >= 5)
        {
            StartCoroutine("Clear");   
        }
        if (!StartRound)
        {
            ////////////////////
            if (Input.GetMouseButtonDown(0))
            {
                if (GameObject.Find("Point") && !Input.GetKey(KeyCode.LeftShift))
                    DerselectUnits();
                mousePosition = Input.mousePosition;
                var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(camRay, out hit))
                {
                    if (hit.transform.CompareTag("PlayerUnit"))
                    {
                        SelectUnit(hit.transform.GetComponent<UnitController>(), Input.GetKey(KeyCode.LeftShift));

                    }
                    else
                    {
                        isDragging = true;
                    }
                }
            }
            /////////////////

            /////////////////////
            if (Input.GetMouseButtonUp(0))
            {
                foreach (var selectableObject in FindObjectsOfType<CapsuleCollider>())
                {
                    if (IsWithSelectionBounds(selectableObject.transform))
                    {
                        SelectUnit(selectableObject.gameObject.GetComponent<UnitController>(), true);
                    }
                }

                isDragging = false;
            }
            ////////////////////

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                    Player[0].SetActive(false);
                Player[1].SetActive(false);
                DerselectUnits();
            }

            if (Input.GetMouseButtonDown(1) && selectedUnit.Count > 0)
            {
                var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(camRay, out hit))
                {
                        foreach (var selectableObj in selectedUnit)
                        {
                            selectableObj.MoveUnit(hit.point);
                        }
                }
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                foreach (var selectableObj in selectedUnit)
                {
                    selectableObj.PauseUnit();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Player[0].activeInHierarchy == false)
                {
                    Player[0].SetActive(true);
                    Player[1].SetActive(false);
                }
                else
                {
                    Player[0].SetActive(false);
                    Player[1].SetActive(false);
                }
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Player[1].activeInHierarchy == false)
                {
                    Player[1].SetActive(true);
                    Player[0].SetActive(false);
                }
                else
                {
                    Player[1].SetActive(false);
                    Player[0].SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Delete))
            {
                foreach (var selectableObj in selectedUnit)
                {
                    selectableObj.SetSelected(false);
                    selectableObj.DestoryUnit();
                }
                selectedUnit.Clear();
            }

        }
    }
    private void OnGUI()
    {
        if (isDragging && !StartRound)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f,0.8f,0.95f,0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.blue);
        }
    }

    private void SelectUnit(UnitController unit, bool isMultiSelect = false)
    {
        if(!isMultiSelect)
        {
            DerselectUnits();
        }
        selectedUnit.Add(unit);
        unit.SetSelected(true);
    }

    private void DerselectUnits()
    {
        for(int i=0;i<selectedUnit.Count;i++)
        {
            selectedUnit[i].SetSelected(false);
        }
        selectedUnit.Clear();
    }

    private bool IsWithSelectionBounds(Transform transform)
    {
        if(!isDragging)
        {
            return false;
        }
        var camera = Camera.main;
        var viewprotBounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return viewprotBounds.Contains(camera.WorldToViewportPoint(transform.position));
    }


    IEnumerator Clear()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(GameObject.FindGameObjectWithTag("PlayerUnit"));
        Count2 = 0;
        StartRound = false;
    }
}
