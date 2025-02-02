GO
	CREATE PROCEDURE spListar_historia_clinica(@dni_paciente VARCHAR(15))
	AS 
	BEGIN
		SELECT
			hc.diagnostico AS Diagnostico,
			t.fecha_turno AS 'Fecha de consulta'
		FROM 
			historia_clinica hc
		INNER JOIN
			turno t
		ON hc.id_turno = t.id 
		INNER JOIN 
			paciente p
		ON hc.id_paciente = p.id
		WHERE p.dni = @dni_paciente;
	END
GO


GO
	CREATE PROCEDURE spAgendar_turno(
		@id_paciente INT,
		@id_medico INT,
		@fecha_turno DATE,
		@horario_turno TIME,
		@total DECIMAL
	)	 
	AS
		BEGIN
			INSERT INTO turno (id_paciente, id_medico, fecha_turno, horario_turno, total)
			VALUES(@id_paciente,@id_medico, @fecha_turno, @horario_turno, @total);
		END
GO

GO
	CREATE PROCEDURE spFiltrar_pagos(@fecha_inicio DATE, @fecha_fin DATE)
	AS 
	BEGIN
	SELECT CONCAT('Dr.', m.apellido, ', ', m.nombre)
		AS Medico, t.total AS Pago, p.fecha_pago AS 'Fecha de pago'
		FROM pago p
		INNER JOIN turno t 
		ON p.id_turno = t.id
		INNER JOIN medico m 
		ON t.id_medico = m.id
		WHERE fecha_pago BETWEEN @fecha_inicio AND @fecha_fin;
	END
GO
