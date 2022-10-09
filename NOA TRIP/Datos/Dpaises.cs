using NOA_TRIP.Model;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Twilio.Rest.Numbers.V2.RegulatoryCompliance;

namespace NOA_TRIP.Datos
{
    public class Dpaises
    {
        public static List<RegionInfo>PaisesIso3166()
        {
            var paises = new List<RegionInfo>();
            foreach(var cultura in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var info = new RegionInfo(cultura.LCID);
                    if (paises.All(p=>p.Name!=info.Name))
                    paises.Add(info);
             
            }
            return paises.OrderBy(p => p.EnglishName).ToList();

        }
        public List<Mpaises> Mostrarpaises()
        {
            var phoneNumberUtil =PhoneNumberUtil.GetInstance();
            var listapaises =new List<Mpaises>();
            var isopaises = PaisesIso3166();
            listapaises.AddRange(isopaises.Select(p=>new Mpaises
                {
                    CodigoPais = phoneNumberUtil.GetCountryCodeForRegion
                    (p.TwoLetterISORegionName).ToString(),
                    Pais=p.EnglishName,
                    Iconourl=$"https://hatscripts.github.io/circle-flags/flags/{p.TwoLetterISORegionName.ToLower()}.svg"
                }));
            return listapaises;
                }
        public Mpaises MostrarpaisesXpais(string pais) 
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var isooais = PaisesIso3166();
            var regioninfo = isooais.FirstOrDefault(c=>c.EnglishName==pais);

            return regioninfo != null
                ? new Mpaises
                {
                    CodigoPais = phoneNumberUtil.GetCountryCodeForRegion
              (regioninfo.TwoLetterISORegionName).ToString(),
                    Iconourl = $"https://hatscripts.github.io/circle-flags/flags/{regioninfo.TwoLetterISORegionName.ToLower()}.svg"
                }
                : new Mpaises
                {
                    Pais = pais,
                };

            //var paises = new Mpaises();
            //if (regioninfo!=null)
            //{
            //    paises.CodigoPais = phoneNumberUtil.GetCountryCodeForRegion
            //        (regioninfo.TwoLetterISORegionName).ToString();
            //    paises.Pais=regioninfo.EnglishName;
            //    paises.Iconourl = $"https://hatscripts.github.io/circle-flags/flags/{regioninfo.TwoLetterISORegionName.ToLower()}.svg";
            //    return paises;
            //}
            //else
            //{
            //    paises.Pais= pais;
            //    return paises;
            //}

        }
    }
}
 