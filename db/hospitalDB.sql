create table tb_cid10
(
	cid varchar(4) not null
		constraint tb_cid10_pkey
			primary key,
	classif "char",
	restrsexo "char",
	causaobto "char",
	decricao varchar(300) not null,
	descrabrev varchar(150) not null,
	refer varchar(40),
	excluidos varchar(14)
);

alter table tb_cid10 owner to postgres;

create table tb_medicos
(
	crm varchar(13) not null
		constraint crm
			primary key,
	nome varchar(150) not null
);

alter table tb_medicos owner to postgres;

create table tb_docentes
(
	crm_medico varchar(13) not null
		constraint tb_docentes_pkey
			primary key
		constraint tb_docentes_crm_medico_fkey
			references tb_medicos,
	titulacao varchar(20) not null
);

alter table tb_docentes owner to postgres;

create table tb_pacientes
(
	id integer not null
		constraint tb_pacientes_pkey
			primary key,
	nome varchar(150) not null,
	sexo "char" not null,
	cor varchar(25),
	dt_nasc date not null
);

alter table tb_pacientes owner to postgres;

create table tb_pedido_exames
(
	id integer not null
		constraint tb_pedido_exames_pkey
			primary key,
	crm_medico varchar(13) not null
		constraint tb_pedido_exames_crm_medico_fkey
			references tb_medicos,
	nome_exame varchar(35) not null,
	data_prevista date not null,
	hipotese_diag_cid varchar(4) not null
		constraint tb_pedido_exames_hipotese_diag_cid_fkey
			references tb_cid10,
	recomendacao varchar(650) not null
);

alter table tb_pedido_exames owner to postgres;

create table tb_residentes
(
	crm_medico varchar(13) not null
		constraint tb_residentes_pkey
			primary key
		constraint tb_residentes_crm_medico_fkey
			references tb_medicos,
	ano_inicio date not null
);

alter table tb_residentes owner to postgres;

create table tb_exames
(
	id integer not null
		constraint tb_exames_pkey
			primary key,
	crm_med_resid varchar(13) not null
		constraint tb_exames_crm_med_resid_fkey
			references tb_residentes,
	link_pdf varchar(350),
	data_hora date not null,
	id_pedido_exame integer not null
);

alter table tb_exames owner to postgres;

create table tb_laudos
(
	id_exame integer not null
		constraint tb_laudos_pkey
			primary key
		constraint tb_laudos_id_exame_fkey
			references tb_exames,
	crm_med_resid varchar(13) not null
		constraint tb_laudos_crm_med_resid_fkey
			references tb_residentes,
	descricao text not null,
	conclusao text not null
);

alter table tb_laudos owner to postgres;

create table tb_laudo_status
(
	id_exame_laudo integer not null
		constraint tb_laudo_status_pkey
			primary key
		constraint tb_laudo_status_id_exame_laudo_fkey
			references tb_laudos,
	status boolean default false not null,
	crm_med_doc varchar(13) not null
		constraint tb_laudo_status_crm_med_doc_fkey
			references tb_docentes
);

comment on column tb_laudo_status.crm_med_doc is 'CRM do médico docente';

alter table tb_laudo_status owner to postgres;

