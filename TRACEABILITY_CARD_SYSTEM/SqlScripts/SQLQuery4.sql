/****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM dbo.TRACE_IFS_INTMD_TAB
where (DOP_ID = '451309') --AND (ORDER_NO = 'L145556' OR
                         --ORDER_NO = 'L145699')                    
                        ;

SELECT *
  FROM [dbo].[TARCE_CARD_DET]
  WHERE (DOP_ID = '451309') --AND (ORDER_NO = 'L145556' OR
                         --ORDER_NO = 'L145699')
  order by RECID desc                      
                        ;
                         
                         
SELECT [RECID], [DOP_ID], [CONTRACT], [PART_NO], [DESCRIPTION], [TOT_PEGGED_QTY], [PER_QTY], [BAG_QTY], [REM_QTY], [NOTE_TEXT], [CARD_QTY], [CURRENT_CARD_NO], [OP_EPF_NO], [CREATED], [UPDATED], [PRINTED], [PRINTED_QTY], [BAL_PRINT_QTY], [PRINTED_YN], [TRACE_NO], [CARD_COUNT], [ORDER_NO]
FROM [dbo].[TRACE_CARD_PRNTD_DETAIL]
WHERE [DOP_ID] = '451309';

SELECT  * FROM [dbo].[TARCE_CARD_DET] WHERE [PRINTED_YN] = 'N' AND [DOP_ID] = '451309';

SELECT [DOP_ID], [CONTRACT], [PART_NO], [DESCRIPTION], [PEGGED_QTY] AS TOT_PEGGED_QTY, 0, 0, [PEGGED_QTY] AS REM_QTY, [NOTE_TEXT], 0, 0, GETDATE(), 0, 0, 'N', '', [ORDER_NO], [LINE_NO], [REL_NO]
                            FROM [dbo].[TRACE_IFS_INTMD_TAB]
                            WHERE [DOP_ID] = '451309'
                            --GROUP BY  [DOP_ID],[CONTRACT],[PART_NO],[DESCRIPTION],[NOTE_TEXT]
                            ORDER BY [WANTED_DELIVERY_DATE] ASC;