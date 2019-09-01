CREATE OR REPLACE FUNCTION analysis_modify_history_fct() 
RETURNS TRIGGER 
language 'plpgsql' 
as $$ 
BEGIN 
	UPDATE ddt_history SET dsdt_operation_date=NEW.dsdt_analysis_date WHERE dsid_operation_id=NEW.r_object_id; 
return new; end; $$;