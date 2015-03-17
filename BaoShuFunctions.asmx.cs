using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;
namespace BaoshuWebService
{

    /// <summary>
    /// Summary description for BaoShuFunctions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BaoShuFunctions : System.Web.Services.WebService
    {

        [WebMethod]
        public bool CheckUser(string user, string pwd, out int StationID)
        {
            bool checkUser = false;
            BaoshuWebService.Data.bsTableAdapters.UsersTableAdapter userTable = new BaoshuWebService.Data.bsTableAdapters.UsersTableAdapter();
            int stationID = Convert.ToInt16(userTable.CheckUser(user, pwd));
            if (stationID !=0)
            {
                checkUser = true;
            }
            StationID = stationID;
            return checkUser;
        }

        [WebMethod]
        public string GetMainStationName(int StationID)
        {
            BaoshuWebService.Data.bsTableAdapters.StationsTableAdapter stationTable = new BaoshuWebService.Data.bsTableAdapters.StationsTableAdapter();
            return stationTable.GetMainStationName(StationID);
        }

        [WebMethod]
        public List<string> GetSubStations(int StationID)
        {
            List<string> list = new List<string>();
            Data.bsTableAdapters.SubStationTableAdapter subStationTable = new BaoshuWebService.Data.bsTableAdapters.SubStationTableAdapter();
            Data.bs.SubStationDataTable subTable=new BaoshuWebService.Data.bs.SubStationDataTable();
            subStationTable.Fill(subTable,StationID);

            foreach (Data.bs.SubStationRow subRow in subTable.Rows)
            {
                list.Add(subRow[0].ToString());
            }
            return list;
        }


        [WebMethod]
        public List<SubItems> GetSubItems(int MainStationID, DateTime SelectDatetime)
        {
            List<SubItems> list = new List<SubItems>();
            Data.bsTableAdapters.SubDataTableAdapter sdt = new BaoshuWebService.Data.bsTableAdapters.SubDataTableAdapter();
            Data.bs.SubDataDataTable sdd = new BaoshuWebService.Data.bs.SubDataDataTable();
            if (sdt.Fill(sdd, MainStationID, SelectDatetime) > 0)
            {


                foreach (Data.bs.SubDataRow subRow in sdd.Rows)
                {
                    list.Add(new SubItems(new SubItemBase(Convert.ToDouble(subRow[0]), Convert.ToDouble(subRow[1]), Convert.ToDouble(subRow[2]), Convert.ToDouble(subRow[3])),
                                          new SubItemBase(Convert.ToDouble(subRow[4]), Convert.ToDouble(subRow[5]), Convert.ToDouble(subRow[6]), Convert.ToDouble(subRow[7])),
                                          new SubItemBase(Convert.ToDouble(subRow[8]), Convert.ToDouble(subRow[9]), Convert.ToDouble(subRow[10]), Convert.ToDouble(subRow[11])),
                                          new SubItemBase(Convert.ToDouble(subRow[12]), Convert.ToDouble(subRow[13]), Convert.ToDouble(subRow[14]), Convert.ToDouble(subRow[15])), subRow[16].ToString()));
                }
            }

            return list;


        }

        [WebMethod]
        public int InsertSubItem(int MainStationID, DateTime CreateDateTime, SubItems si)
        {


            Data.bsTableAdapters.SubDataTableAdapter sdt = new BaoshuWebService.Data.bsTableAdapters.SubDataTableAdapter();


            return sdt.InsertSubItems(MainStationID, GetSubStationID(si.SubStationName), Convert.ToInt32(si.SubItemBC.baseNumber), Convert.ToInt32(si.SubItemBC.reportNumber), Convert.ToInt32(si.SubItemBC.addordecNumber), Convert.ToInt32(si.SubItemBC.sumMouth),
                                                                                          Convert.ToInt32(si.SubItemBP.baseNumber), Convert.ToInt32(si.SubItemBP.reportNumber), Convert.ToInt32(si.SubItemBP.addordecNumber), Convert.ToInt32(si.SubItemBP.sumMouth),
                                                                                          Convert.ToInt32(si.SubItemXZ.baseNumber), Convert.ToInt32(si.SubItemXZ.reportNumber), Convert.ToInt32(si.SubItemXZ.addordecNumber), Convert.ToInt32(si.SubItemXZ.sumMouth),
                                                                                         Decimal.Round((decimal)si.SubItemTK.baseNumber, 1), Decimal.Round((decimal)si.SubItemTK.reportNumber, 1), Decimal.Round((decimal)si.SubItemTK.addordecNumber, 1), Decimal.Round((decimal)si.SubItemTK.sumMouth, 1), CreateDateTime);

        }

        [WebMethod]
        public MainItems GetMainItem(int MainStationID, DateTime CreateDateTime)
        {
            Data.bsTableAdapters.DataTableAdapter dt = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            Data.bs.DataDataTable ddt = new BaoshuWebService.Data.bs.DataDataTable();
            MainItems mis=new MainItems();
            dt.Fill(ddt, MainStationID, CreateDateTime);
            foreach (Data.bs.DataRow dr in ddt.Rows)
            {
                mis.MainBC.BaseNumber=Convert.ToDouble(dr[0]);
                mis.MainBC.ReportNumber=Convert.ToDouble(dr[1]);
                mis.MainBC.AddorDecNumber=Convert.ToDouble(dr[2]);
                mis.MainBC.Persent=Convert.ToDouble(dr[3]);
                mis.MainBC.SumMouth=Convert.ToDouble(dr[4]);

                mis.MainRS.BaseNumber=Convert.ToDouble(dr[5]);
                mis.MainRS.ReportNumber=Convert.ToDouble(dr[6]);
                mis.MainRS.AddorDecNumber=Convert.ToDouble(dr[7]);
                mis.MainRS.Persent=Convert.ToDouble(dr[8]);
                mis.MainRS.SumMouth=Convert.ToDouble(dr[9]);

                mis.MainSR.BaseNumber=Convert.ToDouble(dr[10]);
                mis.MainSR.ReportNumber=Convert.ToDouble(dr[11]);
                mis.MainSR.AddorDecNumber=Convert.ToDouble(dr[12]);
                mis.MainSR.Persent = Convert.ToDouble(dr[13]);
                mis.MainSR.SumMouth = Convert.ToDouble(dr[14]);

                mis.MainWLSR.BaseNumber = Convert.ToDouble(dr[18]);
                mis.MainWLSR.ReportNumber = Convert.ToDouble(dr[19]);
                mis.MainWLSR.AddorDecNumber = Convert.ToDouble(dr[20]);
                mis.MainWLSR.Persent = Convert.ToDouble(dr[21]);
                mis.MainWLSR.SumMouth = Convert.ToDouble(dr[22]);

                mis.MainDSDSR.BaseNumber = Convert.ToDouble(dr[23]);
                mis.MainDSDSR.ReportNumber = Convert.ToDouble(dr[24]);
                mis.MainDSDSR.AddorDecNumber = Convert.ToDouble(dr[25]);
                mis.MainDSDSR.Persent = Convert.ToDouble(dr[26]);
                mis.MainDSDSR.SumMouth = Convert.ToDouble(dr[27]);

                mis.MainJCS.BaseNumber = Convert.ToDouble(dr[28]);
                mis.MainJCS.ReportNumber = Convert.ToDouble(dr[29]);
                mis.MainJCS.AddorDecNumber = Convert.ToDouble(dr[30]);
                mis.MainJCS.Persent = Convert.ToDouble(dr[31]);
                mis.MainJCS.SumMouth = Convert.ToDouble(dr[32]); 
            }

            return mis;
        }

        [WebMethod]
        public Data.bs.DataDataTable GetMainItemByCreateDateTime(DateTime CreateDateTime)
        {
            Data.bs.DataDataTable maindata = new BaoshuWebService.Data.bs.DataDataTable();
            Data.bsTableAdapters.DataTableAdapter maindataAdapter = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            maindataAdapter.FillByCreateDate(maindata, CreateDateTime);
            return maindata;
        }

        [WebMethod]
        public Data.bs.DataDataTable GetMainItemByBeginAndEndDateTime(DateTime beginD, DateTime endD)
        {
            Data.bs.DataDataTable maindata = new BaoshuWebService.Data.bs.DataDataTable();
            Data.bsTableAdapters.DataTableAdapter maindataAdapter = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            maindataAdapter.FillByBeginAndEndDateTime(maindata, beginD, endD);
            return maindata;
        }

        [WebMethod]
        public Data.bs.SubDataDataTable GetSubItemByCreateDateTime(DateTime CreateDateTime)
        {
            Data.bs.SubDataDataTable subdata = new BaoshuWebService.Data.bs.SubDataDataTable();
            Data.bsTableAdapters.SubDataTableAdapter subdataAdapter = new BaoshuWebService.Data.bsTableAdapters.SubDataTableAdapter();
            subdataAdapter.FillByCreateDate(subdata, CreateDateTime);
            return subdata;
        }

        [WebMethod]
        public Data.bs.SubDataDataTable GetSubItemByBeginAndEndDateTime(DateTime beginD, DateTime endD)
        {
            Data.bs.SubDataDataTable subdata = new BaoshuWebService.Data.bs.SubDataDataTable();
            Data.bsTableAdapters.SubDataTableAdapter subdataAdapter = new BaoshuWebService.Data.bsTableAdapters.SubDataTableAdapter();
            subdataAdapter.FillByBeginAndEndDateTime(subdata, beginD, endD);
            return subdata;
        }

        [WebMethod]
        public bool IsHaveMainItems(int MainStationID, DateTime CreateDateTime)
        {
            bool ishave = false;
            Data.bsTableAdapters.DataTableAdapter dt = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            if (dt.ISHaveMainItems(MainStationID, CreateDateTime) > 0)
            {
                ishave=true;
            }
            return ishave;

        }

        [WebMethod]
        public int InsertMainItem(int MainStationID, DateTime CreateDateTime, MainItems mis)
        {
            Data.bsTableAdapters.DataTableAdapter dt = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            return dt.InsertBsData(MainStationID, Convert.ToInt32(mis.MainBC.BaseNumber), Convert.ToInt32(mis.MainBC.ReportNumber), Convert.ToInt32(mis.MainBC.AddorDecNumber), Decimal.Round((decimal)mis.MainBC.Persent, 1), Decimal.Round((decimal)mis.MainBC.SumMouth, 1),
                                                  Convert.ToInt32(mis.MainRS.BaseNumber), Convert.ToInt32(mis.MainRS.ReportNumber), Convert.ToInt32(mis.MainRS.AddorDecNumber), Decimal.Round((decimal)mis.MainRS.Persent, 1), Decimal.Round((decimal)mis.MainRS.SumMouth, 1),
                                                  Decimal.Round((decimal)mis.MainSR.BaseNumber, 1), Decimal.Round((decimal)mis.MainSR.ReportNumber, 1), Decimal.Round((decimal)mis.MainSR.AddorDecNumber, 1), Decimal.Round((decimal)mis.MainSR.Persent, 1), Decimal.Round((decimal)mis.MainSR.SumMouth, 1),
                                                  CreateDateTime,
                                                  Decimal.Round((decimal)mis.MainWLSR.BaseNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.ReportNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.AddorDecNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.SumMouth, 1),

                                                  Decimal.Round((decimal)mis.MainDSDSR.BaseNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.ReportNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.AddorDecNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.SumMouth, 1),

                                                  Convert.ToInt32(mis.MainJCS.BaseNumber),
                                                  Convert.ToInt32(mis.MainJCS.ReportNumber),
                                                  Convert.ToInt32(mis.MainJCS.AddorDecNumber),
                                                  Decimal.Round((decimal)mis.MainJCS.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainJCS.SumMouth, 1)
                                                  );

        }

        [WebMethod]
        public int UpdateMainItem(int MainStationID, DateTime CreateDateTime, MainItems mis)
        {
            Data.bsTableAdapters.DataTableAdapter dt = new BaoshuWebService.Data.bsTableAdapters.DataTableAdapter();
            return dt.UpdateBsData(MainStationID, Convert.ToInt32(mis.MainBC.BaseNumber), Convert.ToInt32(mis.MainBC.ReportNumber), Convert.ToInt32(mis.MainBC.AddorDecNumber), Decimal.Round((decimal)mis.MainBC.Persent, 1), Decimal.Round((decimal)mis.MainBC.SumMouth, 1),
                                                  Convert.ToInt32(mis.MainRS.BaseNumber), Convert.ToInt32(mis.MainRS.ReportNumber), Convert.ToInt32(mis.MainRS.AddorDecNumber), Decimal.Round((decimal)mis.MainRS.Persent, 1), Decimal.Round((decimal)mis.MainRS.SumMouth, 1),
                                                  Decimal.Round((decimal)mis.MainSR.BaseNumber, 1), Decimal.Round((decimal)mis.MainSR.ReportNumber, 1), Decimal.Round((decimal)mis.MainSR.AddorDecNumber, 1), Decimal.Round((decimal)mis.MainSR.Persent, 1), Decimal.Round((decimal)mis.MainSR.SumMouth, 1),

                                                  Decimal.Round((decimal)mis.MainWLSR.BaseNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.ReportNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.AddorDecNumber, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainWLSR.SumMouth, 1),

                                                  Decimal.Round((decimal)mis.MainDSDSR.BaseNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.ReportNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.AddorDecNumber, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainDSDSR.SumMouth, 1),

                                                  Convert.ToInt32(mis.MainJCS.BaseNumber),
                                                  Convert.ToInt32(mis.MainJCS.ReportNumber),
                                                  Convert.ToInt32(mis.MainJCS.AddorDecNumber),
                                                  Decimal.Round((decimal)mis.MainJCS.Persent, 1),
                                                  Decimal.Round((decimal)mis.MainJCS.SumMouth, 1),
                                                  CreateDateTime);

        }


        [WebMethod]
        public void DeleteSameSubData(int MainStationID, DateTime CreateDateTime)
        {
            Data.bsTableAdapters.SubDataTableAdapter sdt = new BaoshuWebService.Data.bsTableAdapters.SubDataTableAdapter();
            if (sdt.ISHaveSubDataBy(MainStationID, CreateDateTime) > 0)
            {
                sdt.DeleteSubData(MainStationID, CreateDateTime);
            }
        }

        [WebMethod]
        public int GetSubStationID(string SubStationName)
        {
            Data.bsTableAdapters.SubStationTableAdapter sdt = new BaoshuWebService.Data.bsTableAdapters.SubStationTableAdapter();
            return (int)sdt.FillBySubStationName(SubStationName);
        }
    
    }
}
