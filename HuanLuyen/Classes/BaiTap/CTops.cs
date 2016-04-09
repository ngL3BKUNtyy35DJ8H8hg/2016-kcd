using ADOConnection;
using AxMapXLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
namespace HuanLuyen
{
    public class CTops
    {
        public static List<CTop> GetList(int pBaiTapID)
        {
            List<CTop> list = new List<CTop>();
            string sText = "SELECT TopID, LoaiTopID, SoLuong, GioBatDau, PhutBatDau, GiayBatDau, MilliGiayBatDau, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo, FlightNo, Name, LoaiMB,LblDeltaX,LblDeltaY FROM tblTop WHERE BaiTapID = " + Convert.ToString(pBaiTapID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CTop cTop = new CTop();
                    CTop cTop2 = cTop;
                    cTop2.TopID = dataReader.GetInt32(0);
                    cTop2.LoaiTopID = (int)dataReader.GetInt16(1);
                    cTop2.SoLuong = (int)dataReader.GetInt16(2);
                    cTop2.GioBatDau = (int)dataReader.GetInt16(3);
                    cTop2.PhutBatDau = (int)dataReader.GetInt16(4);
                    cTop2.GiayBatDau = (int)dataReader.GetInt16(5);
                    cTop2.MilliGiayBatDau = (int)dataReader.GetInt16(6);
                    cTop2.PosFrom.x = dataReader.GetDouble(7);
                    cTop2.PosFrom.y = dataReader.GetDouble(8);
                    cTop2.PosFrom.h = dataReader.GetDouble(9);
                    cTop2.SpeedFrom = dataReader.GetDouble(10);
                    cTop2.PosTo.x = dataReader.GetDouble(11);
                    cTop2.PosTo.y = dataReader.GetDouble(12);
                    cTop2.PosTo.h = dataReader.GetDouble(13);
                    cTop2.SpeedTo = dataReader.GetDouble(14);
                    cTop2.FlightNo = dataReader.GetString(15);
                    cTop2.Name = dataReader.GetString(16);
                    cTop2.LoaiMB = dataReader.GetInt32(17);
                    cTop2.LblDeltaX = (int)dataReader.GetInt16(18);
                    cTop2.LblDeltaY = (int)dataReader.GetInt16(19);
                    list.Add(cTop);
                }
                dataReader.Close();
            }
            catch (Exception expr_1BC)
            {
                throw expr_1BC;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int Insert(CTop objTop)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblTop (BaiTapID, LoaiTopID, SoLuong, GioBatDau, PhutBatDau, GiayBatDau, MilliGiayBatDau, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo, FlightNo, Name, LoaiMB, LblDeltaX, LblDeltaY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiTopID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoLuong", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GioBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PhutBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GiayBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MilliGiayBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedFrom", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("FilghtNo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiMB", true));
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
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, objTop.BaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiTopID", DbType.Int16, objTop.LoaiTopID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoLuong", DbType.Int16, objTop.SoLuong, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GioBatDau", DbType.Int16, objTop.GioBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PhutBatDau", DbType.Int16, objTop.PhutBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GiayBatDau", DbType.Int16, objTop.GiayBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MilliGiayBatDau", DbType.Int16, objTop.MilliGiayBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromX", DbType.Double, objTop.PosFrom.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromY", DbType.Double, objTop.PosFrom.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromH", DbType.Double, objTop.PosFrom.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedFrom", DbType.Double, objTop.SpeedFrom, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToX", DbType.Double, objTop.PosTo.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToY", DbType.Double, objTop.PosTo.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToH", DbType.Double, objTop.PosTo.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedTo", DbType.Double, objTop.SpeedTo, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("FlightNo", DbType.String, objTop.FlightNo, objTop.FlightNo.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, objTop.Name, objTop.Name.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.Int32, objTop.LoaiMB, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaX", DbType.Int16, objTop.LblDeltaX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaY", DbType.Int16, objTop.LblDeltaY, 0));
                num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "TopID", "tblTop");
                dbTransaction.Commit();
            }
            catch (Exception expr_55E)
            {
                throw expr_55E;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static int InsertFrom(int pFromBaiTapID, int pBaiTapID)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblTop (BaiTapID, LoaiTopID, SoLuong, GioBatDau, PhutBatDau, GiayBatDau, MilliGiayBatDau, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo, FlightNo, Name, LoaiMB) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiTopID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoLuong", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GioBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PhutBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GiayBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MilliGiayBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedFrom", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("FilghtNo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiMB", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                List<CTop> list = CTops.GetList(pFromBaiTapID);
                foreach (CTop current in list)
                {
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Transaction = dbTransaction;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, current.BaiTapID, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiTopID", DbType.Int16, current.LoaiTopID, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoLuong", DbType.Int16, current.SoLuong, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GioBatDau", DbType.Int16, current.GioBatDau, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PhutBatDau", DbType.Int16, current.PhutBatDau, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GiayBatDau", DbType.Int16, current.GiayBatDau, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MilliGiayBatDau", DbType.Int16, current.MilliGiayBatDau, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromX", DbType.Double, current.PosFrom.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromY", DbType.Double, current.PosFrom.y, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromH", DbType.Double, current.PosFrom.h, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedFrom", DbType.Double, current.SpeedFrom, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToX", DbType.Double, current.PosTo.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToY", DbType.Double, current.PosTo.y, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToH", DbType.Double, current.PosTo.h, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedTo", DbType.Double, current.SpeedTo, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("FlightNo", DbType.String, current.FlightNo, current.FlightNo.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, current.Name, current.Name.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.Int32, current.LoaiMB, 0));
                    num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "TopID", "tblTop");
                    dbTransaction.Commit();
                }

            }
            catch (Exception expr_535)
            {
                throw expr_535;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Update(CTop objTop)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblTop SET");
            stringBuilder2.Append(" LoaiTopID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiTopID", true));
            stringBuilder2.Append(" FlightNo = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("FlightNo", true));
            stringBuilder2.Append(" SoLuong = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoLuong", true));
            stringBuilder2.Append(" GioBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GioBatDau", true));
            stringBuilder2.Append(" PhutBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PhutBatDau", true));
            stringBuilder2.Append(" GiayBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GiayBatDau", true));
            stringBuilder2.Append(" MilliGiayBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MilliGiayBatDau", false));
            stringBuilder2.Append(" WHERE TopID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiTopID", DbType.Int16, objTop.LoaiTopID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("FlightNo", DbType.String, objTop.FlightNo, objTop.FlightNo.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoLuong", DbType.Int16, objTop.SoLuong, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GioBatDau", DbType.Int16, objTop.GioBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PhutBatDau", DbType.Int16, objTop.PhutBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GiayBatDau", DbType.Int16, objTop.GiayBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MilliGiayBatDau", DbType.Int16, objTop.MilliGiayBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, objTop.TopID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_2B2)
            {
                throw expr_2B2;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long UpdateDauCuoi(CTop objTop)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblTop SET");
            stringBuilder2.Append(" PosFromX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromX", true));
            stringBuilder2.Append(" PosFromY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromY", true));
            stringBuilder2.Append(" PosFromH = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromH", true));
            stringBuilder2.Append(" SpeedFrom = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedFrom", true));
            stringBuilder2.Append(" PosToX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToX", true));
            stringBuilder2.Append(" PosToY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToY", true));
            stringBuilder2.Append(" PosToH = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToH", true));
            stringBuilder2.Append(" SpeedTo = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", false));
            stringBuilder2.Append(" WHERE TopID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromX", DbType.Double, objTop.PosFrom.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromY", DbType.Double, objTop.PosFrom.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromH", DbType.Double, objTop.PosFrom.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedFrom", DbType.Double, objTop.SpeedFrom, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToX", DbType.Double, objTop.PosTo.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToY", DbType.Double, objTop.PosTo.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToH", DbType.Double, objTop.PosTo.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedTo", DbType.Double, objTop.SpeedTo, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, objTop.TopID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_30A)
            {
                throw expr_30A;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long UpdateDauTopPos(CTop objTop)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblTop SET");
            stringBuilder2.Append(" LblDeltaX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaX", true));
            stringBuilder2.Append(" LblDeltaY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LblDeltaY", false));
            stringBuilder2.Append(" WHERE TopID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaX", DbType.Int16, objTop.LblDeltaX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LblDeltaY", DbType.Int16, objTop.LblDeltaY, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, objTop.TopID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_14A)
            {
                throw expr_14A;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(long lTop_Id)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblTop ");
            stringBuilder2.Append(" WHERE TopID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, lTop_Id, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_BA)
            {
                throw expr_BA;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long DeleteTops(int pBaiTapId)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblTop ");
            stringBuilder2.Append(" WHERE (BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapId, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_C7)
            {
                throw expr_C7;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long DeleteNodes(long lTop_Id)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblTopNodes ");
            stringBuilder2.Append(" WHERE TopID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, lTop_Id, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_BA)
            {
                throw expr_BA;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int InsertNode(int pTop_ID, PathNode objNode)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblTopNodes (TopID, Stt, PosX, PosY, Altitude, Speed, Roll, Turn, tspeed, CachVong, CachNhap, CX, CY, DpX, DpY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Altitude", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Speed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Roll", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Turn", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("tspeed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachVong", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachNhap", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpY", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, pTop_ID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, objNode.Stt, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, objNode.D.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, objNode.D.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, objNode.D.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, objNode.Speed, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, objNode.Roll, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Turn", DbType.Int16, objNode.Turn, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("tspeed", DbType.Double, objNode.tspeed, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachVong", DbType.Int16, objNode.CachVong, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachNhap", DbType.Int16, objNode.CachNhap, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CX", DbType.Double, objNode.C.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CY", DbType.Double, objNode.C.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpX", DbType.Double, objNode.Dp.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpY", DbType.Double, objNode.Dp.y, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_41C)
            {
                throw expr_41C;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static int InsertNodes(int pTop_ID, List<PathNode> objNodes)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblTopNodes (TopID, Stt, PosX, PosY, Altitude, Speed, Roll, Turn, tspeed, CachVong, CachNhap, CX, CY, DpX, DpY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("TopID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Altitude", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Speed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Roll", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Turn", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("tspeed", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachVong", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CachNhap", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("CY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("DpY", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                dbCommand.Transaction = dbTransaction;
                foreach (PathNode current in objNodes)
                {
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TopID", DbType.Int32, pTop_ID, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, current.Stt, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, current.D.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, current.D.y, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, current.D.h, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, current.Speed, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, current.Roll, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Turn", DbType.Int16, current.Turn, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("tspeed", DbType.Double, current.tspeed, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachVong", DbType.Int16, current.CachVong, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CachNhap", DbType.Int16, current.CachNhap, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CX", DbType.Double, current.C.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("CY", DbType.Double, current.C.y, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpX", DbType.Double, current.Dp.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("DpY", DbType.Double, current.Dp.y, 0));
                    num = (long)dbCommand2.ExecuteNonQuery();
                }

                dbTransaction.Commit();
            }
            catch (Exception expr_45B)
            {
                throw expr_45B;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static List<PathNode> GetPathDetails(int pTopID)
        {
            List<PathNode> list = new List<PathNode>();
            string sText = "SELECT CachVong, CachNhap, Stt, PosX, PosY, Altitude, Speed, Roll, Turn, tspeed , CX, CY, DpX, DpY FROM tblTopNodes WHERE TopID = " + Convert.ToString(pTopID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    PathNode pathNode = new PathNode();
                    PathNode pathNode2 = pathNode;
                    pathNode2.CachVong = (enCachVong)dataReader.GetInt16(0);
                    pathNode2.CachNhap = (enCachNhap)dataReader.GetInt16(1);
                    pathNode2.Stt = (int)dataReader.GetInt16(2);
                    pathNode2.D.x = dataReader.GetDouble(3);
                    pathNode2.D.y = dataReader.GetDouble(4);
                    pathNode2.D.h = dataReader.GetDouble(5);
                    pathNode2.Speed = dataReader.GetDouble(6);
                    pathNode2.Roll = Convert.ToSingle(dataReader.GetValue(7));
                    pathNode2.Turn = (TurnValue)dataReader.GetInt16(8);
                    pathNode2.tspeed = dataReader.GetDouble(9);
                    pathNode2.C.x = dataReader.GetDouble(10);
                    pathNode2.C.y = dataReader.GetDouble(11);
                    pathNode2.Dp.x = dataReader.GetDouble(12);
                    pathNode2.Dp.y = dataReader.GetDouble(13);
                    pathNode2.C.h = pathNode2.D.h;
                    pathNode2.Dp.h = pathNode2.D.h;
                    list.Add(pathNode);
                }
                dataReader.Close();
            }
            catch (Exception expr_196)
            {
                throw expr_196;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CTop FindAtPoint(AxMap pMap, PointF pt, List<CTop> pFTops)
        {
            checked
            {
                if (pFTops != null && pFTops.Count > 0)
                {
                    for (int i = pFTops.Count - 1; i >= 0; i += -1)
                    {
                        CTop cTop = pFTops[i];
                        if (cTop.HitTest(pMap, pt))
                        {
                            return cTop;
                        }
                    }
                }
                return null;
            }
        }
    }
}