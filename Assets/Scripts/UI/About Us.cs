using System;
using UnityEngine;


namespace UI
{
    public class AboutUs : MonoBehaviour
    {
        public Action ShowAboutUs;
        

        public void ShowInformationAboutUs()
        {
            ShowAboutUs?.Invoke();
        }
    }	
}