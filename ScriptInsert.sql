INSERT INTO public.denemeentity (id,kolon1s,kolon2s,kolon3n,kolon4n) VALUES
	 ('2f4a55ce-2fa5-4de6-81ec-a5ad59c8b4e3','testkolon1','testkolon2',123,321);
INSERT INTO public.form (id,formtitle,entitytable) VALUES
	 ('41ba900d-7650-40bc-a79f-1fae2cc465be','Generic Form Backend','denemeentity');
INSERT INTO public.formelement (id,formref,dtypestring,"label",fieldname,listitems) VALUES
	 ('19958e5b-5166-4698-bbb0-77f04105baf3','41ba900d-7650-40bc-a79f-1fae2cc465be','GSelect','Country','kolon3n','[
  { state: ''List item 1'', abbr: ''1'' },
  { state: ''List item 2'', abbr: ''2'' },
  { state: ''List item 3'', abbr: ''3'' },
  { state: ''List item 4'', abbr: ''4'' },
  { state: ''List item 5'', abbr: ''5'' },
]'),
	 ('72b59da6-2f3e-43b0-a955-37584434aa9a','41ba900d-7650-40bc-a79f-1fae2cc465be','GTextbox','Name','kolon1s',NULL),
	 ('de857f82-5bd8-43f0-9526-3c5a5a0012ac','41ba900d-7650-40bc-a79f-1fae2cc465be','GTextbox','Surname','kolon2s',NULL),
	 ('76559297-09af-408f-a820-dd1633137f03','41ba900d-7650-40bc-a79f-1fae2cc465be','GSelect','FieldType','kolon4n','[
  { state: ''Other item 1'', abbr: ''1'' },
  { state: ''Other item 2'', abbr: ''2'' },
  { state: ''Other item 3'', abbr: ''3'' },
  { state: ''Other item 4'', abbr: ''4'' },
  { state: ''List item 5'', abbr: ''5'' },
]');
INSERT INTO public."user" (id,username,passwordhash,passwordsalt,refreshtoken,refreshtokencreatedat,refreshtokenexpiresat,credate,moddate,"name",surname,email,phonenumber) VALUES
	 ('fa7a12d9-1391-468c-b0f1-d56a0d328a7b','string',decode('DA310BF30EF57BD10F997A980990FB92B14A170BB7511A41E4FBE9719E2EE6529DB763A227822C59B5FC9EF3A589DC0B1ED4D5EF0B35732CBA81B4E1A431F4A8','hex'),decode('93934A5B3538AAD8CD7ECFE818D17A2FC121E4C55B10D406F5DCC5D8C7EBAA3581BAEE5FF81451943DC982740BCF00F2EC4F8F806442915A621FDC4A4EA24B35453AF7FF18264EB7C04A9C52674C2932868E8560106319911A538CFAD7C4FB9A0221508E28C5884F2E4B2CC7BF120B87875D15CF40B86E0843057D6C16FC1937','hex'),'QhSRm8pO9OS+MJbjiyDcbSXusU5vYi50UifG1brSP3n+Akfx7Q4JhXmPBZRmWtrZ0+dZdg79/d3iAJm13iUB3A==','2023-04-09 21:08:48.024294+03','2023-04-16 21:08:48.024293+03','2023-02-16 23:51:53.513567+03','2023-04-09 21:08:48.024593+03','Hasan','Kavak','hk@ella.com','03256565565'),
	 ('094991dd-5106-4028-93b5-db37cccb25fb','username',decode('F5E0238B77DC5FDD076BC2B0156791494233DC5BE973C4C4CC1F403C8AB4C0AFD6B02ACDBD330A2157E95B877F58601D2AD79DA01F87D9A55B6B6FE5825DB2F3','hex'),decode('0A8C4A8802E895CCDAAA75BE46732165050319DF248F9349F653D2A9CFE19B15C3CA447D8914E18211E044ECC31B34105BC87C7622160BDB7C431E6E5CF45FCA769C988AE29288FAB0AE01F8B2E15A6EF860C12BA953F2290F9BE604D5E5930A34E4BBE94BDBFC39538FCCECC346AADAF74445427E276866F3EA3EB70AC19BD2','hex'),'FBe1uRAaVNajFeUwBcGiVDkL3p8IQy1+gsOT4/xnwcd2d+sYUPHrEm0QYVNNrDtgsBOS7yS4m1qMurz0/6OKDg==','2023-03-01 01:36:47.548919+03','2023-03-08 01:36:47.548919+03','2023-03-01 00:41:00.380964+03','2023-03-01 01:36:47.549215+03','Aykut','Sevim','as@ella.com','05322566565');


INSERT INTO public.workitemtype (id, processref, workitemtypename)
VALUES (1::integer, DEFAULT, 'Task'::varchar);

INSERT INTO public.workitemtype (id, processref, workitemtypename)
VALUES (2::integer, DEFAULT, 'Bug'::varchar);

INSERT INTO public.workitemtype (id, processref, workitemtypename)
VALUES (3::integer, DEFAULT, 'New Feature'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (1::integer, 1::integer, 'To Do'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (2::integer, 1::integer, 'In Progress'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (3::integer, 1::integer, 'Done'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (4::integer, 2::integer, 'To Do'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (5::integer, 2::integer, 'In Progress'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (6::integer, 2::integer, 'Done'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (7::integer, 3::integer, 'Proposed'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (8::integer, 3::integer, 'To Do (Approved)'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (9::integer, 3::integer, 'In Progress'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (10::integer, 3::integer, 'Test'::varchar);

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename)
VALUES (11::integer, 3::integer, 'Done'::varchar);

INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority)
VALUES ('19f09fe4-8b5e-4e06-bd51-94c6e889db53'::uuid, 1::integer, 1::integer, null::uuid, 'Work Item 1'::varchar,
        'Detailed description'::varchar, 1::integer);

INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority)
VALUES ('1fabf2ad-4418-481c-b74a-74f5b428240b'::uuid, 1::integer, 2::integer, null::uuid, 'Work Item 2'::varchar,
        'Detailed description'::varchar, 2::integer);

INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority)
VALUES ('4262612d-d927-4a5a-8db1-5ffacb6ac608'::uuid, 2::integer, 1::integer, null::uuid, 'Work Item 3'::varchar,
        'Detailed description'::varchar, 1::integer);
