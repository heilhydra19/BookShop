namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        Img = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PublisherId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        BillId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.BillId })
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreateAt = c.DateTime(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImportDetails",
                c => new
                    {
                        ImportId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImportId, t.BookId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Imports", t => t.ImportId, cascadeDelete: true)
                .Index(t => t.ImportId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Imports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 15),
                        CreateAt = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Imports", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ImportDetails", "ImportId", "dbo.Imports");
            DropForeignKey("dbo.Imports", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ImportDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BillDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Bills", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bills", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BillDetails", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Imports", new[] { "EmployeeId" });
            DropIndex("dbo.Imports", new[] { "SupplierId" });
            DropIndex("dbo.ImportDetails", new[] { "BookId" });
            DropIndex("dbo.ImportDetails", new[] { "ImportId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Bills", new[] { "CustomerId" });
            DropIndex("dbo.Bills", new[] { "EmployeeId" });
            DropIndex("dbo.BillDetails", new[] { "BillId" });
            DropIndex("dbo.BillDetails", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Publishers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Imports");
            DropTable("dbo.ImportDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Bills");
            DropTable("dbo.BillDetails");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
