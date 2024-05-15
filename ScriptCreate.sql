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

create table public.workitemtype
(
    id                  integer           not null
        constraint workitemtypepk
            primary key,
    processref         integer default 1 not null,
    workitemtypename varchar
);

alter table public.workitemtype
    owner to postgres;

create table public.workitemstate
(
    id                   integer not null
        constraint workitemstatepk
            primary key,
    workitemtyperef   integer not null
        constraint workitemstateworkitemtypeidfk
            references public.workitemtype,
    workitemstatename varchar not null
);

alter table public.workitemstate
    owner to postgres;


create table public.workitem
(
    id                  uuid    not null
        constraint workitempk
            primary key,
    workitemtyperef  integer not null
        constraint workitemworkitemtypeidfk
            references public.workitemtype,
    workitemstateref
	 integer not null
        constraint workitemworkitemstateidfk
            references public.workitemstate,
    assignee            uuid,
    title               varchar,
    description         varchar,
    priority            integer
);

alter table public.workitem
    owner to postgres;

