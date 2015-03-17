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
    public class MainItems
    {
        public MainItems()
        {
        }

        public MainItem MainBC=new MainItem();
        public MainItem MainRS=new MainItem();
        public MainItem MainSR=new MainItem();
        public MainItem MainWLSR = new MainItem();
        public MainItem MainDSDSR = new MainItem();
        public MainItem MainJCS = new MainItem();
    }
}
