using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Streaming.WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    ChannelID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChannelName = table.Column<string>(nullable: true),
                    UserOwnerUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.ChannelID);
                    table.ForeignKey(
                        name: "FK_Channel_User_UserOwnerUserId",
                        column: x => x.UserOwnerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    ChatMessageID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChatUserUserId = table.Column<int>(nullable: true),
                    SentTime = table.Column<DateTime>(nullable: false),
                    MessageText = table.Column<string>(nullable: true),
                    ChatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.ChatMessageID);
                    table.ForeignKey(
                        name: "FK_ChatMessage_Chat_ChatID",
                        column: x => x.ChatID,
                        principalTable: "Chat",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_ChatUserUserId",
                        column: x => x.ChatUserUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stream",
                columns: table => new
                {
                    StreamID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerChannelID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Viewer = table.Column<int>(nullable: false),
                    CurrentViewership = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    StreamChatChatID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stream", x => x.StreamID);
                    table.ForeignKey(
                        name: "FK_Stream_Channel_OwnerChannelID",
                        column: x => x.OwnerChannelID,
                        principalTable: "Channel",
                        principalColumn: "ChannelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stream_Chat_StreamChatChatID",
                        column: x => x.StreamChatChatID,
                        principalTable: "Chat",
                        principalColumn: "ChatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channel_UserOwnerUserId",
                table: "Channel",
                column: "UserOwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ChatID",
                table: "ChatMessage",
                column: "ChatID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_ChatUserUserId",
                table: "ChatMessage",
                column: "ChatUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stream_OwnerChannelID",
                table: "Stream",
                column: "OwnerChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Stream_StreamChatChatID",
                table: "Stream",
                column: "StreamChatChatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "Stream");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
