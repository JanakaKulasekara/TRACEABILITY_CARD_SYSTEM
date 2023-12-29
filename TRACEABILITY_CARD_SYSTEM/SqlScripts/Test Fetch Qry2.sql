

SELECT SUM(PEGGED_QTY) FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT
              WHERE  [TIIT].[DOP_ID] = '451309'
              group by DOP_ID;
              
select [DDCOT].[DOP_ID], SUM(CAST([DDCOT].[PEGGED_QTY] AS FLOAT)) from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
where [DDCOT].[DOP_ID] = '451309'
GROUP BY [DDCOT].[DOP_ID]
;     

SELECT TIIT.* FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] >= '457457'
 
 order by DOP_ID desc
 ;
 
 

 

select [DDCOT].* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
left join
[dbo].[TRACE_IFS_INTMD_TAB] TIIT 
on 
[TIIT].[DOP_ID]= [DDCOT].[DOP_ID] 
where [TIIT].[DOP_ID]= '451309'; 

----------------------------------------------------------------------------------------------------------------
select [DDCOT].* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT where([DDCOT].DOP_ID = '453421')

SELECT TIIT.* FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] = '453421';
-----------------------------------------------------------------------------------------------


select [DDCOT].* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
where (select * from [dbo].[TRACE_IFS_INTMD_TAB] TIIT 
where TIIT.DOP_ID=DDCOT.DOP_ID and 




 )

select [DDCOT].* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
left join
[dbo].[TRACE_IFS_INTMD_TAB] TIIT 
on 
[TIIT].[DOP_ID]= [DDCOT].[DOP_ID]
and 
[TIIT].[ORDER_NO]= [DDCOT].[ORDER_NO] 
where [DDCOT].[DOP_ID]= '451309'; 


 
 SELECT RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4)
 FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] = '451309';
 
 

SELECT   
RIGHT('0000000000' + CAST([TIIT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([TIIT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4)
 FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] >= '457458';
 
 select
 RIGHT('0000000000' + CAST([DDCOT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([DDCOT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([DDCOT].[REL_NO],'') as nvarchar(4)),4)
 from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
  WHERE  [DDCOT].[DOP_ID] >= '457458';
  
 ------------------------------------------------------------------------------
  
  
 
  select tbl1.col1,tbl2.col2 from
  (select
 RIGHT('0000000000' + CAST([DDCOT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([DDCOT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([DDCOT].[REL_NO],'') as nvarchar(4)),4) as col1
 from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
  WHERE  [DDCOT].[DOP_ID] = '450753'
  ) as tbl1
  --where tbl1.col1 not in
  
  
  left join
  
  
  (
  SELECT   
RIGHT('0000000000' + CAST([TIIT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([TIIT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4) as col2
 FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] = '450753'
  ) as tbl2
  
 on tbl1.col1=tbl2.col2
  
  ;
 
 -----------------------------------------------------------------------------------
 
  select tbl1.col1,tbl1.DOP_ID, tbl1.ORDER_NO, tbl1.LINE_NO,tbl1.REL_NO from
  (select
 RIGHT('0000000000' + CAST([DDCOT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([DDCOT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([DDCOT].[REL_NO],'') as nvarchar(4)),4) as col1, 
[DDCOT].[ORDER_NO] as ORDER_NO,
[DDCOT].[DOP_ID] as DOP_ID,
[DDCOT].[LINE_NO] as LINE_NO,
[DDCOT].[REL_NO] as REL_NO 
 from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT 
 WHERE  [DDCOT].[DOP_ID] >= '457458'
  ) as tbl1
  where tbl1.col1 not in
  
  
  --left join
  (
  select tbl2.col2 from
  (
  SELECT   
RIGHT('0000000000' + CAST([TIIT].[ORDER_NO] as nvarchar(10)), 10) +
RIGHT('0000' + CAST([TIIT].[LINE_NO] as nvarchar(4)), 4) +
RIGHT('0000'+ CAST( ISNULL([TIIT].[REL_NO],'') as nvarchar(4)),4) as col2
 FROM [dbo].[TRACE_IFS_INTMD_TAB] TIIT       
 WHERE  [TIIT].[DOP_ID] >= '457458'
 --TIIT.WANTED_DELIVERY_DATE>='2016-11-28 00:00:00.000'
  ) as tbl2

 --on tbl1.col1=tbl2.col2
 
 --where tbl1.DOP_ID='451304'

  )
  ;
 
 
 
 
 
 
 
