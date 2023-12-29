using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TRACEABILITY_CARD_SYSTEM.Logic
{

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Traceability RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }



        //public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        //{
        //    // Open the file.
        //    FileStream fs = new FileStream(szFileName, FileMode.Open);
        //    // Create a BinaryReader on the file.
        //    BinaryReader br = new BinaryReader(fs);
        //    // Dim an array of bytes big enough to hold the file's contents.
        //    Byte[] bytes = new Byte[fs.Length];
        //    bool bSuccess = false;
        //    // Your unmanaged pointer.
        //    IntPtr pUnmanagedBytes = new IntPtr(0);
        //    int nLength;

        //    nLength = Convert.ToInt32(fs.Length);
        //    // Read the contents of the file into the array.
        //    bytes = br.ReadBytes(nLength);
        //    // Allocate some unmanaged memory for those bytes.
        //    pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
        //    // Copy the managed byte array into the unmanaged array.
        //    Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
        //    // Send the unmanaged bytes to the printer.
        //    bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
        //    // Free the unmanaged memory that you allocated earlier.
        //    Marshal.FreeCoTaskMem(pUnmanagedBytes);
        //    return bSuccess;
        //}


        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            //dwCount = szString.Length;
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }




















    public class Printer
    {

        private string upc, varpartcode, varsize, vartraceno, varqty, varcardno, varorderno, vardopid, varremarks, varoprepf;

        public void Label(string parapartcodein, string parasizein, string paratracenoin, string paraqtyin, string paracardnoin, string paraordernoin, string paradopidin, string pararemarksin, string paraoprepfin)
        {
            if (parapartcodein == null || parasizein == null || paratracenoin == null || paraqtyin == null || paracardnoin == null || paraordernoin == null || paradopidin == null || pararemarksin == null || paraoprepfin == null)
            {
                throw new ArgumentNullException("parapartcodein");
                throw new ArgumentNullException("parasizein");
                throw new ArgumentNullException("paratracenoin");
                throw new ArgumentNullException("paraqtyin");
                throw new ArgumentNullException("paracardnoin");
                throw new ArgumentNullException("paraordernoin");
                throw new ArgumentNullException("paradopidin");
                throw new ArgumentNullException("pararemarksin");
                throw new ArgumentNullException("paraoprepfin");

            }

            else
            {

                this.varpartcode = parapartcodein;
                this.varsize = parasizein;
                this.vartraceno = paratracenoin;
                this.varqty = paraqtyin;
                this.varcardno = paracardnoin;
                this.varorderno = paraordernoin;
                this.vardopid = paradopidin;
                this.varremarks = pararemarksin;
                this.varoprepf = paraoprepfin;



            }
        }

        //static IEnumerable<string> Split(string str, int chunkSize)
        //{
        //    return Enumerable.Range(0, str.Length / chunkSize)
        //        .Select(i => str.Substring(i * chunkSize, chunkSize));
        //}



        //-------string split into same sized chunks---------------------//
        public static string[] Chop(string value, int length)
        {
            int strLength = value.Length;
            int strCount = (strLength + length - 1) / length;
            string[] result = new string[strCount];
            for (int i = 0; i < strCount; ++i)
            {
                result[i] = value.Substring(i * length, Math.Min(length, strLength));
                strLength -= length;
            }
            return result;
        }

        public void Print(string printerName)
        {
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }

            //string[] words = this.varsize.Split(new char[] { ' ' }, 2);

            string[] words = Chop(this.varsize, 28);

            sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("N");
            sb.AppendLine("q508");
            sb.AppendLine("Q356,26");
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,15,0,4,1,1,N,\"{0}\"", this.varpartcode));
            if (words.Count() == 1)
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,50,0,4,1,1,N,\"{0}\"", words[0]));
            }

            else if (words.Count() == 2)
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,50,0,4,1,1,N,\"{0}\"", words[0]));
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,75,0,4,1,1,N,\"{0}\"", words[1]));
               
            }

            else 
            {
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,50,0,4,1,1,N,\"{0}\"", words[0]));
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,75,0,4,1,1,N,\"{0}\"", words[1]));
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,100,0,4,1,1,N,\"{0}\"", words[2]));
            }
            
            //sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,85,0,4,1,1,N,\"{0}{1}\"", "",""));
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,135,0,4,1,1,N,\"{0}{1}\"", "QTY  : ", this.varqty));
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A250,135,0,4,1,1,N,\"{0}{1}\"", "DOPID: ", this.vardopid));
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,170,0,4,1,1,N,\"{0}{1}\"", "ORDER: ", this.varorderno));
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,205,0,4,1,1,N,\"{0}{1}\"", "CARD#: ", this.varcardno));



            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,240,0,2,1,1,N,\"{0}{1}\"", "OPERT: ", this.varoprepf));
            sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "A12,275,0,2,1,1,N,\"{0}{1}\"", "REMRK: ", this.varremarks));
            sb.AppendLine("P1,1");

            RawPrinterHelper.SendStringToPrinter(printerName, sb.ToString());
        }




    }


}
