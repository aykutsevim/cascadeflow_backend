create table public.denemeentity
(
    id      uuid not null
        primary key,
    kolon1s varchar,
    kolon2s varchar,
    kolon3n bigint,
    kolon4n bigint
);

alter table public.denemeentity
    owner to postgres;

create table public.form
(
    id          uuid not null
        primary key,
    formtitle   varchar,
    entitytable varchar
);

alter table public.form
    owner to postgres;

create table public.formelement
(
    id          uuid    not null
        primary key,
    formref     uuid    not null,
    dtypestring varchar not null,
    label       varchar not null,
    fieldname   varchar,
    listitems   varchar
);

alter table public.formelement
    owner to postgres;

create table public.workitemtype
(
    id               integer           not null
        constraint workitemtypepk
            primary key,
    processref       integer default 1 not null,
    workitemtypename varchar
);

alter table public.workitemtype
    owner to postgres;

create table public.workitemstate
(
    id                integer not null
        constraint workitemstatepk
            primary key,
    workitemtyperef   integer not null
        constraint workitemstateworkitemtypeidfk
            references public.workitemtype,
    workitemstatename varchar not null
);

alter table public.workitemstate
    owner to postgres;

create table public.tenant
(
    id         uuid    not null
        constraint tenant_pk
            primary key,
    tenantname varchar not null
);

alter table public.tenant
    owner to postgres;

create table "user"
(
    id                    uuid not null
        constraint "User_pkey"
            primary key,
    username              varchar(60),
    passwordhash          bytea,
    passwordsalt          bytea,
    refreshtoken          varchar,
    refreshtokencreatedat timestamp with time zone,
    refreshtokenexpiresat timestamp with time zone,
    credate               timestamp with time zone,
    moddate               timestamp with time zone,
    name                  varchar,
    surname               varchar,
    email                 varchar,
    phonenumber           varchar,
    tenantref             uuid not null
        constraint user_tenant_id_fk
            references tenant,
    avatarhashable        uuid not null
);

alter table "user"
    owner to postgres;



create table project
(
    id                uuid    not null
        constraint project_pk
            primary key,
    projectname       varchar not null,
    tenantref         uuid    not null
        constraint project_tenant_id_fk
            references tenant,
    identiconhashable uuid    not null
);

alter table project
    owner to postgres;

CREATE OR REPLACE FUNCTION update_workitem_code() RETURNS TRIGGER AS $$
BEGIN
    -- Check the maximum code for the current projectref
    SELECT COALESCE(MAX(code), 0) + 1 INTO NEW.code FROM workitem
    WHERE projectref = NEW.projectref;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;



create table public.workitem
(
    id               uuid    not null
        constraint workitempk
            primary key,
    workitemtyperef  integer not null
        constraint workitemworkitemtypeidfk
            references public.workitemtype,
    workitemstateref integer not null
        constraint workitemworkitemstateidfk
            references public.workitemstate,
    assignee         uuid,
    title            varchar,
    description      varchar,
    priority         integer,
    projectref       uuid
        constraint workitem_project_id_fk
            references public.project,
    workitemref      uuid
        constraint workitem_workitem_id_fk
            references public.workitem,
    code             integer
);

alter table public.workitem
    owner to postgres;

create trigger set_code_before_insert
    before insert
    on public.workitem
    for each row
execute procedure public.update_workitem_code();


alter table public.workitem
    owner to postgres;
