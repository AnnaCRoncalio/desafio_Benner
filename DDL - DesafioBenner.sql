
CREATE DATABASE benner_parking_control;

-- DROP TABLE  t_parking_control;

CREATE TABLE t_parking_control (
	id INT AUTO_INCREMENT,
    license_plate_number VARCHAR(10) NOT NULL,
    start_datetime DATETIME DEFAULT NOW() NOT NULL,
    end_datetime DATETIME,
    PRIMARY KEY (id, license_plate_number, start_datetime)
);

CREATE TABLE t_ticket_price (
	start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    first_hour_price FLOAT NOT NULL,
    extra_hour_price FLOAT NOT NULL,
    PRIMARY KEY (start_date, end_date)
);
    