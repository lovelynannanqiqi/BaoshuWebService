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
    public class SubItems
    {
        public string SubStationName;
        public SubItemBase SubItemBC;
        public SubItemBase SubItemBP;
        public SubItemBase SubItemXZ;
        public SubItemBase SubItemTK;



        public SubItems(SubItemBase Subbc, SubItemBase Subbp, SubItemBase Subxz, SubItemBase Subtk,string SubStationName)
        {
            this.SubStationName = SubStationName;
            SubItemBC = Subbc;
            SubItemBP = Subbp;
            SubItemXZ = Subxz;
            SubItemTK = Subtk;
        }

        public SubItems()
        {
        }

    }
}
