using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SG.Forms
{
    public interface ISGApp
    {
        Page CurrentPage { get; set; }
        RestClient ServiceClient { get; set; }

        string GetLocalizedText(LanguageToken token, string defaultText);
    }
}
