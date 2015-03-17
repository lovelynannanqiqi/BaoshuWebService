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
    public class MainItem
    {
        double baseNumber;
        double reportNumber;
        double addorDecNumber;
        double persent;
        double sumMouth;

        public double BaseNumber { get { return baseNumber; } set { baseNumber = value; } }
        public double ReportNumber { get { return reportNumber; } set { reportNumber = value; } }
        public double AddorDecNumber { get { return addorDecNumber; } set { addorDecNumber = value; } }
        public double Persent { get { return persent; } set { persent = value; } }
        public double SumMouth { get { return sumMouth; } set { sumMouth = value; } }
        
        public MainItem()
        {
        }

    }
}
