/****** Script for SelectTopNRows command from SSMS  ******/


  
  select ddcott.* 
  from dbo.DOP_DEMAND_CUST_ORD_TAB_Test ddcott
  where ddcott.DERIVED_COL not  in(
  SELECT  tiitt.[DERIVED_COL]
  FROM [dbo].[TRACE_IFS_INTMD_TAB_Test] tiitt
  where tiitt.DERIVED_COL is not null
  )
  
 
  
  ;
  
  select ddcott.*,tiitt.* 
  from dbo.DOP_DEMAND_CUST_ORD_TAB_Test ddcott
  left join
  [dbo].[TRACE_IFS_INTMD_TAB_Test] tiitt
  on ddcott.DERIVED_COL=tiitt.DERIVED_COL;
  
  
  
  select DDCOT.* from [IFS_LNKD]..[IFSAPP].[DOP_DEMAND_CUST_ORD_TAB]  DDCOT
  where DDCOT.CREATE_DATE between '2016-09-01 00:00:00.000' and '2016-09-30 00:00:00.000'
  --and 
  --DDCOT.dop_id='451309'
  --DDCOT.REL_NO>'1'
  order by DDCOT.DOP_ID DESC
  ;
  
  
  select * from dbo.TRACE_IFS_INTMD_TAB
--where DOP_ID in ('7564',
--'7565',
--'8716',
--'7590',
--'7591',
--'6276')
order by --WANTED_DELIVERY_DATE desc;
dop_id desc;


