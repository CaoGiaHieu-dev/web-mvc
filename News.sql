/*
Created		09/10/2019
Modified		08/11/2019
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


Drop table [tintuc] 
go
Drop table [menu] 
go


Create table [menu]
(
	[id_m] Integer Identity NOT NULL,
	[name] Nvarchar(50) NULL,
	[link] Nvarchar(MAX) NULL,
	[meta] Nvarchar(50) NULL,
	[hide] Bit NULL,
	[position] Integer NULL,
	[datebegin] Smalldatetime NULL,
Primary Key ([id_m])
) 
go

Create table [tintuc]
(
	[id] Integer Identity NOT NULL,
	[name] Nvarchar(50) NULL,
	[img] Nvarchar(30) NULL,
	[description] Nvarchar(MAX) NULL,
	[link] Nvarchar(MAX) NULL,
	[detail] Ntext NULL,
	[meta] Nvarchar(MAX) NULL,
	[hide] Bit NULL,
	[position] Integer NULL,
	[datebegin] Smalldatetime NULL,
	[id_m] Integer NOT NULL,
Primary Key ([id])
) 
go


Alter table [tintuc] add  foreign key([id_m]) references [menu] ([id_m])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


