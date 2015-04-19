--Añadiendo CustomerId a la tabla PlayList
use ChinookV2
go
alter table [dbo].[Playlist] add CustomerId int;
go

alter table [dbo].[Playlist] add constraint [FK_Customer]
foreign key ([CustomerId]) References [dbo].[Customer]([Id])
on delete no action on update no action;
go

create index [IFK_CustomerId] on [dbo].[Playlist] ([CustomerId])
go

update [dbo].[Playlist]
set CustomerId = 1;
go


