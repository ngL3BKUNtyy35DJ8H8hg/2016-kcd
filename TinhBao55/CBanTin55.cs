using System;
namespace TinhBao55
{
	public class CBanTin55
	{
		public string DangBT;
		public string SoHieu;
		public string ToaDo;
		public int SoLuong = 0;
		public string KieuLoai;
		public int DoCao = 0;
		public CBanTin55()
		{
			this.DangBT = "";
			this.SoHieu = "";
			this.ToaDo = "";
			this.SoLuong = 0;
			this.KieuLoai = "";
			this.DoCao = 0;
		}
		public override string ToString()
		{
			string result = "";
			string dangBT = this.DangBT;
			if (dangBT == "XH")
			{
				result = string.Concat(new string[]
				{
					"XuấtHiện - ",
					this.TopToString(),
					" - ",
					this.ToaDoToString(),
					" - ",
					this.SoLuongToString(),
					" ",
					this.KieuLoaiToString(),
					" - ",
					this.DoCaoToString()
				});
			}
			else if (dangBT == "RG")
			{
				result = this.TopToString() + " - " + this.ToaDoToString();
			}
			else if (dangBT == "DD")
			{
				result = string.Concat(new string[]
				{
					this.TopToString(),
					" - ",
					this.ToaDoToString(),
					" - ",
					this.SoLuongToString(),
					" ",
					this.KieuLoaiToString(),
					" - ",
					this.DoCaoToString()
				});
			}
			else if (dangBT == "MT")
			{
				result = this.TopToString() + " - " + this.ToaDoToString() + " MấtTiêu";
			}
			else if (dangBT == "TM")
			{
				result = this.TopToString() + " - " + this.ToaDoToString() + " TạmMấtTiêu";
			}
			return result;
		}
		private string TopToString()
		{
			string str = "";
			return str + modBanTin.GetKyTuSoString(this.SoHieu);
		}
		private string ToaDoToString()
		{
			checked
			{
				int startIndex = this.ToaDo.Length - 3;
				string pKyTuSo = this.ToaDo.Substring(0, this.ToaDo.Length - 3);
				string pKyTuSo2 = this.ToaDo.Substring(startIndex, 3);
				return modBanTin.GetKyTuSoString(pKyTuSo) + " - " + modBanTin.GetKyTuSoString(pKyTuSo2);
			}
		}
		private string SoLuongToString()
		{
			string str = "";
			return str + modBanTin.GetKyTuSoString(this.SoLuong.ToString("00"));
		}
		private string KieuLoaiToString()
		{
			return modBanTin.GetKyTuSoString(this.KieuLoai);
		}
		private string DoCaoToString()
		{
			return modBanTin.GetKyTuSoString(this.DoCao.ToString("0000"));
		}
		public void LoadFromString(string pStr)
		{
			string[] array = pStr.Split(new char[]
			{
				'='
			});
			checked
			{
				if (array.GetUpperBound(0) == 1)
				{
					this.DangBT = array[0];
					string text = array[1];
					array = text.Split(new char[]
					{
						','
					});
					int upperBound = array.GetUpperBound(0);
					string dangBT = this.DangBT;
					if (dangBT == "XH")
					{
						if (upperBound >= 4)
						{
							this.SoHieu = array[0];
							this.ToaDo = array[1];
							this.SoLuong = (int)Math.Round(double.Parse(array[2]));
							this.KieuLoai = array[3];
							this.DoCao = (int)Math.Round(double.Parse(array[4]));
						}
					}
					else if (dangBT == "RG")
					{
						if (upperBound >= 1)
						{
							this.SoHieu = array[0];
							this.ToaDo = array[1];
						}
					}
					else if (dangBT == "DD")
					{
						if (upperBound >= 4)
						{
							this.SoHieu = array[0];
							this.ToaDo = array[1];
							this.SoLuong = (int)Math.Round(double.Parse(array[2]));
							this.KieuLoai = array[3];
							this.DoCao = (int)Math.Round(double.Parse(array[4]));
						}
					}
					else if ((dangBT == "MT" || dangBT == "TM") && upperBound >= 1)
					{
						this.SoHieu = array[0];
						this.ToaDo = array[1];
					}
				}
			}
		}
	}
}