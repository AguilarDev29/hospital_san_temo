GO
	CREATE TRIGGER tgIngresar_pago
		ON turno
	AFTER INSERT
	AS 
	BEGIN
		DECLARE @id_turno INT;
		SELECT @id_turno = id FROM inserted;
		INSERT INTO pago (id_turno) VALUES (@id_turno);
	END

GO
	CREATE TRIGGER tgCrear_usuario_medico
	ON medico
	AFTER INSERT
	AS 
	BEGIN
		DECLARE @dni_paciente VARCHAR(15);
		SELECT @dni_paciente = dni FROM inserted;
		INSERT INTO usuario (usuario, clave, rol)
		VALUES (@dni_paciente, @dni_paciente, 'MEDICO');
	END