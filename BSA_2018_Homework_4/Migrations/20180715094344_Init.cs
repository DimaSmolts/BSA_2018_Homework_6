using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BSA_2018_Homework_4.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivalPlace = table.Column<string>(nullable: true),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    DeperturePlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<TimeSpan>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaneType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarryCapacity = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Places = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNumFlightId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightNumFlightId",
                        column: x => x.FlightNumFlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
						onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PilotIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Pilot_PilotIdId",
                        column: x => x.PilotIdId,
                        principalTable: "Pilot",
                        principalColumn: "Id",
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLane",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Exploitation = table.Column<TimeSpan>(nullable: false),
                    Made = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLane_PlaneType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PlaneType",
                        principalColumn: "Id", 
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stewardess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birth = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stewardess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stewardess_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id", 
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakeOff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CrewIdId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FlightNumFlightId = table.Column<int>(nullable: true),
                    PlaneIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakeOff_Crew_CrewIdId",
                        column: x => x.CrewIdId,
                        principalTable: "Crew",
                        principalColumn: "Id", 
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeOff_Flight_FlightNumFlightId",
                        column: x => x.FlightNumFlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeOff_PLane_PlaneIdId",
                        column: x => x.PlaneIdId,
                        principalTable: "PLane",
                        principalColumn: "Id",
						onUpdate: ReferentialAction.Cascade,
						onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crew_PilotIdId",
                table: "Crew",
                column: "PilotIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PLane_TypeId",
                table: "PLane",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewardess_CrewId",
                table: "Stewardess",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeOff_CrewIdId",
                table: "TakeOff",
                column: "CrewIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeOff_FlightNumFlightId",
                table: "TakeOff",
                column: "FlightNumFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeOff_PlaneIdId",
                table: "TakeOff",
                column: "PlaneIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightNumFlightId",
                table: "Ticket",
                column: "FlightNumFlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stewardess");

            migrationBuilder.DropTable(
                name: "TakeOff");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "PLane");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "PlaneType");
        }
    }
}
