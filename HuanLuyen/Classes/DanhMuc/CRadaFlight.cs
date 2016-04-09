using AxMapXLib;
using System;
using System.Collections.Generic;
namespace HuanLuyen
{
    public class CRadaFlight
    {
        public CRada Rada;
        public CFlight Flight;
        public int Stt;
        public enRadaStatus Status;
        public bool DaThay;
        public List<CRadaFlightMT> RadaFlightMTs;
        public CRadaFlight(CRada pRada, CFlight pFlight)
        {
            this.Rada = pRada;
            this.Flight = pFlight;
            this.Stt = -1;
            this.Status = enRadaStatus.ChuaThay;
            this.DaThay = false;
            this.RadaFlightMTs = new List<CRadaFlightMT>();
        }
        private void SetStatus2(AxMap pMap, DateTime pLuc)
        {
            enRadaStatus enRadaStatus = enRadaStatus.ChuaThay;
            switch (this.Flight.MayBay.Status)
            {
                case enTopStatus.ChuaBay:
                    enRadaStatus = enRadaStatus.ChuaThay;
                    break;
                case enTopStatus.DangBay:
                    if (this.Rada.TrongVung(pMap, this.Flight.MayBay.Pos.x, this.Flight.MayBay.Pos.y))
                    {
                        enRadaStatus = enRadaStatus.Thay;
                        foreach (CKhuat current in this.Rada.Khuats)
                        {
                            if (current.Contains(pMap, this.Flight.MayBay.Pos.x, this.Flight.MayBay.Pos.y))
                            {
                                if (this.DaThay)
                                {
                                    enRadaStatus = enRadaStatus.TamMatMT;
                                    break;
                                }
                                enRadaStatus = enRadaStatus.ChuaThay;
                                break;
                            }
                        }
                        if (enRadaStatus == enRadaStatus.Thay)
                        {
                            if (this.DaThay)
                            {
                                enRadaStatus = enRadaStatus.Thay;
                            }
                            else
                            {
                                enRadaStatus = enRadaStatus.XuatHien;
                                this.DaThay = true;
                            }
                        }
                    }
                    else if (this.DaThay)
                    {
                        enRadaStatus = enRadaStatus.TamMatMT;
                    }
                    else
                    {
                        enRadaStatus = enRadaStatus.ChuaThay;
                    }
                    break;
                case enTopStatus.DungBay:
                    if (this.DaThay)
                    {
                        enRadaStatus = enRadaStatus.MatMT;
                    }
                    break;
            }
            this.Status = enRadaStatus;
        }
        private void AddNewMT(DateTime pLuc)
        {
            CRadaFlightMT cRadaFlightMT = new CRadaFlightMT();
            CRadaFlightMT cRadaFlightMT2 = cRadaFlightMT;
            cRadaFlightMT2.Gio = pLuc.Hour;
            cRadaFlightMT2.Phut = pLuc.Minute;
            cRadaFlightMT2.Status = this.Status;
            cRadaFlightMT2.Pos = this.Flight.MayBay.Pos;
            cRadaFlightMT2.SoLuong = this.Flight.SoLuong;
            this.RadaFlightMTs.Add(cRadaFlightMT);
        }
        private void AddMT(DateTime pLuc)
        {
            switch (this.Status)
            {
                case enRadaStatus.XuatHien:
                case enRadaStatus.Thay:
                    this.AddNewMT(pLuc);
                    break;
                case enRadaStatus.TamMatMT:
                case enRadaStatus.MatMT:
                    if (this.RadaFlightMTs.Count > 0)
                    {
                        CRadaFlightMT cRadaFlightMT = this.RadaFlightMTs[checked(this.RadaFlightMTs.Count - 1)];
                        if (cRadaFlightMT.Status != this.Status)
                        {
                            this.AddNewMT(pLuc);
                        }
                    }
                    else
                    {
                        this.AddNewMT(pLuc);
                    }
                    break;
            }
        }
        public void SetStatus(AxMap pMap, DateTime pLuc)
        {
            this.Flight.GetMayBay2(pMap, pLuc);
            this.SetStatus2(pMap, pLuc);
            this.AddMT(pLuc);
        }
        public void SetStatus(AxMap pMap, DateTime pLuc, CFlight pFlight)
        {
            this.Flight.GetMayBay2From(pFlight);
            this.SetStatus2(pMap, pLuc);
            this.AddMT(pLuc);
        }
    }
}