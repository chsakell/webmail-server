select * from [User]
select * from [Email]
select * from [UserEmail]

/*
delete from [UserEmail];
delete from [Email];
delete from [User];
DBCC CHECKIDENT('UserEmail', RESEED, 0);
DBCC CHECKIDENT('Email', RESEED, 0);
DBCC CHECKIDENT('User', RESEED, 0);
*/