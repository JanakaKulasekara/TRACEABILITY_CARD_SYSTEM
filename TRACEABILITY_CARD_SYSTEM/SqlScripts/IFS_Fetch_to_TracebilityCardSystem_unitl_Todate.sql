 ------------------- NEW QUERY TO FETCH IFS TO TIIT TABLE---------------------------------

 
   INSERT INTO [dbo].[TRACE_IFS_INTMD_TAB]
    ([DOP_ID]
    ,[CONTRACT]
	,[PART_NO]
	,[DESCRIPTION]
	,[ORDER_NO]
	,[PEGGED_QTY]
	,[NOTE_TEXT]
    ,[LINE_NO]
    ,[CATALOG_DESC]
    ,[WANTED_DELIVERY_DATE]
    ,[LINE_NOTE_TEXT]
     ,[REL_NO] 
    )
 
 SELECT tt.DDCOTDOP_ID, 
 tt.DHTCONTRACT, 
 tt.DHTPART_NO, 
 tt.IPTDESCRIPTION, 
 tt.DDCOTORDER_NO, 
 tt.DDCOTPEGGED_QTY, 
 tt.CUOTNote_Text, 
 tt.DDCOTLINE_NO, 
 tt.COLTCATALOG_DESC, 
 tt.COLTWANTED_DELIVERY_DATE, 
 tt.COLTLINE_NOTE_TEXT, 
 tt.DDCOTREL_NO
   
FROM
    (
     SELECT tblDerived.*
     FROM
         (
          SELECT DHT.DOP_ID AS DHTDOP_ID, DHT.CONTRACT AS DHTCONTRACT, DHT.PART_NO AS DHTPART_NO, IPT.DESCRIPTION AS IPTDESCRIPTION, DHT.CREATE_DATE AS DHTCREATE_DATE, DHT.LAST_ACTIVITY_DATE AS DHTLAST_ACTIVITY_DATE, DDCOT.DOP_ID AS DDCOTDOP_ID, DDCOT.ORDER_NO AS DDCOTORDER_NO, DDCOT.LINE_NO AS DDCOTLINE_NO, DDCOT.REL_NO AS DDCOTREL_NO, DDCOT.PEGGED_QTY AS DDCOTPEGGED_QTY, COLT.ORDER_NO AS COLTORDER_NO, COLT.LINE_NO AS COLTLINE_NO, COLT.REL_NO AS COLTREL_NO, COLT.CONTRACT AS COLTCONTRACT, COLT.CATALOG_DESC AS COLTCATALOG_DESC, COLT.WANTED_DELIVERY_DATE AS COLTWANTED_DELIVERY_DATE, COLT.NOTE_TEXT AS COLTLINE_NOTE_TEXT, CUOT.Note_Text AS CUOTNote_Text
          --,RIGHT('0000000000'+CAST([DDCOT].[ORDER_NO] AS NVARCHAR(10)), 10)+RIGHT('0000'+CAST([DDCOT].[LINE_NO] AS NVARCHAR(4)), 4)+RIGHT('0000'+CAST(ISNULL([DDCOT].[REL_NO], '') AS NVARCHAR(4)), 4) AS col1
          FROM [IFS_LNKD]..[IFSAPP].[DOP_HEAD_TAB] DHT
               INNER JOIN [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB] DDCOT ON DDCOT.DOP_ID = DHT.DOP_ID
               INNER JOIN [IFS_LNKD]..[IFSAPP].[CUSTOMER_ORDER_LINE_TAB] COLT ON COLT.ORDER_NO = DDCOT.ORDER_NO
                                                                                 AND COLT.LINE_NO = DDCOT.Line_No
                                                                                 AND COLT.Rel_No = DDCOT.Rel_No
                                                                                 AND COLT.Line_Item_No = DDCOT.Line_Item_No
               INNER JOIN [IFS_LNKD]..[IFSAPP].[CUSTOMER_ORDER_TAB] CUOT ON CUOT.ORDER_NO = COLT.ORDER_NO
                                                                            AND CUOT.[CONTRACT] = COLT.[Contract]
               INNER JOIN [IFS_LNKD]..[IFSAPP].[INVENTORY_PART_TAB] IPT ON [IPT].[PART_NO] = [DHT].[PART_NO]
                                                                           AND [IPT].[CONTRACT] = [DHT].[CONTRACT]
          WHERE DHT.CONTRACT = 'SRI'
                AND [IPT].[CONTRACT] = 'SRI'
                AND DHT.ROWSTATE = 'Released'
                AND (DHT.PART_NO LIKE '_2%'
                     OR DHT.PART_NO LIKE '_7%'
                    )
          --ORDER BY DHT.DOP_ID DESC
              
         ) AS tblDerived
    ) AS tt
WHERE --tt.col1 
NOT EXISTS
          (
  
--(
SELECT 
--RIGHT('0000000000'+CAST([TIIT].[ORDER_NO] AS NVARCHAR(10)
--                              ), 10)+RIGHT('0000'+CAST([TIIT].[LINE_NO] AS NVARCHAR(4)
--                                                      ), 4)+RIGHT('0000'+CAST(ISNULL([TIIT].[REL_NO], '') AS NVARCHAR(4)
--                                                                             ), 4) AS col2
TIIT.*
FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT 
--) as TIIT2
WHERE TIIT.DOP_ID = tt.DDCOTDOP_ID
      AND TIIT.ORDER_NO = tt.DDCOTORDER_NO
      AND TIIT.LINE_NO = tt.DDCOTLINE_NO
      AND TIIT.REL_NO = tt.DDCOTREL_NO
          ) 
--  left join
--  (SELECT 
--RIGHT('0000000000' + CAST([TIIT].[ORDER_NO] as nvarchar(10)), 10) +
--RIGHT('0000' + CAST([TIIT].[LINE_NO] as nvarchar(4)), 4) +
--RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4) 
--as col2,
--TIIT.*
-- FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT 
--  ) as TIIT2
--  on
--  TIIT2.CONTRACT=tt.DHTCONTRACT  
--and TIIT2.DOP_ID=tt.DDCOTDOP_ID
--and TIIT2.ORDER_NO=DDCOTORDER_NO
--and TIIT2.LINE_NO=tt.DDCOTLINE_NO
--and TIIT2.REL_NO=tt.DDCOTREL_NO  
--where 
--AND tt.DHTDOP_ID >= CAST('451309' AS INT
--                        )
ORDER BY tt.DHTDOP_ID DESC;