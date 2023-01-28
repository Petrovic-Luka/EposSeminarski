if not exists (select 1 from dbo.[Notes])
begin 
insert into dbo.[Notes] (Title,Description)
values ('Test 1','Desc 1'),
('Test 2','Desc 2'),
('Test 3','Desc 3'),
('Test 4','Desc 4');
end