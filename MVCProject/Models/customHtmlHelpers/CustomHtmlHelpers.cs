using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Models.customHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString DDLGradovi(this HtmlHelper html, List<Grad> kolekcijaGradova, int selectedGrad)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "Grad.IDGrad");
            selectTag.MergeAttribute("name", "Grad.IDGrad");
            selectTag.AddCssClass("form-control");

            foreach (Grad grad in kolekcijaGradova)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", grad.IDGrad.ToString());

                if (selectedGrad == grad.IDGrad)
                {
                    optionTag.MergeAttribute("selected", true.ToString());
                }

                optionTag.SetInnerText(grad.Naziv);
                selectTag.InnerHtml += optionTag.ToString();
            }

            return new MvcHtmlString(selectTag.ToString());
        }

        public static MvcHtmlString DDLKategorije(this HtmlHelper html, List<Kategorija> kolekcijaKategorija, int selectedKategorija)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "Kategorija.IDKategorija");
            selectTag.MergeAttribute("name", "Kategorija.IDKategorija");
            selectTag.AddCssClass("form-control");

            if (kolekcijaKategorija != null)
            {
                foreach (Kategorija kategorija in kolekcijaKategorija)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.MergeAttribute("value", kategorija.IDKategorija.ToString());

                    if (selectedKategorija == kategorija.IDKategorija)
                    {
                        optionTag.MergeAttribute("selected", true.ToString());
                    }

                    optionTag.SetInnerText(kategorija.Naziv);
                    selectTag.InnerHtml += optionTag.ToString();
                }
            }
       

            return new MvcHtmlString(selectTag.ToString());
        }


        public static MvcHtmlString DDLPotkategorije(this HtmlHelper html, List<Potkategorija> kolekcijaPotkategorija, int selectedKategorija)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "Potkategorija.IDPotkategorija");
            selectTag.MergeAttribute("name", "Potkategorija.IDPotkategorija");
            selectTag.AddCssClass("form-control");

            if (kolekcijaPotkategorija != null)
            {
                foreach (Potkategorija potkategorija in kolekcijaPotkategorija)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.MergeAttribute("value", potkategorija.IDPotkategorija.ToString());

                    if (selectedKategorija == potkategorija.IDPotkategorija)
                    {
                        optionTag.MergeAttribute("selected", true.ToString());
                    }

                    optionTag.SetInnerText(potkategorija.Naziv);
                    selectTag.InnerHtml += optionTag.ToString();
                }
            }

            return new MvcHtmlString(selectTag.ToString());
        }
    }
}