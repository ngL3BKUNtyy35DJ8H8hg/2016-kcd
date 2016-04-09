using ADOConnection;
using AxMapXLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
namespace HuanLuyen
{
    internal class CFlights
    {
        public static CFlight FindAtPoint(AxMap pMap, PointF pt, List<CFlight> pFlights)
        {
            checked
            {
                if (pFlights != null && pFlights.Count > 0)
                {
                    for (int i = pFlights.Count - 1; i >= 0; i += -1)
                    {
                        CFlight cFlight = pFlights[i];
                        if (cFlight.MayBay.Status == enTopStatus.DangBay && cFlight.MayBay.HitTest(pMap, pt))
                        {
                            return cFlight;
                        }
                    }
                }
                return null;
            }
        }
        public static CFlight FindAtPoint2(AxMap pMap, PointF pt, List<CFlight> pFlights)
        {
            checked
            {
                if (pFlights != null && pFlights.Count > 0)
                {
                    for (int i = pFlights.Count - 1; i >= 0; i += -1)
                    {
                        CFlight cFlight = pFlights[i];
                        if (cFlight.HitTest(pMap, pt))
                        {
                            return cFlight;
                        }
                    }
                }
                return null;
            }
        }
        public static List<CFlight> GetList(string tblName)
        {
            List<CFlight> list = new List<CFlight>();
            string sText = "SELECT Flight_ID, FlightNo, Path_ID, Departure, LoaiMB, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo FROM " + tblName;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CFlight cFlight = new CFlight();
                    CFlight cFlight2 = cFlight;
                    cFlight2.Flight_ID = dataReader.GetInt32(0);
                    cFlight2.Departure = dataReader.GetDateTime(3);
                    list.Add(cFlight);
                }
                dataReader.Close();
            }
            catch (Exception expr_7A)
            {
                throw expr_7A;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static List<CFlight> GetList(string tblName, DateTime dFrom, DateTime dTo)
        {
            List<CFlight> list = new List<CFlight>();
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(250);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("SELECT Flight_ID, FlightNo, Path_ID, Departure, LoaiMB, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo");
            stringBuilder2.Append(" FROM " + tblName);
            stringBuilder2.Append(" WHERE (Departure >= ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("dFrom", false));
            stringBuilder2.Append(") AND (Departure <= ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("dTo", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbCommand dbCommand2 = dbCommand;
            dbCommand2.Parameters.Add(iDBUtility.CreateParameter("dFrom", DbType.DateTime, dFrom, 0));
            dbCommand2.Parameters.Add(iDBUtility.CreateParameter("dTo", DbType.DateTime, dTo, 0));
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CFlight cFlight = new CFlight();
                    CFlight cFlight2 = cFlight;
                    cFlight2.Flight_ID = dataReader.GetInt32(0);
                    cFlight2.Departure = dataReader.GetDateTime(3);
                    list.Add(cFlight);
                }
                dataReader.Close();
            }
            catch (Exception expr_14F)
            {
                throw expr_14F;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int Insert(string tblName, CFlight objFlight)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO " + tblName + " (FlightNo, Path_ID, Departure, LoaiMB, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("FlightNo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Path_ID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Departure", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiMB", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedFrom", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Departure", DbType.DateTime, objFlight.Departure, 0));
                num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "Path_ID", "tblPath");
                dbTransaction.Commit();
            }
            catch (Exception expr_1BB)
            {
                throw expr_1BB;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Delete(string tblName, int pFlight_ID)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM " + tblName);
            stringBuilder2.Append(" WHERE Flight_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Flight_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Flight_ID", DbType.Int32, pFlight_ID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_C0)
            {
                throw expr_C0;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long DeleteNodes(string tblName, long lFlight_Id)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM " + tblName + "Nodes ");
            stringBuilder2.Append(" WHERE Flight_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Flight_ID", false));
            string text = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Flight_ID", DbType.Int32, lFlight_Id, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_C5)
            {
                throw expr_C5;



            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int InsertNode(string tblName, int pFlight_ID, FlightNode objNode)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO " + tblName + "Nodes (Flight_ID, Stt, nodetype, isPlan, Td, PosX, PosY, Altitude, Speed, Roll, Turn, R, Cx, Cy, yp, DpX, DpY, DpH, hdgCD, typ, t2next, tspeed, CachVong, CachNhap) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Flight_ID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("nodetype", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("isPlan", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Td", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Altitude", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Speed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Roll", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Turn", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("R", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Cx", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Cy", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("yp", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("hdgCD", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("typ", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("t2next", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("tspeed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachVong", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachNhap", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Flight_ID", DbType.Int32, pFlight_ID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, objNode.Stt, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("nodetype", DbType.Int16, objNode.nodetype, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("isPlan", DbType.Boolean, objNode.isPlan, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Td", DbType.DateTime, objNode.td, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, objNode.node.D.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, objNode.node.D.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, objNode.node.D.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, objNode.node.Speed, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, objNode.node.Roll, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Turn", DbType.Int16, objNode.node.Turn, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("R", DbType.Double, objNode.node.R, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Cx", DbType.Double, objNode.node.C.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Cy", DbType.Double, objNode.node.C.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("yp", DbType.Double, objNode.node.yp, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpX", DbType.Double, objNode.node.Dp.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpY", DbType.Double, objNode.node.Dp.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpH", DbType.Double, objNode.node.Dp.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("hdgCD", DbType.Double, objNode.node.hdgCD, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("typ", DbType.Double, objNode.node.typ, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("t2next", DbType.Double, objNode.node.t2next, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("tspeed", DbType.Double, objNode.node.tspeed, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachVong", DbType.Int16, objNode.node.CachVong, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachNhap", DbType.Int16, objNode.node.CachNhap, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_6A2)
            {
                throw expr_6A2;
                string text = "InserNode: ";
                text += Convert.ToString(pFlight_ID);
                text = text + "; " + Convert.ToString(objNode.Stt);
                text = text + "; " + Convert.ToString(objNode.nodetype);
                text = text + "; " + Convert.ToString(objNode.isPlan);
                text = text + "; " + Convert.ToString(objNode.td);
                PathNode node = objNode.node;
                text = text + "; " + Convert.ToString(node.D.x);
                text = text + "; " + Convert.ToString(node.D.y);
                text = text + "; " + Convert.ToString(node.D.h);
                text = text + "; " + Convert.ToString(node.Speed);
                text = text + "; " + Convert.ToString(node.Roll);
                text = text + "; " + Convert.ToString((int)node.Turn);
                text = text + "; " + Convert.ToString(node.R);
                text = text + "; " + Convert.ToString(node.C.x);
                text = text + "; " + Convert.ToString(node.C.y);
                text = text + "; " + Convert.ToString(node.yp);
                text = text + "; " + Convert.ToString(node.Dp.x);
                text = text + "; " + Convert.ToString(node.Dp.y);
                text = text + "; " + Convert.ToString(node.Dp.h);
                text = text + "; " + Convert.ToString(node.hdgCD);
                text = text + "; " + Convert.ToString(node.typ);
                text = text + "; " + Convert.ToString(node.tspeed);
                text = text + "; " + Convert.ToString(node.t2next);



            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static int InsertNode(string tblName, CFlight pFlight)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM " + tblName + "Nodes ");
            stringBuilder2.Append(" WHERE Flight_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Flight_ID", false));
            string sText = stringBuilder.ToString();
            stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder3 = stringBuilder;
            stringBuilder3.Append("INSERT INTO " + tblName + "Nodes (Flight_ID, Stt, nodetype, isPlan, Td, PosX, PosY, Altitude, Speed, Roll, Turn, R, Cx, Cy, yp, DpX, DpY, DpH, hdgCD, typ, t2next, tspeed, CachVong, CachNhap) VALUES(");
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Flight_ID", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("nodetype", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("isPlan", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Td", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Altitude", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Speed", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Roll", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Turn", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("R", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Cx", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("Cy", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("yp", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("DpX", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("DpY", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("DpH", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("hdgCD", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("typ", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("t2next", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("tspeed", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("CachVong", true));
            stringBuilder3.Append(iDBUtility.GetParamPlaceHolder("CachNhap", false));
            stringBuilder3.Append(")");
            string sText2 = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            FlightNode flightNode = pFlight.Path[0];
            try
            {
                IDbCommand dbCommand = connection.CreateCommand(sText);
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Flight_ID", DbType.Int32, pFlight.Flight_ID, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                int num2 = 0;
                foreach (FlightNode flight in pFlight.Path)
                {
                    IDbCommand dbCommand3;
                    checked
                    {
                        num2++;
                        dbCommand = connection.CreateCommand(sText2);
                        dbCommand3 = dbCommand;
                        dbCommand3.Transaction = dbTransaction;
                        flight.Stt = num2;
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Flight_ID", DbType.Int32, pFlight.Flight_ID, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, num2, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("nodetype", DbType.Int16, flight.nodetype, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("isPlan", DbType.Boolean, flight.isPlan, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Td", DbType.DateTime, flight.td, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, flight.node.D.x, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, flight.node.D.y, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, flight.node.D.h, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, flight.node.Speed, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, flight.node.Roll, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Turn", DbType.Int16, flight.node.Turn, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("R", DbType.Double, flight.node.R, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Cx", DbType.Double, flight.node.C.x, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("Cy", DbType.Double, flight.node.C.y, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("yp", DbType.Double, flight.node.yp, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("DpX", DbType.Double, flight.node.Dp.x, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("DpY", DbType.Double, flight.node.Dp.y, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("DpH", DbType.Double, flight.node.Dp.h, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("hdgCD", DbType.Double, flight.node.hdgCD, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("typ", DbType.Double, flight.node.typ, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("t2next", DbType.Double, flight.node.t2next, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("tspeed", DbType.Double, flight.node.tspeed, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("CachVong", DbType.Int16, flight.node.CachVong, 0));
                        dbCommand3.Parameters.Add(iDBUtility.CreateParameter("CachNhap", DbType.Int16, flight.node.CachNhap, 0));
                    }
                    num = (long)dbCommand3.ExecuteNonQuery();
                }

                dbTransaction.Commit();
            }
            catch (Exception expr_7AE)
            {
                throw expr_7AE;
                Exception ex = expr_7AE;
                string str = "InserNodes: ";
                FlightNode flightNode2 = flightNode;
                str += Convert.ToString(pFlight.Flight_ID);
                str = str + "; " + Convert.ToString(flightNode2.Stt);
                str = str + "; " + Convert.ToString(flightNode2.nodetype);
                str = str + "; " + Convert.ToString(flightNode2.isPlan);
                str = str + "; " + Convert.ToString(flightNode2.td);
                PathNode node = flightNode.node;
                str = str + "; " + Convert.ToString(node.D.x);
                str = str + "; " + Convert.ToString(node.D.y);
                str = str + "; " + Convert.ToString(node.D.h);
                str = str + "; " + Convert.ToString(node.Speed);
                str = str + "; " + Convert.ToString(node.Roll);
                str = str + "; " + Convert.ToString((int)node.Turn);
                str = str + "; " + Convert.ToString(node.R);
                str = str + "; " + Convert.ToString(node.C.x);
                str = str + "; " + Convert.ToString(node.C.y);
                str = str + "; " + Convert.ToString(node.yp);
                str = str + "; " + Convert.ToString(node.Dp.x);
                str = str + "; " + Convert.ToString(node.Dp.y);
                str = str + "; " + Convert.ToString(node.Dp.h);
                str = str + "; " + Convert.ToString(node.hdgCD);
                str = str + "; " + Convert.ToString(node.typ);
                str = str + "; " + Convert.ToString(node.tspeed);
                str = str + "; " + Convert.ToString(node.t2next);



            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static List<FlightNode> GetFlightDetails(string tblName, int pFlight_ID)
        {
            List<FlightNode> list = new List<FlightNode>();
            string text = string.Concat(new string[]
{
"SELECT Stt, nodetype, isPlan, Td, PosX, PosY, Altitude, Speed, Roll, Turn, R, Cx, Cy, yp, DpX, DpY, DpH, hdgCD, typ, t2next, tspeed, CachVong, CachNhap FROM ",
tblName,
"Nodes WHERE Flight_ID = ",
Convert.ToString(pFlight_ID),
" ORDER BY Stt"
});
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    FlightNode flightNode = new FlightNode();
                    FlightNode flightNode2 = flightNode;
                    flightNode2.Stt = (int)dataReader.GetInt16(0);
                    flightNode2.nodetype = (int)dataReader.GetInt16(1);
                    flightNode2.isPlan = dataReader.GetBoolean(2);
                    flightNode2.td = dataReader.GetDateTime(3);
                    PathNode node = flightNode.node;
                    node.D.x = dataReader.GetDouble(4);
                    node.D.y = dataReader.GetDouble(5);
                    node.D.h = dataReader.GetDouble(6);
                    node.Speed = dataReader.GetDouble(7);
                    node.Roll = Convert.ToSingle(dataReader.GetValue(8));
                    node.Turn = (TurnValue)dataReader.GetInt16(9);
                    node.R = dataReader.GetDouble(10);
                    node.C.x = dataReader.GetDouble(11);
                    node.C.y = dataReader.GetDouble(12);
                    node.yp = dataReader.GetDouble(13);
                    node.Dp.x = dataReader.GetDouble(14);
                    node.Dp.y = dataReader.GetDouble(15);
                    node.Dp.h = dataReader.GetDouble(16);
                    node.hdgCD = dataReader.GetDouble(17);
                    node.typ = dataReader.GetDouble(18);
                    node.t2next = dataReader.GetDouble(19);
                    node.tspeed = dataReader.GetDouble(20);
                    node.CachVong = (enCachVong)dataReader.GetInt16(21);
                    node.CachNhap = (enCachNhap)dataReader.GetInt16(22);
                    node.C.h = node.D.h;
                    node.Dp.h = node.D.h;
                    list.Add(flightNode);
                }
                dataReader.Close();
            }
            catch (Exception expr_260)
            {
                throw expr_260;


            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static string GetKyHieu(string tblName, int pFlight_ID)
        {
            string result = "";
            OleDbConnection oleDbConnection = null;
            OleDbCommand oleDbCommand = null;
            OleDbDataReader oleDbDataReader = null;
            string cmdText = "SELECT KyHieu FROM " + tblName + " WHERE Flight_ID = " + Convert.ToString(pFlight_ID);
            try
            {
                oleDbConnection = new OleDbConnection(modHuanLuyen.myCnnString);
                oleDbConnection.Open();
                oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    byte[] array = (byte[])oleDbDataReader.GetValue(0);
                    try
                    {
                        result = Encoding.UTF8.GetString(array, 0, checked(array.GetUpperBound(0) + 1));
                    }
                    catch (Exception expr_70)
                    {
                        throw expr_70;
                    }
                }
            }
            catch (Exception expr_89)
            {
                throw expr_89;
            }
            finally
            {
                oleDbDataReader.Close();
                oleDbConnection.Close();
                oleDbCommand.Dispose();
                oleDbConnection.Dispose();
            }
            return result;
        }
        public static long UpdateKyHieu(string tblName, int pFlight_ID, string strKyHieu)
        {
            OleDbConnection oleDbConnection = null;
            OleDbCommand oleDbCommand = null;
            int num = -1;
            string text = "UPDATE " + tblName + " SET";
            text += " KyHieu = ?";
            text += " WHERE Flight_ID = ?";
            try
            {
                oleDbConnection = new OleDbConnection(modHuanLuyen.myCnnString);
                oleDbConnection.Open();
                oleDbCommand = new OleDbCommand(text, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("KyHieu", OleDbType.Binary, 0, "KyHieu"));
                oleDbCommand.Parameters.Add(new OleDbParameter("Original_Flight_ID", OleDbType.Integer, 0, ParameterDirection.Input, false, 10, 0, "Flight_ID", DataRowVersion.Original, null));
                oleDbCommand.Parameters["KyHieu"].Value = Encoding.UTF8.GetBytes(strKyHieu);
                oleDbCommand.Parameters["Original_Flight_ID"].Value = pFlight_ID;
                num = oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception expr_D5)
            {
                throw expr_D5;
            }
            finally
            {
                oleDbConnection.Close();
                oleDbCommand.Dispose();
                oleDbConnection.Dispose();
            }
            return (long)num;
        }
    }
}