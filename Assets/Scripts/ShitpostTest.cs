using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitpostTest : MonoBehaviour
{
    public AudioClip bingChilingClip;
    public AudioSource bingChilingSource;

    public AudioClip aneurysmClip;
    public AudioSource aneurysmSource;

    public AudioClip amongusClip;
    public AudioSource AmongusSource;

    public AudioClip cowboyClip;
    public AudioSource cowboySource;

    public AudioClip dripClip;
    public AudioSource dripSource;
    public void bingChiling()
    {
        if (bingChilingClip != null && bingChilingSource != null)
        {
            bingChilingSource.PlayOneShot(bingChilingClip); 
        }
    }
    public void aneurysm()
    {
        if (aneurysmClip != null && aneurysmSource != null)
        {
            aneurysmSource.PlayOneShot(aneurysmClip); 
        }
    }
    public void slumberParty()
    {
        if (cowboyClip != null && cowboySource != null)
        {
            cowboySource.PlayOneShot(cowboyClip); 
        }
    }
    public void amongus()
    {
        if (amongusClip != null && AmongusSource != null)
        {
            AmongusSource.PlayOneShot(amongusClip); 
        }
    }
    public void drip()
    {
        if (dripClip != null && dripSource != null)
        {
            dripSource.PlayOneShot(dripClip);  
        }
    }
}
