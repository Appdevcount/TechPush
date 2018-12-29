﻿CREATE TABLE [dbo].[Categories] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](500) NOT NULL,
    [UrlSlug] [nvarchar](500) NOT NULL,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Posts] (
    [Id] [int] NOT NULL IDENTITY,
    [Title] [nvarchar](500) NOT NULL,
    [ShortDescription] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [Meta] [nvarchar](1000) NOT NULL,
    [UrlSlug] [nvarchar](1000) NOT NULL,
    [Published] [bit] NOT NULL,
    [PostedOn] [datetime] NOT NULL,
    [Modified] [datetime],
    [Category_Id] [int],
    CONSTRAINT [PK_dbo.Posts] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Category_Id] ON [dbo].[Posts]([Category_Id])
CREATE TABLE [dbo].[Tags] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](500) NOT NULL,
    [UrlSlug] [nvarchar](500) NOT NULL,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Tags] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[TagPosts] (
    [Tag_Id] [int] NOT NULL,
    [Post_Id] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TagPosts] PRIMARY KEY ([Tag_Id], [Post_Id])
)
CREATE INDEX [IX_Tag_Id] ON [dbo].[TagPosts]([Tag_Id])
CREATE INDEX [IX_Post_Id] ON [dbo].[TagPosts]([Post_Id])
ALTER TABLE [dbo].[Posts] ADD CONSTRAINT [FK_dbo.Posts_dbo.Categories_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Categories] ([Id])
ALTER TABLE [dbo].[TagPosts] ADD CONSTRAINT [FK_dbo.TagPosts_dbo.Tags_Tag_Id] FOREIGN KEY ([Tag_Id]) REFERENCES [dbo].[Tags] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[TagPosts] ADD CONSTRAINT [FK_dbo.TagPosts_dbo.Posts_Post_Id] FOREIGN KEY ([Post_Id]) REFERENCES [dbo].[Posts] ([Id]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201812291649098_Initial', N'TechPush.Infrastructure.Migrations.Configuration',  0x1F8B0800000000000400ED5BDB6EE336107D2FD07F10F4D41659CBD945816D60EF227192C2E8260E6267D1B78091689B2845B92215D828FA657DE827F5173AD485A244CA96BC4EB22D82058284973317CE8C3833DC7FFEFA7BF0711D52E711C79C446CE81EF7FAAE83991F05842D866E22E66FDEBB1F3F7CFBCDE02208D7CEE762DD3BB90E76323E749742AC4E3C8FFB4B1C22DE0B891F473C9A8B9E1F851E0A22EF6DBFFF93777CEC61807001CB7106B7091324C4E91FF0E728623E5E8904D1AB28C094E7E330334D519D6B1462BE423E1EBA33EC2F6F12BEEC8DD93C465CC4892F9218F7465753D739A504014B534CE7AE83188B0412C0F0C91DC75311476C315DC100A2B3CD0AC3BA39A21CE7829C94CBDBCAD47F2B65F2CA8D05949F7011851D018FDFE54AF2EADBF752B5AB94086ABC00758B8D943A55E5D01D21811751BC719D3AB193118DE5424DD3A348EA37DF71E454C68F945180EDC87F47CE28A1F244860C272246F4C8B9491E28F17FC19B59F41B66439650AA7307FCC15C6500866EE2688563B1B9C5F39CE771E03A5E759F57DFA8B6697B3269C64CBC7BEB3AD7401C3D50AC0E5F937C2A40A09F31C331C81ADC202170CC24064ED56750AFD1923F0B6A606DE041AE7385D69F305B88E5D0FDB10F3E7349D6382846720EEE180187834D60CBD8C2E176AA77319DD264F1FC84CF31F763B2CA0CB49138FCDA8A788DD6357A248BF4546A546F222EB8EBDC629ACEF2255965FEDE9333F7A55D5FC651781BD17C8B9AB89FA1788105701CD966A75112FB3576065EE93E5B9D4A42B57728B9FAD5999A68CD88A02FE04DD365148BC35AF68BBA5547E25758A02D548FFB2F15C39E8A72EA4D7C8995659F45101510EB0E04DE8C83893AB373B0FA1909F73802B87BCD49C95009D43644963170FF2859C4417B942C62685B8E6668618FD930719F47F492133568C4EA72E68BE234C0B40FD3B0F8354A37D17ABDF2BCE8956787FBD49DD874AC36EE73CA79E49394B4C6501943AA525CB0C0D91A5032AD15A1081407AE4356E02C407AE8FE60A8A50950C58612B00C6B55D07EAF775C9755936ABBB0A58E9BF8B228BCE4298D35ED65B4C4BE4E0A6B142C3B5B48B40522E0EDB97067345A9C9FC951BCB65D5D216FCEC322CFADB6CEB8449D6251FDF4100C16595A93713C86F85594DCA40D804CFE1D9BB36F8DB1373D87DA564D5555E2DA07525B63FD82D663F82EFB57EC2A31BDB61085456810BABEEBDF89AA742D24D7A2892975831BEC70048DD5EC5CB6086B9AFE2E5D6D91B10866CAE0CB929297D5948ADA93D7507C1A5CA1D50A42BB568CCA479C6956891ABD9976AFCC841986E7734B814671AB28C1E7192D706D164803A79724E6026E87E801C98FCB28088D6555F76EF09B8296E1C1E651153E556C91BFE7B6D35C95EB35F94AA9D14B1032841B472A2F36EDDBB235AD0D228A62CBED6714D124644D37A86DBBB3FB8CBE3F1B698FA0EE263A881A6C8F53B96AE8589509136FE0D5745A3F45CF38C69A4FD50DA395D9348586FD2C260DF4DDADC5BEED692C25AF4FE800F9507B0CB3D8A0C399B34F6F3D4D78595D4007CA469EDF2FB4845D47D2863B60A99CBD02A5463BE84725ED151DA9D1AFC64FD3AFF0A1DC54DEA9BA7BA975D76B387F99705EBD4099315DBB09B70FDDDAA636215ADE012D9E695C7C4DE5B432190563B31DA91F45BC2B5FF92D774FBE3AB303F7B880A499E998CBC285AA2BB494B67E5DEE6C105A82D03A40141B2C51A0A52D1859C59EFA9638073001234DD9939DD494BAF1B3FB008DB4A7BE44C51395FED4D29C419E72EC6EC41B3948B6C47580F74712C8FC63BA814F69D8930B7AD3DFE988128860E5822BC4C81C7391D5485D4891DED75AF85F4F3BDDE33CA02D7BEACF5EE82552AB3B4BB91D8B9D7A6D973DA2D85FA2D82CB27E59E9F660B896CA6C81FD5D88D6DFEB8066F5B55B87F7FF71BC9506EBC1CEA1A97FDA7818073FDDCE7D4EABEC59BFF1098C7B2F60A34BF940C417772803B02371880EA50DC8DAE168E853DED72CDDA8428F5980D743F78F74DF8933FEF55EDB7AE44C62F8969C387DE7CF0379B991A1FC679DFC35865B4F77DF30DE78853497365CEF765B4441A39B4364BB9A7CA1757CD88372BEAD03E943371AAB296AE75EA0D171D9A34909E78E63E9A388C2D51B9220B87C1BA9FA4D4C984F5688D6F936338836C1452A5241D667CEF10A33193574B9DAD0D9912D2BDC9A55EF52C03E0D576BBE576D18ED6AB51E1BF9E5849D638A05764EFD2C951821EEA3C0F40E99856DA16C188A1A7B125BB197DA0E6E260D5979B760F8BC4662CBC2BB3AF4FFC64C5A1FDE33DAC99642C7C10DC5FECAC1EC9636D4CA8D07745BDE3064D50EB8FD3E4470C0D9C76E4B3BDEF6C6A1F189830DDBDE01B7BC7E687AFC6003B535E56D980DDCAA99066C3BCF4FFBECA27E78D53EF2AED716C6A38343BEAB50CF22B63CAF682872D63F7BB57ECA8E771586646AEC80C215AF36B609672F99763D832710AFC37B11B3400A014BFBFF4C102C39599410B26ECFB05F09556ACD98CDA32264D6382A96584A179071A3D3589039F2054CFB98F3F411E26744135872113EE060CC268958250244C6E103AD98BE8CBCDBE8A78F62AA3C0F266962C60F2102B04964D160C2CE124203C5F7A52557688090213DCF93E5590A992F2F360AE93A622D8172F5A92FD10C872B0A607CC2A6E811EFC3DB1DC79FF002F99BA2CEDD0CB2FB20AA6A1F9C13B48851C8738C723FFC09361C84EB0FFF024AB0DCDCD6370000 , N'6.2.0-61023')

