USE [master]
GO
/****** Object:  Database [CreditSoft]    Script Date: 16/10/2023 18:09:48 ******/
CREATE DATABASE [CreditSoft]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreditSoft', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SA\MSSQL\DATA\CreditSoft.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreditSoft_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SA\MSSQL\DATA\CreditSoft_log.ldf' , SIZE = 2624KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CreditSoft] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreditSoft].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreditSoft] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreditSoft] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreditSoft] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreditSoft] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreditSoft] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreditSoft] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreditSoft] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreditSoft] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreditSoft] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreditSoft] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreditSoft] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreditSoft] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreditSoft] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreditSoft] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreditSoft] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreditSoft] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreditSoft] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreditSoft] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreditSoft] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreditSoft] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreditSoft] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreditSoft] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreditSoft] SET RECOVERY FULL 
GO
ALTER DATABASE [CreditSoft] SET  MULTI_USER 
GO
ALTER DATABASE [CreditSoft] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreditSoft] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreditSoft] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreditSoft] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CreditSoft] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CreditSoft', N'ON'
GO
ALTER DATABASE [CreditSoft] SET QUERY_STORE = OFF
GO
USE [CreditSoft]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CreditSoft]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 16/10/2023 18:09:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] NOT NULL,
	[noms] [varchar](100) NULL,
	[sexe] [varchar](100) NULL,
	[datenaiss] [date] NULL,
	[adresse] [varchar](100) NULL,
	[etatcivil] [varchar](100) NULL,
	[telephone] [varchar](20) NULL,
	[mail] [varchar](100) NULL,
	[profession] [varchar](100) NULL,
	[adressepostal] [varchar](100) NULL,
	[nationalite] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comptes]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comptes](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[numcompte] [varchar](100) NULL,
	[montant] [float] NULL,
	[libelle] [varchar](100) NULL,
	[dateoperation] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[credits]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[credits](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[compte_id] [int] NULL,
	[montant] [float] NULL,
	[duree] [varchar](100) NULL,
	[taux_interet] [float] NULL,
	[statut] [varchar](20) NULL,
	[relevespaie] [varchar](100) NULL,
	[datecredit] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[demandecrédit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[demandecrédit](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[montant] [float] NULL,
	[duree] [varchar](100) NULL,
	[motif] [text] NULL,
	[datedemande] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[echeances]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[echeances](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[credit_id] [int] NULL,
	[montantcredit] [float] NULL,
	[montantpayer] [float] NULL,
	[date_echeance] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[evenementpaie]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evenementpaie](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[credit_id] [int] NULL,
	[type_evenement] [varchar](100) NULL,
	[penalite] [float] NULL,
	[date_evenement] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[garanties]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[garanties](
	[id] [int] NOT NULL,
	[client_id] [int] NULL,
	[credit_id] [int] NULL,
	[infogarantie] [varchar](100) NULL,
	[valeurestimee] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taux]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taux](
	[id] [int] NOT NULL,
	[categoriecredit] [varchar](100) NULL,
	[taux_annuel] [float] NULL,
	[taux_mensuel] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[noms] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](100) NULL,
	[roles] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comptes]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[credits]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[credits]  WITH CHECK ADD FOREIGN KEY([compte_id])
REFERENCES [dbo].[comptes] ([id])
GO
ALTER TABLE [dbo].[demandecrédit]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[echeances]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[echeances]  WITH CHECK ADD FOREIGN KEY([credit_id])
REFERENCES [dbo].[credits] ([id])
GO
ALTER TABLE [dbo].[evenementpaie]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[evenementpaie]  WITH CHECK ADD FOREIGN KEY([credit_id])
REFERENCES [dbo].[credits] ([id])
GO
ALTER TABLE [dbo].[garanties]  WITH CHECK ADD FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([id])
GO
ALTER TABLE [dbo].[garanties]  WITH CHECK ADD FOREIGN KEY([credit_id])
REFERENCES [dbo].[credits] ([id])
GO
/****** Object:  StoredProcedure [dbo].[delete_client]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create procedure [dbo].[delete_client]
(
@id int
)
as
begin
Delete from clients where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[delete_clients]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 create procedure [dbo].[delete_clients]
(
@id int
)
as
begin
Delete from clients where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[delete_compte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 CREATE procedure [dbo].[delete_compte]
(
@id int
)
as
begin
Delete from comptes where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[delete_credits]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create procedure [dbo].[delete_credits]
(
@id int
)
as
begin
Delete from credits where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[delete_demmande]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create procedure [dbo].[delete_demmande]
(
@id int
)
as
begin
Delete from demandecrédit where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[delete_echeance]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create procedure [dbo].[delete_echeance]
(
@id int
)
as
begin
Delete from echeances where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteCompte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCompte]
(
@id int
)
as
begin
Delete from comptes where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteCredit]
(
@id int
)
as
begin
Delete from credits where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteDemandeCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteDemandeCredit]
(
@id int
)
as
begin
Delete from demandecrédit where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteEcheance]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteEcheance]
(
@id int
)
as
begin
Delete from echeances where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteEvenement]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteEvenement]
(
@id int
)
as
begin
Delete from evenementpaie where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteGarantie]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteGarantie]
(
@id int
)
as
begin
Delete from garanties where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteTaux]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteTaux]
(
@id int
)
as
begin
Delete from taux where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[deleteUsers]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteUsers]
(
@id int
)
as
begin
Delete from users where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[fetchAallclient]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[fetchAallclient]
 as
 begin
 SELECT * FROM clients
 end
GO
/****** Object:  StoredProcedure [dbo].[fetchADemmandes]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[fetchADemmandes]
 as
 begin
 SELECT * FROM demandecrédit
 end
GO
/****** Object:  StoredProcedure [dbo].[fetchAllcompte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[fetchAllcompte]
 as
 begin
 SELECT * FROM comptes
 end
GO
/****** Object:  StoredProcedure [dbo].[fetchAllCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[fetchAllCredit]
 as
 begin
 SELECT * FROM credits
 end
GO
/****** Object:  StoredProcedure [dbo].[fetchAllEcheance]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[fetchAllEcheance]
 as
 begin
 SELECT * FROM echeances
 end
GO
/****** Object:  StoredProcedure [dbo].[GetAllCompte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllCompte]
as
begin
SELECT * FROM comptes
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllCredit]
as
begin
SELECT * FROM credits
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllDemandeCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllDemandeCredit]
as
begin
SELECT * FROM demandecrédit
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllEcheances]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllEcheances]
as
begin
SELECT * FROM echeances
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllEvenement]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllEvenement]
as
begin
SELECT * FROM evenementpaie
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllGarantie]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllGarantie]
as
begin
SELECT * FROM garanties
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllTaux]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllTaux]
as
begin
SELECT * FROM taux
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllUsers]
as
begin
SELECT * FROM users
end
GO
/****** Object:  StoredProcedure [dbo].[GetclientById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetclientById]
(
@id int
)
as
begin
Select * from clients where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetCompteById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetCompteById]
(
@id int
)
as
begin
Select * from comptes where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetCreditById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCreditById]
(
@id int
)
as
begin
Select * from credits where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetDemandeCreditById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetDemandeCreditById]
(
@id int
)
as
begin
Select * from demandecrédit where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetDemmandeById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetDemmandeById]
(
@id int
)
as
begin
Select * from demandecrédit where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetecheanceById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetecheanceById]
(
@id int
)
as
begin
Select * from echeances where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetEvenementById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetEvenementById]
(
@id int
)
as
begin
Select * from evenementpaie where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetGarantieById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetGarantieById]
(
@id int
)
as
begin
Select * from garanties where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[getNameCLient]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getNameCLient]
as
begin
select clients.id,noms from clients
end
GO
/****** Object:  StoredProcedure [dbo].[getNumCompte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getNumCompte]
as
begin
select comptes.id,numcompte from comptes
end
GO
/****** Object:  StoredProcedure [dbo].[getSelectCredit]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[getSelectCredit]
as
begin
select credits.id,montant,relevespaie,datecredit from credits
end
GO
/****** Object:  StoredProcedure [dbo].[GetTauxById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTauxById]
(
@id int
)
as
begin
Select * from taux where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUserById]
(
@id int
)
as
begin
Select * from users where id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[pro_Login]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[pro_Login]
(
@email varchar(50),
@password varchar(50),
@isvalid BIT OUT
)
as 
begin
SET @isvalid = (select count(1) from users where email=@email and password=@password)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_clients]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[proc_clients]
(
@noms varchar(100),
@sexe varchar(100),
@datenaiss date,
@adresse varchar(100),
@etatcivil varchar(100),
@telephone varchar(20),
@mail varchar(100),
@profession varchar(100),
@adressepostal varchar(100),
@nationalite varchar(100)
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from clients)
if not exists(select * from clients where id=@code)
insert into clients(id,noms,sexe,datenaiss,adresse,etatcivil,telephone,mail,profession,adressepostal,nationalite)
values(@code,@noms,@sexe,@datenaiss,@adresse,@etatcivil,@telephone,@mail,@profession,@adressepostal,@nationalite)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_compte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_compte]
(
@client_id int,
@numcompte varchar(100),
@montant float,
@libelle varchar(100),
@dateoperation date
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from comptes)
if not exists(select * from comptes where id=@code)
insert into comptes(id,client_id,numcompte,montant,libelle,dateoperation)
values(@code,@client_id,@numcompte,@montant,@libelle,@dateoperation)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_credits]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_credits]
(
@client_id int,
@compte_id int,
@montant float,
@duree varchar(100),
@taux_interet float,
@statut varchar(20),
@relevespaie varchar(100),
@datecredit date
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from credits)
if not exists(select * from credits where id=@code)
insert into credits(id,client_id,compte_id,montant,duree,taux_interet,statut,relevespaie,datecredit)
values(@code,@client_id,@compte_id,@montant,@duree,@taux_interet,@statut,@relevespaie,@datecredit)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_demande]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_demande]
(
@client_id int,
@montant float,
@duree varchar(100),
@motif text,
@datedemande date
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from demandecrédit)
if not exists(select * from demandecrédit where id=@code)
insert into demandecrédit(id,client_id,montant,duree,motif,datedemande)
values(@code,@client_id,@montant,@duree,@motif,@datedemande)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_echeance]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_echeance]
(
@client_id int,
@credit_id int,
@montantcredit float,
@montantpayer float,
@date_echeance date
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from echeances)
if not exists(select * from echeances where id=@code)
insert into echeances(id,client_id,credit_id,montantcredit,montantpayer,date_echeance)
values(@code,@client_id,@credit_id,@montantcredit,@montantpayer,@date_echeance)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_evenement]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_evenement]
(
@client_id int,
@credit_id int,
@type_evenement varchar(100),
@penalite float,
@date_evenement date
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from evenementpaie)
if not exists(select * from evenementpaie where id=@code)
insert into evenementpaie(id,client_id,credit_id,type_evenement,penalite,date_evenement)
values(@code,@client_id,@credit_id,@type_evenement,@penalite,@date_evenement)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_garanties]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_garanties]
(
@client_id int,
@credit_id int,
@infogarantie varchar(100),
@valeurestimee float
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from garanties)
if not exists(select * from garanties where id=@code)
insert into garanties(id,client_id,credit_id,infogarantie,valeurestimee)
values(@code,@client_id,@credit_id,@infogarantie,@valeurestimee)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_taux]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_taux]
(
@categoriecredit varchar(100),
@taux_annuel float,
@taux_mensuel float
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from taux)
if not exists(select * from taux where id=@code)
insert into taux(id,categoriecredit,taux_annuel,taux_mensuel)
values(@code,@categoriecredit,@taux_annuel,@taux_mensuel)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updateclients]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updateclients]
(
@noms varchar(100),
@sexe varchar(100),
@datenaiss date,
@adresse varchar(100),
@etatcivil varchar(100),
@telephone varchar(20),
@mail varchar(100),
@profession varchar(100),
@adressepostal varchar(100),
@nationalite varchar(100),
@id int
)
as
begin
update clients set noms=@noms,sexe=@sexe,datenaiss=@datenaiss,adresse=@adresse,etatcivil=@etatcivil,
telephone=@telephone,mail=@mail,profession=@profession,adressepostal=@adressepostal,nationalite=@nationalite 
where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updatecompte]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_updatecompte]
(
@client_id int,
@numcompte varchar(100),
@montant float,
@libelle varchar(100),
@dateoperation date,
@id int
)
as
begin
update comptes set client_id=@client_id,numcompte=@numcompte,montant=@montant,libelle=@libelle,
dateoperation=@dateoperation WHERE id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updatecredits]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updatecredits]
(
@client_id int,
@compte_id int,
@montant float,
@duree varchar(100),
@taux_interet float,
@statut varchar(20),
@relevespaie varchar(100),
@datecredit date,
@id int
)
as
begin
update credits set client_id=@client_id,compte_id=@compte_id,montant=@montant,duree=@duree,
taux_interet=@taux_interet,statut=@statut,relevespaie=@relevespaie,datecredit=@datecredit where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updatedemande]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updatedemande]
(
@client_id int,
@montant float,
@duree varchar(100),
@motif text,
@datedemande date,
@id int
)
as
begin
update demandecrédit set client_id=@client_id,montant=@montant,duree=@duree,motif=@motif,
datedemande=@datedemande where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updateecheance]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updateecheance]
(
@client_id int,
@credit_id int,
@montantcredit float,
@montantpayer float,
@date_echeance date,
@id int
)
as
begin
update echeances set client_id=@client_id,credit_id=@credit_id,montantcredit=@montantcredit,
montantpayer=@montantpayer,date_echeance=@date_echeance where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updateevenement]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updateevenement]
(
@client_id int,
@credit_id int,
@type_evenement varchar(100),
@penalite float,
@date_evenement date,
@id int
)
as
begin
update evenementpaie set client_id=@client_id,credit_id=@credit_id,type_evenement=@type_evenement,
penalite=@penalite,date_evenement=@date_evenement where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updategaranties]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updategaranties]
(
@client_id int,
@credit_id int,
@infogarantie varchar(100),
@valeurestimee float,
@id int
)
as
begin
update garanties set client_id=@client_id,credit_id=@credit_id,infogarantie=@infogarantie,
valeurestimee=@valeurestimee where  id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updatetaux]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updatetaux]
(
@categoriecredit varchar(100),
@taux_annuel float,
@taux_mensuel float,
@id int
)
as
begin
update taux set categoriecredit=@categoriecredit,taux_annuel=@taux_annuel,taux_mensuel=@taux_mensuel where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_updateusers]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_updateusers]
(
@noms varchar(100),
@email varchar(100),
@password varchar(100),
@roles varchar(100),
@id int
)
as
begin
update users set noms=@noms,email=@email,password=@password,roles=@roles where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[proc_users]    Script Date: 16/10/2023 18:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[proc_users]
(
@noms varchar(100),
@email varchar(100),
@password varchar(100),
@roles varchar(100)
)
as
begin
declare @code int = (select coalesce(max(id),0)+1 from users)
if not exists(select * from users where id=@code)
insert into users(id,noms,email,password,roles) values(@code,@noms,@email,@password,@roles)
end
GO
USE [master]
GO
ALTER DATABASE [CreditSoft] SET  READ_WRITE 
GO
