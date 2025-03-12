using System;
using UnityEngine;


namespace UI
{
    public class AboutUs : MonoBehaviour
    {
        public Action LoadAboutUs;
        

        public void OnLoadAboutUs()
        {
            LoadAboutUs?.Invoke();
        }
    }	
}