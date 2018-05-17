using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTI.Orcamento.AP.QuadroConsolidado
{
    class Config
    {
        //Comum
        public string user = "portalpmo";
        public string password = "b2w@123456";
        public string uri = "/_vti_bin/listdata.svc";
        //public string linkContratoView = "/Lists/Contratos/DispForm.aspx";

        //Produção
        //public string site = "http://portalti.b2w/orcamento";
        //public string domain = "lab2w";
        //public string mailhost = "bwuolhub01.la.ad.b2w";
        //public string mailfrom = "noreply@b2wdigital.com";

        //Desenv
        public string site = "http://bwspdev01:4050/orcamento";
        public string domain = "la.ad.b2w";
        //public string mailhost = "BWSPDEV01.la.ad.b2w";
        //public string mailfrom = "sharepoint@BWSPDEV01.la.ad.b2w.com";
    }
}
