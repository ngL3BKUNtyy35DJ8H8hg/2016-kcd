using ADOConnection;
using AxMapXLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
namespace HuanLuyen
{
    public class CAirports
    {
        public static List<CAirport> GetList(string tblName)
        {
            List<CAirport> list = new List<CAirport>();
            string sText = "SELECT SB_ID, Name, MaSB, SymbolID, PosX, PosY, Altitude, Rotation, Scale, LblText,LblDeltaX,LblDeltaY FROM " + tblName + " ORDER BY Name";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CAirport cAirport = new CAirport();
                    CAirport cAirport2 = cAirport;
                    cAirport2.SB_ID = dataReader.GetInt32(0);
                    cAirport2.Name = dataReader.GetString(1);
                    cAirport2.MaSB = dataReader.GetString(2);
                    cAirport2.SymbolID = (int)dataReader.GetInt16(3);
                    cAirport2.Pos.x = dataReader.GetDouble(4);
                    cAirport2.Pos.y = dataReader.GetDouble(5);
                    cAirport2.Pos.h = dataReader.GetDouble(6);
                    cAirport2.Rotation = Convert.ToSingle(dataReader.GetValue(7));
                    cAirport2.Scale = Convert.ToSingle(dataReader.GetValue(8));
                    string lblText = "";
                    try
                    {
                        lblText = dataReader.GetString(9);
                    }
                    catch (Exception expr_FB)
                    {
                        throw expr_FB;
                    }
                    cAirport2.LblText = lblText;
                    cAirport2.LblDeltaX = (int)dataReader.GetInt16(10);
                    cAirport2.LblDeltaY = (int)dataReader.GetInt16(11);
                    cAirport2 = null;
                    list.Add(cAirport);
                }
                dataReader.Close();
            }
            catch (Exception expr_153)
            {
                throw expr_153;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static List<CAirport> GetList(string tblName, string pName)
        {
            List<CAirport> list = new List<CAirport>();
            string str = "";
            if (pName.Length > 0)
            {
                str = " WHERE (InStr(1,[Name],'" + pName + "') > 0)";
            }
            string sText = "SELECT SB_ID, Name, MaSB, SymbolID, PosX, PosY, Altitude, Rotation, Scale, LblText,LblDeltaX,LblDeltaY FROM " + tblName + str + " ORDER BY Name";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CAirport cAirport = new CAirport();
                    CAirport cAirport2 = cAirport;
                    cAirport2.SB_ID = dataReader.GetInt32(0);
                    cAirport2.Name = dataReader.GetString(1);
                    cAirport2.MaSB = dataReader.GetString(2);
                    cAirport2.SymbolID = (int)dataReader.GetInt16(3);
                    cAirport2.Pos.x = dataReader.GetDouble(4);
                    cAirport2.Pos.y = dataReader.GetDouble(5);
                    cAirport2.Pos.h = dataReader.GetDouble(6);
                    cAirport2.Rotation = Convert.ToSingle(dataReader.GetValue(7));
                    cAirport2.Scale = Convert.ToSingle(dataReader.GetValue(8));
                    string lblText = "";
                    try
                    {
                        lblText = dataReader.GetString(9);
                    }
                    catch (Exception expr_11F)
                    {
                        throw expr_11F;
                    }
                    cAirport2.LblText = lblText;
                    cAirport2.LblDeltaX = (int)dataReader.GetInt16(10);
                    cAirport2.LblDeltaY = (int)dataReader.GetInt16(11);
                    cAirport2 = null;
                    list.Add(cAirport);
                }
                dataReader.Close();
            }
            catch (Exception expr_177)
            {
                throw expr_177;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CAirport GetAirport(string tblName, int lSB_ID)
        {
            CAirport cAirport = new CAirport();
            cAirport.SB_ID = -1;
            string sText = "SELECT  Name, MaSB, SymbolID, PosX, PosY, Altitude, Rotation, Scale, LblText,LblDeltaX,LblDeltaY FROM " + tblName + " WHERE SB_ID = " + Convert.ToString(lSB_ID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CAirport cAirport2 = cAirport;
                    cAirport2.SB_ID = lSB_ID;
                    cAirport2.Name = dataReader.GetString(0);
                    cAirport2.MaSB = dataReader.GetString(1);
                    cAirport2.SymbolID = (int)dataReader.GetInt16(2);
                    cAirport2.Pos.x = dataReader.GetDouble(3);
                    cAirport2.Pos.y = dataReader.GetDouble(4);
                    cAirport2.Pos.h = dataReader.GetDouble(5);
                    cAirport2.Rotation = Convert.ToSingle(dataReader.GetValue(6));
                    cAirport2.Scale = Convert.ToSingle(dataReader.GetValue(7));
                    string lblText = "";
                    try
                    {
                        lblText = dataReader.GetString(8);
                    }
                    catch (Exception expr_F8)
                    {
                        throw expr_F8;
                    }
                    cAirport2.LblText = lblText;
                    cAirport2.LblDeltaX = (int)dataReader.GetInt16(9);
                    cAirport2.LblDeltaY = (int)dataReader.GetInt16(10);
                    cAirport2 = null;
                }
                dataReader.Close();
            }
            catch (Exception expr_148)
            {
                throw expr_148;
            }
            finally
            {
                connection.Close();
            }
            return cAirport;
        }
        public static int Insert(string tblName, CAirport objAirport)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO " + tblName + " (Name, MaSB, SymbolID, PosX, PosY, Altitude, Rotation, Scale, LblText,LblDeltaX,LblDeltaY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MaSB", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SymbolID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Altitude", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Rotation", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Scale", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblText", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaY", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, objAirport.Name, objAirport.Name.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MaSB", DbType.String, objAirport.MaSB, objAirport.MaSB.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SymbolID", DbType.Int16, objAirport.SymbolID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, objAirport.Pos.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, objAirport.Pos.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, objAirport.Pos.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Rotation", DbType.Single, objAirport.Rotation, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Scale", DbType.Single, objAirport.Scale, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblText", DbType.String, objAirport.LblText, objAirport.LblText.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaX", DbType.Int16, objAirport.LblDeltaX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaY", DbType.Int16, objAirport.LblDeltaY, 0));
                num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "SB_ID", tblName);
                dbTransaction.Commit();
            }
            catch (Exception expr_344)
            {
                throw expr_344;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Update(string tblName, CAirport objAirport)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE " + tblName + " SET");
            stringBuilder2.Append(" Name = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
            stringBuilder2.Append(" MaSB = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MaSB", true));
            stringBuilder2.Append(" SymbolID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SymbolID", true));
            stringBuilder2.Append(" PosX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(" PosY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(" Altitude = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(" Rotation = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Rotation", true));
            stringBuilder2.Append(" Scale = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Scale", true));
            stringBuilder2.Append(" LblText = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblText", true));
            stringBuilder2.Append(" LblDeltaX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaX", true));
            stringBuilder2.Append(" LblDeltaY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaY", false));
            stringBuilder2.Append(" WHERE SB_ID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, objAirport.Name, objAirport.Name.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MaSB", DbType.String, objAirport.MaSB, objAirport.MaSB.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SymbolID", DbType.Int16, objAirport.SymbolID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, objAirport.Pos.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, objAirport.Pos.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, objAirport.Pos.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Rotation", DbType.Single, objAirport.Rotation, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Scale", DbType.Single, objAirport.Scale, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblText", DbType.String, objAirport.LblText, objAirport.LblText.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaX", DbType.Int16, objAirport.LblDeltaX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaY", DbType.Int16, objAirport.LblDeltaY, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, objAirport.SB_ID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_3EF)
            {
                throw expr_3EF;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(string tblName, long lSBId)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM " + tblName);
            stringBuilder2.Append(" WHERE SB_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, lSBId, 0));
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
        public static CAirport FindAtPoint(AxMap pMap, PointF pt, List<CAirport> pAirports)
        {
            checked
            {
                if (pAirports != null && pAirports.Count > 0)
                {
                    for (int i = pAirports.Count - 1; i >= 0; i += -1)
                    {
                        CAirport cAirport = pAirports[i];
                        if (cAirport.HitTest(pMap, pt))
                        {
                            return cAirport;
                        }
                    }
                }
                return null;
            }
        }
    }
}