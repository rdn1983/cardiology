CREATE FUNCTION dmtrg_f_modify_date () 
RETURNS trigger 
LANGUAGE 'plpgsql'
AS $$
BEGIN
NEW.r_modify_date=now();
return NEW;
END;
$$;