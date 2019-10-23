using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CLDomaci3
{
    public class Class1:Interface1
    {
        public string sadrzaj;
        public string putanja;

        public string Read(string putanja)
        {
            try
            {
                StreamReader sr = new StreamReader(putanja);
                sadrzaj = sr.ReadToEnd();
                sr.Close();
                return sadrzaj;
            }
            catch(Exception ex)
            {
                string opisGreske = ex.ToString();
                return opisGreske;
            }
        }

        public bool Save(string sadrzaj, string putanja)
        {
            try
            {
                StreamWriter sw = new StreamWriter(putanja);
                sw.Write(sadrzaj);
                sw.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
