
DROP PROCEDURE IF EXISTS parking_calculate_price;

DELIMITER &&
CREATE PROCEDURE parking_calculate_price( 
	IN p_license_plate VARCHAR(10)
)
BEGIN   
    DECLARE v_end_datetime_parking DATETIME;
    DECLARE v_id_license_plate INT;
    DECLARE v_start_datetime_license_plate DATETIME;
    DECLARE v_first_hour_price FLOAT;
    DECLARE v_extra_hour_price FLOAT;
    DECLARE v_total_parking_time TIME;
    DECLARE v_parking_price FLOAT;
        
    -- Data e hora da saída do estacionamento 
    SET v_end_datetime_parking = NOW();
    
    -- Busca dados da placa do veículo  
    SELECT start_datetime, id 
    INTO v_start_datetime_license_plate, v_id_license_plate 
    FROM t_parking_control
	WHERE license_plate_number = p_license_plate
    AND end_datetime IS NULL;
           
    -- Atualiza registro de estacionamento
    UPDATE t_parking_control
    SET end_datetime = v_end_datetime_parking
	WHERE id = v_id_license_plate;     
	
    -- Busca valores de cadastro de valor por hora de acordo com data da saída do veículo 
    SELECT first_hour_price, extra_hour_price
    INTO v_first_hour_price, v_extra_hour_price
    FROM t_ticket_price
    WHERE v_end_datetime_parking BETWEEN start_date AND end_date;
		
    -- Calcula tempo de permanência no estacionamento
	SET v_total_parking_time = TIMEDIFF(v_end_datetime_parking, v_start_datetime_license_plate);
    
    -- Se permaneceu até 30min, cobra metade do valor de 1h
	IF v_total_parking_time <= '00:30' THEN 
		SET v_parking_price = v_first_hour_price / 2;
	-- Se permaneceu até 01:10, cobra 1h
    ELSEIF v_total_parking_time <= '01:10' THEN 
		SET v_parking_price = v_first_hour_price;
	ELSE 
		-- Se a quantidade de minutos do tempo total no estacionamento for maior que a tolerância
		IF MINUTE(v_total_parking_time) > 10 THEN
			-- Adiciona 1 hora na quantidade de tempo total no estacionamento
            SET v_total_parking_time = DATE_ADD(v_total_parking_time, INTERVAL 1 HOUR);
        END IF;				
	
		SET v_parking_price = v_first_hour_price + (v_extra_hour_price * HOUR(DATE_ADD(v_total_parking_time, INTERVAL -1 HOUR)));
    END IF;        
	
    SELECT v_parking_price;
END &&

