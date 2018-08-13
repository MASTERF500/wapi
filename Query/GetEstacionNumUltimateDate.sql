select max(fecha) as fecha,numero,prec,tmax,tmin,tmed,velvmax,velv,dirvvmax,dirv,radg,humr,et,ep,porc 
from estado1
where numero=22



select numero,fecha, prec, temt, dirv, velv,radg,humr,humh,eto 
from estado1 where numero=2 and fecha=(select max(fecha) from estado1 where numero=2)

