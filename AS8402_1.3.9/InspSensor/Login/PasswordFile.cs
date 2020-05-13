using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspSensor.Login
{
    public class PasswordFile
    {
        private string mFilename;
        private bool mFound;
        private bool mIsValid;
        private StringDictionary mDefaultPasswords;
        private StringDictionary mLoadedPasswords;
        public PasswordFile(string fname)
        {
            mFilename = fname;
            mFound = false;
            mIsValid = false;
            mDefaultPasswords = new StringDictionary();
            mLoadedPasswords = new StringDictionary();

            // look for file & validate & load passwords
            if (File.Exists(mFilename))
            {
                mFound = true;
                ReadPasswordFile();
            }
        }
        private void ReadPasswordFile()
        {
            mIsValid = false;
            mLoadedPasswords.Clear();

            StringDictionary filePasswords = new StringDictionary();

            // read _filename and fill _loadedPasswords
            ArrayList fileLines = new ArrayList();
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(mFilename))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        fileLines.Add(line);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

            // first line is "Version x"
            if (fileLines.Count < 1)
                return;
            line = (string)fileLines[0];
            if (!line.StartsWith("Version "))
                return;
            line = line.Substring(8);

            int ver = -1;
            try
            {
                ver = int.Parse(line);
            }
            catch (Exception) { return; }

            // only version 1 supported at this time
            if (ver != 1)
                return;

            // next lines are password lines
            for (int i = 1; i < fileLines.Count; ++i)
            {
                // line to bytes
                byte[] bytes;
                if (!ExtractBytesFromString((string)fileLines[i], out bytes))
                    return;

                // doxor
                this.DoXOrDecode(bytes);

                // decode accesslevel & password
                AccessLevel level;
                string pass;
                if (!this.Decode(bytes, out level, out pass))
                    return;

                // put in table
                filePasswords.Add(level.ToString(), pass);
            }

            mIsValid = true;
            this.mLoadedPasswords = filePasswords;
        }
        private bool ExtractBytesFromString(string str, out byte[] bytes)
        {
            try
            {
                bytes = new byte[str.Length / 2];

                for (int i = 0; i < str.Length; i += 2)
                {
                    string bstr = str.Substring(i, 2);
                    bytes[i / 2] = byte.Parse(bstr, System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception)
            {
                bytes = null;
                return false;
            }

            return true;
        }
        private bool Decode(byte[] bytes, out AccessLevel level, out string pass)
        {
            string accessLevelString;
            pass = "";
            level = AccessLevel.Operator;

            int i = 0;
            if (!RemoveString(bytes, ref i, out accessLevelString))
                return false;
            if (!RemoveString(bytes, ref i, out pass))
                return false;

            try
            {
                object obj = Enum.Parse(typeof(AccessLevel), accessLevelString, true);
                level = (AccessLevel)obj;
            }
            catch (Exception) { return false; }

            return true;
        }
        private void DoXOrDecode(byte[] bytes)
        {
            byte xor = 0x3c;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte encodedval = bytes[i];
                bytes[i] = (byte)(bytes[i] ^ xor);
                xor += encodedval;
            }
        }
        private bool RemoveString(byte[] bytes, ref int i, out string s)
        {
            s = "";
            while (i < bytes.Length)
            {
                byte low = bytes[i];
                ++i;
                byte high = bytes[i];
                ++i;

                UInt16 val = (UInt16)((high << 8) + low);
                if (val == 0)
                    return true;

                s += (char)val;
            }

            return false;
        }
    }
}
