using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycast : MonoBehaviour
{
    [Header("Put your planeMarker here")]//по€сн€юща€ надпись в юнити
    [SerializeField] private GameObject PlaneMarkerPrefab;//приватный, но в юнити его можно найти 
    private ARRaycastManager ARRaycastManagerScript;
    private Vector2 TouchPosition;
    public GameObject ObjectToSpawn;


    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        PlaneMarkerPrefab.SetActive(false);
    }

    void Update()
    {
        ShowMarker();

    }

    void ShowMarker()
    {


        List<ARRaycastHit> hits = new List<ARRaycastHit>();//создаем контейнер, куда будут попадать все объекты взаимодействующие с лучом 
        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);//источник луча,куда помещаетс€ инфа попадани€,фиксируем плоскость


        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;//берем позицию маркера и присваеваем значение места где луч пересекс€ с плоскостью
            PlaneMarkerPrefab.SetActive(true);
        }


        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {


            
            //Touch touch = Input.GetTouch(0);//получили инфу что коснулись по экрану
           // TouchPosition = touch.position;//в переменную помещаем координаты позиции косани€ экрана
            //ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);

            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
        }
    }
}