INSERT INTO public.form (id, formtitle, entitytable) VALUES ('41ba900d-7650-40bc-a79f-1fae2cc465be', 'Generic Form Backend', 'denemeentity');

INSERT INTO public.formelement (id, formref, dtypestring, label, fieldname, listitems) VALUES ('19958e5b-5166-4698-bbb0-77f04105baf3', '41ba900d-7650-40bc-a79f-1fae2cc465be', 'GSelect', 'Country', 'kolon3n', e'[
  { state: \'List item 1\', abbr: \'1\' },
  { state: \'List item 2\', abbr: \'2\' },
  { state: \'List item 3\', abbr: \'3\' },
  { state: \'List item 4\', abbr: \'4\' },
  { state: \'List item 5\', abbr: \'5\' },
]');
INSERT INTO public.formelement (id, formref, dtypestring, label, fieldname, listitems) VALUES ('72b59da6-2f3e-43b0-a955-37584434aa9a', '41ba900d-7650-40bc-a79f-1fae2cc465be', 'GTextbox', 'Name', 'kolon1s', null);
INSERT INTO public.formelement (id, formref, dtypestring, label, fieldname, listitems) VALUES ('de857f82-5bd8-43f0-9526-3c5a5a0012ac', '41ba900d-7650-40bc-a79f-1fae2cc465be', 'GTextbox', 'Surname', 'kolon2s', null);
INSERT INTO public.formelement (id, formref, dtypestring, label, fieldname, listitems) VALUES ('76559297-09af-408f-a820-dd1633137f03', '41ba900d-7650-40bc-a79f-1fae2cc465be', 'GSelect', 'FieldType', 'kolon4n', e'[
  { state: \'Other item 1\', abbr: \'1\' },
  { state: \'Other item 2\', abbr: \'2\' },
  { state: \'Other item 3\', abbr: \'3\' },
  { state: \'Other item 4\', abbr: \'4\' },
  { state: \'List item 5\', abbr: \'5\' },
]');

INSERT INTO public.denemeentity (id, kolon1s, kolon2s, kolon3n, kolon4n) VALUES ('2f4a55ce-2fa5-4de6-81ec-a5ad59c8b4e3', 'testkolon1', 'testkolon2', 123, 321);

INSERT INTO public.tenant (id, tenantname) VALUES ('cd84c13b-b072-48d3-b4bd-65e746ff919c', 'kitlesel.com.tr');
INSERT INTO public.tenant (id, tenantname) VALUES ('da61ee64-31dc-4302-8491-0f59112b6c28', 'oynio.com');

INSERT INTO public.project (id, projectname, tenantref) VALUES ('c212793b-d8b3-4aa8-8e42-42e1e34d77f4', 'oba-frontend', 'da61ee64-31dc-4302-8491-0f59112b6c28');
INSERT INTO public.project (id, projectname, tenantref) VALUES ('666fcd2a-a67a-417c-aca8-63334fb9f0b1', 'oba-backend', 'da61ee64-31dc-4302-8491-0f59112b6c28');

INSERT INTO public."user" (id, username, passwordhash, passwordsalt, refreshtoken, refreshtokencreatedat, refreshtokenexpiresat, credate, moddate, name, surname, email, phonenumber, tenantref) VALUES ('094991dd-5106-4028-93b5-db37cccb25fb', 'username', E'\\xF5E0238B77DC5FDD076BC2B0156791494233DC5BE973C4C4CC1F403C8AB4C0AFD6B02ACDBD330A2157E95B877F58601D2AD79DA01F87D9A55B6B6FE5825DB2F3', E'\\x0A8C4A8802E895CCDAAA75BE46732165050319DF248F9349F653D2A9CFE19B15C3CA447D8914E18211E044ECC31B34105BC87C7622160BDB7C431E6E5CF45FCA769C988AE29288FAB0AE01F8B2E15A6EF860C12BA953F2290F9BE604D5E5930A34E4BBE94BDBFC39538FCCECC346AADAF74445427E276866F3EA3EB70AC19BD2', 'FBe1uRAaVNajFeUwBcGiVDkL3p8IQy1+gsOT4/xnwcd2d+sYUPHrEm0QYVNNrDtgsBOS7yS4m1qMurz0/6OKDg==', '2023-02-28 22:36:47.548919 +00:00', '2023-03-07 22:36:47.548919 +00:00', '2023-02-28 21:41:00.380964 +00:00', '2023-02-28 22:36:47.549215 +00:00', 'Aykut', 'Sevim', 'as@ella.com', '05322566565', 'cd84c13b-b072-48d3-b4bd-65e746ff919c');
INSERT INTO public."user" (id, username, passwordhash, passwordsalt, refreshtoken, refreshtokencreatedat, refreshtokenexpiresat, credate, moddate, name, surname, email, phonenumber, tenantref) VALUES ('fa7a12d9-1391-468c-b0f1-d56a0d328a7b', 'string', E'\\xDA310BF30EF57BD10F997A980990FB92B14A170BB7511A41E4FBE9719E2EE6529DB763A227822C59B5FC9EF3A589DC0B1ED4D5EF0B35732CBA81B4E1A431F4A8', E'\\x93934A5B3538AAD8CD7ECFE818D17A2FC121E4C55B10D406F5DCC5D8C7EBAA3581BAEE5FF81451943DC982740BCF00F2EC4F8F806442915A621FDC4A4EA24B35453AF7FF18264EB7C04A9C52674C2932868E8560106319911A538CFAD7C4FB9A0221508E28C5884F2E4B2CC7BF120B87875D15CF40B86E0843057D6C16FC1937', 'QhSRm8pO9OS+MJbjiyDcbSXusU5vYi50UifG1brSP3n+Akfx7Q4JhXmPBZRmWtrZ0+dZdg79/d3iAJm13iUB3A==', '2023-04-09 18:08:48.024294 +00:00', '2023-04-16 18:08:48.024293 +00:00', '2023-02-16 20:51:53.513567 +00:00', '2023-04-09 18:08:48.024593 +00:00', 'Hasan', 'Kavak', 'hk@ella.com', '03256565565', 'cd84c13b-b072-48d3-b4bd-65e746ff919c');

INSERT INTO public.workitemtype (id, processref, workitemtypename) VALUES (1, 1, 'Task');
INSERT INTO public.workitemtype (id, processref, workitemtypename) VALUES (2, 1, 'Bug');
INSERT INTO public.workitemtype (id, processref, workitemtypename) VALUES (3, 1, 'New Feature');

INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (1, 1, 'To Do');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (2, 1, 'In Progress');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (3, 1, 'Done');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (4, 2, 'To Do');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (5, 2, 'In Progress');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (6, 2, 'Done');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (7, 3, 'Proposed');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (8, 3, 'To Do (Approved)');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (9, 3, 'In Progress');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (10, 3, 'Test');
INSERT INTO public.workitemstate (id, workitemtyperef, workitemstatename) VALUES (11, 3, 'Done');

INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority, projectref, workitemref) VALUES ('4262612d-d927-4a5a-8db1-5ffacb6ac608', 2, 1, null, 'Work Item 3', 'Detailed description', 1, '666fcd2a-a67a-417c-aca8-63334fb9f0b1', null);
INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority, projectref, workitemref) VALUES ('1fabf2ad-4418-481c-b74a-74f5b428240b', 1, 2, null, 'Work Item 2', 'Detailed description', 2, '666fcd2a-a67a-417c-aca8-63334fb9f0b1', null);
INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority, projectref, workitemref) VALUES ('19f09fe4-8b5e-4e06-bd51-94c6e889db53', 1, 1, null, 'Work Item 1', 'Detailed description', 1, '666fcd2a-a67a-417c-aca8-63334fb9f0b1', null);
INSERT INTO public.workitem (id, workitemtyperef, workitemstateref, assignee, title, description, priority, projectref, workitemref) VALUES ('6c86c51a-beb5-49e4-ae0a-69ea1f1f62c4', 1, 1, null, 'Child Item 2.1', 'Child', 2, '666fcd2a-a67a-417c-aca8-63334fb9f0b1', '1fabf2ad-4418-481c-b74a-74f5b428240b');

