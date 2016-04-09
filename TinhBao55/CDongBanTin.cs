using System;
using System.Collections.Generic;
namespace TinhBao55
{
	public partial class CDongBanTin
	{
		public string GioPhut;
		public string Phut;
		public List<CBanTin55> CaCBanTin55;
		public override string ToString()
		{
			string text = "";
			foreach(CBanTin55 current in this.CaCBanTin55){
					if (current.DangBT == "RG")
					{
						text = string.Concat(new string[]
						{
							text,
							" - - ",
							current.ToString(),
							" - ",
							modBanTin.GetKyTuSoString(this.Phut)
						});
					}
					else
					{
						text = string.Concat(new string[]
						{
							text,
							" - - ",
							current.ToString(),
							" - ",
							modBanTin.GetKyTuSoString(this.GioPhut)
						});
					}
					if (current.DangBT == "XH")
					{
						text = string.Concat(new string[]
						{
							text,
							" - - ",
							current.ToString(),
							" - ",
							modBanTin.GetKyTuSoString(this.GioPhut)
						});
					}
				}
			
			return text;
		}
		private string PhutToString()
		{
			string str = "Phút ";
			return str + modBanTin.GetValueString(Convert.ToInt32(this.Phut));
		}
		public void LoadFromString(string pStr)
		{
			string[] array = pStr.Split(new char[]
			{
				':'
			});
			checked
			{
				if (array.GetUpperBound(0) == 1)
				{
					this.GioPhut = array[0];
					this.Phut = this.GioPhut.Substring(2, 2);
					string text = array[1];
					array = text.Split(new char[]
					{
						'+'
					});
					int upperBound = array.GetUpperBound(0);
					if (upperBound >= 0)
					{
						int arg_68_0 = 0;
						int num = upperBound;
						for (int i = arg_68_0; i <= num; i++)
						{
							CBanTin55 cBanTin = new CBanTin55();
							cBanTin.LoadFromString(array[i]);
							this.CaCBanTin55.Add(cBanTin);
						}
					}
				}
			}
		}
		public CDongBanTin()
		{
			this.GioPhut = "";
			this.Phut = "";
			this.CaCBanTin55 = new List<CBanTin55>();
		}
	}
}