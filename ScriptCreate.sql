-- public.denemeentity definition

-- Drop table

-- DROP TABLE public.denemeentity;

CREATE TABLE public.denemeentity (
	id uuid NOT NULL,
	kolon1s varchar NULL,
	kolon2s varchar NULL,
	kolon3n int8 NULL,
	kolon4n int8 NULL,
	CONSTRAINT denemeentity_pkey PRIMARY KEY (id)
);


-- public.form definition

-- Drop table

-- DROP TABLE public.form;

CREATE TABLE public.form (
	id uuid NOT NULL,
	formtitle varchar NULL,
	entitytable varchar NULL,
	CONSTRAINT form_pkey PRIMARY KEY (id)
);


-- public.formelement definition

-- Drop table

-- DROP TABLE public.formelement;

CREATE TABLE public.formelement (
	id uuid NOT NULL,
	formref uuid NOT NULL,
	dtypestring varchar NOT NULL,
	"label" varchar NOT NULL,
	fieldname varchar NULL,
	listitems varchar NULL,
	CONSTRAINT formelement_pkey PRIMARY KEY (id)
);


-- public."user" definition

-- Drop table

-- DROP TABLE public."user";

CREATE TABLE public."user" (
	id uuid NOT NULL,
	username varchar(60) NULL,
	passwordhash bytea NULL,
	passwordsalt bytea NULL,
	refreshtoken varchar NULL,
	refreshtokencreatedat timestamptz NULL,
	refreshtokenexpiresat timestamptz NULL,
	credate timestamptz NULL,
	moddate timestamptz NULL,
	"name" varchar NULL,
	surname varchar NULL,
	email varchar NULL,
	phonenumber varchar NULL,
	CONSTRAINT "User_pkey" PRIMARY KEY (id)
);

create table public.work_item_type
(
    id                  integer           not null
        constraint work_item_type_pk
            primary key,
    process_ref         integer default 1 not null,
    work_item_type_name varchar
);

alter table public.work_item_type
    owner to postgres;

create table public.work_item_state
(
    id                   integer not null
        constraint work_item_state_pk
            primary key,
    work_item_type_ref   integer not null
        constraint work_item_state_work_item_type_id_fk
            references public.work_item_type,
    work_item_state_name varchar not null
);

alter table public.work_item_state
    owner to postgres;


create table public.work_item
(
    id                  uuid    not null
        constraint work_item_pk
            primary key,
    work_item_type_ref  integer not null
        constraint work_item_work_item_type_id_fk
            references public.work_item_type,
    work_item_state_ref
	 integer not null
        constraint work_item_work_item_state_id_fk
            references public.work_item_state,
    assignee            uuid,
    title               varchar,
    description         varchar,
    priority            integer
);

alter table public.work_item
    owner to postgres;

