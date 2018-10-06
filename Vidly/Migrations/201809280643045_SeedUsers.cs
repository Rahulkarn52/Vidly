namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c2ae43c5-a633-49a4-92e3-73f1f4385ecc', N'guest@vidly.com', 0, N'ALDcfOU1h76NL3c7vgsUMF45ag1j1q2QrWkwUVAPMwaWcj7+D6x9ejWqTvPKgYAjcg==', N'aa607fe8-fe57-4cfc-9a98-57ef13cf7e25', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e328518c-4a3e-4672-88fe-13cb128c39df', N'admin@vidly.com', 0, N'AG5jfr/6cfu0RlIS2G1Kge87TAC9Q4ECMQ63+7Z3t/IJMuCGXgIxh3algYHvCThP6A==', N'c8fbb79c-25c9-42d5-a532-58723c4bc783', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e5567b4d-87b3-4226-abf2-4a89d46a9b11', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e328518c-4a3e-4672-88fe-13cb128c39df', N'e5567b4d-87b3-4226-abf2-4a89d46a9b11')
");
        }
        
        public override void Down()
        {
        }
    }
}
