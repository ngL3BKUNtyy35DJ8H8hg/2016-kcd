using ADOConnection;
using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
namespace HuanLuyen
{
    public class CPaths
    {
        public static List<CPath> GetList()
        {
            List<CPath> list = new List<CPath>();
            string sText = "SELECT Path_ID, Name, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo, LoaiMB FROM tblPath";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CPath cPath = new CPath();
                    CPath cPath2 = cPath;
                    cPath2.Path_ID = dataReader.GetInt32(0);
                    cPath2.Name = dataReader.GetString(1);
                    cPath2.PosFrom.x = dataReader.GetDouble(2);
                    cPath2.PosFrom.y = dataReader.GetDouble(3);
                    cPath2.PosFrom.h = dataReader.GetDouble(4);
                    cPath2.SpeedFrom = dataReader.GetDouble(5);
                    cPath2.PosTo.x = dataReader.GetDouble(6);
                    cPath2.PosTo.y = dataReader.GetDouble(7);
                    cPath2.PosTo.h = dataReader.GetDouble(8);
                    cPath2.SpeedTo = dataReader.GetDouble(9);
                    cPath2.LoaiMB = dataReader.GetInt32(10);
                    list.Add(cPath);
                }
                dataReader.Close();
            }
            catch (Exception expr_121)
            {
                throw expr_121;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int Insert(CPath objPath)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblPath (Name, PosFromX, PosFromY, PosFromH, SpeedFrom, PosToX, PosToY, PosToH, SpeedTo, LoaiMB) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosFromH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedFrom", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosToH", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiMB", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, objPath.Name, objPath.Name.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromX", DbType.Double, objPath.PosFrom.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromY", DbType.Double, objPath.PosFrom.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromH", DbType.Double, objPath.PosFrom.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedFrom", DbType.Double, objPath.SpeedFrom, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToX", DbType.Double, objPath.PosTo.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToY", DbType.Double, objPath.PosTo.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToH", DbType.Double, objPath.PosTo.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedTo", DbType.Double, objPath.SpeedTo, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.Int32, objPath.LoaiMB, 0));
                num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "Path_ID", "tblPath");
                dbTransaction.Commit();
            }
            catch (Exception expr_301)
            {
                dbTransaction.Rollback();
                throw expr_301;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Update(CPath objPath)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblPath SET");
            stringBuilder2.Append(" Name = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", true));
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
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SpeedTo", true));
            stringBuilder2.Append(" LoaiMB = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiMB", false));
            stringBuilder2.Append(" WHERE Path_ID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Path_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, objPath.Name, objPath.Name.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromX", DbType.Double, objPath.PosFrom.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromY", DbType.Double, objPath.PosFrom.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosFromH", DbType.Double, objPath.PosFrom.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedFrom", DbType.Double, objPath.SpeedFrom, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToX", DbType.Double, objPath.PosTo.x, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToY", DbType.Double, objPath.PosTo.y, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosToH", DbType.Double, objPath.PosTo.h, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SpeedTo", DbType.Double, objPath.SpeedTo, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.Int32, objPath.LoaiMB, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Path_ID", DbType.Int32, objPath.Path_ID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_39D)
            {
                dbTransaction.Rollback();
                throw expr_39D;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(long lPath_Id)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblPath ");
            stringBuilder2.Append(" WHERE Path_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Path_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Path_ID", DbType.Int32, lPath_Id, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_BA)
            {
                dbTransaction.Rollback();
                throw expr_BA;
                
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long DeleteNodes(long lPath_Id)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblPathNodes ");
            stringBuilder2.Append(" WHERE Path_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Path_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Path_ID", DbType.Int32, lPath_Id, 0));
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
        public static int InsertNode(int pPath_ID, PathNode objNode)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblPathNodes (Path_ID, Stt, PosX, PosY, Altitude, Speed, Roll, Turn, tspeed, CachVong, CachNhap, CX, CY, DpX, DpY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Path_ID", true));
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
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Path_ID", DbType.Int32, pPath_ID, 0));
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
        public static List<PathNode> GetPathDetails(int pPath_ID)
        {
            List<PathNode> list = new List<PathNode>();
            string sText = "SELECT CachVong, CachNhap, Stt, PosX, PosY, Altitude, Speed, Roll, Turn, tspeed , CX, CY, DpX, DpY FROM tblPathNodes WHERE Path_ID = " + Convert.ToString(pPath_ID);
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
        public static CPath FindAtPoint(AxMap pMap, PointF pt, List<CPath> pFPaths)
        {
            checked
            {
                if (pFPaths != null && pFPaths.Count > 0)
                {
                    for (int i = pFPaths.Count - 1; i >= 0; i += -1)
                    {
                        CPath cPath = pFPaths[i];
                        if (cPath.HitTest(pMap, pt))
                        {
                            return cPath;
                        }
                    }
                }
                return null;
            }
        }
        public static struPhuongVi GetPhuongVi(AxMap pMap, MapPoint pTdPos, double pPosX, double pPosY)
        {
            struPhuongVi result = default(struPhuongVi);
            PointF pPT = default(PointF);
            PointF pPT2 = default(PointF);
            float num = pPT.X;
            float num2 = pPT.Y;
            pMap.ConvertCoord(ref num, ref num2, ref pTdPos.x, ref pTdPos.y, ConversionConstants.miMapToScreen);
            pPT.Y = num2;
            pPT.X = num;
            num2 = pPT2.X;
            num = pPT2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref pPosX, ref pPosY, ConversionConstants.miMapToScreen);
            pPT2.Y = num;
            pPT2.X = num2;
            result.CuLy = pMap.Distance(pTdPos.x, pTdPos.y, pPosX, pPosY) / 1000.0;
            result.PhuongVi = modHuanLuyen.GetHDG(pPT, pPT2);
            return result;
        }
    }
}