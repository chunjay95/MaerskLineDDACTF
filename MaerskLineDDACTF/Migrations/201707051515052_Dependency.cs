namespace MaerskLineDDACTF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dependency : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingSchedules",
                c => new
                    {
                        BookingScheduleID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        YardID = c.Int(nullable: false),
                        Yard1ID = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BookingScheduleID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .ForeignKey("dbo.Yards", t => t.YardID, cascadeDelete: false)
                .ForeignKey("dbo.Yards", t => t.Yard1ID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.YardID)
                .Index(t => t.Yard1ID);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DetailedDescription = c.String(),
                        AmountOfContainers = c.Int(nullable: false),
                        TotalWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(),
                        Capacity = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Yards",
                c => new
                    {
                        YardID = c.Int(nullable: false, identity: true),
                        YardName = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.YardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingSchedules", "Yard1ID", "dbo.Yards");
            DropForeignKey("dbo.BookingSchedules", "YardID", "dbo.Yards");
            DropForeignKey("dbo.BookingSchedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Ships", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.BookingSchedules", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Ships", new[] { "CompanyID" });
            DropIndex("dbo.BookingSchedules", new[] { "Yard1ID" });
            DropIndex("dbo.BookingSchedules", new[] { "YardID" });
            DropIndex("dbo.BookingSchedules", new[] { "ContainerID" });
            DropIndex("dbo.BookingSchedules", new[] { "ShipID" });
            DropTable("dbo.Yards");
            DropTable("dbo.Companies");
            DropTable("dbo.Ships");
            DropTable("dbo.Containers");
            DropTable("dbo.BookingSchedules");
        }
    }
}
