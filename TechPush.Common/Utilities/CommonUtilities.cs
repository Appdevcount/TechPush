using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPush.Common.Utilities
{
    public class CommonUtilities
    {

        public string[] GetHTMLbyWEBScrapping()
        {
            string LPGGASCylinderPrice = "https://www.petroldieselprice.com/lp15/lpg-gas-cylinder-price-in-chennai-madras";
            string PetrolDieselPrice = "https://www.petroldieselprice.com/petrol-diesel-price-in-Chennai";


            HtmlAgilityPack.HtmlWeb W = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument D1 = W.Load(LPGGASCylinderPrice);
            var HTMLNodes1=D1.DocumentNode.SelectNodes("//div[@id='order_review']").ToList();

            HtmlAgilityPack.HtmlDocument D2 = W.Load(PetrolDieselPrice);
            var HTMLNodes2 = D2.DocumentNode.SelectNodes("//div[@id='order_review']").ToList();

            string[] Contents = { HTMLNodes1[1].InnerHtml, HTMLNodes2[1].InnerHtml };

            return Contents;

        }

    }
}
