use ChinookV2
go
alter table [dbo].[Customer] add constraint [UK_UserName] unique nonclustered (Email)