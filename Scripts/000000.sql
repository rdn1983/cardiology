CREATE or REPLACE FUNCTION GetNextId()
  RETURNS character varying
LANGUAGE 'plpgsql'
AS $$
declare
  str text :=  '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
  val int;
  id_ text;
  mod int;
begin
  val:=nextval('dmi_id_sequence');
  id_:='';
  while (length(id_) < 16) loop
    mod = val % 62;
    id_:=substring(str,mod+1,1)||id_;
    val = val / 62;
  end loop;
  return id_;
  return 'null';
end;
$$