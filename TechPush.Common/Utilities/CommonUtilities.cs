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
            string LPGGASCylinderPriceChennai = "https://www.petroldieselprice.com/lp15/lpg-gas-cylinder-price-in-chennai-madras";
            //string LPGGASCylinderPricePondy = "https://www.petroldieselprice.com/lpg-gas-cylinder-price";
            string PetrolDieselPriceChennai = "https://www.petroldieselprice.com/petrol-diesel-price-in-Chennai";
            //string PetrolDieselPricePondy ="https://www.petroldieselprice.com/search-petrol-diesel-price";


            HtmlAgilityPack.HtmlWeb W = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument D1 = W.Load(LPGGASCylinderPriceChennai);
            var HTMLNodes1=D1.DocumentNode.SelectNodes("//div[@id='order_review']").ToList();

            HtmlAgilityPack.HtmlDocument D2 = W.Load(PetrolDieselPriceChennai);
            var HTMLNodes2 = D2.DocumentNode.SelectNodes("//div[@id='order_review']").ToList();

            string[] Contents = { HTMLNodes1[1].InnerHtml, HTMLNodes2[1].InnerHtml };

            return Contents;

        }

    }
}
