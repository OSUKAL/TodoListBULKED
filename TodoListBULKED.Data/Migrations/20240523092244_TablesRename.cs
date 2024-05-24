using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListBULKED.Data.Migrations
{
    /// <inheritdoc />
    public partial class TablesRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "tickets");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Username",
                table: "users",
                newName: "IX_users_username");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "tickets",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "tickets",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "tickets",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "tickets",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tickets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tickets",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tickets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "tickets",
                newName: "performer_id");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "tickets",
                newName: "creator_id");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "tickets",
                newName: "creation_date");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "tickets",
                type: "varchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tickets",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tickets",
                table: "tickets",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tickets",
                table: "tickets");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tickets",
                newName: "Tickets");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameIndex(
                name: "IX_users_username",
                table: "Users",
                newName: "IX_Users_Username");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Tickets",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Tickets",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Tickets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Tickets",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tickets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tickets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "performer_id",
                table: "Tickets",
                newName: "PerformerId");

            migrationBuilder.RenameColumn(
                name: "creator_id",
                table: "Tickets",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "Tickets",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Tickets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tickets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");
        }
    }
}
