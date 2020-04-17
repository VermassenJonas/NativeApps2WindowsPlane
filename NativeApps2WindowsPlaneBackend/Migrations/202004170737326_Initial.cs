namespace NativeApps2WindowsPlaneBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        Destination = c.String(),
                        Origin = c.String(),
                        ETA = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Flight_FlightId = c.Int(),
                        Passenger_TicketNumber = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .ForeignKey("dbo.Passengers", t => t.Passenger_TicketNumber)
                .Index(t => t.Flight_FlightId)
                .Index(t => t.Passenger_TicketNumber);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Article_ArticleId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Article_ArticleId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        TicketNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        Seat_SeatId = c.Int(),
                        TravelGroup_TravelGroupId = c.Int(),
                        Flight_FlightId = c.Int(),
                        Notification_NotificationId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketNumber)
                .ForeignKey("dbo.Seats", t => t.Seat_SeatId)
                .ForeignKey("dbo.TravelGroups", t => t.TravelGroup_TravelGroupId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .ForeignKey("dbo.Notifications", t => t.Notification_NotificationId)
                .Index(t => t.Seat_SeatId)
                .Index(t => t.TravelGroup_TravelGroupId)
                .Index(t => t.Flight_FlightId)
                .Index(t => t.Notification_NotificationId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        SeatNumber = c.String(),
                    })
                .PrimaryKey(t => t.SeatId);
            
            CreateTable(
                "dbo.TravelGroups",
                c => new
                    {
                        TravelGroupId = c.Int(nullable: false, identity: true),
                        Flight_FlightId = c.Int(),
                    })
                .PrimaryKey(t => t.TravelGroupId)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .Index(t => t.Flight_FlightId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Sent = c.DateTime(nullable: false),
                        Sender_TicketNumber = c.Int(),
                        TravelGroup_TravelGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Passengers", t => t.Sender_TicketNumber)
                .ForeignKey("dbo.TravelGroups", t => t.TravelGroup_TravelGroupId)
                .Index(t => t.Sender_TicketNumber)
                .Index(t => t.TravelGroup_TravelGroupId);
            
            CreateTable(
                "dbo.Stewards",
                c => new
                    {
                        PersonnelNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Hash = c.String(),
                        Flight_FlightId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonnelNumber)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightId)
                .Index(t => t.Flight_FlightId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediumId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.MediumId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "Notification_NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.TravelGroups", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Stewards", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Passengers", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Passengers", "TravelGroup_TravelGroupId", "dbo.TravelGroups");
            DropForeignKey("dbo.Messages", "TravelGroup_TravelGroupId", "dbo.TravelGroups");
            DropForeignKey("dbo.Messages", "Sender_TicketNumber", "dbo.Passengers");
            DropForeignKey("dbo.Passengers", "Seat_SeatId", "dbo.Seats");
            DropForeignKey("dbo.Orders", "Passenger_TicketNumber", "dbo.Passengers");
            DropForeignKey("dbo.Orders", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.OrderLines", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.Stewards", new[] { "Flight_FlightId" });
            DropIndex("dbo.Messages", new[] { "TravelGroup_TravelGroupId" });
            DropIndex("dbo.Messages", new[] { "Sender_TicketNumber" });
            DropIndex("dbo.TravelGroups", new[] { "Flight_FlightId" });
            DropIndex("dbo.Passengers", new[] { "Notification_NotificationId" });
            DropIndex("dbo.Passengers", new[] { "Flight_FlightId" });
            DropIndex("dbo.Passengers", new[] { "TravelGroup_TravelGroupId" });
            DropIndex("dbo.Passengers", new[] { "Seat_SeatId" });
            DropIndex("dbo.OrderLines", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderLines", new[] { "Article_ArticleId" });
            DropIndex("dbo.Orders", new[] { "Passenger_TicketNumber" });
            DropIndex("dbo.Orders", new[] { "Flight_FlightId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Media");
            DropTable("dbo.Stewards");
            DropTable("dbo.Messages");
            DropTable("dbo.TravelGroups");
            DropTable("dbo.Seats");
            DropTable("dbo.Passengers");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Orders");
            DropTable("dbo.Flights");
            DropTable("dbo.Articles");
        }
    }
}
