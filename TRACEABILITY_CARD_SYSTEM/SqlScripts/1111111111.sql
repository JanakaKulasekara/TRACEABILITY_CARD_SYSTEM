select DHT.DOP_ID,DHT.CONTRACT,DHT.PART_NO,DHT.DESCRIPTION,DHT.CREATE_DATE,DHT.LAST_ACTIVITY_DATE,DDCOT.*,COT.Note_Text,COLT.ORDER_NO,COLT.LINE_NO,COLT.REL_NO,COLT.CONTRACT
from DOP_HEAD_TAB DHT
inner join
DOP_DEMAND_CUST_ORD_TAB DDCOT
on
DDCOT.DOP_ID=DHT.DOP_ID
inner join
CUSTOMER_ORDER_LINE_TAB COLT
on
COLT.ORDER_NO=DDCOT.ORDER_NO
and COLT.LINE_NO=DDCOT.Line_No
and COLT.Rel_No=DDCOT.Rel_No
and COLT.Line_Item_No=DDCOT.Line_Item_No
inner join
CUSTOMER_ORDER_TAB COT
on
COT.ORDER_NO=COLT.ORDER_NO
and
COT.CONTRACT=COLT.Contract

where DHT.CONTRACT = 'SRI' 
              AND DHT.ROWSTATE= 'Released' 
              AND (DHT.PART_NO LIKE '_2%' OR
              DHT.PART_NO LIKE '_7%')
              ORDER BY DHT.DOP_ID DESC;
              
              
select DDCOT.* from DOP_DEMAND_CUST_ORD_TAB DDCOT
;

select COT.* from CUSTOMER_ORDER_TAB COT where  order_no='E10011';
/*inner join
CUSTOMER_ORDER_LINE_TAB COLT
on COT.ORDER_NO=COLT.ORDER_NO
and COT.*\
*/
select COLT.* from CUSTOMER_ORDER_LINE_TAB COLT where  order_no='E10011';              
              