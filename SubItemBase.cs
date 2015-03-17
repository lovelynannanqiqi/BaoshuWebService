using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BaoshuWebService
{
    public class SubItemBase
    {
        public double baseNumber;
        public double reportNumber;
        public double addordecNumber;
        public double sumMouth;

        public SubItemBase()
        {

        }

        public SubItemBase(double baseNumber, double reportNumber, double addordecNumber, double sumMouth)
        {
            this.baseNumber = baseNumber;
            this.reportNumber = reportNumber;
            this.addordecNumber = addordecNumber;
            this.sumMouth = sumMouth;
        }
    }
}
