 -- INSERT INTO [dbo].[TRACE_IFS_INTMD_TAB]
 --   ([DOP_ID]
 --   ,[CONTRACT]
	--,[PART_NO]
	--,[DESCRIPTION]
	--,[ORDER_NO]
	--,[PEGGED_QTY]
	--,[NOTE_TEXT]
 --   ,[LINE_NO]
 --   ,[CATALOG_DESC]
 --   ,[WANTED_DELIVERY_DATE]
 --   ,[LINE_NOTE_TEXT]
 --    ,[REL_NO] 
 --   )
    
    
    SELECT [DHT].[DOP_ID],
    [DHT].[CONTRACT],
    [DHT].[PART_NO],
    [IPT].[DESCRIPTION] AS PART_DESC,
    --[DDCOT].[ORDER_NO],
    --[DDCOT].[PEGGED_QTY],
    [CUOT].[NOTE_TEXT],
    [COLT].[LINE_NO],
    [COLT].[CATALOG_DESC],
    [COLT].[WANTED_DELIVERY_DATE],
    [COLT].[NOTE_TEXT] AS LINE_NOTE_TEXT,
    --[DDCOT].[REL_NO] 
    tbl3.ORDER_NO,
    tbl3.LINE_NO,
    tbl3.REL_NO,
    tbl3.col1
	FROM 
	[IFS_LNKD]..[IFSAPP].[DOP_HEAD_TAB]  DHT
	--INNER JOIN 
	--[IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT
	--ON [DHT].[DOP_ID]=[DDCOT].[DOP_ID]
	
	INNER JOIN
	(
	select 

tbl1.col1,
tbl1.DOP_ID, 
tbl1.ORDER_NO, 
tbl1.LINE_NO,
tbl1.REL_NO,
tbl1.LINE_ITEM_NO,
tbl1.PEGGED_QTY 

from
  (
  select
 RIGHT('0000000000' + CAST([DDCOT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([DDCOT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([DDCOT].[REL_NO],'') as nvarchar(4)),4) 
as col1, 
[DDCOT].[ORDER_NO] as ORDER_NO,
[DDCOT].[DOP_ID] as DOP_ID,
[DDCOT].[LINE_NO] as LINE_NO,
[DDCOT].[REL_NO] as REL_NO,
[DDCOT].[LINE_ITEM_NO] as LINE_ITEM_NO,
[DDCOT].[PEGGED_QTY] as PEGGED_QTY
 from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
  WHERE  --[DDCOT].[CREATE_DATE] >= '2016-04-28 11:28:21.000' --[DDCOT].[DOP_ID] = '442392'
  --and 
  --[DDCOT].[REL_NO] IS NOT NULL
  
  [DDCOT].[DOP_ID] >= '457458'
  ) as tbl1
  
  
  where tbl1.col1 not  in
 
  (
  select tbl2.col2 
  from
  (
  SELECT 
RIGHT('0000000000' + CAST([TIIT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([TIIT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4) 
as col2,
TIIT.WANTED_DELIVERY_DATE
 FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT  
 --order by  TIIT.WANTED_DELIVERY_DATE desc
 WHERE   --TIIT.WANTED_DELIVERY_DATE between '2016-09-01 00:00:00.000' and '2016-09-01 00:00:00.000'
  --[TIIT].[DOP_ID] = '442392'  
  --and [tbl1].col1=[TIIT].
  --and 

--[TIIT].[REL_NO] is not null

--and [TIIT].[ORDER_NO]='Z10134'

TIIT.[DOP_ID] >= '457458'
  ) as tbl2
  )
  ) as tbl3
 

 on tbl3.DOP_ID=[DHT].[DOP_ID]
	
	
	
	
	
	
	
	
	
	
	INNER JOIN 
	[IFS_LNKD]..[IFSAPP].[CUSTOMER_ORDER_TAB]  CUOT
	ON 
	[tbl3].[ORDER_NO]=[CUOT].[ORDER_NO]
	INNER JOIN 
	[IFS_LNKD]..[IFSAPP].[INVENTORY_PART_TAB] IPT
	ON
	[IPT].[PART_NO]=[DHT].[PART_NO]
	INNER JOIN
	[IFS_LNKD]..[IFSAPP].[CUSTOMER_ORDER_LINE_TAB] COLT
	ON
	[tbl3].[ORDER_NO]=[COLT].[ORDER_NO] 
	AND  [COLT].[LINE_NO]=[tbl3].[LINE_NO] 
	AND [COLT].[REL_NO]=[tbl3].[REL_NO] 
	AND [COLT].[LINE_ITEM_NO]=[tbl3].[LINE_ITEM_NO]
	
	

 

	
WHERE 
   --NOT EXISTS (SELECT * FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT
   --           WHERE [DHT].[DOP_ID] = [TIIT].[DOP_ID]
   --           AND
   --           [DDCOT].[ORDER_NO]=[TIIT].[ORDER_NO]
   --           )
   --           AND  
              --[DDCOT].[DOP_ID] = 453421 AND
              --tbl3.DOP_ID  >= '457458'
              --and 
              [DHT].[CONTRACT] = 'SRI' 
              AND [DHT].[ROWSTATE]= 'Released' 
              AND [IPT].[CONTRACT] = 'SRI'
              AND ([DHT].[PART_NO] LIKE '_2%' OR
              [DHT].[PART_NO] LIKE '_7%'
              
              )
              ORDER BY [COLT].[WANTED_DELIVERY_DATE] ASC