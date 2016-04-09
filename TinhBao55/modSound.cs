using myWaveLib;
using StretchWav;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace TinhBao55
{
	public static class modSound
	{
		public static string mySoundDir = "D:\\binh\\VTServer\\Sounds";
		public static float Tempo = 1.5f;
		public static double DurationMax = 30.0;
		private static string fileout = "mysound.wav";
		private static CSoundDataDict SoundDataDict;
		private static bool populateSoundDataDict(string mySoundDir)
		{
			bool result = false;
			string text = mySoundDir + "\\SoundList.txt";
			try
			{
				if (File.Exists(text))
				{
					StreamReader streamReader = new StreamReader(text);
					while (streamReader.Peek() >= 0)
					{
						string text2 = streamReader.ReadLine();
						string[] array = text2.Split(new char[]
						{
							','
						});
						if (array.GetUpperBound(0) == 1)
						{
							SoundData soundData = WaveIO.GetSoundData(mySoundDir + "\\" + array[1]);
                            //if (soundData is null)
                            //{
                            //    result = false;
                            //    break;
                            //}
							modSound.SoundDataDict.AddSound(array[0], soundData);
						}
					}
					streamReader.Close();
					result = true;
				}
				else
				{
					MessageBox.Show("Khong thay '" + text + "' khong load duoc.", "Thông báo", MessageBoxButtons.OK);
				}
			}
			catch (Exception expr_B6)
			{
				throw expr_B6;
				MessageBox.Show("Load Truc trac", "Thông báo", MessageBoxButtons.OK);
            }
			return result;
		}
		public static bool populateSoundDataDict()
		{
			modSound.SoundDataDict = new CSoundDataDict();
			return modSound.populateSoundDataDict(modSound.mySoundDir);
		}
		public static FileStream GetSoundStream(string pStr)
		{
			List<string> list = new List<string>();
			string[] array = pStr.Split(new char[]
			{
				' '
			});
			string[] array2 = array;
			checked
			{
				for (int i = 0; i < array2.Length; i++)
				{
					string item = array2[i];
					list.Add(item);
				}
				int count = list.Count;
				if (count > 0)
				{
					string[] array3 = new string[count - 1 + 1];
					int arg_62_0 = 0;
					int num = count - 1;
					for (int j = arg_62_0; j <= num; j++)
					{
						array3[j] = list[j];
					}
					try
					{
						string text = "mysound0.wav";
						modSound.SoundDataDict.NoiSound(array3, text);
						float newTempo = modSound.Tempo;
						int duration = WaveIO.GetDuration(text);
						if ((double)((float)duration / modSound.Tempo) > modSound.DurationMax)
						{
							newTempo = (float)unchecked((double)modSound.Tempo * ((double)((float)duration / modSound.Tempo) / modSound.DurationMax));
						}
						Helper.processWave(text, modSound.fileout, newTempo);
						return new FileStream(modSound.fileout, FileMode.Open, FileAccess.Read);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
                        throw ex;
                    }
				}
				return null;
			}
		}
	}
}