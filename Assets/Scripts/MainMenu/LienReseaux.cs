using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LienReseaux: MonoBehaviour
{
    public string urlLinked;
    public string urlInsta;
    public string urlYoutube;
    public string urlArtstation;
    public string urlFacebook;
    public string urlTwitter;
    public string urlItch;
    public string urlDiscord;
    public string urlGitHub;
    public string urlLesTrans;
    public string urlETPA;



    public void UrlLinkedIn()
    {
        Application.OpenURL(urlLinked);
    }
    public void UrlInsta()
    {
        Application.OpenURL(urlInsta);
    }
    public void UrlYoutube()
    {
        Application.OpenURL(urlYoutube);
    }
    public void UrlArtstation()
    {
        Application.OpenURL(urlArtstation);
    }
    public void UrlFacebook()
    {
        Application.OpenURL(urlFacebook);
    }
    public void UrlTwitter()
    {
        Application.OpenURL(urlTwitter);
    }
    public void UrlItch()
    {
        Application.OpenURL(urlItch);
    }
    public void UrlDiscord()
    {
        Application.OpenURL(urlDiscord);
    }
    public void UrlGitHub()
    {
        Application.OpenURL(urlGitHub);
    }
    public void UrlLesTrans()
    {
        Application.OpenURL(urlLesTrans);
    }
    public void UrlETPA()
    {
        Application.OpenURL(urlETPA);
    }

}
