select 

tbl1.col1,
tbl1.DOP_ID, 
tbl1.ORDER_NO, 
tbl1.LINE_NO,
tbl1.REL_NO 

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
[DDCOT].[REL_NO] as REL_NO 
 from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
  --WHERE  [DDCOT].[CREATE_DATE] >= '2016-04-28 11:28:21.000' --[DDCOT].[DOP_ID] = '442392'
  --and 
  --[DDCOT].[REL_NO] IS NOT NULL
  
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
 --WHERE   --TIIT.WANTED_DELIVERY_DATE between '2016-09-01 00:00:00.000' and '2016-09-01 00:00:00.000'
  --[TIIT].[DOP_ID] = '442392'  
  --and [tbl1].col1=[TIIT].
  --and 

--[TIIT].[REL_NO] is not null

--and [TIIT].[ORDER_NO]='Z10134'
  ) as tbl2
  )
  ;
 

 
 
