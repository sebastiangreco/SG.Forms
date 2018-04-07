using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using SG.Forms.Services;
using Xamarin.Forms;

namespace SG.Forms
{
    public class SGApp : BaseClass, ISGApp
    {
        #region Properties
        protected readonly IDialogService DialogService;

        public Page CurrentPage { get; set; }
        public RestClient ServiceClient { get; set; }
        public virtual TranslationCache Translation { get; protected set; }
        #endregion

        public SGApp()
            :base("SGApp")
        {

        }

        public string GetLocalizedText(LanguageToken token, string defaultText)
        {
            return base.ExecuteFunction("GetLocalizedText", delegate ()
            {
                if (this.Translation != null && this.Translation.Translations != null)
                {
                    string translated = string.Empty;
                    if (this.Translation.Translations.TryGetValue(token.ToString(), out translated))
                    {
                        return translated;
                    }
                }
                return defaultText;
            });
        }
    }
}
