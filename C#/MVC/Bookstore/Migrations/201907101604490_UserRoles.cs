namespace Bookstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'480397b6-b474-41f6-98c5-7f887b56049f', N'admin@bookstore.com', 0, N'AAxAlcc2DHIHVwJuhKiWpwxaEhAb/XIicdFC58n54dBEXypOqHeFfYCrLkvyg+ehlw==', N'62d55559-5c56-4061-bd59-ffb1cec6951a', NULL, 0, 0, NULL, 1, 0, N'admin@bookstore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6cf0cca2-403e-468f-995b-8635572822e0', N'guest@bookstore.com', 0, N'AJD6H+gc1uJfGLltlCTBYkNZaybbL0lXl0O1B1e8LFaqmzrpd2QGVSvd+vyOmyG3bQ==', N'70f63b5f-7c7e-4dc9-b52e-7bfb21464dbf', NULL, 0, 0, NULL, 1, 0, N'guest@bookstore.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10', N'User')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'480397b6-b474-41f6-98c5-7f887b56049f', N'1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6cf0cca2-403e-468f-995b-8635572822e0', N'10')


");
        }
        
        public override void Down()
        {
        }
    }
}
