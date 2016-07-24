using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Ostara {
	class IniReader {
		[DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileIntA", CharSet = CharSet.Ansi)]
		static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
		[DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]
		static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
		[DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi)]
		static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
		[DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileSectionNamesA", CharSet = CharSet.Ansi)]
		static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);
		[DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileSectionA", CharSet = CharSet.Ansi)]
		static extern int WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

		readonly string filename;
		string _section;
		const int MAX_ENTRY = 32768;

		public IniReader(string file) {
			filename = $"{Directory.GetCurrentDirectory()}\\{file}";
		}

		public void Select(string section) {
			_section = section;
		}

		public int ReadInt32(string key, int defVal = 0)
			=> GetPrivateProfileInt(_section, key, defVal, filename);

		public string ReadString(string key, string defVal = "") {
			var sb = new StringBuilder(MAX_ENTRY);
			GetPrivateProfileString(_section, key, defVal, sb, MAX_ENTRY, filename);

			return sb.ToString();
		}

		public long ReadInt64(string key, long defVal = 0)
			=> long.Parse(ReadString(key, defVal.ToString()));

		public byte[] ReadByteArray(string key) {
			try {
				return Convert.FromBase64String(ReadString(_section, key));
			} catch { }

			return null;
		}

		public bool ReadBoolean(string key, bool defVal = false)
			=> bool.Parse(ReadString(key, defVal.ToString()));

		public ArrayList GetSectionNames() {
			try {
				var buf = new byte[MAX_ENTRY];
				GetPrivateProfileSectionNames(buf, MAX_ENTRY, filename);
				string[] parts = Encoding.ASCII.GetString(buf).Trim('\0').Split('\0');

				return new ArrayList(parts);
			} catch { }

			return null;
		}
	}
}