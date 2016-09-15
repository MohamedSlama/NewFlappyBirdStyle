using UnityEngine;
using System.Collections;

public class controlrer : MonoBehaviour {

    Camera cam;
    private float maxWidth;



    public GameObject egg,box;
    public float range1, range2;
    bool nullbox;

	// Use this for initialization
	void Start () {
        if (box == null)
            nullbox = true;
	    cam =Camera.main;
        StartCoroutine(Spawn());
	}

  

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            Vector3 spPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Quaternion spRot = Quaternion.identity;

            Instantiate(egg, spPos, spRot);
            if(!nullbox)
                Instantiate(box, spPos, spRot);

            yield return new WaitForSeconds(Random.Range(range1, range2));
        }
    }
}
