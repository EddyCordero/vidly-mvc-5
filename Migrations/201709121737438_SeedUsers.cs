namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5d70c5ec-2c15-428d-8c10-e946f82bc81d', N'guest@vidly.com', 0, N'AONviadKyibumVcPesKPXrSagy2TNGNBbCo/vJmOZMAewuWiKEttcpxVxA9NiP+SjQ==', N'2a4ae6bc-cb2b-4521-8fcf-1c59f57b6d50', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'78c441ce-b177-40d5-bf75-5f7ac386035f', N'admin@vidly.com', 0, N'AHynJrwOWAblb1nNoes2s/l+Lz/0pt9XlGndL4WJi2x9wJthMOHLqc1b68gV5f71HQ==', N'17cc07c8-e1f2-403a-b718-1f388bbf0c7d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'50ed1770-174a-4df1-86e0-201678194f90', N'CanManegeMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5d70c5ec-2c15-428d-8c10-e946f82bc81d', N'50ed1770-174a-4df1-86e0-201678194f90')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'78c441ce-b177-40d5-bf75-5f7ac386035f', N'50ed1770-174a-4df1-86e0-201678194f90')


");
        }
        
        public override void Down()
        {
        }
    }
}
