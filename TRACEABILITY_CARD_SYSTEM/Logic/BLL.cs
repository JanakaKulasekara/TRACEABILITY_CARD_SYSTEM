using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing.Printing;




namespace TRACEABILITY_CARD_SYSTEM.Logic
{
    public class BLL
    {


        public int InsertToTraceDetails(string paratxtdopidin, string paratracenoin)
        {

            SqlCommand cmdMyQuery = new SqlCommand("usp_SELECT_FROM_IFSINTMDTAB3");
            cmdMyQuery.CommandType = CommandType.StoredProcedure;

            cmdMyQuery.Parameters.Clear();
            cmdMyQuery.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paratxtdopidin.Trim());
            cmdMyQuery.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(paratracenoin.Trim());

            SqlParameter pararetvalueout = cmdMyQuery.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdMyQuery);

            int paraout = Convert.ToInt32(pararetvalueout.Value);

            return paraout;
        }


        public DataTable ShowDataInDGV()
        {

            SqlCommand cmdMyQuery = new SqlCommand("SELECT  [RECID],[DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[BAG_QTY],[REM_QTY],[NOTE_TEXT],[CARD_QTY],[CURRENT_CARD_NO],[OP_EPF_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[BAL_PRINT_QTY],[PRINTED_YN],[TRACE_NO],[ORDER_NO] FROM [dbo].[TARCE_CARD_DET]");
            //cmdMyQuery.Parameters.AddWithValue("@username", "Matt");
            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdMyQuery);

            return dtResults;
        }


        public DataTable ShowDataInDGV(int paradopidin)
        {
            SqlCommand cmdshowdgv = new SqlCommand("SELECT [RECID],[DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[BAG_QTY],[REM_QTY],[NOTE_TEXT],[CARD_QTY],[CURRENT_CARD_NO],[OP_EPF_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[BAL_PRINT_QTY],[PRINTED_YN],[TRACE_NO],[ORDER_NO] FROM [dbo].[TARCE_CARD_DET] WHERE [DOP_ID] = @DOP_ID");
            cmdshowdgv.Parameters.AddWithValue("@DOP_ID", SqlDbType.Int).Value = paradopidin;
            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdshowdgv);

            return dtResults;
        }


        public DataTable ShowDataInDgvChangePeggedQty(int paradopidin)
        {
            SqlCommand cmdshowdgv = new SqlCommand("SELECT [RECID],[DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY] AS CURRENT_PEGGED_QTY,[TOT_PEGGED_QTY] AS NEW_PEGGED_QTY,[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[OP_EPF_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO] FROM [dbo].[TARCE_CARD_DET] WHERE [DOP_ID] = @DOP_ID");
            cmdshowdgv.Parameters.AddWithValue("@DOP_ID", SqlDbType.Int).Value = paradopidin;
            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdshowdgv);

            return dtResults;

        }


        public DataTable ShowDataInReprintTab(int paradopidin)
        {
            SqlCommand cmdshowdgv = new SqlCommand("SELECT [RECID],[DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[BAG_QTY],[REM_QTY],[NOTE_TEXT],[CARD_QTY],[CURRENT_CARD_NO],[OP_EPF_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[BAL_PRINT_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO] FROM [dbo].[TRACE_CARD_PRNTD_DETAIL] WHERE [DOP_ID] = @DOP_ID");
            cmdshowdgv.Parameters.AddWithValue("@DOP_ID", SqlDbType.Int).Value = paradopidin;
            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdshowdgv);

            return dtResults;
        }









        public string GetDefaultPrinter()
        {
            //PrinterSettings settings = new PrinterSettings();
            //foreach (string printer in PrinterSettings.InstalledPrinters)
            //{
            //    settings.PrinterName = printer;
            //    if (settings.IsDefaultPrinter)
            //        return printer;
            //}


            SqlCommand cmdgetdefprnt = new SqlCommand("SELECT [PRINTER_NAME] FROM [dbo].[PRINTERS] WHERE [DEFAULT_FLAG] = 'Y' AND [APP_ID] = 1");
            //cmdgetdefprnt.Parameters.AddWithValue("@DOP_ID", SqlDbType.Int).Value = paradopidin;
            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdgetdefprnt);



            foreach (DataRow row in dtResults.Rows)
            {
                foreach (DataColumn column in dtResults.Columns)
                {
                    string printer = row[column].ToString();
                    return printer;
                }
            }

            return string.Empty;



        }


        public List<String> GetPrinters()
        {
            PrinterSettings settings = new PrinterSettings();
            List<string> printerlist = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                //if (settings.)
                //return printer;
                printerlist.Add(printer);

            }

            return printerlist;
        }


        public void SetPrinters(string paraprinterin)
        {
            SqlCommand cmdsetprinter = new SqlCommand("usp_SET_PRINTERS");
            cmdsetprinter.CommandType = CommandType.StoredProcedure;
            cmdsetprinter.Parameters.Clear();
            cmdsetprinter.Parameters.Add("@PRINTER_NAME", SqlDbType.VarChar, 50).Value = Convert.ToString(paraprinterin).Trim();


            //SqlParameter pararetvalueout = cmdupdperqty.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            //pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdsetprinter);

        }



        private void ClearFields()
        {

        }


        public void UpdatePerQty(int paraperqtyin, int pararecidin)
        {

            SqlCommand cmdupdperqty = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [PER_QTY] = @PER_QTY WHERE [RECID] = @RECID");
            cmdupdperqty.CommandType = CommandType.Text;

            cmdupdperqty.Parameters.Clear();
            cmdupdperqty.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(paraperqtyin);
            cmdupdperqty.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(pararecidin);

            //SqlParameter pararetvalueout = cmdupdperqty.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            //pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdupdperqty);


        }




        public void UpdatePerQty(int paraperqtyin, int pararecidin, string paranotetextin)
        {
            SqlCommand cmdupdperqty = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [PER_QTY] = @PER_QTY, [NOTE_TEXT] = @NOTE_TEXT WHERE [RECID] = @RECID");
            cmdupdperqty.CommandType = CommandType.Text;

            cmdupdperqty.Parameters.Clear();
            cmdupdperqty.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(paraperqtyin);
            cmdupdperqty.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(pararecidin);
            cmdupdperqty.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(paranotetextin.Trim());
            //SqlParameter pararetvalueout = cmdupdperqty.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            //pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdupdperqty);

        }



        public void UpdateReprintFlag(char paraprintedflagin, int pararecidin, int paraperqtyin, string paranotetextin)
        {
            SqlCommand cmdupdrepntflg = new SqlCommand("UPDATE [dbo].[TRACE_CARD_PRNTD_DETAIL] SET [PER_QTY] = @PER_QTY, [NOTE_TEXT] = @NOTE_TEXT, [PRINTED_YN] = @PRINTED_YN WHERE [RECID] = @RECID");
            cmdupdrepntflg.CommandType = CommandType.Text;



            cmdupdrepntflg.Parameters.Clear();
            cmdupdrepntflg.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar(Char.ToUpper(paraprintedflagin));
            cmdupdrepntflg.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(paraperqtyin);
            cmdupdrepntflg.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(paranotetextin.Trim());
            cmdupdrepntflg.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(pararecidin);

            //SqlParameter pararetvalueout = cmdupdperqty.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            //pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdupdrepntflg);

        }




        public void UpdatePeggedQty(int paranewpeggedqtyin, int paraperqtyin, int pararemqtyin, char paraprintedynin, int pararecidin)
        {

            SqlCommand cmdupdperqty = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [TOT_PEGGED_QTY] = @NEW_PEGGED_QTY,[PER_QTY] = @PER_QTY,[REM_QTY] = @REM_QTY,[PRINTED_YN] = @PRINTED_YN WHERE [RECID] = @RECID");
            cmdupdperqty.CommandType = CommandType.Text;

            cmdupdperqty.Parameters.Clear();
            cmdupdperqty.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(paraperqtyin);
            cmdupdperqty.Parameters.Add("@NEW_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(paranewpeggedqtyin);
            cmdupdperqty.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(pararemqtyin);
            cmdupdperqty.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar(paraprintedynin);
            cmdupdperqty.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(pararecidin);

            //SqlParameter pararetvalueout = cmdupdperqty.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            //pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdupdperqty);

        }




        public int FetchDataFromIFS()
        {
            SqlCommand cmdfecthifs = new SqlCommand("usp_INSERT_TO_IFSINTMDTAB2");
            cmdfecthifs.CommandType = CommandType.StoredProcedure;

            cmdfecthifs.Parameters.Clear();
            //cmdMyQuery.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paratxtdopidin.Trim());

            SqlParameter pararetvalueout = cmdfecthifs.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdfecthifs);

            int paraout = Convert.ToInt32(pararetvalueout.Value);

            return paraout;


        }


        public DataTable Test()
        {
            SqlCommand cmdreprintlbl = new SqlCommand("SELECT [DOP_ID] FROM [dbo].[TRACE_CARD_PRNTD_DETAIL] WHERE [PRINTED_YN] = 'Y'");
            cmdreprintlbl.CommandType = CommandType.Text;
            cmdreprintlbl.Parameters.Clear();
            //cmdreprintlbl.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paradopidin);


            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdreprintlbl);

            return dtResults;
        }







        //Reprint of labels/////

        public void RePrintLabels(int paradopidin)
        {

            int varcardqty, varbalcardqty, varcurrcardno, varprintdqty, vardopid, var1, var3, var4, var5 = 0, var6, varrecid, varcardcount;
            double varqty, vartotpeggqty, varremqty, varremqtydecimal, var2;

            char varprintyn;
            string varpartcode, varsize, varorderno, varcontract, vartraceno, varorderno2;

            SqlCommand cmdreprintlbl = new SqlCommand("SELECT  * FROM [dbo].[TRACE_CARD_PRNTD_DETAIL] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = @DOP_ID");
            cmdreprintlbl.CommandType = CommandType.Text;
            cmdreprintlbl.Parameters.Clear();
            cmdreprintlbl.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paradopidin);


            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdreprintlbl);

            foreach (DataRow row in dtResults.Rows)
            {
                varcontract = Convert.ToString(row["CONTRACT"]);
                vardopid = Convert.ToInt32(row["DOP_ID"]);
                //varcardqty = Convert.ToInt32(row["CARD_QTY"]);
                //varbalcardqty = Convert.ToInt32(row["BAL_PRINT_QTY"]);
                varcurrcardno = Convert.ToInt32(row["CURRENT_CARD_NO"]);
                varprintdqty = Convert.ToInt32(row["PRINTED_QTY"]);
                varprintyn = Convert.ToChar(row["PRINTED_YN"]);
                varpartcode = Convert.ToString(row["PART_NO"]);
                varsize = Convert.ToString(row["DESCRIPTION"]);
                varorderno = Convert.ToString(row["NOTE_TEXT"]);
                varqty = Convert.ToDouble(row["PER_QTY"]);
                vartotpeggqty = Convert.ToDouble(row["TOT_PEGGED_QTY"]);
                var1 = Convert.ToInt32(row["PER_QTY"]);
                var3 = Convert.ToInt32(row["REM_QTY"]);
                vartraceno = Convert.ToString(row["TRACE_NO"]).Trim();
                varrecid = Convert.ToInt32(row["RECID"]);
                varorderno2 = Convert.ToString(row["ORDER_NO"]).Trim();
                varcardcount = Convert.ToInt32(row["CARD_COUNT"]);



                //while (var1 < var3)
                //{

                //var5 = var5 + 1;

                Printer objprint = new Printer();
                objprint.Label(varpartcode, varsize, vartraceno, Convert.ToString(var3), Convert.ToString(varprintdqty), varorderno, Convert.ToString(vardopid), "", "");
                objprint.Print(GetDefaultPrinter());


                //SqlCommand cmdinsrtprntd = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT,@ORDER_NO)");
                //cmdinsrtprntd.CommandType = CommandType.Text;

                //cmdinsrtprntd.Parameters.Clear();
                //cmdinsrtprntd.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //cmdinsrtprntd.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmdinsrtprntd.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmdinsrtprntd.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                //cmdinsrtprntd.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                //cmdinsrtprntd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                //cmdinsrtprntd.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                //cmdinsrtprntd.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                //cmdinsrtprntd.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                //cmdinsrtprntd.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                //cmdinsrtprntd.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                //cmdinsrtprntd.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                //cmdinsrtprntd.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);
                //cmdinsrtprntd.Parameters.Add("@ORDER_NO", SqlDbType.VarChar, 10).Value = Convert.ToString(varorderno2).Trim();

                //Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd);






                //var3 = var3 - var1;

                SqlCommand cmd3 = new SqlCommand("UPDATE [dbo].[TRACE_CARD_PRNTD_DETAIL] SET [CARD_COUNT] = @CARD_COUNT, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                cmd3.CommandType = CommandType.Text;

                cmd3.Parameters.Clear();
                cmd3.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmd3.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(varcardcount + 1);
                cmd3.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                //cmd3.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                //cmd3.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                cmd3.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                Database.Dataaccess.ExecuteSQLCommand(cmd3);









                //var3 = var3 - var1;
                //}

                //var5 = var5 + 1;

                //Printer objprint2 = new Printer();
                //objprint2.Label(varpartcode, varsize, vartraceno, Convert.ToString(var3), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                //objprint2.Print(GetDefaultPrinter());


                //SqlCommand cmdinsrtprntd2 = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT,@ORDER_NO)");
                //cmdinsrtprntd2.CommandType = CommandType.Text;

                //cmdinsrtprntd2.Parameters.Clear();
                //cmdinsrtprntd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //cmdinsrtprntd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmdinsrtprntd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmdinsrtprntd2.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                //cmdinsrtprntd2.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                //cmdinsrtprntd2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                //cmdinsrtprntd2.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                //cmdinsrtprntd2.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                //cmdinsrtprntd2.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                //cmdinsrtprntd2.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                //cmdinsrtprntd2.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                //cmdinsrtprntd2.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                //cmdinsrtprntd2.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);
                //cmdinsrtprntd2.Parameters.Add("@ORDER_NO", SqlDbType.VarChar, 10).Value = Convert.ToString(varorderno2).Trim();

                //Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd2);









                //SqlCommand cmd5 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                //cmd5.CommandType = CommandType.Text;

                //cmd5.Parameters.Clear();
                //cmd5.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //cmd5.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmd5.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //cmd5.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                ////cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                //cmd5.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = 0;
                //cmd5.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                //Database.Dataaccess.ExecuteSQLCommand(cmd5);


            }







        }











        public void PrintLabels(int paradopidin)
        {

            int varcardqty, varbalcardqty, varcurrcardno, varprintdqty, vardopid, var1, var3, var4, var5 = 0, var6, varrecid;
            double varqty, vartotpeggqty, varremqty, varremqtydecimal, var2;

            char varprintyn;
            string varpartcode, varsize, varorderno, varcontract, vartraceno;

            SqlCommand cmdMyQuery = new SqlCommand("SELECT  * FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = @DOP_ID");
            cmdMyQuery.CommandType = CommandType.Text;
            cmdMyQuery.Parameters.Clear();
            cmdMyQuery.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paradopidin);




            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdMyQuery);

            foreach (DataRow row in dtResults.Rows)
            {
                varcontract = Convert.ToString(row["CONTRACT"]);
                vardopid = Convert.ToInt32(row["DOP_ID"]);
                varcardqty = Convert.ToInt32(row["CARD_QTY"]);
                varbalcardqty = Convert.ToInt32(row["BAL_PRINT_QTY"]);
                var5 = Convert.ToInt32(row["CURRENT_CARD_NO"]);
                varprintdqty = Convert.ToInt32(row["PRINTED_QTY"]);
                varprintyn = Convert.ToChar(row["PRINTED_YN"]);
                varpartcode = Convert.ToString(row["PART_NO"]);
                varsize = Convert.ToString(row["DESCRIPTION"]);
                varorderno = Convert.ToString(row["NOTE_TEXT"]);
                varqty = Convert.ToDouble(row["PER_QTY"]);
                vartotpeggqty = Convert.ToDouble(row["TOT_PEGGED_QTY"]);
                var1 = Convert.ToInt32(row["PER_QTY"]);
                var3 = Convert.ToInt32(row["REM_QTY"]);
                vartraceno = Convert.ToString(row["TRACE_NO"]).Trim();
                varrecid = Convert.ToInt32(row["RECID"]);

                while (var1 < var3)
                {

                    var5 = var5 + 1;

                    //var5 = varcurrcardno + 1;

                    Printer objprint = new Printer();
                    objprint.Label(varpartcode, varsize, vartraceno, Convert.ToString(var1), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                    objprint.Print(GetDefaultPrinter());


                    SqlCommand cmdinsrtprntd = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT)");
                    cmdinsrtprntd.CommandType = CommandType.Text;

                    cmdinsrtprntd.Parameters.Clear();
                    cmdinsrtprntd.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmdinsrtprntd.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                    cmdinsrtprntd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                    cmdinsrtprntd.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                    cmdinsrtprntd.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                    cmdinsrtprntd.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                    cmdinsrtprntd.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                    cmdinsrtprntd.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                    cmdinsrtprntd.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);




                    Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd);






                    var3 = var3 - var1;

                    SqlCommand cmd3 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                    cmd3.CommandType = CommandType.Text;

                    cmd3.Parameters.Clear();
                    cmd3.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmd3.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmd3.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                    cmd3.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                    cmd3.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                    Database.Dataaccess.ExecuteSQLCommand(cmd3);









                    //var3 = var3 - var1;
                }

                var5 = var5 + 1;

                //var5 = varcurrcardno + 1;

                Printer objprint2 = new Printer();
                objprint2.Label(varpartcode, varsize, vartraceno, Convert.ToString(var3), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                objprint2.Print(GetDefaultPrinter());


                SqlCommand cmdinsrtprntd2 = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT)");
                cmdinsrtprntd2.CommandType = CommandType.Text;

                cmdinsrtprntd2.Parameters.Clear();
                cmdinsrtprntd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmdinsrtprntd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                cmdinsrtprntd2.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                cmdinsrtprntd2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                cmdinsrtprntd2.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                cmdinsrtprntd2.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                cmdinsrtprntd2.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                cmdinsrtprntd2.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                cmdinsrtprntd2.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                cmdinsrtprntd2.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);

                Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd2);









                SqlCommand cmd5 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                cmd5.CommandType = CommandType.Text;

                cmd5.Parameters.Clear();
                cmd5.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmd5.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                cmd5.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = 0;
                cmd5.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                Database.Dataaccess.ExecuteSQLCommand(cmd5);






            }

        }


        public DataTable GetCurrentCardNo(int paradopidin)
        {
            SqlCommand cmdMyQuery = new SqlCommand("SELECT DOP_ID, MAX(CURRENT_CARD_NO) AS MAX_CURRENT_NO FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = @DOP_ID GROUP BY DOP_ID;");
            cmdMyQuery.CommandType = CommandType.Text;
            cmdMyQuery.Parameters.Clear();
            cmdMyQuery.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paradopidin);


            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdMyQuery);
            return dtResults;
        }








        public void PrintLabelsDopWise(int paradopidin)
        {

            int varcardqty, varbalcardqty, varcurrcardno, varprintdqty, vardopid, var1, var3, var4, var5 = 0, var6, varrecid;
            double varqty, vartotpeggqty, varremqty, varremqtydecimal, var2;

            char varprintyn;
            string varpartcode, varsize, varorderno, varcontract, vartraceno, varorderno2;


            DataTable dtres = GetCurrentCardNo(paradopidin);

            foreach (DataRow dtrow in dtres.Rows)
            {
                var5 = Convert.ToInt32(dtrow["MAX_CURRENT_NO"]);
            }





            SqlCommand cmdMyQuery = new SqlCommand("SELECT  * FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = @DOP_ID");
            cmdMyQuery.CommandType = CommandType.Text;
            cmdMyQuery.Parameters.Clear();
            cmdMyQuery.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(paradopidin);


            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdMyQuery);

            foreach (DataRow row in dtResults.Rows)
            {
                varcontract = Convert.ToString(row["CONTRACT"]);
                vardopid = Convert.ToInt32(row["DOP_ID"]);
                varcardqty = Convert.ToInt32(row["CARD_QTY"]);
                varbalcardqty = Convert.ToInt32(row["BAL_PRINT_QTY"]);
                varcurrcardno = Convert.ToInt32(row["CURRENT_CARD_NO"]);
                varprintdqty = Convert.ToInt32(row["PRINTED_QTY"]);
                varprintyn = Convert.ToChar(row["PRINTED_YN"]);
                varpartcode = Convert.ToString(row["PART_NO"]);
                varsize = Convert.ToString(row["DESCRIPTION"]);
                varorderno = Convert.ToString(row["NOTE_TEXT"]);
                varqty = Convert.ToDouble(row["PER_QTY"]);
                vartotpeggqty = Convert.ToDouble(row["TOT_PEGGED_QTY"]);
                var1 = Convert.ToInt32(row["PER_QTY"]);
                var3 = Convert.ToInt32(row["REM_QTY"]);
                vartraceno = Convert.ToString(row["TRACE_NO"]).Trim();
                varrecid = Convert.ToInt32(row["RECID"]);
                varorderno2 = Convert.ToString(row["ORDER_NO"]).Trim();


                while (var1 < var3)
                {

                    var5 = var5 + 1;

                    Printer objprint = new Printer();
                    objprint.Label(varpartcode, varsize, vartraceno, Convert.ToString(var1), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                    objprint.Print(GetDefaultPrinter());


                    SqlCommand cmdinsrtprntd = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT,@ORDER_NO)");
                    cmdinsrtprntd.CommandType = CommandType.Text;

                    cmdinsrtprntd.Parameters.Clear();
                    cmdinsrtprntd.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmdinsrtprntd.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                    cmdinsrtprntd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                    cmdinsrtprntd.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                    cmdinsrtprntd.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                    cmdinsrtprntd.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                    cmdinsrtprntd.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                    cmdinsrtprntd.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                    cmdinsrtprntd.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);
                    cmdinsrtprntd.Parameters.Add("@ORDER_NO", SqlDbType.VarChar, 10).Value = Convert.ToString(varorderno2).Trim();

                    Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd);






                    var3 = var3 - var1;

                    SqlCommand cmd3 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                    cmd3.CommandType = CommandType.Text;

                    cmd3.Parameters.Clear();
                    cmd3.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmd3.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmd3.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                    cmd3.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                    cmd3.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                    Database.Dataaccess.ExecuteSQLCommand(cmd3);









                    //var3 = var3 - var1;
                }

                var5 = var5 + 1;

                Printer objprint2 = new Printer();
                objprint2.Label(varpartcode, varsize, vartraceno, Convert.ToString(var3), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                objprint2.Print(GetDefaultPrinter());


                SqlCommand cmdinsrtprntd2 = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT,@ORDER_NO)");
                cmdinsrtprntd2.CommandType = CommandType.Text;

                cmdinsrtprntd2.Parameters.Clear();
                cmdinsrtprntd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmdinsrtprntd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                cmdinsrtprntd2.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                cmdinsrtprntd2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                cmdinsrtprntd2.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                cmdinsrtprntd2.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                cmdinsrtprntd2.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                cmdinsrtprntd2.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                cmdinsrtprntd2.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                cmdinsrtprntd2.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);
                cmdinsrtprntd2.Parameters.Add("@ORDER_NO", SqlDbType.VarChar, 10).Value = Convert.ToString(varorderno2).Trim();

                Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd2);









                SqlCommand cmd5 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                cmd5.CommandType = CommandType.Text;

                cmd5.Parameters.Clear();
                cmd5.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmd5.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                cmd5.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = 0;
                cmd5.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                Database.Dataaccess.ExecuteSQLCommand(cmd5);


            }

        }






        public void PrintLabels()
        {

            int varcardqty, varbalcardqty, varcurrcardno, varprintdqty, vardopid, var1, var3, var4, var5 = 0, var6, varrecid;
            double varqty, vartotpeggqty, varremqty, varremqtydecimal, var2;

            char varprintyn;
            string varpartcode, varsize, varorderno, varcontract, vartraceno;

            SqlCommand cmdMyQuery = new SqlCommand("SELECT  TOP 1 * FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N'");
            cmdMyQuery.CommandType = CommandType.Text;

            DataTable dtResults = Database.Dataaccess.SQLSelect(cmdMyQuery);

            foreach (DataRow row in dtResults.Rows)
            {
                varcontract = Convert.ToString(row["CONTRACT"]);
                vardopid = Convert.ToInt32(row["DOP_ID"]);
                varcardqty = Convert.ToInt32(row["CARD_QTY"]);
                varbalcardqty = Convert.ToInt32(row["BAL_PRINT_QTY"]);
                varcurrcardno = Convert.ToInt32(row["CURRENT_CARD_NO"]);
                varprintdqty = Convert.ToInt32(row["PRINTED_QTY"]);
                varprintyn = Convert.ToChar(row["PRINTED_YN"]);
                varpartcode = Convert.ToString(row["PART_NO"]);
                varsize = Convert.ToString(row["DESCRIPTION"]);
                varorderno = Convert.ToString(row["NOTE_TEXT"]);
                varqty = Convert.ToDouble(row["PER_QTY"]);
                vartotpeggqty = Convert.ToDouble(row["TOT_PEGGED_QTY"]);
                var1 = Convert.ToInt32(row["PER_QTY"]);
                var3 = Convert.ToInt32(row["REM_QTY"]);
                vartraceno = Convert.ToString(row["TRACE_NO"]).Trim();
                varrecid = Convert.ToInt32(row["RECID"]);

                while (var1 < var3)
                {

                    var5 = var5 + 1;

                    Printer objprint = new Printer();
                    objprint.Label(varpartcode, varsize, vartraceno, Convert.ToString(var1), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                    //objprint.Print(GetDefaultPrinter());


                    SqlCommand cmdinsrtprntd = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT)");
                    cmdinsrtprntd.CommandType = CommandType.Text;

                    cmdinsrtprntd.Parameters.Clear();
                    cmdinsrtprntd.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmdinsrtprntd.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmdinsrtprntd.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                    cmdinsrtprntd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                    cmdinsrtprntd.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                    cmdinsrtprntd.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                    cmdinsrtprntd.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                    cmdinsrtprntd.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                    cmdinsrtprntd.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                    cmdinsrtprntd.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                    cmdinsrtprntd.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);


                    Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd);






                    var3 = var3 - var1;

                    SqlCommand cmd3 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                    cmd3.CommandType = CommandType.Text;

                    cmd3.Parameters.Clear();
                    cmd3.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                    cmd3.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    cmd3.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                    //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                    cmd3.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                    cmd3.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                    Database.Dataaccess.ExecuteSQLCommand(cmd3);









                    //var3 = var3 - var1;
                }

                var5 = var5 + 1;

                Printer objprint2 = new Printer();
                objprint2.Label(varpartcode, varsize, vartraceno, Convert.ToString(var3), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                //objprint2.Print(GetDefaultPrinter());


                SqlCommand cmdinsrtprntd2 = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[REM_QTY],[NOTE_TEXT],[CURRENT_CARD_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT]) VALUES(@DOP_ID,@CONTRACT,@PART_NO,@DESCRIPTION,@TOT_PEGGED_QTY,@PER_QTY,@REM_QTY,@NOTE_TEXT,@CURRENT_CARD_NO,GETDATE(),GETDATE(),GETDATE(),@PRINTED_QTY,@PRINTED_YN,@TRACE_NO,@CARD_COUNT)");
                cmdinsrtprntd2.CommandType = CommandType.Text;

                cmdinsrtprntd2.Parameters.Clear();
                cmdinsrtprntd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmdinsrtprntd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmdinsrtprntd2.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);
                cmdinsrtprntd2.Parameters.Add("@PART_NO", SqlDbType.VarChar, 25).Value = Convert.ToString(varpartcode).Trim();
                cmdinsrtprntd2.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar, 200).Value = Convert.ToString(varsize).Trim();
                cmdinsrtprntd2.Parameters.Add("@NOTE_TEXT", SqlDbType.VarChar, 200).Value = Convert.ToString(varorderno).Trim();
                cmdinsrtprntd2.Parameters.Add("@CONTRACT", SqlDbType.VarChar, 5).Value = Convert.ToString(varcontract).Trim();
                cmdinsrtprntd2.Parameters.Add("@TRACE_NO", SqlDbType.VarChar, 15).Value = Convert.ToString(vartraceno).Trim();
                cmdinsrtprntd2.Parameters.Add("@TOT_PEGGED_QTY", SqlDbType.Int).Value = Convert.ToInt32(vartotpeggqty);
                cmdinsrtprntd2.Parameters.Add("@PER_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);
                cmdinsrtprntd2.Parameters.Add("@PRINTED_YN", SqlDbType.Char).Value = Convert.ToChar('Y');
                cmdinsrtprntd2.Parameters.Add("@CARD_COUNT", SqlDbType.Int).Value = Convert.ToInt32(1);


                Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd2);









                SqlCommand cmd5 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID AND [RECID] = @RECID");
                cmd5.CommandType = CommandType.Text;

                cmd5.Parameters.Clear();
                cmd5.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                cmd5.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                cmd5.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                cmd5.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = 0;
                cmd5.Parameters.Add("@RECID", SqlDbType.Int).Value = Convert.ToInt32(varrecid);

                Database.Dataaccess.ExecuteSQLCommand(cmd5);














                //////////////////////////////--------------//////////////////


                //for (int j = var1; j < var3; j++)
                //{


                //    var5 = var5 + 1;



                //    //Printer objprint = new Printer();
                //    //objprint.Label(varpartcode, varsize, "", Convert.ToString(var1), Convert.ToString(var5), varorderno, Convert.ToString(vardopid), "", "");
                //    //objprint.Print("ZDesigner GT800 (EPL)");





                //    var4 = var3 - var1;

                //    SqlCommand cmd3 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID");
                //    cmd3.CommandType = CommandType.Text;

                //    cmd3.Parameters.Clear();
                //    cmd3.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //    cmd3.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //    cmd3.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //    //cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                //    cmd3.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var4);


                //    Database.Dataaccess.ExecuteSQLCommand(cmd3);

                //    ///////////////////////////////

                //    //SqlCommand cmdinsrtprntd = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CURRENT_CARD_NO],[PRINTED_QTY],[REM_QTY]) VALUES(@DOP_ID,@CURRENT_CARD_NO,@PRINTED_QTY,@REM_QTY)");
                //    //cmdinsrtprntd.CommandType = CommandType.Text;

                //    //cmdinsrtprntd.Parameters.Clear();
                //    //cmdinsrtprntd.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //    //cmdinsrtprntd.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //    //cmdinsrtprntd.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5);
                //    //cmdinsrtprntd.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var1);


                //    //Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd);


                //    ///////////////////////////////

                //    SqlCommand cmdMyQuery2 = new SqlCommand("SELECT  TOP 1 * FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = @DOP_ID ORDER BY [DOP_ID] ASC");
                //    cmdMyQuery2.CommandType = CommandType.Text;
                //    cmdMyQuery2.Parameters.Clear();
                //    cmdMyQuery2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);


                //    DataTable dtResults2 = Database.Dataaccess.SQLSelect(cmdMyQuery2);

                //    foreach (DataRow row2 in dtResults2.Rows)
                //    {
                //        var1 = Convert.ToInt32(row2["PER_QTY"]);
                //        var3 = Convert.ToInt32(row2["REM_QTY"]);

                //    }



                //}


                ////Printer objprint2 = new Printer();
                ////objprint2.Label(varpartcode, varsize, "", Convert.ToString(var3), Convert.ToString(var5 + 1), varorderno, Convert.ToString(vardopid), "", "");
                ////objprint2.Print("ZDesigner GT800 (EPL)");



                ////SqlCommand cmdinsrtprntd2 = new SqlCommand("INSERT INTO [dbo].[TRACE_CARD_PRNTD_DETAIL]([DOP_ID],[CURRENT_CARD_NO],[PRINTED_QTY],[REM_QTY]) VALUES(@DOP_ID,@CURRENT_CARD_NO,@PRINTED_QTY,@REM_QTY)");
                ////cmdinsrtprntd2.CommandType = CommandType.Text;

                ////cmdinsrtprntd2.Parameters.Clear();
                ////cmdinsrtprntd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                ////cmdinsrtprntd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5 + 1);
                ////cmdinsrtprntd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5 + 1);
                ////cmdinsrtprntd2.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = Convert.ToInt32(var3);

                ////Database.Dataaccess.ExecuteSQLCommand(cmdinsrtprntd2);



                ///////////////////////////////



                //SqlCommand cmd5 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [REM_QTY] = @REM_QTY, [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY, [PRINTED_YN] = @PRINTED_YN, [PRINTED] = GETDATE()  WHERE [DOP_ID] = @DOP_ID");
                //cmd5.CommandType = CommandType.Text;

                //cmd5.Parameters.Clear();
                //cmd5.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //cmd5.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(var5 + 1);
                //cmd5.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(var5 + 1);
                //cmd5.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                ////cmd3.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);
                //cmd5.Parameters.Add("@REM_QTY", SqlDbType.Int).Value = 0;


                //Database.Dataaccess.ExecuteSQLCommand(cmd5);







                //for (int i = 1; i <= varcardqty; i++)
                //{


                //    //varremqty = vartotpeggqty / varqty;

                //    //varremqtydecimal = varremqty - Math.Truncate(varremqty);

                //    //var2 = varremqty * varqty;

                //    //if(var2)



                //    SqlCommand cmd2 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [CURRENT_CARD_NO] = @CURRENT_CARD_NO, [PRINTED_QTY] = @PRINTED_QTY,[BAL_PRINT_QTY] = @BAL_PRINT_QTY WHERE [DOP_ID] = @DOP_ID");
                //    cmd2.CommandType = CommandType.Text;

                //    cmd2.Parameters.Clear();
                //    cmd2.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);
                //    cmd2.Parameters.Add("@CURRENT_CARD_NO", SqlDbType.Int).Value = Convert.ToInt32(i);
                //    cmd2.Parameters.Add("@PRINTED_QTY", SqlDbType.Int).Value = Convert.ToInt32(i);
                //    cmd2.Parameters.Add("@BAL_PRINT_QTY", SqlDbType.Int).Value = Convert.ToInt32(varbalcardqty);

                //    Database.Dataaccess.ExecuteSQLCommand(cmd2);

                //    Printer objprint = new Printer();
                //    objprint.Label(varpartcode, varsize, "", Convert.ToString(varqty), Convert.ToString(i), varorderno, Convert.ToString(vardopid), "", "");
                //    objprint.Print("ZDesigner GT800 (EPL)");



                //}

                //SqlCommand cmd4 = new SqlCommand("UPDATE [dbo].[TARCE_CARD_DET] SET [PRINTED_YN] = @PRINTED_YN WHERE [DOP_ID] = @DOP_ID");
                //cmd4.CommandType = CommandType.Text;

                //cmd4.Parameters.Clear();
                //cmd4.Parameters.Add("@PRINTED_YN", SqlDbType.Char, 1).Value = Convert.ToChar('Y');
                //cmd4.Parameters.Add("@DOP_ID", SqlDbType.Int).Value = Convert.ToInt32(vardopid);

                //Database.Dataaccess.ExecuteSQLCommand(cmd4);

            }


        }


        public int ValidateLogin(string parausernamein, string parapassin)
        {
            SqlCommand cmdMyQuery = new SqlCommand("usp_TRACE_VALIDATE_USER");
            cmdMyQuery.CommandType = CommandType.StoredProcedure;

            cmdMyQuery.Parameters.Clear();
            cmdMyQuery.Parameters.Add("@UserId", SqlDbType.NVarChar, 10).Value = Convert.ToString(parausernamein).Trim();
            cmdMyQuery.Parameters.Add("@Password", SqlDbType.NVarChar, 10).Value = Convert.ToString(parapassin).Trim();

            SqlParameter pararetvalueout = cmdMyQuery.Parameters.Add("@RETURN_VAL", SqlDbType.Int);
            pararetvalueout.Direction = ParameterDirection.Output;

            Database.Dataaccess.ExecuteSQLCommand(cmdMyQuery);

            int paraout = Convert.ToInt32(pararetvalueout.Value);

            return paraout;
        }


    }










    public class Worker
    {





    }
}
