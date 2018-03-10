using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ExtPr : MonoBehaviour {

    public string Path;

	void Start ()
    {
        ProcessStartInfo sInf = new ProcessStartInfo();
        sInf.FileName = Path;
        Process.Start(sInf);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
