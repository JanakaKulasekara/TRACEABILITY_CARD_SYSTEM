/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TIIT.*
  FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT
  where  not exists(
  
  select TCD.* from
  [dbo].[TARCE_CARD_DET] TCD
 where
  TIIT.DOP_ID=TCD.DOP_ID
  and TIIT.ORDER_NO=TCD.ORDER_NO
  and TIIT.LINE_NO=TCD.LINE_NO
  and TIIT.REL_NO=TCD.REL_NO
  )
  and TIIT.DOP_ID='451221'
    order by TIIT.DOP_ID desc
  ;
  
  
  
  SELECT *
  FROM [dbo].[TARCE_CARD_DET]
  WHERE (DOP_ID = '451221') --AND (ORDER_NO = 'L145556' OR
                         --ORDER_NO = 'L145699')
  order by RECID desc                      
                        ;
  
  
  SELECT [RECID],[DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[TOT_PEGGED_QTY],[PER_QTY],[BAG_QTY],[REM_QTY],[NOTE_TEXT],[CARD_QTY],[CURRENT_CARD_NO],[OP_EPF_NO],[CREATED],[UPDATED],[PRINTED],[PRINTED_QTY],[BAL_PRINT_QTY],[PRINTED_YN],[TRACE_NO],[CARD_COUNT],[ORDER_NO] FROM [dbo].[TRACE_CARD_PRNTD_DETAIL] WHERE [DOP_ID] = '451221';
  
  
  select [DDCOT].* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT where [DDCOT].[DOP_ID]='451221';
  