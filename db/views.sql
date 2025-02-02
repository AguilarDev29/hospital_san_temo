GO
	CREATE VIEW vista_turnos_pendientes AS
	SELECT 
		CONCAT(p.apellido, ', ', p.nombre) AS Paciente,
		CONCAT('Dr. ', m.apellido,', ', m.nombre) AS Medico,
		t.fecha_turno AS 'Fecha de Turno',
		t.horario_turno AS 'Horario de Turno',
		t.atendido AS Atendido
	FROM 
		turno t
	INNER JOIN 
		paciente P ON t.id_paciente = p.id
	INNER JOIN 
		medico M ON t.id_medico = m.id
	WHERE t.atendido = 'NO';

	
GO
	CREATE VIEW vista_pacientes AS 
	SELECT 
		p.apellido AS Apellido,
		p.nombre AS Nombre,
		p.dni AS 'DNI',
		p.sexo AS Sexo,
		p.fecha_nac AS 'Fecha de nacimiento',
		p.direccion AS 'Dirección',
		p.localidad AS Localidad,
		p.telefono AS 'Teléfono',
		p.email AS Email,
		os.nombre AS 'Obra Social'
	FROM 
		paciente p
	LEFT JOIN 
		obra_social os ON p.id_obra_social = os.id
	WHERE p.activo = 1;

GO
	CREATE VIEW vista_medicos AS
	SELECT 
    m.apellido AS Apellido,
    m.nombre AS Nombre,
    m.dni AS 'DNI',
    m.sexo AS Sexo,
    m.telefono AS 'Teléfono',
    m.email AS Email,
    e.nombre AS Especialidad,
    CONCAT('$', CAST(m.plus AS VARCHAR)) AS Plus
	FROM 
		medico M
	INNER JOIN 
		especialidad e ON m.id_especialidad = e.id
	WHERE 
		m.activo = 1;
